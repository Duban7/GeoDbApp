using Geo.FormFactory.Interfaces;
using Geo.FormFactory.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using System.Linq;

namespace Geo
{
    internal static class Program
    {
        public static IServiceProvider serviceProvider { get; private set; }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            serviceProvider = host.Services;
            Application.Run(serviceProvider.GetService<Form1>());
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton<IFormFactory, FormFactoryImpl>();
                //Add all forms
                    var forms = typeof(Program).Assembly
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(Form))
                    .ToList();

                    forms.ForEach(form =>
                    {
                        services.AddTransient(form);
                    });
                });
        }
    }
}
