using CelebrationCore.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationCore.Commands
{
    public class NavigateCommand<TViewModel> where TViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly object _args;

        public NavigateCommand(INavigationService navigationService, object args = null)
        {
            if (navigationService != null)
            {
                _navigationService = navigationService;
            }
            if (args != null)
            {
                _args = args;
            }
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
