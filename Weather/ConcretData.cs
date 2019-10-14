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
        public static WeatherTypes<Temperature> dTemperature = null;
        public static WeatherTypes<Humidity> dHumidity = null;
        public static WeatherTypes<Pressure> dPressure = null;

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
            if (attributes.Count != 0) attributes.Clear();
            string weburl = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "," + domen + "&APPID=8ff22b4d46994877e20b80bcb6befeba&mode=xml";

            var xml = new WebClient().DownloadString(new Uri(weburl));

            if(xml == null)
            {
                throw new NullReferenceException();
            }

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
            return attributes;
        }
    }

    public class DarkSky : WeatherService
    {
        public DarkSky() : base()
        {
            
        }

        public override List<Attributes> GetData(string arg1, string arg2)
        {
            if (attributes.Count != 0) attributes.Clear();
            string webxml = "https://api.darksky.net/forecast/b4ec7c8979cd92b9980f9ebb4ff428ec/" + arg1 + "," + arg2;

            string json = new WebClient().DownloadString(new Uri(webxml));
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            Console.Out.WriteLine(root.daily.data.Count);
            foreach(var time in root.daily.data)
            {
                Console.Out.WriteLine(TimeConversions.UnixTimeStampToDateTime(time.time) + " ");
            }

            foreach(var data in root.daily.data)
            {
                attributes.Add(new Attributes(
                    dTemperature(new Temperature(data.apparentTemperatureLow, "")),
                    dHumidity(new Humidity(data.humidity, "")),
                    dPressure(new Pressure(data.pressure, "")),
                    new Wind(data.windSpeed, "", Wind.GetDirection(data.windBearing))
                    ));
            }

            return attributes;
        }
    }
}
