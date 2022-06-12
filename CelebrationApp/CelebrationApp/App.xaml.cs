using CelebrationApp.Services;
using CelebrationApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

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

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            m_window = new MainWindow();

            Frame rootFrame = CreateRootFrame();

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(ListPage), args.Arguments);
            }

            m_window.Activate();
            MainRoot = m_window.Content as FrameworkElement;


        }

        private Frame CreateRootFrame()
        {
            Frame rootFrame = m_window.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                m_window.Content = rootFrame;
                Ioc.Default.GetRequiredService<NavigationService>().SetFrame(rootFrame);
            }

            return rootFrame;
        }

        private Window m_window;
    }
}
