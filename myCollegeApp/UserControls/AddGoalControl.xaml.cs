using myCollegeApp.Model;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236
//Author: Kamila Michel
//Source based on: https://www.youtube.com/watch?v=bvz7vtkpchI


namespace myCollegeApp.UserControls
{
    public sealed partial class AddGoalControl : UserControl
    {
        public event EventHandler<Goal> OnGoalsaved;
        public AddGoalControl()
        {
            this.InitializeComponent();
        }

        //SaveButton_Click method on click save button
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //Fire event so that the Grade age gets the data
            var newGoal = new Goal();//Create a new object
            newGoal.Name = ModuleNameTextBox.Text;
            newGoal.GradeGoal = Convert.ToDouble(GradeValueTextBox.Text);
            newGoal.Notes = NotesTextBox.Text;

            //Fire on goal save event
            FireOnGoalSave(newGoal);

            //Happens at the end
            ClearTextBoxes();
            Visibility = Visibility.Collapsed;
        }//End of SaveButton_Click

        //CancelButtom_Click method on click cancel button
        private void CancelButtom_Click(object sender, RoutedEventArgs e)
        {
            //Close user control
            Visibility = Visibility.Collapsed;
            ClearTextBoxes();
        }//End of CancelButtom_Click

        private void ClearTextBoxes()
        {
            //Clear all text boxes
            ModuleNameTextBox.Text = string.Empty;
            GradeValueTextBox.Text = string.Empty;
            NotesTextBox.Text = string.Empty;
        }//End of ClearTextBoxes method

        //FireOnGoalSave method, call anytime needs to save info to the grade page
        private void FireOnGoalSave(Goal newGoal)
        {
            //If not null then invoke
            OnGoalsaved?.Invoke(null, newGoal);

        }//End of FireOnGoalSave method

    }//End of AddGoalControl class

}//End of myCollegeApp.UserControls namespace