using CelebrationAppWPF.Services;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace CelebrationAppWPF
{
    public partial class App : Application
    {
        private Mutex _mutex;


        public App()
        {
            ServiceProvider.CreateDefaultServices();
        }

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    //CreateRootFrame();

        //    base.OnStartup(e);
        //}


        protected override void OnActivated(EventArgs e)
        {
            _mutex = new Mutex(true, "CelebrationAppWPF", out bool IsFirstWindow);

            if (!IsFirstWindow)
            {
                Process currentApp = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(currentApp.ProcessName))
                {
                    if (process.Id != currentApp.Id)
                    {
                        process.Kill();
                        break;
                    }
                }
            }

            base.OnActivated(e);
        }

        //private void CreateRootFrame()
        //{
        //    MainWindow = new MainWindow()
        //    {
        //        DataContext = Ioc.Default.GetRequiredService<CelebrationListPageViewModel>()
        //    };
        //    MainWindow.Show();
        //}
    }
}
