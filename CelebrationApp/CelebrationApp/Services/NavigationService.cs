using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.Services
{
    public class NavigationService
    {

        private static readonly Dictionary<Type, Type> _viewMapping = new Dictionary<Type, Type>();

        private Frame _frame;
        public Frame Frame
        {
            get { return _frame; }
        }

        public void SetFrame(Frame frame) => _frame = frame;

        public void Navigate<TViewModel>(object args)
        {
            if (_viewMapping.ContainsKey(typeof(TViewModel))){
                Frame.Navigate(_viewMapping[typeof(TViewModel)], args);
            }
            else
            {
                throw new Exception();
            }
        }

        public void GoBack()
        {
            Frame.GoBack();
        }

        public bool CanGoBack()
        {
            return Frame.CanGoBack;
        }

        public void Configure(Type viewModel, Type view)
        {

            if (_viewMapping.ContainsKey(viewModel))
            {
                throw new Exception();
            }
            _viewMapping[viewModel] = view;
        }
    }
}
