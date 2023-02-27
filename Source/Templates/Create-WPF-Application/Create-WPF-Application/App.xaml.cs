using Create_WPF_Application.Contracts.Views;
using Create_WPF_Application.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Create_WPF_Application
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostcontext, services) =>
                {
                    services.AddSingleton<ShellView>();
                    services.AddTransient<IShellViewModel, ShellViewModel>();

                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startWindow = AppHost.Services.GetRequiredService<ShellView>();
            startWindow.Show();

            base.OnStartup(e);
        }


    }
}
