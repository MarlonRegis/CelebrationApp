using CelebrationApp.ViewModels;
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
        public RegistrationPage()
        {
            this.InitializeComponent();
            this.DataContext = new RegistrationPageViewModel();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Save();
        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clean();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Remove();
        }
    }
}
