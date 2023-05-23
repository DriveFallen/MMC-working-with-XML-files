using System.IO;
using System.Xml.Serialization;
using System.Xml;
using SerializerXML.XMLClasses;
using System.Windows.Forms;

public class MySerializer
{
    public static string SerializerXML(Контрагенты контрагенты)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(контрагенты.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, контрагенты, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(Сотрудники сотрудники)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(сотрудники.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, сотрудники, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(Договора договора)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(договора.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, договора, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(ПериодическиеМедОсмотры listПМО)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(listПМО.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, listПМО, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(ПредварительныеМедОсмотры listПМО)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(listПМО.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, listПМО, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(Должности должности)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(должности.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, должности, emptyNamespaces);
            return stream.ToString();
        }
    }
    public static string SerializerXML(Здравпункты здравпункты)
    {
        var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(здравпункты.GetType());
        var settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        settings.NewLineHandling = NewLineHandling.Entitize;

        using (var stream = new StringWriter())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            serializer.Serialize(writer, здравпункты, emptyNamespaces);
            return stream.ToString();
        }
    }

    public static Контрагенты DeserializerXML_контрагенты()
    {
        Контрагенты контрагенты = new Контрагенты();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Контрагенты));
            using (FileStream stream = new FileStream("Контрагенты.xml", FileMode.OpenOrCreate))
            {
                контрагенты = (Контрагенты)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return контрагенты;
    }
    public static Сотрудники DeserializerXML_сотрудники()
    {
        Сотрудники сотрудники = new Сотрудники();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Сотрудники));
            using (FileStream stream = new FileStream("Сотрудники.xml", FileMode.OpenOrCreate))
            {
                сотрудники = (Сотрудники)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return сотрудники;
    }
    public static Договора DeserializerXML_договора()
    {
        Договора договора = new Договора();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Договора));
            using (FileStream stream = new FileStream("Договора.xml", FileMode.OpenOrCreate))
            {
                договора = (Договора)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return договора;
    }
    public static ПериодическиеМедОсмотры DeserializerXML_ПМО()
    {
        ПериодическиеМедОсмотры ПМО = new ПериодическиеМедОсмотры();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ПериодическиеМедОсмотры));
            using (FileStream stream = new FileStream("ПМО.xml", FileMode.OpenOrCreate))
            {
                ПМО = (ПериодическиеМедОсмотры)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return ПМО;
    }
    public static ПредварительныеМедОсмотры DeserializerXML_ПредМО()
    {
        ПредварительныеМедОсмотры ПредМО = new ПредварительныеМедОсмотры();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ПредварительныеМедОсмотры));
            using (FileStream stream = new FileStream("Трудоустройства.xml", FileMode.OpenOrCreate))
            {
                ПредМО = (ПредварительныеМедОсмотры)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return ПредМО;
    }
    public static Должности DeserializerXML_должности()
    {
        Должности должности = new Должности();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Должности));
            using (FileStream stream = new FileStream("Должности.xml", FileMode.OpenOrCreate))
            {
                должности = (Должности)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return должности;
    }
    public static Здравпункты DeserializerXML_здравпункты()
    {
        Здравпункты здравпункты = new Здравпункты();

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Здравпункты));
            using (FileStream stream = new FileStream("Здравпункты.xml", FileMode.OpenOrCreate))
            {
                здравпункты = (Здравпункты)serializer.Deserialize(stream);
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show(ex.Message, "Структура XML файла нарушена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        return здравпункты;
    }
}