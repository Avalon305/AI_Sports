//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using SDKTemplate.Logging;
using System;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SDKTemplate
{
    /// <summary>
    /// Demonstrates multi-track video playback and camera selection.
    /// </summary>
    public sealed partial class Scenario4 : Page
    {
        MainPage rootPage = MainPage.Current;
        private MediaPlaybackItemLogger mpiLogger;
        MediaPlaybackItem item;

        public Scenario4()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.item = new MediaPlaybackItem(MediaSource.CreateFromUri(rootPage.MultiTrackVideoMediaUri));
            mpiLogger = new MediaPlaybackItemLogger(LoggerControl, item);

            item.VideoTracks.SelectedIndexChanged += VideoTracks_SelectedIndexChanged;

            this.mediaPlayerElement.Source = item;
            LoggerControl.Log($"Loaded: {rootPage.MultiTrackVideoMediaUri}");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            mpiLogger?.Dispose();
            mpiLogger = null;
            MediaPlayerHelper.CleanUpMediaPlayerSource(mediaPlayerElement.MediaPlayer);
        }

        private void TrackButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the video track index based on value of the 'tag' field
            var button = sender as Button;
            int videoTrackIndex = int.Parse(button.Tag as string);

            // Select the clicked camera track
            if (this.item != null && this.item.VideoTracks != null && this.item.VideoTracks.Count -1 >= videoTrackIndex)
            {
                this.item.VideoTracks.SelectedIndex = videoTrackIndex;
            }
        }

        private async void VideoTracks_SelectedIndexChanged(ISingleSelectMediaTrackList sender, object args)
        {
            var videoTrackIndex = sender.SelectedIndex;

            LoggerControl.Log("Switched to video track #" + (videoTrackIndex + 1)
                    + " | Id: " + this.item.VideoTracks[videoTrackIndex].Id
                    + " | Label: " + this.item.VideoTracks[videoTrackIndex].Label);

            // Forces a new frame to be rendered when we are paused.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                //Make sure to call the mediaPlayerElement on the UI thread:
                if (mediaPlayerElement.MediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Paused)
                    mediaPlayerElement.MediaPlayer.StepForwardOneFrame();
            });
        }
    }
}
