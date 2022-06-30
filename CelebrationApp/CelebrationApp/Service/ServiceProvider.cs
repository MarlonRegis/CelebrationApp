
using CelebrationApp.Views;
using CelebrationCore.Commons;
using CelebrationCore.Interfaces;
using CelebrationCore.Models;
using CelebrationCore.Stores;
using CelebrationCore.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Repository;
using Repository.Repository.DbContexts;
using CelebrationCore.Services;
using Commons.MyLogger;

namespace CelebrationApp.Service
{
    public static class CelebrationServiceProvider
    {
        private static CelebrationDbContextFactory _dbContextFactory;
        private static readonly string CONNECTION_STRTING = $"Data Source={GlobalVariables.DataBaseString}";
        private static ServiceCollection _servicesProvider = new ServiceCollection();
        private static INavigationService _navigationService;

        public static void CreateDefaultServices()
        {

            MyLogger.GetLog().LogDebug("Created a default services in Celebration App Win UI");
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

            MyLogger.GetLog().LogDebug("Added a repository context");
            CelebrationDbContext context = _dbContextFactory.CreateDbContext();

            _servicesProvider.AddSingleton(new CelebrationRepository(context));
        }

        private static void AddServices()
        {

            MyLogger.GetLog().LogDebug("Added a services and navigations");
            _servicesProvider.AddSingleton((s) => new CelebrationService(s.GetRequiredService<CelebrationRepository>()));

            _navigationService = new NavigationService();
            _navigationService.Configure(typeof(ListPageViewModel), typeof(ListPage));
            _navigationService.Configure(typeof(RegistrationPageViewModel), typeof(RegistrationPage));

            _servicesProvider.AddSingleton(_navigationService);

        }
        private static void AddModels()
        {

            MyLogger.GetLog().LogDebug("Added a models");
            _servicesProvider.AddTransient<CelebrationBook>();
            _servicesProvider.AddSingleton((s) => new Main("CelebrationApp", s.GetRequiredService<CelebrationBook>()));
        }


        private static void AddStores()
        {
            MyLogger.GetLog().LogDebug("Added a stores");
            _servicesProvider.AddSingleton((s) => new MainStore(s.GetRequiredService<Main>()));
        }

        private static void AddViewModels()
        {
            MyLogger.GetLog().LogDebug("Added a view models");
            _servicesProvider.AddTransient((s) => new RegistrationPageViewModel(s.GetRequiredService<MainStore>(), s.GetRequiredService<INavigationService>()));
            _servicesProvider.AddTransient((s) => ListPageViewModel.LoadViewModel(s.GetRequiredService<MainStore>(), s.GetRequiredService<INavigationService>()));
        }

    }
}

