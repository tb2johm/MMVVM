using System;
using System.Windows.Input;

namespace MMVVM.Commands
{
    /// <summary>
    /// RelayCommand. Use this as a command for buttons and other commands
    /// Useage: create a public RelayCommand property in your ViewModel
    /// and then connect it to a action with the wanted behaivour
    /// you can also connect a Func(bool) that determines if
    /// the command is enabed or not.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="execute">Action to execute when command is executed</param>
        /// <param name="canExecute">Function to define if the command is availible or not</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// Call this function whenever you want to update if the
        /// command is enabled or not (the canExecute function will be called).
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
    }
}