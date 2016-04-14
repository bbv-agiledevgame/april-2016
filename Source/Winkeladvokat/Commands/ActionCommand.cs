namespace Winkeladvokat.Commands
{
    using System;
    using System.Windows.Input;

    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> act;
        private readonly Func<T, bool> canExecuteAction;

        public ActionCommand(Action<T> act, Func<T, bool> canExecuteAction)
        {
            this.canExecuteAction = canExecuteAction;
            this.act = act;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecuteAction((T)parameter);
        }

        public void Execute(object parameter)
        {
            this.act((T)parameter);
        }
    }
}