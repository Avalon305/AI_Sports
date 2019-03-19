'*********************************************************
'
' Copyright (c) Microsoft. All rights reserved.
' This code is licensed under the MIT License (MIT).
' THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
' ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
' IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
' PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
Imports Windows.Devices.Sensors
Imports Windows.UI.Core

Namespace Global.SDKTemplate

    Public NotInheritable Partial Class Scenario5_DataEventsBatching
        Inherits Page

        Dim rootPage As MainPage = MainPage.Current

        Private accelerometer As Accelerometer

        Private desiredReportInterval As UInteger

        Private desiredReportLatency As UInteger

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
            accelerometer = Accelerometer.GetDefault(rootPage.AccelerometerReadingType)
            If accelerometer IsNot Nothing Then
                ' Select a report interval that is both suitable for the purposes of the app and supported by the sensor.
                ' This value will be used later to activate the sensor.
                desiredReportInterval = Math.Max(accelerometer.MinimumReportInterval, 16)
                ' MaxBatchSize will be 0 if the accelerometer does not support batching.
                Dim maxLatency As UInteger = accelerometer.MaxBatchSize * desiredReportInterval
                desiredReportLatency = Math.Min(maxLatency, 10000)

                rootPage.NotifyUser(rootPage.AccelerometerReadingType.ToString & " accelerometer ready", NotifyType.StatusMessage)
                ScenarioEnableButton.IsEnabled = True
            Else
                rootPage.NotifyUser(rootPage.AccelerometerReadingType.ToString & " accelerometer not found", NotifyType.ErrorMessage)
            End If
        End Sub

        Protected Overrides Sub OnNavigatingFrom(e As NavigatingCancelEventArgs)
            If ScenarioDisableButton.IsEnabled Then
                ScenarioDisable()
            End If
        End Sub

        ''' <summary>
        ''' This is the event handler for VisibilityChanged events. You would register for these notifications
        ''' if handling sensor data when the app is not visible could cause unintended actions in the app.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e">
        ''' Event data that can be examined for the current visibility state.
        ''' </param>
        Private Sub VisibilityChanged(sender As Object, e As VisibilityChangedEventArgs)
            If ScenarioDisableButton.IsEnabled Then
                If e.Visible Then
                    AddHandler accelerometer.ReadingChanged, AddressOf ReadingChanged
                Else
                    RemoveHandler accelerometer.ReadingChanged, AddressOf ReadingChanged
                End If
            End If
        End Sub

        ''' <summary>
        ''' This is the event handler for ReadingChanged events.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Async Private Sub ReadingChanged(sender As Object, e As AccelerometerReadingChangedEventArgs)
            Await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, Sub()
                MainPage.SetReadingText(ScenarioOutput, e.Reading)
            End Sub)
        End Sub

        ''' <summary>
        ''' This is the click handler for the 'Enable' button.
        ''' </summary>
        Private Sub ScenarioEnable()
            accelerometer.ReportInterval = desiredReportInterval
            accelerometer.ReportLatency = desiredReportLatency
            AddHandler Window.Current.VisibilityChanged, AddressOf VisibilityChanged
            AddHandler accelerometer.ReadingChanged, AddressOf ReadingChanged
            ScenarioEnableButton.IsEnabled = False
            ScenarioDisableButton.IsEnabled = True
        End Sub

        ''' <summary>
        ''' This is the click handler for the 'Disable' button.
        ''' </summary>
        Private Sub ScenarioDisable()
            RemoveHandler Window.Current.VisibilityChanged, AddressOf VisibilityChanged
            RemoveHandler accelerometer.ReadingChanged, AddressOf ReadingChanged
            accelerometer.ReportInterval = 0
            ScenarioEnableButton.IsEnabled = True
            ScenarioDisableButton.IsEnabled = False
        End Sub
    End Class
End Namespace
