//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

#include "pch.h"
#include "Scenario1_Events.xaml.h"

const unsigned int HundredNanoSecondsToMilliseconds = 10000;

using namespace SDKTemplate;

using namespace Concurrency;
using namespace Platform;
using namespace Windows::Devices::Enumeration;
using namespace Windows::Devices::Sensors;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::Globalization::DateTimeFormatting;
using namespace Windows::UI::Core;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;

Scenario1_Events::Scenario1_Events() : rootPage(MainPage::Current)
{
    InitializeComponent();

    // Disable the 'Register' button until we have a pedometer
    RegisterButton->IsEnabled = false;

    // Determine if we can access pedometers
    deviceAccessInfo = DeviceAccessInformation::CreateFromDeviceClassId(GUID_Pedometer_ClassId);
    if (deviceAccessInfo->CurrentStatus == DeviceAccessStatus::Allowed)
    {
        // Access is allowed. Register for access change notifications
        deviceAccessInfo->AccessChanged += ref new TypedEventHandler<DeviceAccessInformation ^, DeviceAccessChangedEventArgs ^>(this, &Scenario1_Events::OnAccessChanged);

        rootPage->NotifyUser("Waiting for Default Pedometer (Pedometer::GetDefaultAsync)", NotifyType::StatusMessage);

        // Get the default pedometer asynchronously
        create_task(Pedometer::GetDefaultAsync).then([this](task<Pedometer^> task)
        {
            pedometer = task.get();
            if (nullptr != pedometer)
            {
                rootPage->NotifyUser("Pedometer available - Not registered for events", NotifyType::StatusMessage);
                RegisterButton->IsEnabled = true;
            }
            else
            {
                rootPage->NotifyUser("No pedometers available", NotifyType::ErrorMessage);
                RegisterButton->IsEnabled = false;
            }
        });
    }
    else
    {
        rootPage->NotifyUser("Access to pedometer is denied", NotifyType::ErrorMessage);
        RegisterButton->IsEnabled = false;
    }

    registeredForEvents = false;
}

/// <summary>
/// 'Register ReadingChanged' button click handler. Registers for the '
/// ReadingChanged' event of the default pedometer opened earlier.
/// </summary>
/// <param name="sender">unused</param>
/// <param name="e">unused</param>
void Scenario1_Events::Button_Click(Platform::Object^ /*sender*/, Windows::UI::Xaml::RoutedEventArgs^ /*e*/)
{
    UpdateEventRegistration(!registeredForEvents);
}

/// <summary>
/// Invoked when navigating away from this page - unregisters for 'ReadingChanged' event.
/// </summary>
/// <param name="e">unused</param>
void Scenario1_Events::OnNavigatedFrom(Windows::UI::Xaml::Navigation::NavigationEventArgs^ /*e*/)
{
    if (registeredForEvents)
    {
        UpdateEventRegistration(false);
    }
}

/// <summary>
/// Invoked when the access to pedometers has changed
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
void Scenario1_Events::OnAccessChanged(DeviceAccessInformation ^sender, DeviceAccessChangedEventArgs ^args)
{
    if (args->Status != DeviceAccessStatus::Allowed)
    {
        pedometer = nullptr;

        Dispatcher->RunAsync(
            CoreDispatcherPriority::Normal,
            ref new DispatchedHandler(
                [this]()
        {
            if (registeredForEvents)
            {
                UpdateEventRegistration(false);
            }

            rootPage->NotifyUser("Access to the pedometer has been denied", NotifyType::ErrorMessage);
        },
        CallbackContext::Any));
    }
}

/// <summary>
/// Invoked when the underlying Pedometer sees a change in the step count for a step kind
/// </summary>
/// <param name="sender">unused</param>
/// <param name="args">Pedometer reading that is being notified</param>
void Scenario1_Events::OnReadingChanged(Windows::Devices::Sensors::Pedometer ^/*sender*/, Windows::Devices::Sensors::PedometerReadingChangedEventArgs ^args)
{
    // We need to dispatch to the UI thread to display the output
    Dispatcher->RunAsync(
        CoreDispatcherPriority::Normal,
        ref new DispatchedHandler(
        [this, args]()
        {
            PedometerReading^ reading = args->Reading;
            int32 newCount = 0;
            long long duration = 0;

            // update step counts based on the step kind
            switch (reading->StepKind)
            {
            case PedometerStepKind::Unknown:
                if (reading->CumulativeSteps < unknownStepCount)
                {
                    unknownStepCount = 0;
                }
                newCount = reading->CumulativeSteps - unknownStepCount;
                unknownStepCount = reading->CumulativeSteps;
                ScenarioOutput_UnknownCount->Text = unknownStepCount.ToString();
                duration = reading->CumulativeStepsDuration.Duration / HundredNanoSecondsToMilliseconds;
                ScenarioOutput_UnknownDuration->Text = duration.ToString();
                break;
            case PedometerStepKind::Walking:
                if (reading->CumulativeSteps < walkingStepCount)
                {
                    walkingStepCount = 0;
                }
                newCount = reading->CumulativeSteps - walkingStepCount;
                walkingStepCount = reading->CumulativeSteps;
                ScenarioOutput_WalkingCount->Text = walkingStepCount.ToString();
                duration = reading->CumulativeStepsDuration.Duration / HundredNanoSecondsToMilliseconds;
                ScenarioOutput_WalkingDuration->Text = duration.ToString();
                break;
            case PedometerStepKind::Running:
                if (reading->CumulativeSteps < runningStepCount)
                {
                    runningStepCount = 0;
                }
                newCount = reading->CumulativeSteps - runningStepCount;
                runningStepCount = reading->CumulativeSteps;
                ScenarioOutput_RunningCount->Text = runningStepCount.ToString();
                duration = reading->CumulativeStepsDuration.Duration / HundredNanoSecondsToMilliseconds;
                ScenarioOutput_RunningDuration->Text = duration.ToString();
                break;
            default:
                break;
            }

            totalCumulativeSteps += newCount;
            ScenarioOutput_TotalStepCount->Text = totalCumulativeSteps.ToString();

            auto timestampFormatter = ref new DateTimeFormatter("day month year hour minute second");
            ScenarioOutput_Timestamp->Text = timestampFormatter->Format(reading->Timestamp);
        },
        CallbackContext::Any
        )
    );
}

/// <summary>
/// Helper function to register/un-register to the 'ReadingChanged' event of the default pedometer
/// </summary>
/// <param name="registerForEvents">tell if a registration or un-registration actions needs to be taken</param>
void Scenario1_Events::UpdateEventRegistration(bool registerForEvents)
{
    if (registerForEvents)
    {
        if (pedometer != nullptr)
        {
            pedometer->ReportInterval = pedometer->MinimumReportInterval;
            readingToken = (pedometer->ReadingChanged += ref new Windows::Foundation::TypedEventHandler<Windows::Devices::Sensors::Pedometer ^, Windows::Devices::Sensors::PedometerReadingChangedEventArgs ^>(this, &Scenario1_Events::OnReadingChanged));
            rootPage->NotifyUser("Registered for step count changes", NotifyType::StatusMessage);
            registeredForEvents = true;
            RegisterButton->Content = "Un-Register ReadingChanged";
        }
    }
    else
    {
        if (pedometer != nullptr)
        {
            pedometer->ReadingChanged -= readingToken;
            rootPage->NotifyUser("Pedometer available - Not registered for events", NotifyType::StatusMessage);
        }

        registeredForEvents = false;
        RegisterButton->Content = "Register ReadingChanged";
    }
}