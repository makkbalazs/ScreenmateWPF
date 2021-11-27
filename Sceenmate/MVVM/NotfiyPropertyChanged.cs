using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Screenmate.MVVM
{
    public class NotfiyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if(!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
