using Geo.FormFactory.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;

namespace Geo.FormFactory.Implementation
{
    public class FormFactoryImpl : IFormFactory
    {
        private readonly IServiceScope _scope;

        public FormFactoryImpl(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public T? Create<T>() where T: Form
        {
            return _scope.ServiceProvider.GetService<T>();
        }

    }
}
