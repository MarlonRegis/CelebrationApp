using CelebrationAppWPF.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Windows.Controls;

namespace CelebrationAppWPF.Views
{

    public partial class CelebrationListPage : Page
    {
        public CelebrationListPageViewModel ViewModel => (CelebrationListPageViewModel)this.DataContext;
        
        public CelebrationListPage()
        {
            InitializeComponent();          
            CelebrationListPageViewModel ViewModel = Ioc.Default.GetRequiredService<CelebrationListPageViewModel>();
            this.DataContext = ViewModel;
            
        }

     
    }
}
