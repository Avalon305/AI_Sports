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
using Windows.UI.Xaml.Controls;

namespace SDKTemplate
{
    public partial class MainPage : Page
    {
        public const string FEATURE_NAME = "TouchKeyboard";

        List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title="Display touch keyboard automatically", ClassType=typeof(Scenario1_Launch)},
            new Scenario() { Title="Listen for Show/Hide events", ClassType=typeof(Scenario2_ShowHideEvents)},
            new Scenario() { Title="Programmatically Show/Hide\nthe touch keyboard", ClassType=typeof(Scenario3_ShowHideMethods)}
        };
    }

    public class Scenario
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
