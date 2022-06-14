using CelebrationCore.Commands;
using CelebrationCore.Services;
using CelebrationCore.Stores;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;

namespace CelebrationCore.ViewModels
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

        private readonly MainStore _mainStore;
        private readonly NavigationService _navigationService;
        public AsyncRelayCommand SubmitCommand { get; }
        public AsyncRelayCommand UpdateCommand { get; }
        public AsyncRelayCommand RemoveCelebration { get; }
        public RelayCommand CancelCommand { get; }

        public RegistrationPageViewModel(MainStore mainStore, NavigationService navigationService)
        {
            DateControl();
            MakeCelebrationCommand makeCelebrationCommand = new MakeCelebrationCommand(this, mainStore, navigationService);

            SubmitCommand = new AsyncRelayCommand(makeCelebrationCommand.SaveCelebration, makeCelebrationCommand.CanExecute);
            UpdateCommand = new AsyncRelayCommand(makeCelebrationCommand.UpdateCelebration, makeCelebrationCommand.CanExecute);
            RemoveCelebration = new AsyncRelayCommand(makeCelebrationCommand.RemoveCelebration, makeCelebrationCommand.CanExecute);
            CancelCommand = new RelayCommand(new NavigateCommand<ListPageViewModel>(navigationService).Navigate);
            _mainStore = mainStore;
            _navigationService = navigationService;
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
            if (datePicker.SelectedDate == null && args.NewDate != null)
            {
                CelebrationDate = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
        }

        public void Clean()
        {
            Name = string.Empty;
            Description = string.Empty;
            RecordDate = DateTime.Now;
            datePicker.SelectedDate = new DateTime(2022,01,01);
            CelebrationDate = DateTime.Now;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
            {
                CelebrationRecordViewModel celebrationRecordViewModel = e.Parameter as CelebrationRecordViewModel;
                if (celebrationRecordViewModel != null)
                    setCelebration(celebrationRecordViewModel);
            }
            
        }

        protected void setCelebration(CelebrationRecordViewModel e)
        {
            ID = e.Id;
            Name = e.Name;
            Description = e.Description;
            CelebrationDate = e.CelebrationDate;
            datePicker.SelectedDate = e.CelebrationDate;
            RecordDate = e.RegisterDate;

            SaveClearVisible = "Collapsed";
            UpdateRemoveVisible = "Visible";
        }
    }
    
}

