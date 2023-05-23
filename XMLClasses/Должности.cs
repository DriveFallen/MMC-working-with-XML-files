using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Должности
    {
        public Должности() { }
        [XmlElement("Должность")]
        public List<Должность> должности { get; set; } = new List<Должность>();
    }

    [Serializable]
    public class Должность
    {
        public Должность() { }
        public Должность(string Идентификатор, string Наименование)
        {
            this.Идентификатор = Идентификатор;
            this.Наименование = Наименование;
        }

        public string Идентификатор { get; set; }
        public string Наименование { get; set; }
    }
}
