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

<!--
  category: GlobalizationAndLocalization
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620555
-->

# Japanese phonetic analysis sample

Shows how to analyze Japanese texts and retrieves words or segments in the text by using the 
[JapanesePhoneticAnalyzer](http://msdn.microsoft.com/library/windows/apps/dn434076) class.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

The sample demonstrates these tasks:

1.  **Analyze Japanese text**

    This scenario shows how to use the [GetWords](http://msdn.microsoft.com/library/windows/apps/dn434078) method to split Japanese text, one segment per line.
    The segments can be words or pronunciation units.

**Note** The Universal Windows app samples require Visual Studio 2017 to build and Windows 10 to execute.
 
To obtain information about Windows 10 development, go to the [Windows Dev Center](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio and the tools for developing Windows apps, go to [Visual Studio](http://go.microsoft.com/fwlink/?LinkID=532422)

## Related topics

### Samples

[Unicode](/Samples/Unicode)  

### Reference

[JapanesePhoneticAnalyzer class](https://msdn.microsoft.com/library/windows/apps/windows.globalization.japanesephoneticanalyzer.aspx)  

## System requirements

**Client:** Windows 10

**Server:** Windows Server 2016 Technical Preview

**Phone:** Not supported

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

- To debug the sample and then run it, press F5 or select Debug > Start Debugging. To run the sample without debugging, press Ctrl+F5 or select Debug > Start Without Debugging. 

## How to use the sample

- Enter Japanese text into the edit control, or use the sample text provided.
- Select whether you wish to split the text based on words or based on units of pronunciation.
- Click the Analyze button to perform phonetic analysis.
