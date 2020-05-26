using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;
using Xamarin.Forms;

namespace TheREALCovidApp.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        DateTime dateTime;
        public CovidItem covidItem { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public DashboardViewModel()
        {
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => { this.DateTime = DateTime.Now; return true; });
        }

        public DateTime DateTime
        {
            set
            {
                if(dateTime != value) { dateTime = value; if(PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("DateTime")); } }
            }
            get { return dateTime; }
        }
    }
}
