using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;

namespace CelebrationApp.ViewModels
{
    public class ListPageViewModel : ObservableObject
    {
        
        public void OpenList()
        {
            var toWPFProcess = new Process();
            toWPFProcess.StartInfo.FileName= "com.celebrationappwpf://";
            toWPFProcess.StartInfo.UseShellExecute = true;
            toWPFProcess.Start();
            //Process.Start("com.celebrationappwpf://");
        }
        public void Create()
        {
            
        }
        
        public void Refrash()
        {

        }
        public void Close()
        {
            Application.Current.Exit();
        }
    }
}
