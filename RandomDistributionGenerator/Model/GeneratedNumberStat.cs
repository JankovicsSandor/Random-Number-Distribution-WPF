using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomDistributionGenerator.Model
{
    class GeneratedNumberStat : ObservableObject
    {
        private int number;
        private int numberOfChoice;

        public int NumberOfChoice
        {
            get { return numberOfChoice; }
            set { Set(ref numberOfChoice, value); }
        }


        public int Number
        {
            get { return number; }
            set { Set(ref number, value); }
        }

    }
}
