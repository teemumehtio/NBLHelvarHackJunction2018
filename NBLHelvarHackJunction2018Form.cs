using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBLHelvarHackJunction2018
{
    public partial class NBLHelvarHackJunction2018Form : Form
    {
        private static readonly string ApiKey = "PRIVATE";
        private static readonly string ApiHost = "https://v0wwaqqnpa.execute-api.eu-west-1.amazonaws.com/V1/sites/site_exp";

        private HttpClient Client;

        public NBLHelvarHackJunction2018Form()
        {
            InitializeComponent();
            Client = new HttpClient();
        }

        private async void buttonGetDevices_Click(object sender, EventArgs e)
        {
            await GetDevices();
            MessageBox.Show("Done.");
        }

        private async void buttonGetOccupancy_Click(object sender, EventArgs e)
        {
            await GetOccupancy();
            MessageBox.Show("Done.");
        }

        private async void buttonGetHistory_Click(object sender, EventArgs e)
        {
            await GetOccupancyHistory();
            MessageBox.Show("Done.");
        }

        private async Task GetDevices()
        {
            int startIndex = 0;
            int itemCount = 10;

            while (startIndex < 351)
            {
                HttpRequestMessage request = GetRequest($"{ApiHost}/devices?itemCount={itemCount}&startIndex={startIndex}");

                HttpResponseMessage response = await Client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                JObject jsonObject = JObject.Parse(responseBody);
                IEnumerable<JToken> itemTokens = jsonObject.SelectTokens("$.data.items");

                foreach (JToken token in itemTokens)
                {
                    foreach (JToken item in token)
                    {
                        string id = item["id"].ToObject<string>();
                        string name = item["name"].ToObject<string>();
                        string deviceType = item["deviceType"].ToObject<string>();

                        string masterController = item["address"]["masterControllerId"].ToObject<string>();

                        this.textBoxOutput.Text += $"{id};{name};{deviceType};{masterController}\r\n";
                    }
                }

                startIndex += itemCount;
            }
        }

        private async Task GetOccupancy()
        {
            if (this.textBoxInput.Text.Length > 0)
            {
                string[] sensors = this.textBoxInput.Text.Split('\n');

                foreach (string sensor in sensors)
                {
                    string sensorTrimmed = sensor.Trim();

                    if (sensorTrimmed.Length > 0)
                    {
                        DateTime startTime = new DateTime(2018, 11, 1, 10, 0, 0);
                        DateTime endTime = new DateTime(2018, 11, 1, 11, 0, 0);
                        TimeSpan interval = new TimeSpan(10, 0, 5, 0); // Days, hours, minutes, seconds

                        //while (startTime < endTime)
                        {
                            HttpRequestMessage request = PostRequest($"{ApiHost}/sensors/{sensorTrimmed}/occupancy");
                            Dictionary<string, string> requestBody = new Dictionary<string, string>();
                            requestBody.Add("timeDate", startTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                            //HttpRequestMessage request = PostRequest($"{ApiHost}/sensors/{sensorTrimmed}/movements/count");
                            //Dictionary<string, string> requestBody = new Dictionary<string, string>();
                            //requestBody.Add("timeDateFrom", startTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                            //requestBody.Add("timeDateStart", endTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                            //HttpRequestMessage request = PostRequest($"{ApiHost}/sensors/{sensorTrimmed}/indoorclimate/latest");
                            //Dictionary<string, string> requestBody = new Dictionary<string, string>();
                            //requestBody.Add("timeDateFrom", startTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                            //requestBody.Add("timeDateStart", endTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                            string content = JsonConvert.SerializeObject(requestBody, Formatting.Indented);
                            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await Client.SendAsync(request);
                            string responseBody = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                JObject jsonObject = JObject.Parse(responseBody);
                                JToken occupiedToken = jsonObject.SelectToken("$.data.occupied");
                                //JToken occupiedToken = jsonObject.SelectToken("$.data.count");
                                string occupiedStatus = occupiedToken.ToObject<string>();
                                this.textBoxOutput.Text += sensorTrimmed + ";" + occupiedStatus + "\r\n";

                                //JToken temperatureToken = jsonObject.SelectToken("$.data.indoorClimate.temperature");
                                //JToken humidityToken = jsonObject.SelectToken("$.data.indoorClimate.humidity");
                                //JToken co2Token = jsonObject.SelectToken("$.data.indoorClimate.co2");

                                //string temperatureStatus = temperatureToken.ToObject<string>();
                                //string humidityStatus = humidityToken.ToObject<string>();
                                //string co2Status = co2Token.ToObject<string>();

                                //this.textBoxOutput.Text += $"{sensorTrimmed};{temperatureStatus};{humidityStatus};{co2Status}\r\n";
                            }
                            else
                            {
                                JObject jsonObject = JObject.Parse(responseBody);
                                JToken messageToken = jsonObject.SelectToken("$.error.message");
                                string message = messageToken.ToObject<string>();

                                //this.textBoxOutput.Text += sensorTrimmed + ";" + message + "\r\n";
                                this.textBoxOutput.Text += $"{sensorTrimmed};{message};;\r\n";
                            }

                            startTime = startTime + interval;
                        }
                    }
                }
            }
        }

        private async Task GetOccupancyHistory()
        {
            if (this.textBoxInput.Text.Length > 0)
            {
                string[] sensors = this.textBoxInput.Text.Split('\n');

                foreach (string sensor in sensors)
                {
                    string sensorTrimmed = sensor.Trim();

                    if (sensorTrimmed.Length > 0)
                    {
                        DateTime startTime = new DateTime(2018, 10, 15, 0, 0, 0);
                        DateTime endTime = new DateTime(2018, 11, 4, 0, 0, 0);
                        TimeSpan interval = new TimeSpan(0, 1, 0, 0); // Days, hours, minutes, seconds

                        while (startTime < endTime)
                        {
                            HttpRequestMessage request = PostRequest($"{ApiHost}/sensors/{sensorTrimmed}/occupancy/measure");
                            //HttpRequestMessage request = PostRequest($"{ApiHost}/sensors/{sensorTrimmed}/movements/count");
                            Dictionary<string, string> requestBody = new Dictionary<string, string>();
                            requestBody.Add("timeDateFrom", startTime.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                            DateTime intervalEnd = startTime.Add(interval);
                            requestBody.Add("timeDateTo", intervalEnd.ToString("yyyy-MM-ddTHH:mm:ssZ"));

                            string content = JsonConvert.SerializeObject(requestBody, Formatting.Indented);
                            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

                            HttpResponseMessage response = await Client.SendAsync(request);
                            string responseBody = await response.Content.ReadAsStringAsync();
                            if (response.IsSuccessStatusCode)
                            {
                                JObject jsonObject = JObject.Parse(responseBody);
                                JToken occupiedToken = jsonObject.SelectToken("$.data.measure");
                                //JToken occupiedToken = jsonObject.SelectToken("$.data.count");
                                string occupiedCount = occupiedToken.ToObject<string>();
                                this.textBoxOutput.Text += $"{sensorTrimmed};{startTime.ToString("yyyy-MM-ddTHH:mm:ssZ")};{occupiedCount}\r\n";
                            }
                            else
                            {
                                JObject jsonObject = JObject.Parse(responseBody);
                                JToken messageToken = jsonObject.SelectToken("$.error.message");
                                string message = messageToken.ToObject<string>();

                                this.textBoxOutput.Text += $"{sensorTrimmed};{message};\r\n";
                            }

                            startTime = intervalEnd;
                        }
                    }
                }
            }
        }

        private static HttpRequestMessage GetRequest(string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, uri);
            message.Headers.Add("x-api-key", ApiKey);
            return message;
        }

        private static HttpRequestMessage PostRequest(string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, uri);
            message.Headers.Add("x-api-key", ApiKey);
            return message;
        }
    }
}
