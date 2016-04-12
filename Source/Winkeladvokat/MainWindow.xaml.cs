using System.ComponentModel;
using System.Windows;
using Winkeladvokat.Services;

namespace Winkeladvokat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IDialogService dialogService;

        public MainWindow(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            InitializeComponent();
        }


        private void MainWindowOnClosing(object sender, CancelEventArgs cancelEvent)
        {
            if (this.dialogService.ShowExitMessageBox() == MessageBoxResult.No)
            {
                cancelEvent.Cancel = true;
            }
        }
    }
}
