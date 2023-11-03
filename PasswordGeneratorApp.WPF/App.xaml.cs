using PasswordGeneratorApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordGeneratorApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindow = new MainWindow()
            {
                DataContext = new PasswordViewModel()
            };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
