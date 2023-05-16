using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class ПериодическиеМедОсмотры
    {
        public ПериодическиеМедОсмотры() { }

        [XmlElement("ПериодическийМедОсмотр")]
        public List<ПМО> listПМО { get; set; } = new List<ПМО>();

    }

    [Serializable]
    public class ПМО
    {
        public ПМО() { }
        public ПМО(
            string Идентификатор, string УидСотрудника, string ИдентификаторДолжности,
            string ИдентификаторПодразделения, string ИдентификаторДоговора,
            string НомерОбращения, string ДатаОсмотра, string Ограничения,
            string Результат, string ИдентификаторЗдравпункта, string Председатель,
            string ГруппаРиска, string Рекомендации, string СтоимостьУслуг,
            string ДатаПрисвоенияГруппыЗдоровья, string ГруппаЗдоровья,
            ВредныеУсловия вредныеУсловия, ВредныеФакторы вредныеФакторы,
            Справка справка)
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
        public ВредныеУсловия вредныеУсловия { get; set; }
        public ВредныеФакторы вредныеФакторы { get; set; }
        public Справка справка { get; set; }

    }
    [Serializable]
    public class ВредныеУсловия
    {
        public ВредныеУсловия() { }
        
        [XmlElement("Условие")]
        public List<Условие> условия { get; set; } = new List<Условие>();
    }

    [Serializable]
    public class Условие
    {
        public Условие() { }
        public Условие(string Код, string Наименование)
        {
            this.Код = Код;
            this.Наименование = Наименование;
        }

        public string Код { get; set; }
        public string Наименование { get; set; }
    }

    [Serializable]
    public class ВредныеФакторы
    {
        public ВредныеФакторы() { }

        [XmlElement("Фактор")]
        public List<Фактор> факторы { get; set; } = new List<Фактор>();

    }

    [Serializable]
    public class Фактор
    {
        public Фактор() { }
        public Фактор(string Код, string Наименование)
        {
            this.Код = Код;
            this.Наименование = Наименование;
        }

        public string Код { get; set; }
        public string Наименование { get; set; }

    }

    [Serializable]
    public class Справка
    {
        public Справка() { }
        public Справка(string НомерСправки, string ДатаВыдачиСправки, string Файл)
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
