using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Weather
{

    public interface IWeatherData
    {
        Dictionary<string, string> GetData(string city);
    }

    public abstract class WeatherService : IWeatherData
    {
        protected Dictionary<string, string> data;

        public delegate string WeatherTypes(string temp);
        public Dictionary<string, WeatherTypes> weather = new Dictionary<string, WeatherTypes>()
        {
            { "temperature", null },
            { "humidity", null },
            { "pressure", null },
            { "windSpeed", null },
            { "windDirection", null },
        };

        protected WeatherService()
        {
            data = new Dictionary<string, string>()
            {
                { "temperature", "" },
                { "humidity", "" },
                { "pressure", "" },
                { "windSpeed", "" },
                { "windDirection", "" },
            };
        }

        protected string ChangeText(string text)
        {
            return text.Replace(".", ",");
        }

        public abstract Dictionary<string, string> GetData(string city);
    }

    public class OpenWeather : WeatherService
    {
        public OpenWeather() : base()
        {
        }

        public override Dictionary<string, string> GetData(string city)
        {
            string weburl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=8ff22b4d46994877e20b80bcb6befeba&mode=xml";

            var xml = new WebClient().DownloadString(new Uri(weburl));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            //gettingData
            data["temperature"] = weather["temperature"](ChangeText(doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value));
            data["humidity"] = weather["humidity"](ChangeText(doc.DocumentElement.SelectSingleNode("humidity").Attributes["value"].Value));
            data["pressure"] = weather["pressure"](ChangeText(doc.DocumentElement.SelectSingleNode("pressure").Attributes["value"].Value));

            data["windSpeed"] = doc.DocumentElement.SelectSingleNode("wind").ChildNodes.Item(0).Attributes["value"].Value + " m/s";
            ChangeText("windSpeed");

            data["windDirection"] = doc.DocumentElement.SelectSingleNode("wind").ChildNodes.Item(2).Attributes["name"].Value;

            return data;
        }
    }

    public class DarkSky : WeatherService
    {
        public DarkSky() : base()
        {
            
        }

        public override Dictionary<string, string> GetData(string city)
        {

            return new Dictionary<string, string>();
        }
    }
}
