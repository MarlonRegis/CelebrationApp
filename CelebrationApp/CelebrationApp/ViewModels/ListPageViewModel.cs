using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace CelebrationApp.ViewModels
{
    public class ListPageViewModel
    {

        public void Close()
        {
            CoreApplication.GetCurrentView().CoreWindow.Close();
        }
    }
}
