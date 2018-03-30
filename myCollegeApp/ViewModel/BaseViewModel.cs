using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Author: Kamila Michel
//Source code based on: https://www.youtube.com/watch?v=fkSW0eSF9mg

namespace myCollegeApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }//End of if

        }//End of NotifyPropertyChanged method

    }//End of BaseViewModel class

}//End of namespace BaseViewModel
