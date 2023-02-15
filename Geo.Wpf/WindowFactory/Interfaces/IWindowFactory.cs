using System.Windows;

namespace Geo.Wpf.WindowFactory.Interfaces
{
    public interface IWindowFactory
    {
        T? Create<T>() where T : Window;
    }
}
