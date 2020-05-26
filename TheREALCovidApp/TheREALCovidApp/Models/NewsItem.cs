using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TheREALCovidApp.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class NewsItem
    {
        [JsonProperty(PropertyName = "source")]
        public object Source { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "urlToImage")]
        public string ImageuRL { get; set; }
    }
}
