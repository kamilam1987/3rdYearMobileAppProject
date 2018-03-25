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
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

//Author: Kamila Michel
//Source code Based on: https://www.youtube.com/watch?v=k3g-TCPtw74, https://www.sitepoint.com/adding-geolocation-and-maps-to-windows-phone-apps/
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


        //Method CenterMap changes Map Center. Map has to show a specific location, or at least focus on a specific area.
        private void CenterMap(double lat, double lon)
        {
            MapControl.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = lat,
                Longitude = lon
            });
        }//End of CenterMap method

        //When tap on the map it shows the current position
        private async void MapControl_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
        {
            //On tap get location position
            var tappedGeoPosition = args.Location.Position;
            string status = $"Map tapped at \nLatitude: {tappedGeoPosition.Latitude}" + $"\nLongitude: {tappedGeoPosition.Longitude}";

            var accessStatus = await Geolocator.RequestAccessAsync();
            var messageDialog = new MessageDialog(status);
            await messageDialog.ShowAsync();

        }//End of MapControl_MapTapped method

        //Method GetLocation gets user location
        private async void GetLocation()
        {
            Geolocator gl = new Geolocator
            {
                //Declare a Geolocator with position accuracy set to high
                DesiredAccuracy = PositionAccuracy.High
                
            };

            //try-catch block that contains the asynchronous call to get the GeoPosition using the geolocator
            try
            {
                Geoposition gp = await gl.GetGeopositionAsync(
                    //Specifies how old we want the location data to be
                    maximumAge: TimeSpan.FromMinutes(1),
                    //The time willing to wait for a response
                    timeout: TimeSpan.FromSeconds(20));
                //Prints out Coordinate for current location in message box
                //Message("Lat: " + gp.Coordinate.Point.Position.Latitude + "\n Lon: " + gp.Coordinate.Point.Position.Longitude, "Coordinates");
                CenterMap(gp.Coordinate.Point.Position.Latitude, gp.Coordinate.Point.Position.Longitude);
            }
            catch (Exception e)
            {
                //Display message if user has localisation switched off
                Message(e.Message, "ERROR!");
            }
        }//End of GetLocation method

        //Message method displays the coordinates as a message dialog
        private async void Message(string body, string title)
        {
            var dlg = new MessageDialog(
                    string.Format(body), title);

            try
            {
                await dlg.ShowAsync();
            }
            catch (Exception) { }
        }
        //AppBarButton_Click method on click button "Get localisation"(Event Handler)s
        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            GetLocation();


        }//End of AppBarButton_Click

        //AppBarToggleButton_Checked method adds a pushpin from the map children.
        private void AppBarToggleButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AddPushpin(MapControl.Center.Position.Latitude,
            MapControl.Center.Position.Longitude, Colors.Red);
        }//End of AppBarToggleButton_Checked method

        //AppBarToggleButton_Checked method removes a pushpin from the map children.
        private void AppBarToggleButton_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MapControl.Children.Clear();
        }//End of AppBarToggleButton_Unchecked method

        //AddPushpin method has three parameters: latitude and longitude of the location, and a color of the pushpin
        public void AddPushpin(double lat, double lon, Color c)
        {
            BasicGeoposition location = new BasicGeoposition();
            location.Latitude = lat;
            location.Longitude = lon;

            var pin = new Ellipse()
            {
                Fill = new SolidColorBrush(c),
                Stroke = new SolidColorBrush(Colors.Blue),
                StrokeThickness = 1,
                Width = 20,
                Height = 20,
            };

            pin.Tapped += Pin_Tapped;

            Windows.UI.Xaml.Controls.Maps.MapControl.SetLocation(pin, new Geopoint(location));
            MapControl.Children.Add(pin);
        }//End of AddPushpin method

        //Pin_Tapped method display message box
        void Pin_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            Message("This is your location.", "");
        }//End of Pin_Tapped method

    }//End of MapPage class

}//End of name space myCollegeApp
