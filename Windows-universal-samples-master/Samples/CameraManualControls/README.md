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
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=627611
--->

# Manual camera controls sample

Provides an end-to-end sample to show how to write a camera app using the Windows.Media.Capture API in conjunction with 
orientation sensors to cover some of the functions that advanced camera apps will require. This sample is based on the [Basic camera app sample](../CameraStarterKit).

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

Specifically, this sample will cover how to:

1. **Manage the MediaCapture object** throughout the lifecycle of the app and through navigation events.
2. **Acquire a camera located on a specific side of the device**. In this case, the sample attempts to get the rear camera.
3. **Start and stop the preview** to a UI element, including mirroring for front-facing cameras.
4. **Take a picture** to a file (taking into account the orientation of the device), and disable the video capture button if the app is running on a device that doesn't support concurrent capturing of photos and video.
5. **Record a video** to a file, and disable the photo capture button if the app is running on a device that doesn't support concurrent capturing of photos and video.
6. **Discover the capabilities of a device** regarding the following advanced camera controls:
    * Flash and video light
    * Zoom, including Smooth Zoom if supported by the device
    * Focus: manual, continuous, and tap-to-focus
    * ISO Speed
    * Shutter Speed (Exposure)
    * Exposure Value
    * White Balance
7. **Configure manual camera controls** individually, allowing the user to see the effect the controls would have on the preview (where applicable).
8. **Handle rotation events** for both, the device moving in space and the page orientation changing on the screen. Also apply any necessary corrections to the preview stream rotation and user interactions with the CaptureElement.
9. **Handle MediaCapture Failed event** to clean up the MediaCapture instance when an error occurs.

This sample also implements a custom UI to better simulate the experience that a camera application would provide, so any messages intended for the developer are printed to the debug console.

To keep code complexity low, but offer easier navigation between the different controls, the sample uses partial classes to separate the code that handles specific controls into their own files. Each file is named according to the control they cover, in the format of: MainPage.Control.xaml.cs.

## Related topics

**Samples**

[CameraStarterKit](/Samples/CameraStarterKit)  
[CameraResolution](/Samples/CameraResolution)  

**Conceptual**

[Capture photos and video with MediaCapture](https://msdn.microsoft.com/library/windows/apps/mt243896)  
[Media capture using capture device](https://code.msdn.microsoft.com/windowsapps/Media-Capture-Sample-adf87622)  
[Using Smooth Zoom](http://go.microsoft.com/fwlink/?LinkId=627232)  

**Reference**

[Windows.Media.Capture.MediaCapture namespace](https://msdn.microsoft.com/library/windows/apps/windows.media.devices.aspx)  
[Windows.Media.Capture.MediaCaptureInitializationSettings constructor](https://msdn.microsoft.com/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.mediacaptureinitializationsettings.aspx)  
[Windows.Media.Capture.MediaCaptureInitilizationSettings.VideoDeviceId property](https://msdn.microsoft.com/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.videodeviceid.aspx)  
[Windows.Devices.Enumeration namespace](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.aspx)  
[Windows.Devices.Enumeration.DeviceInformation class](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation)  
[Windows.Devices.Sensors.SimpleOrientationSensor class](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.simpleorientationsensor.aspx)  
[Windows.Graphics.Display.DisplayInformation class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.aspx)  
[Windows.Phone.UI.Input.HardwareButtons.CameraPressed event](https://msdn.microsoft.com/library/windows/apps/windows.phone.ui.input.hardwarebuttons.camerapressed.aspx)  
[Windows.Graphics.Imaging.BitmapDecoder class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.imaging.bitmapdecoder.aspx)  
[Windows.Graphics.Imaging.BitmapEncoder class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.imaging.bitmapencoder.aspx)  

## System requirements

**Hardware:** Camera

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

**Deploying the sample:**

1.  Select **Build** \> **Deploy Solution**.

**Deploying and running the sample:**

1.  To debug the sample and then run it, press F5 or select **Debug** \> **Start Debugging**. To run the sample without debugging, press Ctrl+F5 or select **Debug** \> **Start Without Debugging**.


