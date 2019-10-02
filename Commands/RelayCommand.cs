using System;
using System.Windows.Input;

namespace MMVVM.Commands
{
    /// <summary>
    /// RelayCommand (with parameter). Use this as a command for buttons and other commands
    /// Useage: 
    /// 1. create a public RelayCommand property in your ViewModel
    /// 2. bind the Control's command option to that RelayCommand
    /// 3. in the ViewModels ctor; instantiate the RelayCommand with an Action
    /// 4. [optional] you can also add a Func(bool) to the RelayCommand which determines if the command is enable or not
    /// 5. [optional] every time the enable property change, call the RaiseCanExecuteChanged function to update the GUI
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Command
        /// </summary>
        /// <param name="execute">Action to execute when command is executed</param>
        /// <param name="canExecute">Function to define if the command is availible or not</param>
        public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute ?? (() => true);
        }

        /// <summary>
        /// Call this function whenever you want to update if the
        /// command is enabled or not (the canExecute function will be called).
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Interface stuff
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke((T)parameter);
        }
        #endregion
    }


    /// <summary>
    /// RelayCommand. Use this as a command for buttons and other commands
    /// Useage: 
    /// 1. create a public RelayCommand property in your ViewModel
    /// 2. bind the Control's command option to that RelayCommand
    /// 3. in the ViewModels ctor; instantiate the RelayCommand with an Action
    /// 4. [optional] you can also add a Func(bool) to the RelayCommand which determines if the command is enable or not
    /// 5. [optional] every time the enable property change, call the RaiseCanExecuteChanged function to update the GUI
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

        /// <summary>
        /// Call this function whenever you want to update if the
        /// command is enabled or not (the canExecute function will be called).
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Interface stuff
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            _execute.Invoke();
        }
        #endregion
    }
}