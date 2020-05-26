using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheREALCovidApp.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CovidItem
    {
        public string Text { get; set; }
        public string Valve { get; set; }
        public Microcharts.Chart Chart { get; set; }
    }
}
