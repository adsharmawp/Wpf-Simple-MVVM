using System;
using System.Windows.Input;

namespace Wpf_Simple_MVVM.MVVMBase
{
    public class RelayCommand<T> : ICommand
    {
        // private fields
        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this._execute = execute;
            this._canExecute = canExecute;
        }

        // CommandManager.RequerySuggested event is raised whenever the CommandManager thinks that something has changed
        // and that will affect the ability of commands to execute. For example this might be a change of focus.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
