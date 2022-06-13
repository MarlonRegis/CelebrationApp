using CelebrationApp.Commands;
using CelebrationApp.Models;
using CelebrationApp.Services;
using CelebrationApp.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;

namespace CelebrationApp.ViewModels
{
    public class ListPageViewModel : ObservableObject
    {
        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationListDay;
        public IEnumerable<CelebrationRecordViewModel> CelebrationListDay => celebrationListDay;

        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationListMonth;
        public IEnumerable<CelebrationRecordViewModel> CelebrationListMonth => celebrationListMonth;

        public AsyncRelayCommand LoadCelebrationCommand { get; }
        public RelayCommand MakeCelebrationCommand { get; }
        public NavigationService _navigationService { get; }

        public ListPageViewModel(MainStore mainStore, NavigationService navigationService)
        {

            celebrationListDay = new ObservableCollection<CelebrationRecordViewModel>();
            celebrationListMonth = new ObservableCollection<CelebrationRecordViewModel>();

            CelebrationListingCommand celebrationListingCommand = new CelebrationListingCommand(mainStore, this);
            LoadCelebrationCommand = new AsyncRelayCommand(celebrationListingCommand.LoadComponents);
            MakeCelebrationCommand = new RelayCommand(new NavigateCommand<RegistrationPageViewModel>(navigationService).Navigate);
            _navigationService = navigationService;
        }

        public static ListPageViewModel LoadViewModel(MainStore mainStore, NavigationService navigationService)
        {
            ListPageViewModel viewModel = new ListPageViewModel(mainStore, navigationService);
            viewModel.LoadCelebrationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateList(IEnumerable<Celebration> list)
        {
            celebrationListDay.Clear();
            celebrationListMonth.Clear();

            foreach (Celebration item in list)
            {                
                if (item.CelebrationDate.Day == DateTime.Now.Day)
                {
                    CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                    celebrationListDay.Add(celebrationRecordViewModel);
                }
                if (item.CelebrationDate.Month == DateTime.Now.Month)
                {
                    CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                    celebrationListMonth.Add(celebrationRecordViewModel);
                }

            }

        }

        public void OpenRegistrationPage(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is CelebrationRecordViewModel Celebration)
            {
                _navigationService.Navigate<RegistrationPageViewModel>(Celebration);
            }

        }

        public void OpenList()
        {
            var toWPFProcess = new Process();
            toWPFProcess.StartInfo.FileName = "com.celebrationappwpf://";
            toWPFProcess.StartInfo.UseShellExecute = true;
            toWPFProcess.Start();
        }
        public void Close()
        {
            Application.Current.Exit();
        }
    }
}
