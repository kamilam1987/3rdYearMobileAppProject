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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

//Author: Kamila Michel
//Source code adapted from: https://www.youtube.com/watch?v=k3g-TCPtw74
namespace myCollegeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
        }

        private void RadioButtonPaneItem_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                switch (radioButton.Tag.ToString()) //Access using tags that are declared in MainPage.xaml
                {
                    case "Map": //If tag is map load MapPage
                        MainFrame.Navigate(typeof(MapPage));
                        break;
                }//End of switch

                //After selection close the split view
                MySplitView.IsPaneOpen = false;

            }//End of if statement
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            //If close open it, if open close it
            this.MySplitView.IsPaneOpen = this.MySplitView.IsPaneOpen ? false : true;
        }//End of HamburgerButton_Click method

    }//End of MainPage class

}//End of namespace myCollegeApp
