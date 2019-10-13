using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;


namespace Weather
{

    public interface IWeatherData
    {
        List<Attributes> GetData(string arg1, string arg2);
    }

    public abstract class WeatherService : IWeatherData
    {
        protected Dictionary<string, List<string>> data;
        protected List<Attributes> attributes;

        public delegate T WeatherTypes<T>(T weatherData);
        public WeatherTypes<Temperature> dTemperature = null;
        public WeatherTypes<Humidity> dHumidity = null;
        public WeatherTypes<Pressure> dPressure = null;

        protected WeatherService()
        {
            attributes = new List<Attributes>();
        }

        public abstract List<Attributes> GetData(string arg1, string arg2);
    }

    public class OpenWeather : WeatherService
    {
        public OpenWeather() : base()
        {

        }

        public override List<Attributes> GetData(string city, string domen)
        {
            string weburl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "," + domen + "&APPID=8ff22b4d46994877e20b80bcb6befeba&mode=xml";

            var xml = new WebClient().DownloadString(new Uri(weburl));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            //gettingData
            Console.WriteLine(doc.OuterXml);
            Current response;
            using (TextReader sr = new StringReader(doc.OuterXml))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Current));
                response = (Current)serializer.Deserialize(sr);
            }
            Console.WriteLine(response.Temperature.Value);
            attributes.Add(
                new Attributes(
                    dTemperature(new Temperature(response.Temperature.Value, response.Temperature.Unit)),
                    dHumidity(new Humidity(response.Humidity.Value, response.Humidity.Unit)),
                    dPressure(new Pressure(response.Pressure.Value, response.Pressure.Unit)),
                    new Wind(response.Wind.Speed.Value, response.Wind.Speed.Unit, response.Wind.Direction.Name)
                    )
                );
            ////list[3] = doc.DocumentElement.SelectNodes("wind");
            //for (int i = 0; i < list.Length; ++i)
            //{
            //    Attributes attr = new Attributes();

            //    for (int k = 0; k < list[i].Count; ++k)
            //    {
            //        attr = double.Parse(list[i][k].Attributes["value"].Value.Replace(".", ","));
            //        dTemperature(attributes[0].);
            //    }
            //    attributes.Add(attr);
            //}
            //data["temperature"] = ParseData(list, "temperature", "value", null);

            //list = doc.DocumentElement.SelectNodes("humidity");
            //data["humidity"] = ParseData(list, "humidity", "value", null);

            //list = doc.DocumentElement.SelectNodes("pressure");
            //data["pressure"] = ParseData(list, "pressure", "value", null);

            //list = doc.DocumentElement.SelectNodes("wind");
            //data["windSpeed"] = ParseData(list, "windSpeed", "value", 0);

            //list = doc.DocumentElement.SelectNodes("wind");
            //data["windDirection"] = ParseData(list, "windDirection", "name", 2);

            //data["humidity"] = weather["humidity"](ChangeText(doc.DocumentElement.SelectSingleNode("humidity").Attributes["value"].Value));
            //data["pressure"] = weather["pressure"](ChangeText(doc.DocumentElement.SelectSingleNode("pressure").Attributes["value"].Value));

            //data["windSpeed"] = doc.DocumentElement.SelectSingleNode("wind").ChildNodes.Item(0).Attributes["value"].Value + " m/s";
            //ChangeText("windSpeed");

            //data["windDirection"] = doc.DocumentElement.SelectSingleNode("wind").ChildNodes.Item(2).Attributes["name"].Value;

            return attributes;
        }
    }

    public class DarkSky : WeatherService
    {
        public DarkSky() : base()
        {
            
        }

        public override List<Attributes> GetData(string city, string domen)
        {
            string webxml = "https://api.darksky.net/forecast/b4ec7c8979cd92b9980f9ebb4ff428ec/37.8267,-122.4233";

            string json = new WebClient().DownloadString(new Uri(webxml));
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            Console.Out.WriteLine(root.daily.data.Count);
            foreach(var time in root.daily.data)
            {
                Console.Out.WriteLine(TimeConversions.UnixTimeStampToDateTime(time.time) + " ");
            }



            return attributes;
        }
    }
}
