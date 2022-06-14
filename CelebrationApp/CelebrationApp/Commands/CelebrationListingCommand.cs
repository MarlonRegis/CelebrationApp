using CelebrationApp.Services;
using CelebrationApp.Stores;
using CelebrationApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace CelebrationApp.Commands
{
    public class CelebrationListingCommand
    {
        private readonly MainStore _mainStore;
        private readonly ListPageViewModel _listPageViewModel;

        public CelebrationListingCommand(MainStore mainStore, ListPageViewModel listPageViewModel)
        {
            _mainStore = mainStore;
            _listPageViewModel = listPageViewModel;
        }

        public async Task LoadComponents()
        {
            try
            {
                await _mainStore.Load(); 
                if (_mainStore.CelebrationEnumerable.Any() == false)
                {
                    await ModalView.MessageDialogAsync(App.MainRoot, "Error", "Not found celebrations");
                }
                _listPageViewModel.UpdateList(_mainStore.CelebrationEnumerable);
            }
            catch
            {
                await ModalView.MessageDialogAsync(App.MainRoot, "Error", "Error");
            }
        }

        public async void OpenDetailsCelebration(CelebrationRecordViewModel celebration)
        {
                string ID = Uri.EscapeDataString($"{celebration.Id}");
                await Launcher.LaunchUriAsync(new System.Uri($"com.celebrationapp://?ID={ID}"));
        }
    }
}
