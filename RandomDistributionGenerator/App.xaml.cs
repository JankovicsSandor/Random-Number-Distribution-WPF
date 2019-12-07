using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using RandomDistributionGenerator.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RandomDistributionGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IGenerateLogic, GenerateLogic>();
        }
    }
}
