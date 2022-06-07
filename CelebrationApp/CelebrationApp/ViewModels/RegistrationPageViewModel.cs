using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.ViewModels
{
    public class RegistrationPageViewModel : ObservableObject
    {
        public DatePicker datePicker { get; set; }

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

        private string textDate;
        public string TextDate
        {
            get { return textDate; }
            set => SetProperty(ref textDate, value);
        }

        private DateTime recordDate;
        public DateTime RecordDate
        {
            get { return recordDate; }
            set => SetProperty(ref recordDate, value);
        }

        private DateTime celebrationDate = DateTime.Now;
        public DateTime CelebrationDate
        {
            get { return celebrationDate; }
            set => SetProperty(ref celebrationDate, value);
        }

        public RegistrationPageViewModel()
        {
            DateControl();
        }

        private void DateControl()
        {
            RecordDate = DateTime.Now;
            datePicker = new DatePicker();
            datePicker.MinYear = DateTimeOffset.Now.AddYears(-100);
            datePicker.MaxYear = DateTimeOffset.Now;
            datePicker.SelectedDateChanged += DateChanged;
        }

        public void DateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            if (datePicker.SelectedDate != null)
            {
                CelebrationDate = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
            TextDate = CelebrationDate.ToString("dd/MM/yyyy");
        }


        public void Save()
        {

        }
        public void Clean()
        {
            Name = string.Empty;
            Description = string.Empty;
            RecordDate = DateTime.Now;
            TextDate = string.Empty;
            datePicker.SelectedDate = null;
            CelebrationDate = DateTime.Now;
        }
        public void Remove()
        {

        }

    }
}
