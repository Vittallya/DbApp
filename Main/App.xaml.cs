using Main.ContextDb;
using Main.Handlers;
using Main.Interfaces;
using Main.Models;
using Main.ViewModels;
using Main.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<DetailsWindow, DetailsViewModel>();

            containerRegistry.RegisterSingleton<MainDbContext>(x =>
            {
                var connStr = x
                        .GetContainer()
                        .GetRequiredService<IConfiguration>()
                        .GetConnectionString("MsSql");
                return new MainDbContext(new DbContextOptionsBuilder<MainDbContext>()
                    .UseSqlServer(connStr)
                    .Options);
            });


            containerRegistry.Register<IConfiguration>(x => 
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build());

            containerRegistry.Register<ITableHandler<Promotion>, PromotionHandler>();
        }
    }
}
