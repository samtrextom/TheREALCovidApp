using Microcharts;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;
using TheREALCovidApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheREALCovidApp.Views
{
    [DesignTimeVisible(false)]
    public partial class Dashboard : ContentPage
    {
        List<CovidItemList> lists = new List<CovidItemList>();
        public Dashboard()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            lists = await App.CovidManager.GetTasksAsync();

            usListView.ItemsSource = lists[0].CovidItems;
            stateListView.ItemsSource = lists[1].CovidItems;
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new Modal()
                {
                    BindingContext = e.SelectedItem as CovidItem
                });
            }
        }
    }
}