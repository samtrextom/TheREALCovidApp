using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheREALCovidApp.Views
{

    [DesignTimeVisible(false)]
    public partial class News : ContentPage
    {
        public News()
        {
            InitializeComponent();
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.NewsManager.GetTasksAsync();
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NewsItem newsItem = (NewsItem)e.SelectedItem;
            var uri = new Uri(string.Format(newsItem.Url, string.Empty));
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);

        }
    }
}