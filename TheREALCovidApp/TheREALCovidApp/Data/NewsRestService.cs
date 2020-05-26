using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{

    public class NewsRestService : IRestService
    {
        HttpClient _client;

        public List<NewsItem> Items { get; private set; }

        public NewsRestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<NewsItem>> NewsRefreshDataAsync()
        {
            List<NewsItem> Items = new List<NewsItem>();

            try
            {
                var uri = new Uri(string.Format(Constants.NewsUrl, string.Empty));
                var response = await _client.GetAsync(uri);
                //Debug.WriteLine("XXXX: " + response.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //Debug.WriteLine(content);
                    NewsItemsList newsItems = JsonConvert.DeserializeObject<NewsItemsList>(content);
                    //Debug.WriteLine(newsItems.Articles[0].Title);
                    foreach(var newsItem in newsItems.Articles)
                    {
                        Items.Add(newsItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public Task SaveNewsItemAsync(NewsItem item, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CovidItemList>> CovidRefreshDataAsync() { throw new NotImplementedException(); }
    }
}
