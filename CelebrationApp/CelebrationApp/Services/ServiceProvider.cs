﻿using CelebrationApp.Commons;
using CelebrationApp.Models;
using CelebrationApp.Stores;
using CelebrationApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Repository;
using Repository.DbContexts;
using Repository.Repository.DbContexts;
using System;

namespace CelebrationApp.Services
{
    public static class CelebrationServiceProvider
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
            CelebrationDbContext context = _dbContextFactory.CreateDbContext();

            _servicesProvider.AddSingleton(new CelebrationRepository(context));
        }

        private static void AddServices()
        {
            _servicesProvider.AddSingleton((s) => new CelebrationService(s.GetRequiredService<CelebrationRepository>()));
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
           
            _servicesProvider.AddTransient((s) => new RegistrationPageViewModel(s.GetRequiredService<MainStore>()));
        }

    }
}