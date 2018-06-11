using LiteDB;
using ProductionManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProductionManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Open database (or create if doesn't exist)
            using (LiteDatabase db = new LiteDatabase(@"ProductionManager.db"))
            {
                MainWindow app = new MainWindow();
                MainViewModel context = new MainViewModel(db);
                app.DataContext = context;
                app.Show();
            }
        }
    }
}
