using CelebrationCore.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationCore.ViewModels
{
    public class CelebrationRecordViewModel : ObservableObject
    {
        //public Guid Id { get; set; }

        private object id;
        public object Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private DateTime celebrationDate;
        public DateTime CelebrationDate
        {
            get { return celebrationDate; }
            set { SetProperty(ref celebrationDate, value); }
        }

        private string celebrationDateView;
        public string CelebrationDateView
        {
            get { return celebrationDateView; }
            set { SetProperty(ref celebrationDateView, value); }
        }

        private DateTime registerDate;
        public DateTime RegisterDate
        {
            get { return registerDate; }
            set { SetProperty(ref registerDate, value); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { SetProperty(ref image, value); }
        }

        public CelebrationRecordViewModel(Celebration celebration)
        {
            Id = celebration.Id;
            Name = celebration.Name;
            CelebrationDate = celebration.CelebrationDate;
            CelebrationDateView = celebration.CelebrationDate.ToString("MM/dd/yyyy");
            RegisterDate = celebration.RecordDate;
            Description = celebration.Description;
            Image = "ms-appx:///../CelebrationCore/Assets/Images/Confetti.png";
        }


    }
}
