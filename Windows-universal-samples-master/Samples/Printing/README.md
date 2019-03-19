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
  category: ControlsLayoutAndText Printing
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=619984
--->

# Printing sample

Shows how apps can add support for printing on Windows. 

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

The scenarios demonstrated in this sample include:

- Adding support for printing using app UX
- Customizing the print experience by changing how the printer settings are shown to the user
- Using a custom print template to print a range of pages
- Printing alternate content that is not part of the current document
- Disabling print preview
- Removing the Print button if the device does not support printing

## Related samples

[Coloring Book app sample](https://github.com/Microsoft/Windows-appsample-coloringbook)  

System requirements
-------------------

**Client:** Windows 10 build 14295

**Server:** Windows Server 2016 Technical Preview

**Phone:** Windows 10 build 14295

Build the sample
----------------

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

Run the sample
--------------

To debug the app and then run it, press F5 or use **Debug** \> **Start Debugging**. To run the app without debugging, press Ctrl+F5 or use **Debug** \> **Start Without Debugging**.
