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
        //OpenWeather openWeather = new OpenWeather();
        //DarkSky darkSky = new DarkSky();

        public Form1()
        {
            SetCustomPropsOnStart();
            InitializeComponent();
        }

        private void SetCustomPropsOnStart()
        {
            WeatherData = null;
            WeatherService.dTemperature = Temperature.SetDefaultTemperature;
            WeatherService.dHumidity = Humidity.SetDefaultHumidity;
            WeatherService.dPressure = Pressure.SetDefaultPressure;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WeatherData != null)
            {
                listBox1.Items.Clear();
                List<List<Attributes>> attributes = WeatherData.GetData(textBox1.Text, textBox2.Text);

                for (int i = 0; i < attributes.Count; ++i)
                {
                    listBox1.Items.Add(attributes[i][0]);
                }
            }
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
            WeatherService.dTemperature = Temperature.SetDefaultTemperature;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dTemperature = Temperature.SetMetricTemperature;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dTemperature = Temperature.SetImperialTemperature;
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
            WeatherService.dHumidity = Humidity.SetDefaultHumidity;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dHumidity = Humidity.SetDefaultHumidity;
        }

        //pressure
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dPressure = Pressure.SetDefaultPressure;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dPressure = Pressure.SetBarPressure;
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            WeatherService.dPressure = Pressure.GetMMRTSTPressure;
        }

        //source
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            WeatherData = new OpenWeather();
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
            WeatherData = new DarkSky();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0) listBox2.Items.Clear();
            //var tempAttr = listBox1.SelectedItem;
            //Console.WriteLine(tempAttr);
            //string tempAttr = listBox1.SelectedItem;
            //listBox2.Items.Add(tempAttr.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
