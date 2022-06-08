using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
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

        private object id;
        public object ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

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

        private DateTime celebrationDate;
        public DateTime CelebrationDate
        {
            get { return celebrationDate; }
            set => SetProperty(ref celebrationDate, value);
        }

        private string _updateRemoveVisible = "Collapsed";
        public string UpdateRemoveVisible
        {
            get { return _updateRemoveVisible; }
            set { SetProperty(ref _updateRemoveVisible, value); }
        }

        private string _saveClearVisible = "Visible";
        public string SaveClearVisible
        {
            get { return _saveClearVisible; }
            set { SetProperty(ref _saveClearVisible, value); }
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
            var newdate = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            datePicker.SelectedDate = newdate;            
            if (datePicker.SelectedDate != null)
            {
                CelebrationDate = newdate;
            }
            TextDate = CelebrationDate.ToString("MM/dd/yyyy");
        }
    
        public void Save()
        {

        }
        public void Update()
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
        

       /* protected void setComponent(ComponentViewModel e)
        {        
            SaveClearVisible = "Collapsed";
            UpdateRemoveVisible = "Visible";
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            ComponentViewModel componentViewModel = e.Parameter as ComponentViewModel;
            if (componentViewModel != null)
                setComponent(componentViewModel);
        }
       */
    }
}
