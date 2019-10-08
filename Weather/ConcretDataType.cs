using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public static class WeatherComponentTypes
    {
        public const double kelvin = 273.15f;

        //temperature
        public static string GetDefaultTemperature(string temp)
        {
            return temp + " Kelvins";
        }

        public static string GetMetricTemperature(string temp)
        {
            double buf = double.Parse(temp) - kelvin;
            return buf.ToString("N2") + " Celcius";
        }

        public static string GetImperialTemperature(string temp)
        {
            double buf = ((double.Parse(temp) - kelvin) * 9 / 5f) + 32;
            return buf.ToString("N2") + " Fahrenheits";
        }

        //humidity
        public static string GetDefaultHumidity(string hum)
        {
            return hum + " %";
        }

        //pressure
        public static string GetDefaultPressure(string press)
        {
            return press + " hPa";
        }

        public static string GetBarPressure(string press)
        {
            double buf = double.Parse(press) / 1000f;
            return buf.ToString("N2") + " Bar";
        }

        public static string GetMMRTSTPressure(string press)
        {
            double buf = double.Parse(press) / 1.333f;
            return buf.ToString("N2") + " mm rt st";
        }
    }
}
