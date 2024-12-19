using System;
using System.Windows.Input;

namespace AdminApp.ViewModels
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            // Generic command implementation for actions with a parameter of type T
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // Determines if the command can execute based on the provided condition
            return _canExecute == null || _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            // Executes the provided action with a parameter
            _execute((T)parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            // Notifies the UI that the CanExecute state has changed
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Command implementation for actions without parameters
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            // Determines if the command can execute based on the provided condition
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            // Executes the provided action
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            // Notifies the UI that the CanExecute state has changed
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
