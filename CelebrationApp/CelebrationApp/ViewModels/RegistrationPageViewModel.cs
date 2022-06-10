using CelebrationApp.Commands;
using CelebrationApp.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;

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
            set
            {
                SetProperty(ref name, value);
                this.SubmitCommand.NotifyCanExecuteChanged();
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set => SetProperty(ref description, value);
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
            set
            {
                SetProperty(ref celebrationDate, value);
                this.SubmitCommand.NotifyCanExecuteChanged();
            }
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



        public AsyncRelayCommand SubmitCommand { get; }

        public RegistrationPageViewModel(MainStore mainStore)
        {
            DateControl();
            MakeCelebrationCommand makeCelebrationCommand = new MakeCelebrationCommand(this, mainStore);

            SubmitCommand = new AsyncRelayCommand(makeCelebrationCommand.SaveCelebration, makeCelebrationCommand.CanExecute);
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
        }

        public void Clean()
        {
            Name = string.Empty;
            Description = string.Empty;
            RecordDate = DateTime.Now;
            datePicker.SelectedDate = null;
            CelebrationDate = DateTime.Now;
        }
        public void Remove()
        {

        }

        //protected void setComponent(ComponentViewModel e)
        //{
        //    SaveClearVisible = "Collapsed";
        //    UpdateRemoveVisible = "Visible";
        //}
        //public void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    ComponentViewModel componentViewModel = e.Parameter as ComponentViewModel;
        //    if (componentViewModel != null)
        //        setComponent(componentViewModel);
        //}
    }
}
