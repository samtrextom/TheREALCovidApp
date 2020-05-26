using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{
    public class CovidManager
    {
        IRestService restService;
        public CovidManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<CovidItemList>> GetTasksAsync()
        {
            return restService.CovidRefreshDataAsync();
        }
    }
}
