// Copyright (c) Microsoft. All rights reserved.

#include "pch.h"
#include "Scenario3CustomOptions.xaml.h"
#include "PageToPrint.xaml.h"

using namespace SDKTemplate;

using namespace Concurrency;
using namespace Platform;
using namespace Windows::Foundation;
using namespace Windows::Foundation::Collections;
using namespace Windows::Graphics::Display;
using namespace Windows::Graphics::Printing;
using namespace Windows::Graphics::Printing::OptionDetails;
using namespace Windows::UI;
using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Controls::Primitives;
using namespace Windows::UI::Xaml::Data;
using namespace Windows::UI::Xaml::Input;
using namespace Windows::UI::Xaml::Media;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::Storage::Streams;

CustomOptionsPrintHelper::CustomOptionsPrintHelper(Page^ scenarioPage) : 
    PrintHelper(scenarioPage)
{
    // Start these operations early because we know we're going to need the
    // streams in PrintTaskRequested.
    RandomAccessStreamReference^ wideMarginsIconReference = RandomAccessStreamReference::CreateFromUri(ref new Uri("ms-appx:///Assets/wideMargins.svg"));
    m_wideMarginsIconAsyncOperation = wideMarginsIconReference->OpenReadAsync();

    RandomAccessStreamReference^ moderateMarginsIconReference = RandomAccessStreamReference::CreateFromUri(ref new Uri("ms-appx:///Assets/moderateMargins.svg"));
    m_moderateMarginsIconAsyncOperation = moderateMarginsIconReference->OpenReadAsync();

    RandomAccessStreamReference^ narrowMarginsIconReference = RandomAccessStreamReference::CreateFromUri(ref new Uri("ms-appx:///Assets/narrowMargins.svg"));
    m_narrowMarginsIconAsyncOperation = narrowMarginsIconReference->OpenReadAsync();
}

DisplayContent GetDisplayContent(int option)
{
    DisplayContent displayContent;
    switch (option)
    {
    case 1:
        displayContent = DisplayContent::Text;
        break;
    case 2:
        displayContent = DisplayContent::Images;
        break;
    default:
        displayContent = DisplayContent::TextAndImages;
        break;
    }

    return displayContent;
}

/// <summary>
/// This is the event handler for PrintManager.PrintTaskRequested.
/// In order to ensure a good user experience, the system requires that the app handle the PrintTaskRequested event within the time specified by PrintTaskRequestedEventArgs->Request->Deadline.
/// Therefore, we use this handler to only create the print task.
/// The print settings customization can be done when the print document source is requested.
/// </summary>
/// <param name="sender">PrintManager</param>
/// <param name="e">PrintTaskRequestedEventArgs</param>
void CustomOptionsPrintHelper::PrintTaskRequested(PrintManager^ sender, PrintTaskRequestedEventArgs^ e)
{
    auto deferral = e->Request->GetDeferral();

    PrintTask^ printTask = e->Request->CreatePrintTask("C++ Printing SDK Sample", ref new PrintTaskSourceRequestedHandler([=](PrintTaskSourceRequestedArgs^ args)
    {
        args->SetSource(PrintDocumentSource);
    }));

    // Clear the print options that are displayed beacuse adding the same one multiple times will throw an exception
    IVector<String^>^ displayedOptions = printTask->Options->DisplayedOptions;
    displayedOptions->Clear();

    // Choose the printer options to be shown.
    // The order in which the options are appended determines the order in which they appear in the UI
    PrintTaskOptionDetails^ printDetailedOptions = PrintTaskOptionDetails::GetFromPrintTaskOptions(printTask->Options);
    displayedOptions->Clear();

    displayedOptions->Append(StandardPrintTaskOptions::Copies);
    displayedOptions->Append(StandardPrintTaskOptions::Orientation);
    displayedOptions->Append(StandardPrintTaskOptions::ColorMode);

    // Create a new list option
    PrintCustomItemListOptionDetails^ pageFormat = printDetailedOptions->CreateItemListOption(L"PageContent", L"Pictures");
    pageFormat->AddItem(L"PicturesText", L"Pictures and text");
    pageFormat->AddItem(L"PicturesOnly", L"Pictures only");
    pageFormat->AddItem(L"TextOnly", L"Text only");

    // Add the custom option to the option list
    displayedOptions->Append(L"PageContent");

    // Create a new toggle option "Show header". 
    PrintCustomToggleOptionDetails^ header = printDetailedOptions->CreateToggleOption("Header", "Show header");

    // App tells the user some more information about what the feature means.
    header->Description = "Display a header on the first page";

    // Set the default value
    header->TrySetValue(m_showHeader);

    // Add the custom option to the option list
    displayedOptions->Append("Header");

    // Create a new list option
    PrintCustomItemListOptionDetails^ margins = printDetailedOptions->CreateItemListOption("Margins", "Margins");
    create_task(m_wideMarginsIconAsyncOperation).then([this, margins](IRandomAccessStreamWithContentType^ stream)
    {
        margins->AddItem("WideMargins", "Wide", "Each margin is 20% of the paper size", stream);
        return create_task(m_moderateMarginsIconAsyncOperation);
    }).then([this, margins](IRandomAccessStreamWithContentType^ stream)
    {
        margins->AddItem("ModerateMargins", "Moderate", "Each margin is 10% of the paper size", stream);
        return create_task(m_narrowMarginsIconAsyncOperation);
    }).then([this, margins](IRandomAccessStreamWithContentType^ stream)
    {
        margins->AddItem("NarrowMargins", "Narrow", "Each margin is 5% of the paper size", stream);
    }).then([this, margins, displayedOptions, printDetailedOptions, printTask]()
    {
        // The default is ModerateMargins
        SetMargins("ModerateMargins");
        margins->TrySetValue("ModerateMargins");

        // App tells the user some more information about what the feature means
        margins->Description = "The space between the content of your document and the edge of the paper";

        // Add the custom option to the option list
        displayedOptions->Append("Margins");

        printDetailedOptions->OptionChanged += ref new TypedEventHandler<PrintTaskOptionDetails^, PrintTaskOptionChangedEventArgs^>(this, &CustomOptionsPrintHelper::printDetailedOptions_OptionChanged);

        // Print Task event handler is invoked when the print job is completed.
        printTask->Completed += ref new TypedEventHandler<PrintTask^, PrintTaskCompletedEventArgs^>([=](PrintTask^ sender, PrintTaskCompletedEventArgs^ e)
        {
            // Notify the user when the print operation fails.
            if (e->Completion == Windows::Graphics::Printing::PrintTaskCompletion::Failed)
            {
                MainPage::Current->NotifyUser(ref new String(L"Failed to print."), NotifyType::ErrorMessage);
            }
        });
    }).then([deferral](task<void> previousTask)
    {
        deferral->Complete();
        previousTask.get();
    });
}

/// <summary>
/// Option change event handler
/// </summary>
/// <param name="sender">PrintTaskOptionsDetails object</param>
/// <param name="args">the event arguments containing the changed option id</param>
void CustomOptionsPrintHelper::printDetailedOptions_OptionChanged(PrintTaskOptionDetails^ sender, PrintTaskOptionChangedEventArgs^ args)
{
    bool invalidatePreview = false;

    String^ optionId = safe_cast<String^>(args->OptionId);

    if (optionId == "PageContent")
    {
        invalidatePreview = true;
    }
    else if (optionId == "Margins")
    {
        PrintCustomItemListOptionDetails^ marginsOption = (PrintCustomItemListOptionDetails^)sender->Options->Lookup("Margins");
        String^ marginsValue = marginsOption->Value->ToString();

        SetMargins(marginsValue);

        marginsOption->WarningText = "";
        if (marginsValue == "NarrowMargins")
        {
            marginsOption->WarningText = "Narrow margins may not be supported by some printers";
        }

        invalidatePreview = true;
    }
    else if (optionId == "Header")
    {
        PrintCustomToggleOptionDetails^ headerOption = (PrintCustomToggleOptionDetails^)sender->Options->Lookup("Header");
        m_showHeader = (bool)headerOption->Value;
        invalidatePreview = true;
    }

    if (invalidatePreview)
    {
        RefreshPreview();
    }
}

/// <summary>
/// Helper function used to set the top and left margins based on used selection
/// </summary>
/// <param name="marginsValue">The Id of the option selected by the user</param>
void CustomOptionsPrintHelper::SetMargins(String^ marginsValue)
{
    if (marginsValue == "WideMargins")
    {
        ApplicationContentMarginTop = 0.2f;
        ApplicationContentMarginLeft = 0.2f;
    }
    else if (marginsValue == "ModerateMargins")
    {
        ApplicationContentMarginTop = 0.1f;
        ApplicationContentMarginLeft = 0.1f;
    }
    else if (marginsValue == "NarrowMargins")
    {
        ApplicationContentMarginTop = 0.05f;
        ApplicationContentMarginLeft = 0.05f;
    }
}

/// <summary>
/// Helper function used to triger a preview refresh
/// </summary>
void CustomOptionsPrintHelper::RefreshPreview()
{
    auto callback = ref new Windows::UI::Core::DispatchedHandler([this]()
    {
        CurrentPrintDocument->InvalidatePreview();
    });


    ScenarioPage->Dispatcher->RunAsync(Windows::UI::Core::CoreDispatcherPriority::Normal, callback);
}

/// <summary>
/// This is the event handler for PrintDocument.Paginate. It creates print preview pages for the app.
/// </summary>
/// <param name="sender"></param>
/// <param name="e">Paginate Event Arguments</param>
void CustomOptionsPrintHelper::CreatePrintPreviewPages(Object^ sender, PaginateEventArgs^ e)
{
    // Get PageContent property
    PrintTaskOptionDetails^ printDetailedOptions = PrintTaskOptionDetails::GetFromPrintTaskOptions(e->PrintTaskOptions);
    IPrintOptionDetails^ printOptionDetails = printDetailedOptions->Options->Lookup(ref new String(L"PageContent"));
    String^ pageContent = safe_cast<String^>(printOptionDetails->Value);

    // Set the text & image display flag
    int result = (wcsstr(pageContent->Data(), L"Pictures") != nullptr) << 1 | (wcsstr(pageContent->Data(), L"Text") != nullptr);
    m_imageText = GetDisplayContent(result);

    PrintHelper::CreatePrintPreviewPages(sender, e);
}

/// <summary>
/// This function creates and adds one print preview page to the internal cache of print preview
/// pages stored in m_printPreviewPages.
/// </summary>
/// <param name="lastRTBOAdded">Last RichTextBlockOverflow element added in the current content</param>
/// <param name="printPageDescription">Printer's page description</param>
RichTextBlockOverflow^ CustomOptionsPrintHelper::AddOnePrintPreviewPage(RichTextBlockOverflow^ lastRTBOAdded, PrintPageDescription printPageDescription)
{
    // Check if we need to hide/show text & images for this scenario
    // Since all is rulled by the first page (page flow), here is where we must start
    if (lastRTBOAdded == nullptr)
    {
        // Get a refference to page objects
        Grid^ pageContent = safe_cast<Grid^>(FirstPage->FindName("PrintableArea"));
        Image^ scenarioImage = safe_cast<Image^>(FirstPage->FindName("ScenarioImage"));
        RichTextBlock^ mainText = safe_cast<RichTextBlock^>(FirstPage->FindName("TextContent"));
        RichTextBlockOverflow^ firstLink = safe_cast<RichTextBlockOverflow^>(FirstPage->FindName("FirstLinkedContainer"));
        RichTextBlockOverflow^ continuationLink = safe_cast<RichTextBlockOverflow^>(FirstPage->FindName("ContinuationPageLinkedContainer"));

        // Hide(collapse) and move elements in different grid cells depending by the viewable content(only text, only pictures)

        scenarioImage->Visibility = ShowImage ? Windows::UI::Xaml::Visibility::Visible : Windows::UI::Xaml::Visibility::Collapsed;
        firstLink->SetValue(Grid::ColumnSpanProperty, ShowImage ? 1 : 2);

        scenarioImage->SetValue(Grid::RowProperty, ShowText ? 2 : 1);
        scenarioImage->SetValue(Grid::ColumnProperty, ShowText ? 1 : 0);

        pageContent->ColumnDefinitions->GetAt(0)->Width = Windows::UI::Xaml::GridLengthHelper::FromValueAndType(ShowText ? 6 : 4, GridUnitType::Star);
        pageContent->ColumnDefinitions->GetAt(1)->Width = Windows::UI::Xaml::GridLengthHelper::FromValueAndType(ShowText ? 4 : 6, GridUnitType::Star);

        // Break the text flow if the app is not printing text in order not to spawn pages with blank content
        mainText->Visibility = ShowText ? Windows::UI::Xaml::Visibility::Visible : Windows::UI::Xaml::Visibility::Collapsed;
        continuationLink->Visibility = ShowText ? Windows::UI::Xaml::Visibility::Visible : Windows::UI::Xaml::Visibility::Collapsed;

        // Hide header if appropriate
        StackPanel^ header = safe_cast<StackPanel^>(FirstPage->FindName("Header"));
        header->Visibility = m_showHeader ? Windows::UI::Xaml::Visibility::Visible : Windows::UI::Xaml::Visibility::Collapsed;
    }

    //Continue with the rest of the base printing layout processing (paper size, printable page size)
    return PrintHelper::AddOnePrintPreviewPage(lastRTBOAdded, printPageDescription);
}

Scenario3CustomOptions::Scenario3CustomOptions()
{
    InitializeComponent();
}

void Scenario3CustomOptions::OnPrintButtonClick(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    printHelper->ShowPrintUIAsync();
}

void Scenario3CustomOptions::OnNavigatedTo(NavigationEventArgs^ e)
{
    if (PrintManager::IsSupported())
    {
        // Tell the user how to print
        MainPage::Current->NotifyUser("Print contract registered with customization, use the Print button to print.", NotifyType::StatusMessage);
    }
    else
    {
        // Remove the print button
        InvokePrintingButton->Visibility = Windows::UI::Xaml::Visibility::Collapsed;

        // Inform user that Printing is not supported
        MainPage::Current->NotifyUser("Printing is not supported.", NotifyType::ErrorMessage);

        // Printing-related event handlers will never be called if printing
        // is not supported, but it's okay to register for them anyway.
    }

    // Initalize common helper class and register for printing
    printHelper = ref new CustomOptionsPrintHelper(this);
    printHelper->RegisterForPrinting();

    // Initialize print content for this scenario
    printHelper->PreparePrintContent(ref new PageToPrint());
}

void Scenario3CustomOptions::OnNavigatedFrom(NavigationEventArgs^ e)
{
    if (printHelper)
    {
        printHelper->UnregisterForPrinting();
    }
}
