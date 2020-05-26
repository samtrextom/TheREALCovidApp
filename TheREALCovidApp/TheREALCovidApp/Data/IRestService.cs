using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{
    public interface IRestService
    {
        Task<List<NewsItem>> NewsRefreshDataAsync();
        Task<List<CovidItemList>> CovidRefreshDataAsync();

        Task SaveNewsItemAsync(NewsItem item, bool isNewItem);

        Task DeleteNewsItemAsync(string id);
    }
}
