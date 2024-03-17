using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestTabs.MVVM
{
	public class BaseViewModel : INotifyPropertyChanged
	{
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetField(ref _isLoading, value);
        }

        public virtual void NavigatedTo(object parameter) { }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}

