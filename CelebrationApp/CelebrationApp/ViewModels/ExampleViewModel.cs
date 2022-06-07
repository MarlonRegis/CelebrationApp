using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelebrationApp.ViewModels
{
    public class ExampleViewModel: ObservableObject
    {
        public DatePicker arrivalDatePicker { get; set; }

        private DateTime dateOne;
        public DateTime DateOne
        {
            get { 
                return dateOne;
            }
            set
            {
                SetProperty(ref dateOne, value);
            }
        }

        public ExampleViewModel()
        {
            arrivalDatePicker = new DatePicker();
            arrivalDatePicker.MinYear = DateTimeOffset.Now;
            arrivalDatePicker.MaxYear = DateTimeOffset.Now.AddYears(5);
            arrivalDatePicker.SelectedDateChanged += TestdateChanged;
            arrivalDatePicker.SelectedDate = DateTimeOffset.Now;


        }

        public void TestdateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {

            if(DateOne != null)
            {
                DateOne = new DateTime(args.NewDate.Value.Year, args.NewDate.Value.Month, args.NewDate.Value.Day);
            }
        }
    }
}
