using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Здравпункты
    {
        public Здравпункты() { }
        [XmlElement("Здравпункт")]
        public List<Здравпункт> здравпункты { get; set; } = new List<Здравпункт>();
    }

    [Serializable]
    public class Здравпункт
    {
        public Здравпункт() { }
        public Здравпункт(string Идентификатор, string Наименование)
        {
            this.Идентификатор = Идентификатор;
            this.Наименование = Наименование;
        }

        public string Идентификатор { get; set; }
        public string Наименование { get; set; }
    }
}
