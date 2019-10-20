using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{

    public interface IAttribute
    {
        double Data { get; set; }
        string Metric { get; set; }
    }

    public struct Temperature : IAttribute
    {
        public double Data { get; set; }
        public string Metric { get; set; }

        public Temperature(double data, string metric)
        {
            Data = data;
            Metric = metric;
        }

        public static Temperature SetDefaultTemperature(Temperature temperature)
        {
            temperature.Metric = "Kelvins";
            return temperature;
        }

        public static Temperature SetMetricTemperature(Temperature temperature)
        {
            temperature.Metric = "Celcius";
            temperature.Data -= 273.15f;
            return temperature;
        }

        public static Temperature SetImperialTemperature(Temperature temperature)
        {
            temperature.Data = ((temperature.Data - 273.15f) * 9 / 5f) + 32;
            temperature.Metric = "Fahrenheits";
            return temperature;
        }
    }

    public struct Humidity : IAttribute
    {
        public double Data { get; set; }
        public string Metric { get; set; }

        public Humidity(double data, string metric)
        {
            Data = data;
            Metric = metric;
        }

        public static Humidity SetDefaultHumidity(Humidity humidity)
        {
            humidity.Metric = "%";
            return humidity;
        }
    }

    public struct Pressure : IAttribute
    {
        public double Data { get; set; }
        public string Metric { get; set; }

        public Pressure(double data, string metric)
        {
            Data = data;
            Metric = metric;
        }

        public static Pressure SetDefaultPressure(Pressure pressure)
        {
            pressure.Metric = "hPa";
            return pressure;
        }

        public static Pressure SetBarPressure(Pressure pressure)
        {
            pressure.Data /= 1000f;
            pressure.Metric = "Bar";
            return pressure;
        }

        public static Pressure GetMMRTSTPressure(Pressure pressure)
        {
            pressure.Data /= 1.333f;
            pressure.Metric = "mm rt st";
            return pressure;
        }
    }
    public struct Wind : IAttribute
    {
        public double Data { get; set; }
        public string Metric { get; set; }

        public string direction;

        public Wind(double data, string metric, string direction)
        {
            Data = data;
            Metric = metric;
            this.direction = direction;
        }

        public static string GetDirection(int degr)
        {
            if (degr >= 337 && degr <= 22) return "N";
            if (degr >= 22 && degr <= 67) return "NE";
            if (degr >= 67 && degr <= 112) return "E";
            if (degr >= 112 && degr <= 157) return "SE";
            if (degr >= 157 && degr <= 202) return "S";
            if (degr >= 202 && degr <= 257) return "SW";
            if (degr >= 257 && degr <= 292) return "W";
            if (degr >= 292 && degr <= 337) return "NW";

            else return " ";
        }
    }

    public class Attributes
    {
        List<IAttribute> datas;

        public Attributes(List<IAttribute> datas) 
        {
            this.datas = datas;
        }

        public override string ToString()
        {
            string data = "";

            foreach (IAttribute item in datas)
            {
                data += item.Data.ToString() + " " + item.Metric.ToString() + "   ";
            }

            return data;
        }
    }
}
