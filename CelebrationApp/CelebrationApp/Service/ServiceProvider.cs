
using CelebrationApp;
using CelebrationApp.Views;
using CelebrationCore.Commons;
using CelebrationCore.Models;
using CelebrationCore.Stores;
using CelebrationCore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using NLog;
using Repository;
using Repository.DbContexts;
using Repository.Repository.DbContexts;
using System;

namespace CelebrationCore.Services
{
    public static class CelebrationServiceProvider
    {
        private static CelebrationDbContextFactory _dbContextFactory;
        private static readonly string CONNECTION_STRTING = $"Data Source={GlobalVariables.DataBaseString}";
        private static ServiceCollection _servicesProvider = new ServiceCollection();
        private static NavigationService _navigationService;
        private static Logger _logger;

        public static void CreateDefaultServices()
        {
            _logger = NLog.LogManager.GetLogger("logfile");
            _logger.Debug(CONNECTION_STRTING);
            _dbContextFactory = new CelebrationDbContextFactory(CONNECTION_STRTING);
            
            AddRepository();
            AddModels();
            AddServices();
            AddStores();
            AddViewModels();

            Ioc.Default.ConfigureServices(_servicesProvider.BuildServiceProvider());
        }

        private static void AddRepository()
        {
            CelebrationDbContext context = _dbContextFactory.CreateDbContext();

            _servicesProvider.AddSingleton(new CelebrationRepository(context));
        }

        private static void AddServices()
        {
            _servicesProvider.AddSingleton((s) => new CelebrationService(s.GetRequiredService<CelebrationRepository>()));

            _navigationService = new NavigationService();
            _navigationService.Configure(typeof(ListPageViewModel), typeof(ListPage));
            _navigationService.Configure(typeof(RegistrationPageViewModel), typeof(RegistrationPage));

            _servicesProvider.AddSingleton<NavigationService>(_navigationService);

        }
        private static void AddModels()
        {
            _servicesProvider.AddTransient<CelebrationBook>();
            _servicesProvider.AddSingleton((s) => new Main("CelebrationApp", s.GetRequiredService<CelebrationBook>()));
        }


        private static void AddStores()
        {
            _servicesProvider.AddSingleton((s) => new MainStore(s.GetRequiredService<Main>()));
        }

        private static void AddViewModels()
        {
            _servicesProvider.AddTransient((s) => new RegistrationPageViewModel(s.GetRequiredService<MainStore>(), s.GetRequiredService<NavigationService>()));
            _servicesProvider.AddTransient((s) => ListPageViewModel.LoadViewModel(s.GetRequiredService<MainStore>(), s.GetRequiredService<NavigationService>()));
        }

    }
}
