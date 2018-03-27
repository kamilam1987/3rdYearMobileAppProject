using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace myCollegeApp
{
    class MyCalculator : INotifyPropertyChanged
    {
        private double topValue=1.00;
        private double bottomValue=1.00;
        private double answerValue;

        public event PropertyChangedEventHandler PropertyChanged;

        public double BottomValue
        {
            set
            {
                bottomValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AnswerValue"));
                }
            }
            get
            {
                return bottomValue;
            }
        }

        public double TopValue
        {
            set
            {
                topValue = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AnswerValue"));
                }
            }
            get
            {
                return topValue;
            }
        }

        public double AnswerValue
        {

            get
            {
                return (topValue * 100) / bottomValue;
            }
        }

    }
}
