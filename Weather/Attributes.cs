using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{

    public interface WeatherData
    {
        double Data { get; set; }
        string Metric { get; set; }
    }

    public struct Temperature : WeatherData
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

    public struct Humidity : WeatherData
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

    public struct Pressure : WeatherData
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

    public struct Wind : WeatherData
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
    }

    public class Attributes
    {
        public Temperature temperature;
        public Humidity humidity;
        public Pressure pressure;
        public Wind wind;

        public Attributes(Temperature temperature, Humidity humidity, Pressure pressure, Wind wind)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.wind = wind;
        }
    }
}
