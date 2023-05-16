using System;
using System.Xml.Serialization;

namespace SerializerXML.XMLClasses
{
    [Serializable]
    public class Выгрузка
    {
        public Выгрузка() { }
        public ЮридическоеЛицо юридическоеЛицо { get; set; }
    }

    [Serializable]
    public class ЮридическоеЛицо
    {

    }

    [Serializable]
    public class Справочники
    {

    }
}
