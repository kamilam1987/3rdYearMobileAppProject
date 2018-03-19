using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//Added for geolocation
using Windows.Devices.Geolocation;
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

//Author: Kamila Michel
//Source code Based on: https://www.youtube.com/watch?v=k3g-TCPtw74
namespace myCollegeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
            MapControl.Loaded += MapControl_Loaded;
            MapControl.MapTapped += MapControl_MapTapped;
        }

        //Turn on trafic flow when the traffic check box is pressed
        private void TrafficCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Set Traffic flow to be visible
            MapControl.TrafficFlowVisible = true;
        }//End of TrafficCheckBox_Checked method

        //Turn off trafic flow when the traffic check box is not pressed
        private void TrafficCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Set Traffic flow to be not visible
            MapControl.TrafficFlowVisible = false;
        }//End of TrafficCheckBox_Unchecke method

        //This method allows on the click buttom switch from Aerial to Road view
        private void MapStyleButton_Click(object sender, RoutedEventArgs e)
        {
            //Map loads with Aerial view at the start
            if (MapControl.Style == Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial)
            {
                MapControl.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Road;
                MapStyleButton.Content = "Aerial";
            }//End of if statement
            else
            {
                MapControl.Style = Windows.UI.Xaml.Controls.Maps.MapStyle.Aerial;
                MapStyleButton.Content = "Road";
            }//End of else statement

        }//End of MapStyleButton_Click method

        //Method that loads the map
        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            MapControl.Center = new Geopoint(new BasicGeoposition()
            {
                //Set Geopoint for Galway, resource :https://www.latlong.net/search.php?keyword=galway
                Latitude = 53.270962,
                Longitude = -9.062691
            });
            MapControl.ZoomLevel = 12; //Set zoom levet to 12

        }//End of MapControl_Loaded method

        //When tapp on the mat it shows the current position
        private async void MapControl_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            //On tapp get location position
            var tappedGeoPosition = args.Location.Position;
            string status = $"Map tapped at \nLatitude: {tappedGeoPosition.Latitude}" + $"\nLongitude: {tappedGeoPosition.Longitude}";

            var messageDialog = new MessageDialog(status);
            await messageDialog.ShowAsync();

        }//End of MapControl_MapTapped method

    }//End of MapPage class

}//End of name space myCollegeApp
