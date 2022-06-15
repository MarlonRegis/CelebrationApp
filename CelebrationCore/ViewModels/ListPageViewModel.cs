using CelebrationCore.Commands;
using CelebrationCore.Interfaces;
using CelebrationCore.Models;
using CelebrationCore.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Windows.System;

namespace CelebrationCore.ViewModels
{
    public class ListPageViewModel : ObservableObject
    {
        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationListDay;
        public IEnumerable<CelebrationRecordViewModel> CelebrationListDay => celebrationListDay;

        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationListMonth;
        public IEnumerable<CelebrationRecordViewModel> CelebrationListMonth => celebrationListMonth;
        public AsyncRelayCommand LoadCelebrationCommand { get; }
        public RelayCommand MakeCelebrationCommand { get; }
        public INavigationService _navigationService { get; }

        public ListPageViewModel(MainStore mainStore, INavigationService navigationService)
        {

            celebrationListDay = new ObservableCollection<CelebrationRecordViewModel>();
            celebrationListMonth = new ObservableCollection<CelebrationRecordViewModel>();

            ICelebrationListingCommand celebrationListingCommand = new CelebrationListingCommand(mainStore, this);
            LoadCelebrationCommand = new AsyncRelayCommand(celebrationListingCommand.LoadCelebration);
            MakeCelebrationCommand = new RelayCommand(new NavigateCommand<RegistrationPageViewModel>(navigationService).Navigate);
            _navigationService = navigationService;
        }

        public static ListPageViewModel LoadViewModel(MainStore mainStore, INavigationService navigationService)
        {
            ListPageViewModel viewModel = new ListPageViewModel(mainStore, navigationService);
            viewModel.LoadCelebrationCommand.Execute(null);

            return viewModel;
        }

        public virtual void UpdateList(IEnumerable<Celebration> list)
        {
            celebrationListDay.Clear();
            celebrationListMonth.Clear();

            foreach (Celebration item in list)
            {

                CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                celebrationListDay.Add(celebrationRecordViewModel);

                //if (item.CelebrationDate.Day == DateTime.Now.Day && item.CelebrationDate.Month == DateTime.Now.Month)
                //{
                //    CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                //    celebrationListDay.Add(celebrationRecordViewModel);
                //}
                //if (item.CelebrationDate.Month == DateTime.Now.Month)
                //{
                //    CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                //    celebrationListMonth.Add(celebrationRecordViewModel);
                //}
            }
        }

        public void OpenRegistrationPage(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is CelebrationRecordViewModel Celebration)
            {
                _navigationService.Navigate<RegistrationPageViewModel>(Celebration);
            }
        }

        public async void OpenList()
        {  
            await Launcher.LaunchUriAsync(new System.Uri("com.celebrationappwpf://"));
        }

        public void Close()
        {
            Application.Current.Exit();
        }
    }
}
