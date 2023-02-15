using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Geo.DAL.context;
using Geo.Wpf.WindowFactory.Interfaces;
using Geo.Wpf.WindowFactory.Implementation;
using System.Windows;

namespace Geo.Wpf
{
    public class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        /// <summary>
        /// ������� ����� ����� ��� ����������.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            // �������� ������ - ������ ������ App
            var app = host.Services.GetService<App>();
            // ��������� ����������
            app?.Run();
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<App>();
                    services.AddSingleton<IWindowFactory, WindowFactoryImpl>();
                    services.AddDbContext<GeoDBContext>();
                   
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
