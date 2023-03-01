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
using Geo.DAL.repositories.Queries;

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

                    services.AddTransient<DbQueries>();

                    services.AddTransient<IMapsRepository, MapsRepository>();
                    services.AddTransient<IRegionsRepository, RegionsRepository>();
                    services.AddTransient<IRoutesRepository, RoutesRepository>();
                    services.AddTransient<IExpeditionsRepository, ExpeditionsRepository>();
                    services.AddTransient<IGeologistsRepository, GeologistsRepository>();
                    services.AddTransient<IPlannedExpeditionsRepository, PlannedExpeditionsRepository>();

                    services.AddSingleton<MainWindowViewModel>();
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<ExpeditionsViewModel>();
                    services.AddTransient<GeologistsViewModel>();
                    services.AddTransient<MapsViewModel>();
                    services.AddTransient<RoutesViewModel>();
                    services.AddTransient<RegionsViewModel>();

                    //Add all forms
                    var windows = typeof(Program).Assembly
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(Window))
                    .ToList();

                    windows.ForEach(window =>
                    {
                        services.AddTransient(window);
                    });
                });
        }
    }
}
