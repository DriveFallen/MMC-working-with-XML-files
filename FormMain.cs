using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SerializerXML.XMLClasses;
namespace SerializerXML
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Листы для контрагентов
        public List<TextBox> list_контрагенты_подразделения_уид = new List<TextBox>();
        public List<TextBox> list_контрагенты_подразделения_код = new List<TextBox>();
        public List<TextBox> list_контрагенты_подразделения_наименование = new List<TextBox>();
        // Листы для договоров
        public List<TextBox> list_договора_услуги = new List<TextBox>();
        // Листы для ПМО
        public List<TextBox> list_ПМО_условия_код = new List<TextBox>();
        public List<TextBox> list_ПМО_условия_наименование = new List<TextBox>();
        public List<TextBox> list_ПМО_факторы_код = new List<TextBox>();
        public List<TextBox> list_ПМО_факторы_наименование = new List<TextBox>();
        // Листы для Трудоустройства
        public List<TextBox> list_трудоустройства_условия_код = new List<TextBox>();
        public List<TextBox> list_трудоустройства_условия_наименование = new List<TextBox>();
        public List<TextBox> list_трудоустройства_факторы_код = new List<TextBox>();
        public List<TextBox> list_трудоустройства_факторы_наименование = new List<TextBox>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Контрагенты контрагенты = MySerializer.DeserializerXML_контрагенты();
            for (int i = 0; i < контрагенты.контрагенты.Count; i++)
            {
                ListViewItem LVI = new ListViewItem(контрагенты.контрагенты[i].УидКонтрагента);
                LVI.Tag = контрагенты.контрагенты[i];
                listView_контрагенты.Items.Add(LVI);
            }
        }

        // Обработка открытия вкладок
        //
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        Clean_контрагенты();
                        listView_контрагенты.Items.Clear();

                        Контрагенты контрагенты = MySerializer.DeserializerXML_контрагенты();
                        for (int i = 0; i < контрагенты.контрагенты.Count; i++)
                        {
                            ListViewItem LVI = new ListViewItem(контрагенты.контрагенты[i].УидКонтрагента);
                            LVI.Tag = контрагенты.контрагенты[i];
                            listView_контрагенты.Items.Add(LVI);
                        }
                    }
                    break; // ready
                case 1:
                    {
                        Clean_договора();
                        listView_договора.Items.Clear();

                        Договора договора = MySerializer.DeserializerXML_договора();
                        for (int i = 0; i < договора.договора.Count; i++)
                        {
                            ListViewItem LVI = new ListViewItem(договора.договора[i].Идентификатор);
                            LVI.Tag = договора.договора[i];
                            listView_договора.Items.Add(LVI);
                        }
                    }
                    break; // ready
                case 2:
                    {
                        
                    }
                    break; // ready
                case 3:
                    {
                        Clean_ПМО();
                        listView_ПМО.Items.Clear();
                        flowLayoutPanel_ПМО_условия.Controls.Clear();
                        flowLayoutPanel_ПМО_факторы.Controls.Clear();

                        ПериодическиеМедОсмотры периодическиеМедОсмотры = MySerializer.DeserializerXML_ПМО();
                        for (int i = 0; i < периодическиеМедОсмотры.listПМО.Count; i++)
                        {
                            ListViewItem LVI = new ListViewItem(периодическиеМедОсмотры.listПМО[i].Идентификатор);
                            LVI.Tag = периодическиеМедОсмотры.listПМО[i];
                            listView_ПМО.Items.Add(LVI);
                        }
                    }
                    break; // ready
                case 4:
                    {
                        
                    }
                    break;
                case 5:
                    {
                        Clean_сотрудники();
                        listView_сотрудники.Items.Clear();

                        Сотрудники сотрудники = MySerializer.DeserializerXML_сотрудники();
                        for (int i = 0; i < сотрудники.сотрудники.Count; i++)
                        {
                            ListViewItem LVI = new ListViewItem(сотрудники.сотрудники[i].Идентификатор);
                            LVI.Tag = сотрудники.сотрудники[i];
                            listView_сотрудники.Items.Add(LVI);
                        }
                    }
                    break;
                case 6:
                    {
                        Clean_Трудоустройства();
                        listView_трудоустройства.Items.Clear();
                        flowLayoutPanel_трудоустройства_условия.Controls.Clear();
                        flowLayoutPanel_трудоустройства_факторы.Controls.Clear();

                        ПредварительныеМедОсмотры предварительныеМедОсмотры = MySerializer.DeserializerXML_ПредМО();
                        for (int i = 0; i < предварительныеМедОсмотры.listТрудоустройства.Count; i++)
                        {
                            ListViewItem LVI = new ListViewItem(предварительныеМедОсмотры.listТрудоустройства[i].Идентификатор);
                            LVI.Tag = предварительныеМедОсмотры.listТрудоустройства[i];
                            listView_трудоустройства.Items.Add(LVI);
                        }
                    }
                    break;
            }
        }

        // Блок Контрагентов
        //
        private void createNew_контрагент_подразделение(decimal count)
        {
            list_контрагенты_подразделения_уид.Clear(); // Очищаем листы, чтобы записать элементы по новой
            list_контрагенты_подразделения_код.Clear();
            list_контрагенты_подразделения_наименование.Clear();

            flowLayoutPanel_контрагенты.Controls.Clear(); // Очищаем поле, чтобы создать элементы по новой

            for (int i = 0; i < count; i++)
            {
                Label Title = new Label()
                {
                    Text = "Подразделение_" + (i + 1),
                    BackColor = Color.Tan,
                    Width = 570,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };

                Label label_Уид = new Label()
                {
                    Text = "УидПодразделения",
                    Width = 165

                };
                TextBox textBox_Уид = new TextBox()
                {
                    Width = 400
                };
                list_контрагенты_подразделения_уид.Add(textBox_Уид);

                Button button_уид = new Button()
                {
                    Tag = i,
                    Text = "Генерация",
                    BackColor = Color.FromArgb(224, 224, 224)
                };
                button_уид.Click += button_контрагенты_подразделения_randGUID_Click;
                button_уид.Font = new Font("Times New Roman", 9.75F);

                Label label_Код = new Label()
                {
                    Text = "Код",
                    Width = 165
                };
                TextBox textBox_Код = new TextBox()
                {
                    Width = 400,
                };
                list_контрагенты_подразделения_код.Add(textBox_Код);

                Label label_Наименование = new Label()
                {
                    Text = "Наименование",
                    Width = 165
                };
                TextBox textBox_Наименование = new TextBox()
                {
                    Width = 400,
                };
                list_контрагенты_подразделения_наименование.Add(textBox_Наименование);

                flowLayoutPanel_контрагенты.Controls.Add(Title);
                flowLayoutPanel_контрагенты.Controls.Add(label_Уид);
                flowLayoutPanel_контрагенты.Controls.Add(list_контрагенты_подразделения_уид[i]);
                flowLayoutPanel_контрагенты.Controls.Add(button_уид);
                flowLayoutPanel_контрагенты.Controls.Add(label_Код);
                flowLayoutPanel_контрагенты.Controls.Add(list_контрагенты_подразделения_код[i]);
                flowLayoutPanel_контрагенты.Controls.Add(label_Наименование);
                flowLayoutPanel_контрагенты.Controls.Add(list_контрагенты_подразделения_наименование[i]);
            }
        } // Функция добавления подразделений
        private void numericUpDown_контрагенты_ValueChanged(object sender, EventArgs e) // Динамическое добавление "Подразделений" на панель
        {
            createNew_контрагент_подразделение(numericUpDown_контрагенты.Value);
        }
        private void listView_контрагенты_SelectedIndexChanged(object sender, EventArgs e) // Нажатие на экземпляр в ListView
        {
            if (listView_контрагенты.SelectedItems.Count == 1)
            {
                Контрагент контрагент = (Контрагент)listView_контрагенты.SelectedItems[0].Tag;
                textBox_контрагенты_уид.Text = контрагент.УидКонтрагента;
                textBox_контрагенты_ИНН.Text = контрагент.Инн;
                textBox_контрагенты_КПП.Text = контрагент.Кпп;
                textBox_контрагенты_ОГРН.Text = контрагент.Огрн;
                textBox_контрагенты_ОКПО.Text = контрагент.Окпо;
                textBox_контрагенты_ЮрАдрес.Text = контрагент.ЮридическийАдрес;
                textBox_контрагенты_названиеОрганизации.Text = контрагент.НазваниеОрганизации;
                textBox_контрагенты_телефон.Text = контрагент.ТелефонОрганизации;
                textBox_контрагенты_почта.Text = контрагент.ПочтаОрганизации;

                numericUpDown_контрагенты.Value = контрагент.поздразделения.подразделения.Count;

                createNew_контрагент_подразделение(контрагент.поздразделения.подразделения.Count);

                for (int i = 0; i < контрагент.поздразделения.подразделения.Count; i++)
                {
                    list_контрагенты_подразделения_уид[i].Text = контрагент.поздразделения.подразделения[i].УидПодразделения;
                    list_контрагенты_подразделения_код[i].Text = контрагент.поздразделения.подразделения[i].Код;
                    list_контрагенты_подразделения_наименование[i].Text = контрагент.поздразделения.подразделения[i].Наименование;
                }
            }
            else if (listView_контрагенты.SelectedItems.Count == 0)
            {
                Clean_контрагенты();
            }
        }
        private void button_randGUID_контрагенты_Click(object sender, EventArgs e) // Рандомайзер GUID
        {
            textBox_контрагенты_уид.Text = Guid.NewGuid().ToString();
        }
        private void button_контрагенты_add_Click(object sender, EventArgs e) // Добавление или изменение экземпляра "Контрагент" в лист, для формирования полноценного файла
        {
            Подразделения подразделения = new Подразделения();
            for (int i = 0; i < list_контрагенты_подразделения_уид.Count; i++)
            {
                Подразделение подразделение = new Подразделение(
                    list_контрагенты_подразделения_уид[i].Text,
                    list_контрагенты_подразделения_код[i].Text,
                    list_контрагенты_подразделения_наименование[i].Text);

                подразделения.подразделения.Add(подразделение);
            } // Создаем подразделения через список

            Контрагент контрагент = new Контрагент(
                textBox_контрагенты_уид.Text, textBox_контрагенты_ИНН.Text,
                textBox_контрагенты_КПП.Text, textBox_контрагенты_ОГРН.Text,
                textBox_контрагенты_ОКПО.Text, textBox_контрагенты_ЮрАдрес.Text,
                textBox_контрагенты_названиеОрганизации.Text,
                textBox_контрагенты_телефон.Text, textBox_контрагенты_почта.Text,
                подразделения);

            if (listView_контрагенты.SelectedItems.Count == 1 && textBox_контрагенты_уид.Text == listView_контрагенты.SelectedItems[0].Text)
            {
                listView_контрагенты.SelectedItems[0].BackColor = Color.Khaki;
                listView_контрагенты.SelectedItems[0].Tag = контрагент;
            } // Сверяем GUID нового и выбранного экземпляра
            else
            {
                ListViewItem LVI = new ListViewItem(контрагент.УидКонтрагента);
                LVI.Tag = контрагент;
                LVI.BackColor = Color.Khaki;
                listView_контрагенты.Items.Add(LVI);
            }

            Clean_контрагенты();
        }
        private void button_контрагенты_serialize_Click(object sender, EventArgs e)  // Сериализация списка "Контрагентов" в XML структуру
        {
            Контрагенты контрагенты = new Контрагенты();

            foreach (ListViewItem item in listView_контрагенты.Items)
            {
                if (item.Tag != null)
                {
                    item.BackColor = Color.Empty;
                    контрагенты.контрагенты.Add((Контрагент)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Контрагенты.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(контрагенты));
                sw.Close();
            }

            richTextBox_контрагенты.Text = MySerializer.SerializerXML(контрагенты);
        }
        private void button_контрагенты_загрузить_Click(object sender, EventArgs e)
        {

        }
        private void button_контрагенты_подразделения_randGUID_Click(object sender, EventArgs e) // Рандомайзер GUID для динамических элементов
        {
            list_контрагенты_подразделения_уид[(int)((Button)sender).Tag].Text = Guid.NewGuid().ToString();
        }
        private void Clean_контрагенты() // Очищение полей ввода, обнуление счетчика, текстового поля
        {
            textBox_контрагенты_уид.Text = string.Empty;
            textBox_контрагенты_ИНН.Text = string.Empty;
            textBox_контрагенты_КПП.Text = string.Empty;
            textBox_контрагенты_ОГРН.Text = string.Empty;
            textBox_контрагенты_ОКПО.Text = string.Empty;
            textBox_контрагенты_ЮрАдрес.Text = string.Empty;
            textBox_контрагенты_названиеОрганизации.Text = string.Empty;
            textBox_контрагенты_телефон.Text = string.Empty;
            textBox_контрагенты_почта.Text = string.Empty;
            numericUpDown_контрагенты.Value = 0;
            richTextBox_контрагенты.Text = string.Empty;
            listView_контрагенты.SelectedItems.Clear();
        }

        // Блок Сотрудников
        //
        private void listView_сотрудники_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_сотрудники.SelectedItems.Count == 1)
            {
                Сотрудник сотрудник = (Сотрудник)listView_сотрудники.SelectedItems[0].Tag;
                textBox_сотрудники_идентификатор.Text = сотрудник.Идентификатор;
                textBox_сотрудники_Уид.Text = сотрудник.УидКонтрагента;
                textBox_сотрудники_снилс.Text = сотрудник.Снилс;
                textBox_сотрудники_фамилия.Text = сотрудник.Фамилия;
                textBox_сотрудники_имя.Text = сотрудник.Имя;
                textBox_сотрудники_отчество.Text = сотрудник.Отчество;
                textBox_сотрудники_пол.Text = сотрудник.Пол;
                textBox_сотрудники_ДатаРождения.Text = сотрудник.ДатаРождения;
                textBox_сотрудники_ДатаНачалаРаботы.Text = сотрудник.ДатаНачалаРаботы;
                textBox_сотрудники_КодПодразделения.Text = сотрудник.КодПодразделения;
                textBox_сотрудники_ИдентификаторДолжности.Text = сотрудник.ИдентификаторДолжности;
            }
            else if (listView_сотрудники.SelectedItems.Count == 0)
            {
                Clean_сотрудники();
            }
        }
        private void button_randGUID_сотрудники_Click(object sender, EventArgs e) // Рандомайзер GUID
        {
            textBox_сотрудники_идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_сотрудники_add_Click(object sender, EventArgs e)
        {
            Сотрудник сотрудник = new Сотрудник(
                textBox_сотрудники_идентификатор.Text, textBox_контрагенты_уид.Text,
                textBox_сотрудники_снилс.Text, textBox_сотрудники_фамилия.Text,
                textBox_сотрудники_имя.Text, textBox_сотрудники_отчество.Text,
                textBox_сотрудники_пол.Text, textBox_сотрудники_ДатаРождения.Text,
                textBox_сотрудники_ДатаНачалаРаботы.Text, textBox_сотрудники_КодПодразделения.Text,
                textBox_сотрудники_ИдентификаторДолжности.Text);

            if (listView_сотрудники.SelectedItems.Count == 1 && textBox_сотрудники_идентификатор.Text == listView_сотрудники.SelectedItems[0].Text)
            {
                listView_сотрудники.SelectedItems[0].BackColor = Color.Khaki;
                listView_сотрудники.SelectedItems[0].Tag = сотрудник;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(сотрудник.Идентификатор);
                LVI.Tag = сотрудник;
                listView_сотрудники.Items.Add(LVI);
            }
        }
        private void button_сотрудники_serialize_Click(object sender, EventArgs e)
        {
            Сотрудники сотрудники = new Сотрудники();

            foreach (ListViewItem item in listView_сотрудники.Items)
            {
                if (item.Tag != null)
                {
                    сотрудники.сотрудники.Add((Сотрудник)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Сотрудники.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(сотрудники));
                sw.Close();
            }

            richTextBox_сотрудники.Text = MySerializer.SerializerXML(сотрудники);
        }
        private void Clean_сотрудники()
        {
            textBox_сотрудники_идентификатор.Text = string.Empty;
            textBox_сотрудники_Уид.Text = string.Empty;
            textBox_сотрудники_снилс.Text = string.Empty;
            textBox_сотрудники_фамилия.Text = string.Empty;
            textBox_сотрудники_имя.Text = string.Empty;
            textBox_сотрудники_отчество.Text = string.Empty;
            textBox_сотрудники_пол.Text = string.Empty;
            textBox_сотрудники_ДатаРождения.Text = string.Empty;
            textBox_сотрудники_ДатаНачалаРаботы.Text = string.Empty;
            textBox_сотрудники_КодПодразделения.Text = string.Empty;
            textBox_сотрудники_ИдентификаторДолжности.Text = string.Empty;
            richTextBox_сотрудники.Text = string.Empty;
            listView_сотрудники.SelectedItems.Clear();
        }

        // Блок Договоров 
        //
        private void createNew_договор_услуга(decimal count)
        {
            list_договора_услуги.Clear();
            flowLayoutPanel_договора.Controls.Clear();

            for (int i = 0; i < numericUpDown_договора.Value; i++)
            {
                TextBox услуга = new TextBox()
                {
                    Width = 282,
                    Tag = i
                };
                list_договора_услуги.Add(услуга);
                Label label = new Label()
                {
                    Margin = new Padding(3, 6, 3, 3),
                    Text = "Услуга_" + (i + 1),
                    Width = 87
                };

                flowLayoutPanel_договора.Controls.Add(list_договора_услуги[i]);
                flowLayoutPanel_договора.Controls.Add(label);
            }
        }
        private void numericUpDown_договора_ValueChanged(object sender, EventArgs e)
        {
            createNew_договор_услуга(numericUpDown_договора.Value);
        }
        private void listView_договора_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_договора.SelectedItems.Count == 1)
            {
                Договор договор = (Договор)listView_договора.SelectedItems[0].Tag;
                textBox_договора_идентификатор.Text = договор.Идентификатор;
                textBox_договора_уид.Text = договор.УидКонтрагента;
                textBox_договора_Код.Text = договор.КодПодразделения;
                textBox_договора_номер.Text = договор.Номер;
                textBox_договора_заключение.Text = договор.ДатаЗаключения;
                textBox_договора_окончание.Text = договор.ДатаОкончания;
                textBox_договора_допустимое.Text = договор.ДопустимоеКоличествоОсмотров;
                textBox_договора_пройденое.Text = договор.ПройденоеКоличествоОсмотров;
                textBox_договора_общая.Text = договор.ОбщаяСуммаПоДоговору;
                textBox_договора_израсходованная.Text = договор.ИзрасходованнаяСуммаПоДоговору;
                textBox_договора_доп.Text = договор.ДополнительныеСоглашения;
                textBox_договора_фамилия.Text = договор.Куратор.Фамилия;
                textBox_договора_имя.Text = договор.Куратор.Имя;
                textBox_договора_отчество.Text = договор.Куратор.Отчество;
                textBox_договора_идентификаторДолжности.Text = договор.Куратор.ИдентификаторДолжности;
                textBox_договора_почта.Text = договор.Куратор.ЭлектроннаяПочта;
                textBox_договора_телефон.Text = договор.Куратор.Телефон;

                numericUpDown_договора.Value = договор.Услуги.услуги.Count;

                createNew_договор_услуга(numericUpDown_договора.Value);

                for (int i = 0; i < numericUpDown_договора.Value; i++)
                {
                    list_договора_услуги[i].Text = договор.Услуги.услуги[i].услуга;
                }
            }
            else if (listView_договора.SelectedItems.Count == 0)
            {
                Clean_договора();
            }
        }
        private void button_randGUID_договора_Click(object sender, EventArgs e) // Рандомайзер GUID
        {
            textBox_договора_идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_договора_add_Click(object sender, EventArgs e)
        {
            Услуги услуги = new Услуги();
            for (int i = 0; i < list_договора_услуги.Count; i++)
            {
                Услуга услуга = new Услуга(list_договора_услуги[i].Text);
                услуги.услуги.Add(услуга);
            }

            Куратор куратор = new Куратор(textBox_договора_фамилия.Text, textBox_договора_имя.Text, textBox_договора_отчество.Text,
               textBox_договора_идентификаторДолжности.Text, textBox_договора_почта.Text, textBox_договора_телефон.Text);      

            Договор newдоговор = new Договор(textBox_договора_идентификатор.Text, textBox_договора_уид.Text, textBox_договора_Код.Text,
                textBox_договора_номер.Text, textBox_договора_заключение.Text, textBox_договора_окончание.Text, textBox_договора_допустимое.Text,
                textBox_договора_пройденое.Text, textBox_договора_общая.Text, textBox_договора_израсходованная.Text, услуги, textBox_договора_доп.Text, куратор);

            if (listView_договора.SelectedItems.Count == 1 && textBox_договора_идентификатор.Text == listView_договора.SelectedItems[0].Text)
            {
                listView_договора.SelectedItems[0].BackColor = Color.Khaki;
                listView_договора.SelectedItems[0].Tag = newдоговор;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(newдоговор.Идентификатор);
                LVI.Tag = newдоговор;
                listView_договора.Items.Add(LVI);
            }

            Clean_договора();
        }
        private void button_договора_serializer_Click(object sender, EventArgs e)
        {
            Договора договора = new Договора();

            foreach (ListViewItem item in listView_договора.Items)
            {
                if (item.Tag != null)
                {
                    договора.договора.Add((Договор)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Договора.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(договора));
                sw.Close();
            }

            richTextBox_договора.Text = MySerializer.SerializerXML(договора);
        }
        private void Clean_договора()
        {
            textBox_договора_идентификатор.Text = string.Empty;
            textBox_договора_уид.Text = string.Empty;
            textBox_договора_Код.Text = string.Empty;
            textBox_договора_номер.Text = string.Empty;
            textBox_договора_заключение.Text = string.Empty;
            textBox_договора_окончание.Text = string.Empty;
            textBox_договора_допустимое.Text = string.Empty;
            textBox_договора_пройденое.Text = string.Empty;
            textBox_договора_общая.Text = string.Empty;
            textBox_договора_израсходованная.Text = string.Empty;
            textBox_договора_доп.Text = string.Empty;
            textBox_договора_фамилия.Text = string.Empty;
            textBox_договора_имя.Text = string.Empty;
            textBox_договора_отчество.Text = string.Empty;
            textBox_договора_идентификаторДолжности.Text = string.Empty;
            textBox_договора_почта.Text = string.Empty;
            textBox_договора_телефон.Text = string.Empty;
            numericUpDown_договора.Value = 0;
            richTextBox_договора.Text = string.Empty;
            listView_договора.SelectedItems.Clear();
        }

        // Блок ПМО
        //
        private void createNew_ПМО_условие(decimal count)
        {
            list_ПМО_условия_код.Clear();
            list_ПМО_условия_наименование.Clear();
            flowLayoutPanel_ПМО_условия.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Label заголовок = new Label()
                {
                    Text = "Условие_" + (i + 1),
                    BackColor = Color.Tan,
                    Width = 400,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                };
                Label label_код = new Label()
                {
                    Text = "Код",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_код = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };
                Label label_наименование = new Label()
                {
                    Text = "Наименование",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_наименование = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };

                list_ПМО_условия_код.Add(textBox_код);
                list_ПМО_условия_наименование.Add(textBox_наименование);

                flowLayoutPanel_ПМО_условия.Controls.Add(заголовок);
                flowLayoutPanel_ПМО_условия.Controls.Add(label_код);
                flowLayoutPanel_ПМО_условия.Controls.Add(list_ПМО_условия_код[i]);
                flowLayoutPanel_ПМО_условия.Controls.Add(label_наименование);
                flowLayoutPanel_ПМО_условия.Controls.Add(list_ПМО_условия_наименование[i]);
            }
        }
        private void createNew_ПМО_фактор(decimal count)
        {
            list_ПМО_факторы_код.Clear();
            list_ПМО_факторы_наименование.Clear();
            flowLayoutPanel_ПМО_факторы.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Label заголовок = new Label()
                {
                    Text = "Фактор_" + (i + 1),
                    BackColor = Color.Tan,
                    Width = 400,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                };
                Label label_код = new Label()
                {
                    Text = "Код",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_код = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };
                Label label_наименование = new Label()
                {
                    Text = "Наименование",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_наименование = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };

                list_ПМО_факторы_код.Add(textBox_код);
                list_ПМО_факторы_наименование.Add(textBox_наименование);

                flowLayoutPanel_ПМО_факторы.Controls.Add(заголовок);
                flowLayoutPanel_ПМО_факторы.Controls.Add(label_код);
                flowLayoutPanel_ПМО_факторы.Controls.Add(list_ПМО_факторы_код[i]);
                flowLayoutPanel_ПМО_факторы.Controls.Add(label_наименование);
                flowLayoutPanel_ПМО_факторы.Controls.Add(list_ПМО_факторы_наименование[i]);
            }
        }
        private void numericUpDown_ПМО_условия_ValueChanged(object sender, EventArgs e)
        {
            createNew_ПМО_условие(numericUpDown_ПМО_условия.Value);
        }
        private void numericUpDown_ПМО_факторы_ValueChanged(object sender, EventArgs e)
        {
            createNew_ПМО_фактор(numericUpDown_ПМО_факторы.Value);
        }
        private void listView_ПМО_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_ПМО.SelectedItems.Count == 1)
            {
                ПМО пмо = (ПМО)listView_ПМО.SelectedItems[0].Tag;
                textBox_ПМО_Идентификатор.Text = пмо.Идентификатор;
                textBox_ПМО_Уид.Text = пмо.УидСотрудника;
                textBox_ПМО_ИдентификаторДолжности.Text = пмо.ИдентификаторДолжности;
                textBox_ПМО_ИдентификаторПодразделения.Text = пмо.ИдентификаторПодразделения;
                textBox_ПМО_ИдентификаторДоговора.Text = пмо.ИдентификаторДоговора;
                textBox_ПМО_НомерОбращения.Text = пмо.НомерОбращения;
                textBox_ПМО_ДатаОсмотра.Text = пмо.ДатаОсмотра;
                textBox_ПМО_Ограничения.Text = пмо.Ограничения;
                textBox_ПМО_Результат.Text = пмо.Результат;
                textBox_ПМО_ИдентификаторЗдравпункта.Text = пмо.ИдентификаторЗдравпункта;
                textBox_ПМО_Председатель.Text = пмо.Председатель;
                textBox_ПМО_ГруппаРиска.Text = пмо.ГруппаРиска;
                textBox_ПМО_Рекомендации.Text = пмо.Рекомендации;
                textBox_ПМО_СтоимостьУслуг.Text = пмо.СтоимостьУслуг;
                textBox_ПМО_ДатаПрисвоения.Text = пмо.ДатаПрисвоенияГруппыЗдоровья;
                textBox_ПМО_ГруппаЗдоровья.Text = пмо.ГруппаЗдоровья;
                textBox_ПМО_НомерСправки.Text = пмо.справка.НомерСправки;
                textBox_ПМО_ДатаВыдачиСправки.Text = пмо.справка.ДатаВыдачиСправки;
                textBox_ПМО_Файл.Text = пмо.справка.Файл;

                createNew_ПМО_условие(numericUpDown_ПМО_условия.Value);
                createNew_ПМО_фактор(numericUpDown_ПМО_факторы.Value);

                for (int i = 0; i < numericUpDown_ПМО_условия.Value; i++)
                {
                    list_ПМО_условия_код[i].Text = пмо.вредныеУсловия.условия[i].Код;
                    list_ПМО_условия_наименование[i].Text = пмо.вредныеУсловия.условия[i].Наименование;
                }

                for (int i = 0; i < numericUpDown_ПМО_факторы.Value; i++)
                {
                    list_ПМО_факторы_код[i].Text = пмо.вредныеФакторы.факторы[i].Код;
                    list_ПМО_факторы_наименование[i].Text = пмо.вредныеФакторы.факторы[i].Наименование;
                }
            }
            else if (listView_ПМО.SelectedItems.Count == 0)
            {
                Clean_ПМО();
            }
        }
        private void button_randGUID_ПМО_Click(object sender, EventArgs e) // Рандомайзер GUID
        {
            textBox_ПМО_Идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_ПМО_add_Click(object sender, EventArgs e)
        {
            ВредныеУсловия условия = new ВредныеУсловия();
            for (int i = 0; i < list_ПМО_условия_код.Count; i++)
            {
                Условие условие = new Условие(
                    list_ПМО_условия_код[i].Text,
                    list_ПМО_условия_наименование[i].Text);

                условия.условия.Add(условие);
            }

            ВредныеФакторы факторы = new ВредныеФакторы();
            for (int i = 0; i < list_ПМО_факторы_код.Count; i++)
            {
                Фактор фактор = new Фактор(
                    list_ПМО_факторы_код[i].Text,
                    list_ПМО_факторы_наименование[i].Text);

                факторы.факторы.Add(фактор);
            }

            Справка справка = new Справка(textBox_договора_номер.Text, textBox_ПМО_ДатаВыдачиСправки.Text, textBox_ПМО_Файл.Text);

            ПМО пмо = new ПМО(
                textBox_ПМО_Идентификатор.Text, textBox_ПМО_Уид.Text,
                textBox_ПМО_ИдентификаторДолжности.Text, textBox_ПМО_ИдентификаторПодразделения.Text,
                textBox_ПМО_ИдентификаторДоговора.Text, textBox_ПМО_НомерОбращения.Text,
                textBox_ПМО_ДатаОсмотра.Text, textBox_ПМО_Ограничения.Text,
                textBox_ПМО_Результат.Text, textBox_ПМО_ИдентификаторЗдравпункта.Text,
                textBox_ПМО_Председатель.Text, textBox_ПМО_ГруппаРиска.Text,
                textBox_ПМО_Рекомендации.Text, textBox_ПМО_СтоимостьУслуг.Text,
                textBox_ПМО_ДатаПрисвоения.Text, textBox_ПМО_ГруппаЗдоровья.Text,
                условия, факторы, справка);

            if (listView_ПМО.SelectedItems.Count == 1 && textBox_ПМО_Идентификатор.Text == listView_ПМО.SelectedItems[0].Text)
            {
                listView_ПМО.SelectedItems[0].BackColor = Color.Khaki;
                listView_ПМО.SelectedItems[0].Tag = пмо;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(пмо.Идентификатор);
                LVI.Tag = пмо;
                listView_ПМО.Items.Add(LVI);
            }

            Clean_ПМО();
        }
        private void button_ПМО_serialise_Click(object sender, EventArgs e)
        {
            ПериодическиеМедОсмотры listПМО = new ПериодическиеМедОсмотры();

            foreach (ListViewItem item in listView_ПМО.Items)
            {
                if (item.Tag != null)
                {
                    listПМО.listПМО.Add((ПМО)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("ПМО.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(listПМО));
                sw.Close();
            }

            richTextBox_ПМО.Text = MySerializer.SerializerXML(listПМО);
        }
        private void Clean_ПМО()
        {
            textBox_ПМО_Идентификатор.Text = string.Empty;
            textBox_ПМО_Уид.Text = string.Empty;
            textBox_ПМО_ИдентификаторДолжности.Text = string.Empty;
            textBox_ПМО_ИдентификаторПодразделения.Text = string.Empty;
            textBox_ПМО_ИдентификаторДоговора.Text = string.Empty;
            textBox_ПМО_НомерОбращения.Text = string.Empty;
            textBox_ПМО_ДатаОсмотра.Text = string.Empty;
            textBox_ПМО_Ограничения.Text = string.Empty;
            textBox_ПМО_Результат.Text = string.Empty;
            textBox_ПМО_ИдентификаторЗдравпункта.Text = string.Empty;
            textBox_ПМО_Председатель.Text = string.Empty;
            textBox_ПМО_ГруппаРиска.Text = string.Empty;
            textBox_ПМО_Рекомендации.Text = string.Empty;
            textBox_ПМО_СтоимостьУслуг.Text = string.Empty;
            textBox_ПМО_ДатаПрисвоения.Text = string.Empty;
            textBox_ПМО_ГруппаЗдоровья.Text = string.Empty;
            textBox_ПМО_НомерСправки.Text = string.Empty;
            textBox_ПМО_ДатаВыдачиСправки.Text = string.Empty;
            textBox_ПМО_Файл.Text = string.Empty;
            numericUpDown_ПМО_условия.Value = 0;
            numericUpDown_ПМО_факторы.Value = 0;
            richTextBox_ПМО.Text = string.Empty;
            listView_ПМО.SelectedItems.Clear();
        }

        // Блок Трудоустройств
        //
        private void createNew_ПредМО_условие(decimal count)
        {
            list_трудоустройства_условия_код.Clear();
            list_трудоустройства_условия_наименование.Clear();
            flowLayoutPanel_трудоустройства_условия.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Label заголовок = new Label()
                {
                    Text = "Условие_" + (i + 1),
                    BackColor = Color.Tan,
                    Width = 400,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                };
                Label label_код = new Label()
                {
                    Text = "Код",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_код = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };
                Label label_наименование = new Label()
                {
                    Text = "Наименование",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_наименование = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };

                list_трудоустройства_условия_код.Add(textBox_код);
                list_трудоустройства_условия_наименование.Add(textBox_наименование);

                flowLayoutPanel_трудоустройства_условия.Controls.Add(заголовок);
                flowLayoutPanel_трудоустройства_условия.Controls.Add(label_код);
                flowLayoutPanel_трудоустройства_условия.Controls.Add(list_трудоустройства_условия_код[i]);
                flowLayoutPanel_трудоустройства_условия.Controls.Add(label_наименование);
                flowLayoutPanel_трудоустройства_условия.Controls.Add(list_трудоустройства_условия_наименование[i]);
            }
        }
        private void createNew_ПредМО_фактор(decimal count)
        {
            list_трудоустройства_факторы_код.Clear();
            list_трудоустройства_факторы_наименование.Clear();
            flowLayoutPanel_трудоустройства_факторы.Controls.Clear();

            for (int i = 0; i < count; i++)
            {
                Label заголовок = new Label()
                {
                    Text = "Фактор_" + (i + 1),
                    BackColor = Color.Tan,
                    Width = 400,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                };
                Label label_код = new Label()
                {
                    Text = "Код",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_код = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };
                Label label_наименование = new Label()
                {
                    Text = "Наименование",
                    Width = 116,
                    Margin = new Padding(3, 6, 0, 0)
                };
                TextBox textBox_наименование = new TextBox()
                {
                    Width = 280,
                    Tag = i
                };

                list_трудоустройства_факторы_код.Add(textBox_код);
                list_трудоустройства_факторы_наименование.Add(textBox_наименование);

                flowLayoutPanel_трудоустройства_факторы.Controls.Add(заголовок);
                flowLayoutPanel_трудоустройства_факторы.Controls.Add(label_код);
                flowLayoutPanel_трудоустройства_факторы.Controls.Add(list_трудоустройства_факторы_код[i]);
                flowLayoutPanel_трудоустройства_факторы.Controls.Add(label_наименование);
                flowLayoutPanel_трудоустройства_факторы.Controls.Add(list_трудоустройства_факторы_наименование[i]);
            }
        }
        private void numericUpDown_трудоустройства_условия_ValueChanged(object sender, EventArgs e)
        {
            createNew_ПредМО_условие(numericUpDown_трудоустройства_условия.Value);
        }
        private void numericUpDown_трудоустройства_факторы_ValueChanged(object sender, EventArgs e)
        {
            createNew_ПредМО_фактор(numericUpDown_трудоустройства_факторы.Value);
        }
        private void listView_трудоустройства_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_трудоустройства.SelectedItems.Count == 1)
            {
                ПредМО предМо = (ПредМО)listView_трудоустройства.SelectedItems[0].Tag;
                textBox_трудоустройства_Идентификатор.Text = предМо.Идентификатор;
                textBox_трудоустройства_УидКонтрагента.Text = предМо.УидСотрудника;
                textBox_трудоустройства_ИдентификаторДолжности.Text = предМо.ИдентификаторДолжности;
                textBox_трудоустройства_ИдентификаторПодразделения.Text = предМо.ИдентификаторПодразделения;
                textBox_трудоустройства_ИдентификаторДоговора.Text = предМо.ИдентификаторДоговора;
                textBox_трудоустройства_НомерОбращения.Text = предМо.НомерОбращения;
                textBox_трудоустройства_ДатаОсмотра.Text = предМо.ДатаОсмотра;
                textBox_трудоустройства_Ограничения.Text = предМо.Ограничения;
                textBox_трудоустройства_Результат.Text = предМо.Результат;
                textBox_трудоустройства_ИдентификаторЗдравпункта.Text = предМо.ИдентификаторЗдравпункта;
                textBox_трудоустройства_Председатель.Text = предМо.Председатель;
                textBox_трудоустройства_ГруппаРиска.Text = предМо.ГруппаРиска;
                textBox_трудоустройства_Рекомендации.Text = предМо.Рекомендации;
                textBox_трудоустройства_СтоимостьУслуг.Text = предМо.СтоимостьУслуг;
                textBox_трудоустройства_ДатаПрисвоенияГруппыЗдоровья.Text = предМо.ДатаПрисвоенияГруппыЗдоровья;
                textBox_трудоустройства_ГруппаЗдоровья.Text = предМо.ГруппаЗдоровья;
                textBox_трудоустройства_НомерСправки.Text = предМо.справка.НомерСправки;
                textBox_трудоустройства_ДатаВыдачиСправки.Text = предМо.справка.ДатаВыдачиСправки;
                textBox_трудоустройства_Файл.Text = предМо.справка.Файл;
            }
            else if (listView_трудоустройства.SelectedItems.Count == 0)
            {
                Clean_Трудоустройства();
            }
        }
        private void button_randGUID_трудоустройства_Click(object sender, EventArgs e) // Рандомайзер GUID
        {
            textBox_трудоустройства_Идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_трудоустройства_add_Click(object sender, EventArgs e)
        {
            ПредВредныеУсловия условия = new ПредВредныеУсловия();
            for (int i = 0; i < list_трудоустройства_условия_код.Count; i++)
            {
                ПредУсловие условие = new ПредУсловие(
                    list_трудоустройства_условия_код[i].Text,
                    list_трудоустройства_условия_наименование[i].Text);

                условия.условия.Add(условие);
            }

            ПредВредныеФакторы факторы = new ПредВредныеФакторы();
            for (int i = 0; i < list_трудоустройства_факторы_код.Count; i++)
            {
                ПредФактор фактор = new ПредФактор(
                    list_трудоустройства_факторы_код[i].Text,
                    list_трудоустройства_факторы_наименование[i].Text);

                факторы.факторы.Add(фактор);
            }

            ПредСправка справка = new ПредСправка(textBox_трудоустройства_НомерСправки.Text, textBox_трудоустройства_ДатаВыдачиСправки.Text, textBox_трудоустройства_Файл.Text);

            ПредМО пмо = new ПредМО(
                textBox_трудоустройства_Идентификатор.Text, textBox_трудоустройства_УидКонтрагента.Text,
                textBox_трудоустройства_ИдентификаторДолжности.Text, textBox_трудоустройства_ИдентификаторПодразделения.Text,
                textBox_трудоустройства_ИдентификаторДоговора.Text, textBox_трудоустройства_НомерОбращения.Text,
                textBox_трудоустройства_ДатаОсмотра.Text, textBox_трудоустройства_Ограничения.Text,
                textBox_трудоустройства_Результат.Text, textBox_трудоустройства_ИдентификаторЗдравпункта.Text,
                textBox_трудоустройства_Председатель.Text, textBox_трудоустройства_ГруппаРиска.Text,
                textBox_трудоустройства_Рекомендации.Text, textBox_трудоустройства_СтоимостьУслуг.Text,
                textBox_трудоустройства_ДатаПрисвоенияГруппыЗдоровья.Text, textBox_трудоустройства_ГруппаЗдоровья.Text,
                условия, факторы, справка);

            if (listView_трудоустройства.SelectedItems.Count == 1 && textBox_трудоустройства_Идентификатор.Text == listView_трудоустройства.SelectedItems[0].Text)
            {
                listView_трудоустройства.SelectedItems[0].BackColor = Color.Khaki;
                listView_трудоустройства.SelectedItems[0].Tag = пмо;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(пмо.Идентификатор);
                LVI.Tag = пмо;
                listView_трудоустройства.Items.Add(LVI);
            }

            Clean_ПМО();
        }
        private void button_трудоустройства_serialise_Click(object sender, EventArgs e)
        {
            ПредварительныеМедОсмотры listПМО = new ПредварительныеМедОсмотры();

            foreach (ListViewItem item in listView_трудоустройства.Items)
            {
                if (item.Tag != null)
                {
                    listПМО.listТрудоустройства.Add((ПредМО)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Трудоустройства.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(listПМО));
                sw.Close();
            }

            richTextBox_трудоустройства.Text = MySerializer.SerializerXML(listПМО);
        }
        private void Clean_Трудоустройства()
        {
            textBox_трудоустройства_Идентификатор.Text = string.Empty;
            textBox_трудоустройства_УидКонтрагента.Text = string.Empty;
            textBox_трудоустройства_ИдентификаторДолжности.Text = string.Empty;
            textBox_трудоустройства_ИдентификаторПодразделения.Text = string.Empty;
            textBox_трудоустройства_ИдентификаторДоговора.Text = string.Empty;
            textBox_трудоустройства_НомерОбращения.Text = string.Empty;
            textBox_трудоустройства_ДатаОсмотра.Text = string.Empty;
            textBox_трудоустройства_Ограничения.Text = string.Empty;
            textBox_трудоустройства_Результат.Text = string.Empty;
            textBox_трудоустройства_ИдентификаторЗдравпункта.Text = string.Empty;
            textBox_трудоустройства_Председатель.Text = string.Empty;
            textBox_трудоустройства_ГруппаРиска.Text = string.Empty;
            textBox_трудоустройства_Рекомендации.Text = string.Empty;
            textBox_трудоустройства_СтоимостьУслуг.Text = string.Empty;
            textBox_трудоустройства_ДатаПрисвоенияГруппыЗдоровья.Text = string.Empty;
            textBox_трудоустройства_ГруппаЗдоровья.Text = string.Empty;
            textBox_трудоустройства_НомерСправки.Text = string.Empty;
            textBox_трудоустройства_ДатаВыдачиСправки.Text = string.Empty;
            textBox_трудоустройства_Файл.Text = string.Empty;
            numericUpDown_трудоустройства_условия.Value = 0;
            numericUpDown_трудоустройства_факторы.Value = 0;
            richTextBox_трудоустройства.Text = string.Empty;
            listView_трудоустройства.SelectedItems.Clear();
        }

        //Блок Должности
        //
        private void listView_должности_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_должности.SelectedItems.Count == 1)
            {
                Должность должность = (Должность)listView_должности.SelectedItems[0].Tag;
                textBox_должности_идентификатор.Text = должность.Идентификатор;
                textBox_должности_наименование.Text = должность.Наименование;

            }
            else if (listView_должности.SelectedItems.Count == 0)
            {
                Clean_должности();
            }
        }
        private void button_randGUID_должности_Click(object sender, EventArgs e)
        {
            textBox_должности_идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_должности_add_Click(object sender, EventArgs e)
        {
            Должность должность = new Должность(textBox_должности_идентификатор.Text, textBox_должности_наименование.Text);

            if (listView_должности.SelectedItems.Count == 1 && textBox_должности_идентификатор.Text == listView_должности.SelectedItems[0].Text)
            {
                listView_должности.SelectedItems[0].BackColor = Color.Khaki;
                listView_должности.SelectedItems[0].Tag = должность;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(должность.Идентификатор);
                LVI.Tag = должность;
                listView_должности.Items.Add(LVI);
            }

            Clean_должности();
        }
        private void button_должности_serialize_Click(object sender, EventArgs e)
        {
            Должности должности = new Должности();

            foreach (ListViewItem item in listView_должности.Items)
            {
                if (item.Tag != null)
                {
                    должности.должности.Add((Должность)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Должности.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(должности));
                sw.Close();
            }

            richTextBox_должности.Text = MySerializer.SerializerXML(должности);
        }
        private void Clean_должности()
        {
            textBox_должности_идентификатор.Text = string.Empty;
            textBox_должности_наименование.Text = string.Empty;
            listView_должности.Items.Clear();
            richTextBox_должности.Text = string.Empty;
        }

        //Блок Здравпункты
        //
        private void listView_здравпункты_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_здравпункты.SelectedItems.Count == 1)
            {
                Здравпункт здравпункт = (Здравпункт)listView_здравпункты.SelectedItems[0].Tag;
                textBox_здравпункты_идентификатор.Text = здравпункт.Идентификатор;
                textBox_здравпункты_наименование.Text = здравпункт.Наименование;

            }
            else if (listView_здравпункты.SelectedItems.Count == 0)
            {
                Clean_здравпункты();
            }
        }
        private void button_randGUID_здравпункты_Click(object sender, EventArgs e)
        {
            textBox_здравпункты_идентификатор.Text = Guid.NewGuid().ToString();
        }
        private void button_здравпункты_add_Click(object sender, EventArgs e)
        {
            Здравпункт здравпункт = new Здравпункт(textBox_здравпункты_идентификатор.Text, textBox_здравпункты_наименование.Text);

            if (listView_здравпункты.SelectedItems.Count == 1 && textBox_здравпункты_идентификатор.Text == listView_здравпункты.SelectedItems[0].Text)
            {
                listView_здравпункты.SelectedItems[0].BackColor = Color.Khaki;
                listView_здравпункты.SelectedItems[0].Tag = здравпункт;
            }
            else
            {
                ListViewItem LVI = new ListViewItem(здравпункт.Идентификатор);
                LVI.Tag = здравпункт;
                listView_здравпункты.Items.Add(LVI);
            }

            Clean_здравпункты();
        }
        private void button_здравпункты_serialize_Click(object sender, EventArgs e)
        {
            Здравпункты здравпункты = new Здравпункты();

            foreach (ListViewItem item in listView_здравпункты.Items)
            {
                if (item.Tag != null)
                {
                    здравпункты.здравпункты.Add((Здравпункт)item.Tag);
                }
            }

            using (StreamWriter sw = new StreamWriter(new FileStream("Здравпункты.xml", FileMode.Create)))
            {
                sw.Write(MySerializer.SerializerXML(здравпункты));
                sw.Close();
            }

            richTextBox_здравпункты.Text = MySerializer.SerializerXML(здравпункты);
        }
        private void Clean_здравпункты()
        {
            textBox_здравпункты_идентификатор.Text = string.Empty;
            textBox_здравпункты_наименование.Text = string.Empty;
            listView_здравпункты.Items.Clear();
            richTextBox_здравпункты.Text = string.Empty;
        }
    }
}