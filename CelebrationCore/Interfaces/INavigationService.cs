using Microsoft.UI.Xaml.Controls;

namespace CelebrationCore.Interfaces
{
    public interface INavigationService
    {
        Frame Frame { get; }

        bool CanGoBack();
        void Configure(Type viewModel, Type view);
        void GoBack();
        void Navigate<TViewModel>(object args = null);
        void SetFrame(Frame frame);
    }
}