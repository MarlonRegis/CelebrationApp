using CelebrationAppWPF.ViewModels;
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
    /// <summary>
    /// Interaction logic for ClebrationListPage.xaml
    /// </summary>
    public partial class ClebrationListPage : Page
    {
        public CelebrationListPageViewModel ViewModel => (CelebrationListPageViewModel)this.DataContext;
        public ClebrationListPage()
        {
            InitializeComponent();
            this.DataContext = new CelebrationListPageViewModel();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CLose();
        }
    }
}
