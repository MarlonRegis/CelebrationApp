using CelebrationCore.Helpers;
using CelebrationCore.Interfaces;
using CelebrationCore.Stores;
using CelebrationCore.ViewModels;
using NLog;
using Windows.System;

namespace CelebrationCore.Commands
{
    public class CelebrationListingCommand : ICelebrationListingCommand
    {
        private readonly MainStore _mainStore;
        private readonly ListPageViewModel _listPageViewModel;
        Logger _logger;

        public CelebrationListingCommand(MainStore mainStore, ListPageViewModel listPageViewModel)
        {
            _mainStore = mainStore;
            _listPageViewModel = listPageViewModel;
            _logger = NLog.LogManager.GetLogger("logfile");
        }

        public async Task LoadCelebration()
        {
            try
            {
                await _mainStore.Load();
                if (_mainStore.CelebrationEnumerable.Any() == false)
                {
                    await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Error", "Not found celebrations");
                }
                _listPageViewModel.UpdateList(_mainStore.CelebrationEnumerable);
            }
            catch(Exception e)
            {
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Error", "Error is: " + e.Message);
            }
        }

        public async void OpenDetailsCelebration(CelebrationRecordViewModel celebration)
        {
            if (celebration != null)
            {
                string ID = Uri.EscapeDataString($"{celebration.Id}");
                await Launcher.LaunchUriAsync(new System.Uri($"com.celebrationapp://?ID={ID}"));
            }
        }
    }
}
