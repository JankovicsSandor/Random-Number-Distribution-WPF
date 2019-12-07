using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RandomDistributionGenerator.Logic;
using RandomDistributionGenerator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomDistributionGenerator.VM
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<GeneratedNumberStat> Generates { get; private set; }
        private string min;
        private string max;
        private int generateStatus;
        private bool showProgressBar;

        public bool ShowProgressBar
        {
            get { return showProgressBar; }
            set { Set(ref showProgressBar, value); }
        }


        public int GenerateStatus
        {
            get { return generateStatus; }
            set { Set(ref generateStatus, value); }
        }


        public string Max
        {
            get { return max; }
            set { Set(ref max, value); }
        }


        public string Min
        {
            get { return min; }
            set { Set(ref min, value); }
        }

        private int times;

        public int Times
        {
            get { return times; }
            set { Set(ref times, value); }
        }


        public ICommand GenerateCommand { get; private set; }

        IGenerateLogic logic
        {

            get { return ServiceLocator.Current.GetInstance<IGenerateLogic>(); }

        }

        public MainWindowViewModel()
        {
            ShowProgressBar = false;
            logic.NumberGenerated += Logic_NumberGenerated;
            logic.ProgressbarUpdate += Logic_ProgressbarUpdate;
            Generates = new ObservableCollection<GeneratedNumberStat>();
            GenerateCommand = new RelayCommand(() =>
            {

                int minInt = int.Parse(min);
                int maxInt = int.Parse(max);
                Generates.Clear();
                for (int i = minInt; i < maxInt; i++)
                {
                    Generates.Add(new GeneratedNumberStat()
                    {
                        Number = i,
                        NumberOfChoice = 0
                    });
                }
                Task.Run(() =>
                {
                    logic.GenerateNumbers(times, minInt, maxInt);
                });
            });

        }

        private void Logic_ProgressbarUpdate(object sender, int e)
        {
            Debug.WriteLine("UPDATE PROGRESS: " + e.ToString());
            GenerateStatus = e;
        }

        private void Logic_NumberGenerated(object sender, int number)
        {
            Debug.WriteLine("UPDATE NUMBER: " + number.ToString());
            GeneratedNumberStat stat = Generates.FirstOrDefault(e => e.Number == number);
            stat.NumberOfChoice++;
        }
    }
}
