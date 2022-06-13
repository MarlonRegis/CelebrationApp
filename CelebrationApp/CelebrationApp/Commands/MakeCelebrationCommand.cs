using CelebrationApp.Models;
using CelebrationApp.Services;
using CelebrationApp.Stores;
using CelebrationApp.ViewModels;
using System;
using System.Threading.Tasks;

namespace CelebrationApp.Commands
{
    public class MakeCelebrationCommand
    {
        private readonly MainStore _mainStore;
        private readonly NavigationService _navigationService;
        private readonly RegistrationPageViewModel _registrationPageViewModel;


        public MakeCelebrationCommand(RegistrationPageViewModel registrationPageViewModel, 
                                      MainStore mainStore,
                                      NavigationService navigationService)
        {
            _mainStore = mainStore;
            _navigationService = navigationService;
            _registrationPageViewModel = registrationPageViewModel;



            _registrationPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(_registrationPageViewModel.Name)
                && !string.IsNullOrEmpty( _registrationPageViewModel.CelebrationDate.ToString())
                && CanExecuteCommand();
        }

        private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_registrationPageViewModel.Name) ||
                e.PropertyName == nameof(_registrationPageViewModel.CelebrationDate))
            {
                _registrationPageViewModel.SubmitCommand.NotifyCanExecuteChanged();
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

                await ModalView.MessageDialogAsync(App.MainRoot, "Sucessfully", "Created a Celebration");

                _navigationService.Navigate<ListPageViewModel>();
            }
            catch (Exception e)
            {
                await ModalView.MessageDialogAsync(App.MainRoot, "Error", "Error when creating celebration: " + e.Message.ToString());
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
                await ModalView.MessageDialogAsync(App.MainRoot, "Sucessfully", "Deleted a Celebration");

                _navigationService.Navigate<ListPageViewModel>();

            }
            catch (Exception)
            {
                await ModalView.MessageDialogAsync(App.MainRoot, "Error", "Unable to delete record");
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
                await ModalView.MessageDialogAsync(App.MainRoot, "Sucessfully", "Updated a Celebration");

                _navigationService.Navigate<ListPageViewModel>();

            }
            catch (Exception)
            {
                await ModalView.MessageDialogAsync(App.MainRoot, "Error", "It's not possible to update celebration");
            }
        }
    }
}
