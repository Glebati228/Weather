using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Weather
{

    public partial class Form1 : Form
    {
        IWeatherData WeatherData { get; set; }
        OpenWeather openWeather = new OpenWeather();
        DarkSky darkSky = new DarkSky();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Attributes> attributes = WeatherData.GetData(textBox1.Text, textBox2.Text);
            label1.Text = attributes[0].temperature.Data + " " + attributes[0].temperature.Metric;
            label2.Text = attributes[0].humidity.Data + " " + attributes[0].humidity.Metric;
            label3.Text = attributes[0].pressure.Data + " " + attributes[0].pressure.Metric;
            label4.Text = attributes[0].wind.Data + " " + attributes[0].wind.Metric;
            //label1.Text = data["temperature"];

            //for (int i = 0; i < data["temperature"].Count; ++i)
            //{
            //    listBox1.Items.Add(data[i] + 
            //        " " + data["humidity"][i] + 
            //        " " + data["pressure"][i] + 
            //        " " + data["windSpeed"][i] + 
            //        " " + data["windDirection"][i]);
            //}

            //label2.Text = data["humidity"];
            //label3.Text = data["pressure"];
            //.Text = data["windSpeed"] + "/" + data["windDirection"];

            //double temp = double.Parse(szTemp) - 273.16;
            //label1.Text = temp.ToString("N2") + " Celcius";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //temperature
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dTemperature = Temperature.SetDefaultTemperature;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dTemperature = Temperature.SetMetricTemperature;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dTemperature = Temperature.SetImperialTemperature;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //humidity
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dHumidity = Humidity.SetDefaultHumidity;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dHumidity = Humidity.SetDefaultHumidity;
        }

        //pressure
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dPressure = Pressure.SetDefaultPressure;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dPressure = Pressure.SetBarPressure;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            openWeather.dPressure = Pressure.GetMMRTSTPressure;
        }

        //source
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            WeatherData = openWeather;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            WeatherData = darkSky;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
