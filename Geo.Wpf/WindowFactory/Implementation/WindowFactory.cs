using Geo.Wpf.WindowFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Geo.Wpf.WindowFactory.Implementation
{
    public class WindowFactoryImpl : IWindowFactory
    {
        private readonly IServiceScope _scope;

        public WindowFactoryImpl(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public T? Create<T>() where T: Window
        {
            return _scope.ServiceProvider.GetService<T>();
        }

    }
}
