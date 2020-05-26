using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{
    public class NewsManager
    {
        IRestService restService;
        public NewsManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<NewsItem>> GetTasksAsync()
        {
            return restService.NewsRefreshDataAsync();
        }
    }
}
