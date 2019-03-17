---
topic: sample
languages:
- csharp
products:
- windows
- uwp
---

<!---
 category: Communications
  samplefwlink: http://go.microsoft.com/fwlink/p/?LinkId=620586
--->

# Phone call sample

Shows how to use the [Calls](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.calls.aspx) APIs. 
This sample does not follow the typical sample template pattern, it is a sample app that uses the MWC pattern to give you a working E2E phone call application to start with. 

> **Note:** This sample is part of a large collection of UWP feature samples. 
> If you are unfamiliar with Git and GitHub, you can download the entire collection as a 
> [ZIP file](https://github.com/Microsoft/Windows-universal-samples/archive/master.zip), but be 
> sure to unzip everything to access shared dependencies. For more info on working with the ZIP file, 
> the samples collection, and GitHub, see [Get the UWP samples from GitHub](https://aka.ms/ovu2uq). 
> For more samples, see the [Samples portal](https://aka.ms/winsamples) on the Windows Dev Center. 

**Note:** This is a mobile only sample.

This sample allows the user to:

-   Query phone line information
-   Query phone call status
-   Query voice mail information
-   Place phone calls (Single and Multi-SIM)

The app UI represents the following tabs:

### Status tab

This focuses on accessing basic phone line information.

### Contacts tab

This focuses on contacts integration with your own phone call app.

### Dialer tab

This is a dialer that allows users to place a phone call.

### Voice mail tab

This focuses on accessing voice mail information and placing calls to the user's voice mail.

## System requirements

**Client:** Not supported

**Server:** Not supported

**Phone:**  Windows 10

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

