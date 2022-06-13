using CelebrationApp.Commands;
using CelebrationApp.Models;
using CelebrationApp.Services;
using CelebrationApp.Stores;
using CelebrationApp.ViewModels;
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
        private readonly ObservableCollection<CelebrationRecordViewModel> celebrationList;
        public IEnumerable<CelebrationRecordViewModel> CelebrationList => celebrationList;

        public AsyncRelayCommand LoadCelebrationCommand { get; }        


        public CelebrationListPageViewModel(MainStore mainStore, NavigationService navigationService) : base(mainStore, navigationService)
        {
            celebrationList = new ObservableCollection<CelebrationRecordViewModel>();
            CelebrationListingCommand celebrationListingCommand = new CelebrationListingCommand(mainStore, this);
            LoadCelebrationCommand = new AsyncRelayCommand(celebrationListingCommand.LoadComponents);
        }

        public static CelebrationListPageViewModel LoadViewModel(MainStore mainStore, NavigationService navigationService)
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
