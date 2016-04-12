using System.Windows;
using Winkeladvokat.Services;

namespace Winkeladvokat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mw = new MainWindow(new DialogService());
            mw.Show();
        }
    }
    
}
