using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.ViewModels
{
    public class RegistrationPageViewModel : ObservableObject
    {
        
        private string name;
        public string Name
        {
            get { return name; }
            set => SetProperty(ref name, value);
        }

        private string description;
        public string Description
        {
            get { return description; }
            set => SetProperty(ref description, value);
        }

        private DateTime recordDate = DateTime.Now;
        public DateTime RecordDate
        {
            get { return recordDate; }
            set => SetProperty(ref recordDate, value);
        }

        private DateTime celebrationDateame = DateTime.Now;
        public DateTime CelebrationDate
        {
            get { return celebrationDateame; }
            set => SetProperty(ref celebrationDateame, value);
        }


        public void Save() 
        {

        }
        public void Clean()
        {
            Name = null;
            Description = null;
            RecordDate = DateTime.Now;
            CelebrationDate= DateTime.Now;
        }
        public void Remove()
        {

        }

    }
}
