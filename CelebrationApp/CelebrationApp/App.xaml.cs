using CelebrationCore.Services;
using CelebrationCore.ViewModels;
using CelebrationApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppLifecycle;
using System;
using System.Threading.Tasks;
using System.Web;
using Windows.ApplicationModel.Activation;
using CelebrationCore;
using CelebrationCore.Models;
using CelebrationCore.Stores;

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

        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            AppActivationArguments argsActivated =
                Microsoft.Windows.AppLifecycle.AppInstance.GetCurrent().GetActivatedEventArgs();

            ExtendedActivationKind kind = argsActivated.Kind;

            Microsoft.Windows.AppLifecycle.AppInstance keyInstance =
                Microsoft.Windows.AppLifecycle.AppInstance.FindOrRegisterForKey("CelebrationAppRegister");

            m_window = new MainWindow();

            Frame rootFrame = CreateRootFrame();

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(ListPage), args.Arguments);
            }

            if (kind == ExtendedActivationKind.Protocol)
                await NavigateToComponent(argsActivated, keyInstance);


            m_window.Activate();

            MainRoot = m_window.Content as FrameworkElement;
            MainStore mainStore = Ioc.Default.GetRequiredService<MainStore>();
            mainStore.MainRoot = MainRoot;

        }

        private static async Task NavigateToComponent(AppActivationArguments argsActivated, Microsoft.Windows.AppLifecycle.AppInstance keyInstance)
        {
            await keyInstance.RedirectActivationToAsync(argsActivated);

            object celebrationId = null;

            if (argsActivated.Data is IProtocolActivatedEventArgs protocolArgs)
            {
                celebrationId = HttpUtility.ParseQueryString(protocolArgs.Uri.Query).Get("ID");
            }
            celebrationId = celebrationId.ToString().Replace("\"", "");

            var celebration = Ioc.Default.GetRequiredService<CelebrationService>().GetCelebrationByID(Guid.Parse((string)celebrationId));
            var celebrationRecordViewModel = new CelebrationRecordViewModel(celebration);

            Ioc.Default.GetRequiredService<NavigationService>().Navigate<RegistrationPageViewModel>(celebrationRecordViewModel);
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
