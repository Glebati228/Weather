using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string weburl = "http://api.openweathermap.org/data/2.5/weather?q="+ textBox1.Text +"&APPID=8ff22b4d46994877e20b80bcb6befeba&mode=xml";

            var xml = await new WebClient().DownloadStringTaskAsync(new Uri(weburl));

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string szTemp = doc.DocumentElement.SelectSingleNode("temperature").Attributes["value"].Value;
            Console.Out.WriteLine(szTemp);
            szTemp = szTemp.Replace('.', ',');
            double temp = double.Parse(szTemp) - 273.16;
            label1.Text = temp.ToString("N2") + " Celcius";

            string humidity = doc.DocumentElement.SelectSingleNode("humidity").Attributes["value"].Value;
            label2.Text = humidity + "%";

            string pressure = doc.DocumentElement.SelectSingleNode("pressure").Attributes["value"].Value;
            label3.Text = pressure + "hPa";
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
    }
}
