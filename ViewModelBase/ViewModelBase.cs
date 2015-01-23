using System;
using System.ComponentModel;

namespace MMVVM.ViewModelBase
{
    /// <summary>
    /// Base ViewModel, gives you access to the Notify function
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Notifies any subscribers when a update has been made
        /// </summary>
        /// <param name="property">Updated property name</param>
        protected void Notify(String property)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}