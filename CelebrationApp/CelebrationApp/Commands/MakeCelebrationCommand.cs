using CelebrationApp.Models;
using CelebrationApp.Services;
using CelebrationApp.Stores;
using CelebrationApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace CelebrationApp.Commands
{
    public class MakeCelebrationCommand
    {
        private readonly MainStore _mainStore;
        private readonly RegistrationPageViewModel _registrationPageViewModel;


        public MakeCelebrationCommand(RegistrationPageViewModel registrationPageViewModel, MainStore mainStore)
        {
            _mainStore = mainStore;
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

    }
}
