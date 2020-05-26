using System;
using System.Collections.Generic;
using System.Text;

namespace TheREALCovidApp.Models
{
    public class CovidItemList
    {
        public List<CovidItem> CovidItems { get; set; }

        public CovidItemList()
        {
            this.CovidItems = new List<CovidItem>();
        }
    }
}
