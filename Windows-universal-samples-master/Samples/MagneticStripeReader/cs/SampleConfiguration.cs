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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.PointOfService;
using Windows.UI.Xaml.Controls;
using MagneticStripeReaderSample;
namespace SDKTemplate
{
    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "Magnetic Stripe Reader";

        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title = "BankCardDataReceived Event", ClassType = typeof(Scenario1_BankCards) },
            new Scenario() { Title = "AamvaCardDataReceived Event", ClassType = typeof(Scenario2_AamvaCards) }
        };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }

    public partial class DeviceHelpers
    {
        // By default, use all connections types.
        public static async Task<MagneticStripeReader> GetFirstMagneticStripeReaderAsync(PosConnectionTypes connectionTypes = PosConnectionTypes.All)
        {
            return await DeviceHelpers.GetFirstDeviceAsync(MagneticStripeReader.GetDeviceSelector(connectionTypes), async (id) => await MagneticStripeReader.FromIdAsync(id));
        }
    }
}
