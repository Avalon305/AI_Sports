---
topic: sample
languages:
- csharp
products:
- windows
- uwp
---

<!---
  category: AudioVideoAndCamera
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620563
--->

# DASH streaming sample

Shows how to create and use the [MSEStreamSource](https://msdn.microsoft.com/library/windows/apps/windows.media.core.msestreamsource.aspx) class 
to playback Live DASH content.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

Live DASH will be supported at a later date within the Adaptive Streaming classes (see AdaptiveStreaming sample).

This sample only supports number-based DASH manifests that are dynamic with a is-offlive DASH profile. 

Specifically, this sample covers:

-   Parsing a Live DASH manifest
-   Downloading segments for streaming
-   Using MSEStreamSource to playback those segments

Related topics
--------------

[MediaStreamSource Sample](https://code.msdn.microsoft.com/windowsapps/MediaStreamSource-media-dfd55dff)  
[Windows.Media.Core namespace](https://msdn.microsoft.com/library/windows/apps/windows.media.core.msesourcebuffer.aspx)  

System requirements
-----------------------------

**Client:** Windows 10

Build the sample
----------------

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

Run the sample
--------------

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

**Deploying the sample**
1.  Select **Build** \> **Deploy Solution**.

**Deploying and running the sample**
1.  To debug the sample and then run it, press F5 or select **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or select**Debug** \> **Start Without Debugging**.




