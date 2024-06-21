using CleanArch.Application.Interfaces;
using CleanArch.Infrastructure;
using CleanArch.Application.Services; 
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace CleanArch.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //// Add Dependensies Injection 
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            //// Run windows Form Application
            System.Windows.Forms.Application.Run(serviceProvider.GetRequiredService<Main>());

        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AppDbContext>();

            //// Add services in below list for inject
            serviceCollection.AddScoped<IListItemService, ListItemService>();


            //// Add Forms in below for using dependencies 
            serviceCollection.AddTransient<Main>();
        }

    }
}