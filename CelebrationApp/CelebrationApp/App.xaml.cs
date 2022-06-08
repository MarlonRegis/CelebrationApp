using Microsoft.UI.Xaml;
using Repository.DbContexts;



namespace CelebrationApp
{

    public partial class App : Application
    {

        public App()
        {
            this.InitializeComponent();
        }

        protected async override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            //using (var db = new CelebrationDbContext())
            //{
            //    await db.Database.EnsureCreatedAsync();
            //}


            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
