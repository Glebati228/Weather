using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Weather
{
    [XmlRoot(ElementName = "coord")]
    public class Coord
    {
        [XmlAttribute(AttributeName = "lon")]
        public double Lon { get; set; }
        [XmlAttribute(AttributeName = "lat")]
        public double Lat { get; set; }
    }

    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "rise")]
        public string Rise { get; set; }
        [XmlAttribute(AttributeName = "set")]
        public string Set { get; set; }
    }

    [XmlRoot(ElementName = "city")]
    public class City
    {
        [XmlElement(ElementName = "coord")]
        public Coord Coord { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "timezone")]
        public string Timezone { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "temperature")]
    public class Temperatures
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "min")]
        public double Min { get; set; }
        [XmlAttribute(AttributeName = "max")]
        public double Max { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "humidity")]
    public class Humiditys
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "pressure")]
    public class Pressures
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }

    [XmlRoot(ElementName = "speed")]
    public class Speed
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "direction")]
    public class Direction
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "wind")]
    public class Winds
    {
        [XmlElement(ElementName = "speed")]
        public Speed Speed { get; set; }
        [XmlElement(ElementName = "gusts")]
        public string Gusts { get; set; }
        [XmlElement(ElementName = "direction")]
        public Direction Direction { get; set; }
    }

    [XmlRoot(ElementName = "clouds")]
    public class Clouds
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }

    [XmlRoot(ElementName = "visibility")]
    public class Visibility
    {
        [XmlAttribute(AttributeName = "value")]
        public double Value { get; set; }
    }

    [XmlRoot(ElementName = "precipitation")]
    public class Precipitation
    {
        [XmlAttribute(AttributeName = "mode")]
        public string Mode { get; set; }
    }

    [XmlRoot(ElementName = "weather")]
    public class Weather
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "icon")]
        public string Icon { get; set; }
    }

    [XmlRoot(ElementName = "lastupdate")]
    public class Lastupdate
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "current")]
    public class Current
    {
        [XmlElement(ElementName = "city")]
        public City City { get; set; }
        [XmlElement(ElementName = "temperature")]
        public Temperatures Temperature { get; set; }
        [XmlElement(ElementName = "humidity")]
        public Humiditys Humidity { get; set; }
        [XmlElement(ElementName = "pressure")]
        public Pressures Pressure { get; set; }
        [XmlElement(ElementName = "wind")]
        public Winds Wind { get; set; }
        [XmlElement(ElementName = "clouds")]
        public Clouds Clouds { get; set; }
        [XmlElement(ElementName = "visibility")]
        public Visibility Visibility { get; set; }
        [XmlElement(ElementName = "precipitation")]
        public Precipitation Precipitation { get; set; }
        [XmlElement(ElementName = "weather")]
        public Weather Weather { get; set; }
        [XmlElement(ElementName = "lastupdate")]
        public Lastupdate Lastupdate { get; set; }
    }

}