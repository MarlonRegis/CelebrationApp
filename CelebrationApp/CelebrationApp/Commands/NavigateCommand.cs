using CelebrationApp.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Commands
{
    public class NavigateCommand<TViewModel> where TViewModel : ObservableObject
    {
        private readonly NavigationService _navigationService;
        private readonly object _args;

        public NavigateCommand(NavigationService navigationService, object args = null)
        {
            _navigationService = navigationService;
            _args = args;
        }

        public void Navigate()
        {
            _navigationService.Navigate<TViewModel>(_args);
        }

        public void GoBack()
        {
            if (_navigationService.CanGoBack())
            {
                _navigationService.GoBack();
            }
        }
    }
}
