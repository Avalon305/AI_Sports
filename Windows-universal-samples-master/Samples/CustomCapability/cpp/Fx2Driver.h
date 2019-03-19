//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
//
//*********************************************************

//
// Scenario1.xaml.h
// Declaration of the Scenario1 class
//

#pragma once

namespace SDKTemplate
{
        ref class Fx2Driver
        {
        internal:
            static const uint16 DeviceType = 65500U;
            static const uint16 FunctionBase = 0x800;

            static Windows::Devices::Custom::IOControlCode^ GetSevenSegmentDisplay;
            static Windows::Devices::Custom::IOControlCode^ SetSevenSegmentDisplay;
            static Windows::Devices::Custom::IOControlCode^ ReadSwitches;
            static Windows::Devices::Custom::IOControlCode^ GetInterruptMessage;

            static const Platform::Guid DeviceInterfaceGuid;

            static byte DigitToSevenSegment(byte value);
            static byte SevenSegmentToDigit(byte value);

        private:
            static const byte SevenSegmentValues[10];
        };
}
