using CelebrationCore.Commands;
using CelebrationCore.Models;
using CelebrationCore.Services;
using CelebrationCore.Stores;
using CelebrationCore.ViewModels;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationAppWPF.ViewModels
{
    public class CelebrationListPageViewModel : ListPageViewModel
    {
        private CelebrationRecordViewModel _selectedCelebration;
        public CelebrationRecordViewModel SelectedCelebration
        {
            get { return _selectedCelebration; }
            set { SetProperty(ref _selectedCelebration, value); }
        }

        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationList;
        public IEnumerable<CelebrationRecordViewModel> CelebrationList => celebrationList;

        public AsyncRelayCommand LoadCelebrationCommandWpf { get; }      
        
        public RelayCommand<CelebrationRecordViewModel> OpenCelebrationCommand { get; }        


        public CelebrationListPageViewModel(MainStore mainStore, NavigationService navigationService) : base(mainStore, navigationService)
        {
            celebrationList = new ObservableCollection<CelebrationRecordViewModel>();
            CelebrationListingCommand celebrationListingCommand = new CelebrationListingCommand(mainStore, this);

            OpenCelebrationCommand = new RelayCommand<CelebrationRecordViewModel>(celebrationListingCommand.OpenDetailsCelebration);
            LoadCelebrationCommandWpf = new AsyncRelayCommand(celebrationListingCommand.LoadCelebration);
        }

        public static  CelebrationListPageViewModel LoadViewModelWpf(MainStore mainStore, NavigationService navigationService)
        {
            CelebrationListPageViewModel viewModel = new CelebrationListPageViewModel(mainStore, navigationService);
            viewModel.LoadCelebrationCommand.Execute(null);

            return viewModel;
        }
        public override void UpdateList(IEnumerable<Celebration> list)
        {
            celebrationList.Clear();
           
            foreach (Celebration item in list)
            {               
               CelebrationRecordViewModel celebrationRecordViewModel = new CelebrationRecordViewModel(item);
                celebrationList.Add(celebrationRecordViewModel);        
            }
        }
    }
}
