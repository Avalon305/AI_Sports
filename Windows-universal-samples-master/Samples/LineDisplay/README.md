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
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=851025
--->

# Line display sample

Shows how to use the [ClaimedLineDisplay](https://docs.microsoft.com/uwp/api/Windows.Devices.PointOfService.ClaimedLineDisplay) class.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

Specifically, this sample shows how to:

1.  **Finding a line display**

    This scenario demonstrates how to find and then clear the line display.

2.  **Displaying text**

    This scenario demonstrates how to display text on the line display.
    It also demonstrates how to detect and take advantage of optional features (in this case, blinking text).

3.  **Windows**

    This scenario creates windows and manipulates them.

4.  **Line display attributes**

    This scenario detects which line display attributes are supported
    and changes them.

5.   **Custom glyphs**

    This scenario detects whether custom glyphs are supported
    and if so, changes glyphs to a solid black rectangle.

6.   **Cursor attributes**

    This scenario detects which cursor attributes are supported
    and changes them.

7.   **Marquee**

    This scenario displays text using a marquee effect, if supported.

**Note** The Windows universal samples require Visual Studio 2017 to build and Windows 10 to execute.
 
To obtain information about Windows 10 development, go to the [Windows Dev Center](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio and the tools for developing Windows apps, go to [Visual Studio](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Line Display sample](/Samples/LineDisplay)

### Reference

[Windows.Devices.PointOfService](http://msdn.microsoft.com/library/windows/apps/dn298071)

[Windows.Devices.PointOfService.LineDisplay](https://docs.microsoft.com/uwp/api/Windows.Devices.PointOfService.LineDisplay)

[Windows.Devices.PointOfService.ClaimedLineDisplay](https://docs.microsoft.com/uwp/api/Windows.Devices.PointOfService.ClaimedLineDisplay)

[Windows app samples](http://go.microsoft.com/fwlink/p/?LinkID=227694)

## System requirements

**Client:** Windows 10

**Server:** Windows Server 2016 Technical Preview

**Phone:** Windows 10

## Build the sample

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

### Deploying the sample

- Select Build > Deploy Solution. 

### Deploying and running the sample

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or selectDebug > Start Without Debugging. 
