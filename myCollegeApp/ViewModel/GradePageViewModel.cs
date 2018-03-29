using myCollegeApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myCollegeApp.ViewModel
{
    public class GradePageViewModel : BaseViewModel
    {
        //List that will hold list of the goals
        private ObservableCollection<Goal> _goalList;//The list changed, display new item that was added
        public ObservableCollection<Goal> GoalList
        {
            get { return _goalList; }//return _goalList
            set
            {
                _goalList = value;
                NotifyPropertyChanged("GoalList");//Tells UI that property change and need to update it
            }//End of set

        }//End of ObservableCollection

        public GradePageViewModel()
        {
            _goalList = new ObservableCollection<Goal>();
        }

        //Method that allows adds items to the goal list
        public void AddNewGoal(Goal newGoal)
        {
            //Add item to goal list
            GoalList.Add(newGoal);
        }//End of AddNewGoal method

    }//End of GradePageViewModel class

}//End of namespace
