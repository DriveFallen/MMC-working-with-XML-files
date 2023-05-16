using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Сотрудники
    {
        public Сотрудники() { }
        [XmlElement("Сотрудник")]
        public List<Сотрудник> сотрудники = new List<Сотрудник>();
    }

    [Serializable]
    public class Сотрудник
    {
        public Сотрудник() { }
        public Сотрудник(
            string Идентификатор, string УидКонтрагента, string Снилс,
            string Фамилия, string Имя, string Отчество, string Пол,
            string ДатаРождения, string ДатаНачалаРаботы,
            string КодПодразделения, string ИдентификаторДолжности)
        {
            this.Идентификатор = Идентификатор;
            this.УидКонтрагента = УидКонтрагента;
            this.Снилс = Снилс;
            this.Фамилия = Фамилия;
            this.Имя = Имя;
            this.Отчество = Отчество;
            this.Пол = Пол;
            this.ДатаРождения = ДатаРождения;
            this.ДатаНачалаРаботы = ДатаНачалаРаботы;
            this.КодПодразделения = КодПодразделения;
            this.ИдентификаторДолжности = ИдентификаторДолжности;
        }

        public string Идентификатор { get; set; }
        public string УидКонтрагента { get; set; }
        public string Снилс { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Пол { get; set; }
        public string ДатаРождения { get; set; }
        public string ДатаНачалаРаботы { get; set; }
        public string КодПодразделения { get; set; }
        public string ИдентификаторДолжности { get; set; }
    }
}
