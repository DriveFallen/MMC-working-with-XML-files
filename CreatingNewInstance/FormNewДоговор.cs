using SerializerXML.XMLClasses;
using System;
using System.Windows.Forms;

namespace SerializerXML.CreatingNewInstance
{
    public partial class FormNewДоговор : Form
    {
        public FormMain formMain;
        public FormNewДоговор(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void FormNewДоговор_Load(object sender, EventArgs e)
        {
            foreach (ListViewItem item in formMain.listView_контрагенты.Items)
            {
                comboBox_контрагент.Items.Add(((Контрагент)item.Tag).НазваниеОрганизации);
            }

            textBox_идентификатор.Text = Guid.NewGuid().ToString().ToUpper();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}