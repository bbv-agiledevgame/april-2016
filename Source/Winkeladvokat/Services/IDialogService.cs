using System.Windows;

namespace Winkeladvokat.Services
{
    public interface IDialogService
    {
        MessageBoxResult ShowExitMessageBox();

        void ShowGameOver();
    }
}