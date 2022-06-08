using CelebrationApp.Commons;
using CelebrationApp.Services;
using CelebrationApp.Services.CelebrationCreators;
using CelebrationApp.Services.Factory;
using Microsoft.UI.Xaml;
using Repository.DbContexts;
using Repository.Repository.DbContexts;

namespace CelebrationApp
{

    public partial class App : Application
    {
        private static string CONNECTION_STRTING = $"Data Source={GlobalVariables.DataBaseString}";

        private readonly CelebrationDbContextFactory _dbContextFactory;

        public App()
        {
            this.InitializeComponent();

            _dbContextFactory = new CelebrationDbContextFactory(CONNECTION_STRTING);
            ICelebrationService celebrationService = new CelebrationService(_dbContextFactory);

        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            m_window = new MainWindow();
            m_window.Activate();

            
        }

        private Window m_window;
    }
}
