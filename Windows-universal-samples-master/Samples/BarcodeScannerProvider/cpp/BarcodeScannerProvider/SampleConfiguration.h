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

#pragma once

#include "pch.h"

namespace SDKTemplate
{
    value struct Scenario;

    partial ref class MainPage
    {
    internal:
        static property Platform::String^ FEATURE_NAME
        {
            Platform::String^ get()
            {
                return "Barcode Scanner Provider C++";
            }
        }

        static property Platform::Array<Scenario>^ scenarios
        {
            Platform::Array<Scenario>^ get()
            {
                return scenariosInner;
            }
        }

    private:
        static Platform::Array<Scenario>^ scenariosInner;
    };

    public value struct Scenario
    {
        Platform::String^ Title;
        Platform::String^ ClassName;
    };

    namespace DeviceHelpers
    {
        // By default, use all connections types.
        Concurrency::task<Windows::Devices::PointOfService::BarcodeScanner^> GetFirstBarcodeScannerAsync(
            Windows::Devices::PointOfService::PosConnectionTypes connectionTypes = Windows::Devices::PointOfService::PosConnectionTypes::All);
    }

    [Windows::UI::Xaml::Data::Bindable]
    public ref class BindingHelpers sealed
    {
    public:
        // Inverters for binding.
        static bool Not(bool value)
        {
            return !value;
        }

        static Windows::UI::Xaml::Visibility CollapsedIf(bool value)
        {
            return value ? Windows::UI::Xaml::Visibility::Collapsed : Windows::UI::Xaml::Visibility::Visible;
        }
    };

    // Creates a completed Concurrency::task<void> that is based on an IAsyncAction,
    // so that it can be used easily from UI threads.
    inline Concurrency::task<void> completed_ui_task()
    {
        return Concurrency::create_task(concurrency::create_async([] {}));
    }

    [Windows::UI::Xaml::Data::Bindable]
    public ref class BarcodeScannerInfo sealed
    {
    public:
        property Platform::String^ Name
        {
            Platform::String^ get()
            {
                return deviceName + L" (" + deviceId + L")";
            }
        }

        property Platform::String^ DeviceId
        {
            Platform::String^ get()
            {
                return deviceId;
            }
        }

        BarcodeScannerInfo(Platform::String^ deviceName, Platform::String^ deviceId)
        {
            this->deviceName = deviceName;
            this->deviceId = deviceId;
        }
    private:
        Platform::String^ deviceName;
        Platform::String^ deviceId;
    };

    /// <summary>
    /// The class is used for data-binding.
    /// </summary>
    [Windows::UI::Xaml::Data::Bindable]
    public ref class SymbologyListEntry sealed
    {
    public:
        SymbologyListEntry(UINT symbologyId) : SymbologyListEntry(symbologyId, true) { }

        SymbologyListEntry(UINT symbologyId, bool symbologyEnabled)
        {
            id = symbologyId;
            enabled = symbologyEnabled;
        }

        property uint32_t Id
        {
            uint32_t get()
            {
                return id;
            }
        }

        property bool IsEnabled
        {
            bool get()
            {
                return enabled;
            }
            void set(bool value)
            {
                enabled = value;
            }
        }

        property Platform::String^ Name
        {
            Platform::String^ get()
            {
                return Windows::Devices::PointOfService::BarcodeSymbologies::GetName(id);
            }
        }

    private:
        uint32_t id;
        bool enabled;
    };

}
