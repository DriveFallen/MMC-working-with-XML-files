using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Договора
    {
        public Договора() { }
        [XmlElement("Договор")]
        public List<Договор> договора { get; set; } = new List<Договор>();
    }

    [Serializable]
    public class Договор
    {
        public Договор() { }
        public Договор(string Идентификатор, string УидКонтрагента, string КодПодразделения, string Номер,
            string ДатаЗаключения, string ДатаОкончания, string ДопустимоеКоличествоОсмотров,
            string ПройденоеКоличествоОсмотров, string ОбщаяСуммаПоДоговору,
            string ИзрасходованнаяСуммаПоДоговору, Услуги Услуги, string ДополнительныеСоглашения,
            Куратор куратор)
        {
            this.Идентификатор = Идентификатор;
            this.УидКонтрагента = УидКонтрагента;
            this.КодПодразделения = КодПодразделения;
            this.Номер = Номер;
            this.ДатаЗаключения = ДатаЗаключения;
            this.ДатаОкончания = ДатаОкончания;
            this.ДопустимоеКоличествоОсмотров = ДопустимоеКоличествоОсмотров;
            this.ПройденоеКоличествоОсмотров = ПройденоеКоличествоОсмотров;
            this.ОбщаяСуммаПоДоговору = ОбщаяСуммаПоДоговору;
            this.ИзрасходованнаяСуммаПоДоговору = ИзрасходованнаяСуммаПоДоговору;
            this.Услуги = Услуги;
            this.ДополнительныеСоглашения = ДополнительныеСоглашения;
            this.Куратор = куратор;
        }

        public string Идентификатор { get; set; }
        public string УидКонтрагента { get; set; }
        public string КодПодразделения { get; set; }
        public string Номер { get; set; }
        public string ДатаЗаключения { get; set; }
        public string ДатаОкончания { get; set; }
        public string ДопустимоеКоличествоОсмотров { get; set; }
        public string ПройденоеКоличествоОсмотров { get; set; }
        public string ОбщаяСуммаПоДоговору { get; set; }
        public string ИзрасходованнаяСуммаПоДоговору { get; set; }
        public Услуги Услуги { get; set; }
        public string ДополнительныеСоглашения { get; set; }
        public Куратор Куратор { get; set; }
    }

    [Serializable]
    public class Услуги
    {
        public Услуги() { }
        [XmlElement("Услуга")]
        public List<Услуга> услуги { get; set; } = new List<Услуга>();
    }

    [Serializable]
    public class Услуга
    {
        public Услуга() { }
        public Услуга(string услуга)
        {
            this.услуга = услуга;
        }
        public string услуга { get; set; }
    }

    [Serializable]
    public class Куратор
    {
        public Куратор() { }
        public Куратор(string Фамилия, string Имя, string Отчество, string ИдентификаторДолжности, string ЭлектроннаяПочта, string Телефон)
        {
            this.Фамилия = Фамилия;
            this.Имя = Имя;
            this.Отчество = Отчество;
            this.ИдентификаторДолжности = ИдентификаторДолжности;
            this.ЭлектроннаяПочта = ЭлектроннаяПочта;
            this.Телефон = Телефон;
        }

        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string ИдентификаторДолжности { get; set; }
        public string ЭлектроннаяПочта { get; set; }
        public string Телефон { get; set; }
    }
}
