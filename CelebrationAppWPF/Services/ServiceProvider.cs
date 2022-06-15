using CelebrationCore.Commons;
using CelebrationCore.Models;
using CelebrationCore.Services;
using CelebrationCore.Stores;
using CelebrationAppWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Repository;
using Repository.DbContexts;
using Repository.Repository.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace CelebrationAppWPF.Services
{
    public static class ServiceProvider
    {
        private static CelebrationDbContextFactory _dbContextFactory;
        private static string CONNECTION_STRTING = $"Data Source={GlobalVariables.DataBaseString}";
        private static ServiceCollection _servicesProvider = new ServiceCollection();


        public static void CreateDefaultServices()
        {
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
            CelebrationDbContext context = _dbContextFactory?.CreateDbContext();

            _servicesProvider.AddSingleton(new CelebrationRepository(context));
        }

        private static void AddServices()
        {
            _servicesProvider.AddSingleton((s) => new CelebrationService(s.GetRequiredService<CelebrationRepository>()));

        }
        private static void AddModels()
        {
            _servicesProvider.AddTransient<CelebrationBook>();
            _servicesProvider.AddSingleton((s) => new Main("CelebrationAppWPF", s.GetRequiredService<CelebrationBook>()));
        }


        private static void AddStores()
        {
            _servicesProvider.AddSingleton((s) => new MainStore(s.GetRequiredService<Main>()));
        }

        private static void AddViewModels()
        {

            _servicesProvider.AddSingleton((s) =>  CelebrationListPageViewModel.LoadViewModelWpf(s.GetRequiredService<MainStore>(), null));
        }

    }
}
