---
topic: sample
languages:
- csharp
- cpp
- js
- vb
products:
- windows
- uwp
---

<!---
  category: AudioVideoAndCamera
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=619479
--->

# Basic camera app sample

Provides an end-to-end sample to show how to write a camera application using the Windows.Media.Capture API in
conjunction with orientation sensors to cover the functions that most camera apps will require.

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
4. **Take a picture** to a file, and disable the video capture button if the app is running on a device that doesn't support concurrent capturing of photos and video.
5. **Record a video** to a file, and disable the photo capture button if the app is running on a device that doesn't support concurrent capturing of photos and video.
6. **Handle rotation events** for both, the device moving in space and the page orientation changing on the screen. Also apply any necessary corrections to the preview stream rotation and to captured photos and videos.
7. **Handle MediaCapture RecordLimitationExceeded and Failed events** to be notified that video recording needs to be stopped due to a video being too long, or clean up the MediaCapture instance when an error occurs.
8. **Handle cameras mounted at an angle in the device enclosure** by inspecting the EnclosureLocation.RotationAngleInDegreesClockwise and adjusting the UI to take it into account.

This sample also implements a custom UI to better simulate the experience that a camera application would provide, so any messages intended for the developer are printed to the debug console.

For apps that are interested in capturing a photo or video without requiring access to all camera controls, CameraCaptureUI abstracts and simplifies the access to the MediaCapture APIs through the built-in Camera application. See the related topics section below for more information on how to use it instead.

## Related topics

**Conceptual**

[Capture photos and video with MediaCapture](http://go.microsoft.com/fwlink/?LinkId=627234)  
[Capture photos and video with CameraCaptureUI](https://msdn.microsoft.com/library/windows/apps/mt282142)  
[Media capture using capture device](https://code.msdn.microsoft.com/windowsapps/Media-Capture-Sample-adf87622)  

**Reference**

[Windows.Media.Capture.MediaCapture namespace](https://msdn.microsoft.com/library/windows/apps/windows.media.devices.aspx)  
[Windows.Media.Capture.MediaCaptureInitializationSettings constructor](https://msdn.microsoft.com/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.mediacaptureinitializationsettings.aspx)  
[Windows.Media.Capture.MediaCaptureInitilizationSettings.VideoDeviceId property](https://msdn.microsoft.com/library/windows/apps/windows.media.capture.mediacaptureinitializationsettings.videodeviceid.aspx)  
[Windows.Devices.Enumeration namespace](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.aspx)  
[Windows.Devices.Enumeration.EnclosureLocation namespace](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.enclosurelocation.aspx)  
[Windows.Devices.Enumeration.DeviceInformation class](https://msdn.microsoft.com/library/windows/apps/windows.devices.enumeration.deviceinformation)  
[Windows.Devices.Sensors.SimpleOrientationSensor class](https://msdn.microsoft.com/library/windows/apps/windows.devices.sensors.simpleorientationsensor.aspx)  
[Windows.Graphics.Display.DisplayInformation class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.display.displayinformation.aspx)  
[Windows.Phone.UI.Input.HardwareButtons.CameraPressed event](https://msdn.microsoft.com/library/windows/apps/windows.phone.ui.input.hardwarebuttons.camerapressed.aspx)  
[Windows.Graphics.Imaging.BitmapDecoder class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.imaging.bitmapdecoder.aspx)  
[Windows.Graphics.Imaging.BitmapEncoder class](https://msdn.microsoft.com/library/windows/apps/windows.graphics.imaging.bitmapencoder.aspx)  

## Related samples

[Family Notes sample](https://github.com/Microsoft/Windows-appsample-familynotes)  

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
