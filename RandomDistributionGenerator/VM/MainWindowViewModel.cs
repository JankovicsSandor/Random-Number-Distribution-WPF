using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RandomDistributionGenerator.Logic;
using RandomDistributionGenerator.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RandomDistributionGenerator.VM
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<GeneratedNumberStat> Generates { get; private set; }

        private string min;
        private string max;

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
            logic.NumberGenerated += Logic_NumberGenerated;
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
                logic.GenerateNumbers(times, minInt, maxInt);
            });

        }

        private void Logic_NumberGenerated(object sender, int number)
        {
            GeneratedNumberStat stat = Generates.FirstOrDefault(e => e.Number == number);
            stat.NumberOfChoice++;
        }
    }
}
