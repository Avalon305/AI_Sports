﻿using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Notifications.ScenarioPages.LiveTiles.AdaptiveTemplates.Branding.Logo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScenarioElement : UserControl
    {
        public ScenarioElement()
        {
            this.InitializeComponent();

            // Because different densities might be able to display more, we just set tons of text wrapped to make sure it overflows at some point
            string fillerText = "<text hint-wrap='true'>bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb</text>";

            updateFourTilesControl.SetTilePayload($@"
                <tile version='3'>
                    <visual>

                        <binding template='TileSmall' branding='logo'>
                            <text>logo</text>
                            {fillerText}
                        </binding>

                        <binding template='TileMedium' branding='logo'>
                            <text hint-wrap='true'>branding: logo</text>
                            {fillerText}
                        </binding>

                        <binding template='TileWide' branding='logo'>
                            <text hint-wrap='true'>branding: logo</text>
                            {fillerText}
                        </binding>

                        <binding template='TileLarge' branding='logo'>
                            <text hint-wrap='true'>branding: logo</text>
                            {fillerText}
                        </binding>

                    </visual>
                </tile>");
        }
    }
}
