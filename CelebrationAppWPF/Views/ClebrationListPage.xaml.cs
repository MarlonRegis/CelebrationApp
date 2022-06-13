using CelebrationApp.Stores;
using CelebrationAppWPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CelebrationAppWPF.Views
{

    public partial class ClebrationListPage : Page
    {
        public CelebrationListPageViewModel ViewModel => (CelebrationListPageViewModel)this.DataContext;
        
        public ClebrationListPage()
        {
            InitializeComponent();          
            CelebrationListPageViewModel ViewModel = Ioc.Default.GetRequiredService<CelebrationListPageViewModel>();
            this.DataContext = ViewModel;
            
        }

     
    }
}
