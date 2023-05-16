using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class ПредварительныеМедОсмотры
    {
        public ПредварительныеМедОсмотры() { }

        [XmlElement("ПредварительныйМедОсмотры")]
        public List<ПредМО> listТрудоустройства { get; set; } = new List<ПредМО>();

    }

    [Serializable]
    public class ПредМО
    {
        public ПредМО() { }
        public ПредМО(
            string Идентификатор, string УидСотрудника, string ИдентификаторДолжности,
            string ИдентификаторПодразделения, string ИдентификаторДоговора,
            string НомерОбращения, string ДатаОсмотра, string Ограничения,
            string Результат, string ИдентификаторЗдравпункта, string Председатель,
            string ГруппаРиска, string Рекомендации, string СтоимостьУслуг,
            string ДатаПрисвоенияГруппыЗдоровья, string ГруппаЗдоровья,
            ПредВредныеУсловия вредныеУсловия, ПредВредныеФакторы вредныеФакторы,
            ПредСправка справка)
        {
            this.Идентификатор = Идентификатор;
            this.УидСотрудника = УидСотрудника;
            this.ИдентификаторДолжности = ИдентификаторДолжности;
            this.ИдентификаторПодразделения = ИдентификаторПодразделения;
            this.ИдентификаторДоговора = ИдентификаторДоговора;
            this.НомерОбращения = НомерОбращения;
            this.ДатаОсмотра = ДатаОсмотра;
            this.Ограничения = Ограничения;
            this.Результат = Результат;
            this.ИдентификаторЗдравпункта = ИдентификаторЗдравпункта;
            this.Председатель = Председатель;
            this.ГруппаРиска = ГруппаРиска;
            this.Рекомендации = Рекомендации;
            this.СтоимостьУслуг = СтоимостьУслуг;
            this.ДатаПрисвоенияГруппыЗдоровья = ДатаПрисвоенияГруппыЗдоровья;
            this.ГруппаЗдоровья = ГруппаЗдоровья;
            this.вредныеУсловия = вредныеУсловия;
            this.вредныеФакторы = вредныеФакторы;
            this.справка = справка;
        }

        public string Идентификатор { get; set; }
        public string УидСотрудника { get; set; }
        public string ИдентификаторДолжности { get; set; }
        public string ИдентификаторПодразделения { get; set; }
        public string ИдентификаторДоговора { get; set; }
        public string НомерОбращения { get; set; }
        public string ДатаОсмотра { get; set; }
        public string Ограничения { get; set; }
        public string Результат { get; set; }
        public string ИдентификаторЗдравпункта { get; set; }
        public string Председатель { get; set; }
        public string ГруппаРиска { get; set; }
        public string Рекомендации { get; set; }
        public string СтоимостьУслуг { get; set; }
        public string ДатаПрисвоенияГруппыЗдоровья { get; set; }
        public string ГруппаЗдоровья { get; set; }
        public ПредВредныеУсловия вредныеУсловия { get; set; }
        public ПредВредныеФакторы вредныеФакторы { get; set; }
        public ПредСправка справка { get; set; }

    }
    [Serializable]
    public class ПредВредныеУсловия
    {
        public ПредВредныеУсловия() { }

        [XmlElement("Условие")]
        public List<ПредУсловие> условия { get; set; } = new List<ПредУсловие>();
    }

    [Serializable]
    public class ПредУсловие
    {
        public ПредУсловие() { }
        public ПредУсловие(string Код, string Наименование)
        {
            this.Код = Код;
            this.Наименование = Наименование;
        }

        public string Код { get; set; }
        public string Наименование { get; set; }
    }

    [Serializable]
    public class ПредВредныеФакторы
    {
        public ПредВредныеФакторы() { }

        [XmlElement("Фактор")]
        public List<ПредФактор> факторы { get; set; } = new List<ПредФактор>();

    }

    [Serializable]
    public class ПредФактор
    {
        public ПредФактор() { }
        public ПредФактор(string Код, string Наименование)
        {
            this.Код = Код;
            this.Наименование = Наименование;
        }

        public string Код { get; set; }
        public string Наименование { get; set; }

    }

    [Serializable]
    public class ПредСправка
    {
        public ПредСправка() { }
        public ПредСправка(string НомерСправки, string ДатаВыдачиСправки, string Файл)
        {
            this.НомерСправки = НомерСправки;
            this.ДатаВыдачиСправки = ДатаВыдачиСправки;
            this.Файл = Файл;
        }

        public string НомерСправки { get; set; }
        public string ДатаВыдачиСправки { get; set; }
        public string Файл { get; set; }
    }
}
