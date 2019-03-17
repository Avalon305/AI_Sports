---
topic: sample
languages:
- cpp
products:
- windows
- uwp
---

<!---
  category: AudioVideoAndCamera
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620629
--->

# Windows audio session (WASAPI) sample

Shows how to do various audio related tasks using the [Windows Audio Session API (WASAPI)](http://msdn.microsoft.com/library/windows/apps/dd371455).

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

Specifically, this sample covers:

-   Enumerating audio playback devices attached to the system and retrieve additional properties.
-   Demonstrates how to opt-in to hardware audio offload on supported devices.
-   Demonstrates how to implement the basic media transport controls in order to properly support background audio playback.
-   Playback of audio using the **Windows Audio Session APIs**.
-   Capture of PCM audio using the **Windows Audio Session APIs**.
-   Low latency audio playback and capture.

For more information on adding audio to your app, see [Quickstart: adding audio to an app](http://msdn.microsoft.com/library/windows/apps/hh452730).

Playing audio in the background is supported by the Windows Audio Session API
only in communication scenarios as demonstrated by the [VoIP](/Samples/VoIP) sample.
Instead, for general background audio playback of media,
use the MediaPlayer class demonstrated in the [Background Media Playback](/Samples/BackgroundMediaPlayback) sample.

## Related topics

### Samples

[Background Audio](/Samples/BackgroundAudio)  
[VoIP](/Samples/VoIP)  

### Roadmaps

[Audio, video, and camera](https://msdn.microsoft.com/library/windows/apps/mt203788)  
[Designing UX for apps](http://msdn.microsoft.com/library/windows/apps/hh767284)  
[Roadmap for apps using C\# and Visual Basic](http://msdn.microsoft.com/library/windows/apps/br229583)  
[Roadmap for apps using C++](http://msdn.microsoft.com/library/windows/apps/hh700360)  
[Roadmap for apps using JavaScript](http://msdn.microsoft.com/library/windows/apps/hh465037)  

### Reference

[Windows Audio Session API (WASAPI)](http://msdn.microsoft.com/library/windows/apps/dd371455)  
[Core Audio APIs](http://msdn.microsoft.com/library/windows/apps/dd370802)  
[Media Foundation](http://msdn.microsoft.com/library/windows/apps/ms694197)  

## Operating system requirements

**Client:** Windows 10

**Phone:** Windows 10

## Build the sample

1. If you download the samples ZIP, be sure to unzip the entire archive, not just the folder with the sample you want to build. 
2. Start Microsoft Visual Studio 2017 and select **File** \> **Open** \> **Project/Solution**.
3. Starting in the folder where you unzipped the samples, go to the Samples subfolder, then the subfolder for this specific sample, then the subfolder for your preferred language (C++, C#, or JavaScript). Double-click the Visual Studio Solution (.sln) file.
4. Press Ctrl+Shift+B, or select **Build** \> **Build Solution**.

## Run the sample

The next steps depend on whether you just want to deploy the sample or you want to both deploy and run it.

**Deploying the sample**
1.  Select **Build** \> **Deploy Solution**.

**Deploying and running the sample**
1.  To debug the sample and then run it, press F5 or select **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or select**Debug** \> **Start Without Debugging**.