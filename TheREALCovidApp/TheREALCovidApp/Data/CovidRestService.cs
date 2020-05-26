using Microcharts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TheREALCovidApp.Models;

namespace TheREALCovidApp.Data
{
    public class CovidRestService : IRestService
    {
        HttpClient _client;

        public List<CovidItem> Items { get; private set; }

        public CovidRestService()
        {
            _client = new HttpClient();
        }

        public async Task<List<CovidItemList>> CovidRefreshDataAsync()
        {
            CovidItemList UsList = new CovidItemList();
            CovidItemList StateList = new CovidItemList();
            for (int x = 0; x < 2; x++)
            {
                string BaseUrl = "";
                string DateUrl = "";
                if (x == 0)
                {
                    BaseUrl = Constants.CovidUsUrl;
                    DateUrl = Constants.CovidUsByDateUrl;
                }
                else
                {
                    BaseUrl = Constants.CovidStateUrl;
                    DateUrl = Constants.CovidStateByDateUrl;
                }
                for (int i = 0; i < 4; i++)
                {
                    CovidItem covidItem = new CovidItem();
                    DateTime currentDate = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
                    List<Microcharts.Entry> entries = new List<Microcharts.Entry>();

                    try
                    {
                        var uri = new Uri(string.Format(BaseUrl, string.Empty));
                        var response = await _client.GetAsync(uri);
                        //Debug.WriteLine("XX52: " + response.ToString());
                        if (response.IsSuccessStatusCode)
                        {
                            var content = await response.Content.ReadAsStringAsync();
                            Debug.WriteLine(content.ToString()+"58");

                            var newArry = content.Split(',');
                            Debug.WriteLine(newArry[0]+"61");
                            switch (i)
                            {
                                case 0:
                                    {
                                        if (x == 0) { covidItem.Valve = newArry[0].Split(':')[1]; }
                                        else { covidItem.Valve = newArry[1].Split(':')[1]; }
                                        covidItem.Text = "Positive Cases: ";
                                        break;
                                    }
                                case 1:
                                    {
                                        if (x == 0)
                                        {
                                            covidItem.Valve = newArry[1].Split(':')[1];
                                        }
                                        else { covidItem.Valve = newArry[11].Split(':')[1]; }
                                        covidItem.Text = "Negative Cases: ";
                                        break;
                                    }
                                case 2:
                                    {
                                        if (x == 0)
                                        {
                                            covidItem.Valve = newArry[9].Split(':')[1];
                                        }
                                        else { covidItem.Valve = newArry[19].Split(':')[1]; }
                                        covidItem.Text = "Recovered Cases: ";
                                        break;
                                    }
                                case 3:
                                    {
                                        if (x==0) { covidItem.Valve = newArry[12].Split(':')[1]; }
                                        else { covidItem.Valve = newArry[22].Split(':')[1]; }
                                        covidItem.Text = "Total Deaths: ";
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"\tERROR line 53{0}"  + "x:" + x + "i:" + i, ex.Message);
                    }
                    try
                    {
                        for (int y = 10; y > 0; y--)
                        {
                            DateTime tempDate = currentDate.Subtract(new TimeSpan((7 * y), 0, 0, 0));
                            string urlDate = tempDate.Year.ToString();

                            if (tempDate.Month < 10) { urlDate = urlDate + "0" + tempDate.Month.ToString(); }
                            else { urlDate = urlDate + tempDate.Month.ToString(); }

                            if (tempDate.Day < 10) { urlDate = urlDate + "0" + tempDate.Day.ToString(); }
                            else { urlDate = urlDate + tempDate.Day.ToString(); }

                            //Debug.WriteLine(urlDate);
                            try
                            {
                                var test = string.Format((DateUrl + urlDate + ".json"), string.Empty);
                                var uriDate = new Uri(string.Format((DateUrl + urlDate + ".json"), string.Empty));
                                var response = await _client.GetAsync(uriDate);
                                //Debug.WriteLine("X116: " + response.ToString());
                                //Debug.WriteLine(test);
                                if (response.IsSuccessStatusCode)
                                {
                                    var content = await response.Content.ReadAsStringAsync();
                                    //Debug.WriteLine(content.ToString());

                                    var newArry = content.Split(',');
                                    string tempVal;
                                    string tempLabel;

                                    switch (i)
                                    {
                                        case 0:
                                            {
                                                if (x == 0) { tempVal = newArry[2].Split(':')[1]; }
                                                else { tempVal = newArry[2].Split(':')[1]; }
                                                //Debug.WriteLine(tempVal);
                                                if (tempVal == "null") { tempVal = "0"; }
                                                break;
                                            }
                                        case 1:
                                            {
                                                if (x==0) { tempVal = newArry[3].Split(':')[1]; }
                                                else { tempVal = newArry[11].Split(':')[1]; }
                                                //Debug.WriteLine(tempVal);
                                                if (tempVal== "null") { tempVal = "0"; }
                                                break;
                                            }
                                        case 2:
                                            {
                                                if (x==0) { tempVal = newArry[11].Split(':')[1]; }
                                                else { tempVal = newArry[19].Split(':')[1]; }
                                                //Debug.WriteLine(tempVal);
                                                if (tempVal == "null") { tempVal = "0"; }
                                                break;
                                            }
                                        case 3:
                                            {
                                                if (x == 0) { tempVal = newArry[15].Split(':')[1]; }
                                                else { tempVal = newArry[22].Split(':')[1]; }
                                                //Debug.WriteLine(tempVal);
                                                if (tempVal == "null") { tempVal = "0"; }
                                                break;
                                            }
                                        default:
                                            {
                                                tempVal = "0";
                                                break;
                                            }
                                    }
                                    
                                    SkiaSharp.SKColor tempColor = new SkiaSharp.SKColor();

                                    switch (y)
                                    {
                                        case 0:
                                            {
                                                tempColor = new SkiaSharp.SKColor(71, 230, 113);
                                                break;
                                            }
                                        case 1:
                                            {
                                                tempColor = new SkiaSharp.SKColor(71, 230, 206);
                                                break;
                                            }
                                        case 2:
                                            {
                                                tempColor = new SkiaSharp.SKColor(71, 137, 230);
                                                break;
                                            }
                                        case 3:
                                            {
                                                tempColor = new SkiaSharp.SKColor(71, 105, 230);
                                                break;
                                            }
                                        default:
                                            {
                                                tempColor = new SkiaSharp.SKColor(230, 71, 71);
                                                break;
                                            }
                                    }

                                    tempLabel = newArry[0].Split(':')[1].Substring(0, 4);
                                    tempLabel = newArry[0].Split(':')[1].Substring(6, 2) + ", " + tempLabel;
                                    tempLabel = newArry[0].Split(':')[1].Substring(4, 2) + "/" + tempLabel;

                                    Debug.WriteLine(tempLabel);

                                    Microcharts.Entry entry = new Microcharts.Entry(float.Parse(tempVal));
                                    entry.Color = tempColor;
                                    entry.Label = tempLabel;
                                    entry.ValueLabel = tempVal;

                                    entries.Add(entry);
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(@"\tERROR line 135 {0}" + "y:"+y+"x:"+x+"i:"+i, ex.Message);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"\tERROR line 141 {0}"  + "x:" + x + "i:" + i, ex.Message);
                    }

                    covidItem.Chart = new LineChart() { Entries = entries,LabelTextSize=40 };

                    Debug.WriteLine(covidItem.Text);
                    Debug.WriteLine(covidItem.Valve);
                    Debug.WriteLine(covidItem.Chart.Entries.Count());

                    covidItem.Text = covidItem.Text + " " + covidItem.Valve;

                    if (x == 0) { UsList.CovidItems.Add(covidItem); }
                    else { StateList.CovidItems.Add(covidItem); }
                }
    
            }
            List<CovidItemList> list = new List<CovidItemList>();
            list.Add(UsList);
            list.Add(StateList);
            return list;
        }

        public Task SaveNewsItemAsync(NewsItem item, bool isNewItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<NewsItem>> NewsRefreshDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
