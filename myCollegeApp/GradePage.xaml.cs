using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using myCollegeApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
//Author: Kamila Michel
//Source code adapted from: https://www.youtube.com/watch?v=bvz7vtkpchI

namespace myCollegeApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GradePage : Page
    {
        public GradePage()
        {
            this.InitializeComponent();
            Loaded += GradePage_Loaded;
        }

        private void GradePage_Loaded(object sender, RoutedEventArgs e)
        {
            GoalControl.OnGoalsaved += GoalControl_OnGoalsaved;
        }

        private void GoalControl_OnGoalsaved(object sender, Goal e)
        {
           
        }

        //AppBarAddButton_Click method on click add button, display goal control
        private void AppBarAddButton_Click(object sender, RoutedEventArgs e)
        {
            //Open the add goal control
            GoalControl.Visibility = Visibility.Visible;
        }//End of AppBarAddButton_Click

    }//End of GradePage class

}//End of myCollegeApp namespace 
