using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Geo.DAL.context;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.WindowFactory.Implementation;
using System.Windows;
using Geo.DAL.repositories.interfaces;
using Geo.Domain.Models;
using Geo.DAL.repositories.implementation;
using System.Windows.Controls;
using Geo.Wpf.MVVM.ViewModel;

namespace Geo.Wpf
{
    public class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            // получаем сервис - объект класса App
            var app = host.Services.GetService<App>();
            // запускаем приложения
            app?.Run();
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<App>();
                    services.AddSingleton<IWindowFactory, WindowFactoryImpl>();

                    services.AddDbContext<GeoDBContext>();

                    services.AddTransient<IRepository<Map>, MapsRepository>();
                    services.AddTransient<IRepository<Region>, RegionsRepository>();
                    services.AddTransient<IRepository<Route>, RoutesRepository>();
                    services.AddTransient<IRepository<Expedition>, ExpeditionsRepository>();
                    services.AddTransient<IRepository<Geologist>, GeologistsRepository>();

                    services.AddSingleton<MainWindowViewModel>();
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<ExpeditionsViewModel>();

                    //Add all forms
                    var windows = typeof(Program).Assembly
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(Window))
                    .ToList();

                    windows.ForEach(window =>
                    {
                        services.AddTransient(window);
                    });

                    //Add all user controls
                    var userControls = typeof(Program).Assembly
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(UserControl))
                    .ToList();

                    userControls.ForEach(uC =>
                    {
                        services.AddTransient(uC);
                    });
                });
        }
    }
}
