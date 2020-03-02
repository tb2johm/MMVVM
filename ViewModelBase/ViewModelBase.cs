using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MMVVM.ViewModelBase
{
    /// <summary>
    /// Base ViewModel, gives you access to the Notify function
    /// Usage:
    /// 1. Make your ViewModel extend the MMVVM.ViewModelBase.ViewModelBase
    /// 2. In the setter of your public properties add a Notify("%propertyname%");
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies any subscribers when a update has been made
        /// </summary>
        /// <param name="propertyName">Updated property name</param>
        protected void Notify([CallerMemberName] string propertyName = null)
        {
            if (propertyName is null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Interface stuff
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion
    }
}