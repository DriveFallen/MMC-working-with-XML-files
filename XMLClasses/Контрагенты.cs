using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Контрагенты
    {
        public Контрагенты() { }

        [XmlElement("Контрагент")]
        public List<Контрагент> контрагенты { get; set; } = new List<Контрагент>();
    }

    [Serializable]
    public class Контрагент
    {
        public Контрагент() { }
        public Контрагент(
            string уид, string инн, string кпп,
            string огрн, string окпо, string ЮрАдрес,
            string название, string телефон, string почта,
            Подразделения подразделения)
        {
            this.УидКонтрагента = уид;
            this.Инн = инн;
            this.Кпп = кпп;
            this.Огрн = огрн;
            this.Окпо = окпо;
            this.ЮридическийАдрес = ЮрАдрес;
            this.НазваниеОрганизации = название;
            this.ТелефонОрганизации = телефон;
            this.ПочтаОрганизации = почта;
            this.поздразделения = подразделения;
        }

        public string УидКонтрагента { get; set; }
        public string Инн { get; set; }
        public string Кпп { get; set; }
        public string Огрн { get; set; }
        public string Окпо{ get; set; }
        public string ЮридическийАдрес { get; set; }
        public string НазваниеОрганизации { get; set; }
        public string ТелефонОрганизации { get; set; }
        public string ПочтаОрганизации { get; set; }
        public Подразделения поздразделения { get; set; }
    }

    [Serializable]
    public class Подразделения
    {
        public Подразделения() { }

        [XmlElement("Подразделение")]
        public List<Подразделение> подразделения { get; set; } = new List<Подразделение>();
    }

    [Serializable]
    public class Подразделение
    {
        public Подразделение() { }
        public Подразделение(string уид, string код, string наименование) 
        {
            this.УидПодразделения = уид;
            this.Код = код;
            this.Наименование = наименование;
        }

        public string УидПодразделения { get; set; }
        public string Код { get; set; }
        public string Наименование { get; set; }
    }
}
