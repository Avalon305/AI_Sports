---
topic: sample
languages:
- csharp
- cpp
- js
products:
- windows
- uwp
---

<!---
  category: DevicesSensorsAndPower
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=624150
--->

# Inter-Integrated Circuit (I2C) sample

Shows how to use the [Windows.Devices.I2c](http://msdn.microsoft.com/library/windows.devices.i2c.aspx) namespace
to allow apps to communicate with Inter-Integrated Circuit devices
(commmonly abbreviated IIC or I2C)
on a Windows IoT (Internet of Things) device.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

I2C is a two-wire low-speed bus used to interface devices such as sensors, EEPROMs, and touch controllers. This sample shows how to access the I2C bus.

The sample shows the following techniques:

- Reading data from an I2C device.

**Note** The Windows universal samples require Visual Studio 2017 to build and Windows 10 IoT Core to execute.

To obtain information about Windows 10 IoT Core, go to [Windows on Devices](http://windowsondevices.com)

You can find more Windows IoT Core samples in the [Windows 10 Internet of Things (IoT) Samples repo](https://go.microsoft.com/fwlink/?linkid=860459).

To obtain information about Microsoft Visual Studio and the tools for developing Windows apps, go to [Visual Studio](http://go.microsoft.com/fwlink/?LinkID=532422)

## System requirements

**IoT:** Windows 10 IoT Core

## Build the sample

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select the appropriate architecture for the device you want to deploy to (i.e. ARM for Raspberry Pi 2 or x86 for MinnowBoard Max)
- For C#, select Remote Machine from Debug > Target device in your Project properties.  For C++ and JavaScript, select Remote Machine from Debugger to launch dropdown in the Debugging tab of your Project properties.
- For C#, enter the target device name or IP address in Debug > Remote Machine in your Project properties.  For C++ and JavaScript, enter the target device name or IP address in Debugging > Machine Name in your Project properties.
- For C#, deselect the Use Athentication checkbox in the Debug tab of your Project properties.  For C++ and JavaScript, select No for Debugging > Require Authentication in your Project properties.
- Select Build > Deploy Solution. 

### Deploying and running the sample

- Select the appropriate architecture for the device you want to deploy to (i.e. ARM for Raspberry Pi 2 or x86 for MinnowBoard Max)
- For C#, select Remote Machine from Debug > Target device in your Project properties.  For C++ and JavaScript, select Remote Machine from Debugger to launch dropdown in the Debugging tab of your Project properties.
- For C#, enter the target device name or IP address in Debug > Remote Machine in your Project properties.  For C++ and JavaScript, enter the target device name or IP address in Debugging > Machine Name in your Project properties.
- For C#, deselect the Use Athentication checkbox in the Debug tab of your Project properties.  For C++ and JavaScript, select No for Debugging > Require Authentication in your Project properties.
- Press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or select Debug > Start Without Debugging. 
