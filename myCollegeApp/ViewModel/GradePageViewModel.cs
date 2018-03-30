using myCollegeApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Kamila Michel
//Source based on: https://www.youtube.com/watch?v=fkSW0eSF9mg 

namespace myCollegeApp.ViewModel
{
    public class GradePageViewModel : BaseViewModel
    {
        //An ObservableCollection is a dynamic collection of objects of a given type. Objects can be added, removed or be updated with an automatic notification of actions. When an object is added to or removed from an observable collection, the UI is automatically updated
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