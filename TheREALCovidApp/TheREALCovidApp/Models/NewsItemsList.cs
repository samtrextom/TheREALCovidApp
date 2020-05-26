using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheREALCovidApp.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class NewsItemsList
    {
        [JsonProperty(PropertyName = "articles")]
        public List<NewsItem> Articles { get; set; }
    }
}
