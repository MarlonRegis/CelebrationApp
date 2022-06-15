using CelebrationCore.Helpers;
using CelebrationCore.Interfaces;
using CelebrationCore.Models;
using CelebrationCore.Stores;
using CelebrationCore.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CelebrationCore.Commands
{
    public class MakeCelebrationCommand : IMakeCelebrationCommand
    {
        private readonly MainStore _mainStore;
        private readonly INavigationService _navigationService;
        private readonly RegistrationPageViewModel _registrationPageViewModel;


        public MakeCelebrationCommand(RegistrationPageViewModel registrationPageViewModel,
                                      MainStore mainStore,
                                      INavigationService navigationService)
        {
            _mainStore = mainStore;
            _navigationService = navigationService;
            _registrationPageViewModel = registrationPageViewModel;

            _registrationPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(_registrationPageViewModel.Name)
                && !string.IsNullOrEmpty(_registrationPageViewModel.CelebrationDate.ToString())
                && CanExecuteCommand();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e != null)
            {
                if (e.PropertyName == nameof(_registrationPageViewModel.Name) ||
                e.PropertyName == nameof(_registrationPageViewModel.CelebrationDate))
                {
                    _registrationPageViewModel.SubmitCommand.NotifyCanExecuteChanged();
                }
            }

        }

        public async Task SaveCelebration()
        {
            Celebration celebration = new Celebration(
                    _registrationPageViewModel.Name,
                    _registrationPageViewModel.Description,
                    _registrationPageViewModel.RecordDate,
                    _registrationPageViewModel.CelebrationDate
                );

            try
            {
                await _mainStore.SaveCelebration(celebration);

                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Sucessfully", "Created a Celebration");

                _navigationService.Navigate<ListPageViewModel>();
            }
            catch (Exception e)
            {
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Error", "Error when creating celebration: " + e.Message.ToString());
            }
        }

        public virtual bool CanExecuteCommand()
        {
            return true;
        }

        public async Task RemoveCelebration()
        {
            try
            {
                await _mainStore.RemoveCelebration(_registrationPageViewModel.ID);
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Sucessfully", "Deleted a Celebration");

                _navigationService.Navigate<ListPageViewModel>();

            }
            catch (Exception)
            {
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Error", "Unable to delete record");
            }
        }

        public async Task UpdateCelebration()
        {
            try
            {
                Celebration celebration = new Celebration(
                    _registrationPageViewModel.Name,
                    _registrationPageViewModel.Description,
                    _registrationPageViewModel.RecordDate,
                    _registrationPageViewModel.CelebrationDate,
                    _registrationPageViewModel.ID
                );

                await _mainStore.UpdateCelebration(celebration);
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Sucessfully", "Updated a Celebration");

                _navigationService.Navigate<ListPageViewModel>();

            }
            catch (Exception)
            {
                await ModalView.MessageDialogAsync(_mainStore.MainRoot, "Error", "It's not possible to update celebration");
            }
        }
    }
}
