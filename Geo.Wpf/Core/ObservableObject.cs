﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Geo.Wpf.Core
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string? name = null)
        {
            if(PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
