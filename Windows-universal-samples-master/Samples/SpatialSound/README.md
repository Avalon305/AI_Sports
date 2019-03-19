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
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620607
--->

# Spatial audio sample

Shows how to render spatial audio using HRTF xAPO and XAudio2 API within Universal Applications.

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

Specifically, this sample covers hosting the HRTF xAPO in an XAudio2 graph for rendering sources with different spatial locations, radiation patterns and distance decay behaviors. You can choose one of the following three scenarios:

- Omnidirectional source with natural distance decay.
- Cardioid source with natural distance decay.
- Omnidirectional source with custom distance decay.

### Omnidirectional source with natural distance decay

"Play" button starts playback from an omnidirectional source which starts orbiting around the listener's head. The sliders control the radius and height of orbit.

### Cardioid source with natural distance decay.

"Play" button starts playback from a source with Cardioid radiation pattern. The sliders control the orientation of the source and the shape of the radiation pattern.

### Omnidirectional source with custom distance decay.

"Play" button starts playback from an omnidiretional source. The sliders allow control the location of the source.

**Note** The Windows universal samples require Visual Studio 2017 to build and Windows 10 to execute.
 
To obtain information about Windows 10 development, go to the [Windows Dev Center](http://go.microsoft.com/fwlink/?LinkID=532421)

To obtain information about Microsoft Visual Studio and the tools for developing Windows apps, go to [Visual Studio](http://go.microsoft.com/fwlink/?LinkID=532422)

### Remark

HRTF xAPO API is present but nonfunctional on Phone devices.

## Reference

[XAudio2 API](https://msdn.microsoft.com/library/windows/desktop/hh405049.aspx)  
[IXAPOHrtfParameters](https://msdn.microsoft.com/library/windows/desktop/mt186608.aspx)  

## System requirements

**Client:** Windows 10 

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

- To debug the sample and then run it, press F5 or select Debug >  Start Debugging. To run the sample without debugging, press Ctrl+F5 or selectDebug > Start Without Debugging. 

Spatial sound requires headphones.
