using System.Windows;

namespace Winkeladvokat.Services
{
    public class DialogService : IDialogService
    {
        public MessageBoxResult ShowExitMessageBox()
        {
            return MessageBox.Show("Wollen Sie das Spiel beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        public void ShowGameOver()
        {
            MessageBox.Show("Spiel ist fertig!");
        }
    }
}
