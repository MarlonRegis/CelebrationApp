using CelebrationApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace CelebrationApp
{

    public partial class App : Application
    {
        public static FrameworkElement MainRoot { get; private set; }

        public App()
        {
            this.InitializeComponent();

            CelebrationServiceProvider.CreateDefaultServices();
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            m_window = new MainWindow();
            m_window.Activate();
            MainRoot = m_window.Content as FrameworkElement;
        }

        private Window m_window;
    }
}
