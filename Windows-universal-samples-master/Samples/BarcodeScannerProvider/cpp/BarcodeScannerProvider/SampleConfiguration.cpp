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
#include "MainPage.xaml.h"
#include "SampleConfiguration.h"
#include "DeviceHelpers.h"
#include "Scenario1_Configuration.xaml.h"

using namespace Concurrency;
using namespace Platform;
using namespace SDKTemplate;
using namespace Windows::Devices::PointOfService;
using namespace Windows::Foundation;

Platform::Array<Scenario>^ MainPage::scenariosInner = ref new Platform::Array<Scenario>
{
    { "Decoder Configuration", "SDKTemplate.Scenario1_Configuration" }
};

task<BarcodeScanner^> DeviceHelpers::GetFirstBarcodeScannerAsync(PosConnectionTypes connectionTypes)
{
    return DeviceHelpers::GetFirstDeviceAsync(BarcodeScanner::GetDeviceSelector(connectionTypes),
        [](String^ id) { return create_task(BarcodeScanner::FromIdAsync(id)); });
}
