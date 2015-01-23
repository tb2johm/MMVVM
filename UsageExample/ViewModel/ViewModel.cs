using System;

namespace UsageExample.ViewModel
{
    // Let the ViewModel extend the ViewModelBase class to get the Notify function
    public class ViewModel : MMVVM.ViewModelBase.ViewModelBase
    {
        // Initialize the ClearCommand
        public ViewModel()
        {
            // bind the ClearAction and CanExecuteClearAction function to the command
            // if no canExecute function is given, the command will always be enable
            ClearCommand = new MMVVM.Commands.RelayCommand(ClearAction, CanExecuteClearAction);
        }




        #region Properties

        // Create the TextToClear property (and backing variable _textToClear)
        private string _textToClear = string.Empty;
        public string TextToClear
        {
            get { return _textToClear; }
            set
            {
                if (value != _textToClear)
                {
                    _textToClear = value;
                    // Notify the text change to update the GUI
                    Notify("TextToClear");
                    // Raise the CanExecuteChanged to update the button availibility
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion




        #region Commands

        //Create the ClearCommand
        public MMVVM.Commands.RelayCommand ClearCommand { get; set; }

        // This is the action that is called when the button is pressed
        private void ClearAction()
        {
            TextToClear = string.Empty;
        }

        // This function is what defines if the button is enabled or not
        private bool CanExecuteClearAction()
        {
            return !String.IsNullOrEmpty(TextToClear);
        }

        #endregion
    }
}
