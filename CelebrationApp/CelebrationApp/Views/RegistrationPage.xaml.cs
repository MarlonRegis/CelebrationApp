using CelebrationCore.Services;
using CelebrationCore.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace CelebrationApp.Views
{
    public sealed partial class RegistrationPage : Page
    {
        public RegistrationPageViewModel ViewModel => (RegistrationPageViewModel)this.DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.OnNavigatedTo(e);


        }
        public RegistrationPage()
        {
            this.InitializeComponent();
            DataContext = Ioc.Default.GetRequiredService<RegistrationPageViewModel>();
        }

    }
}
