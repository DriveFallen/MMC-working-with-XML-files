using System;
using System.Windows.Forms;

namespace SerializerXML.CreatingNewInstance
{
    public partial class FormNewКонтрагент : Form
    {
        public FormNewКонтрагент()
        {
            InitializeComponent();
        }

        private void FormNewКонтрагент_Load(object sender, EventArgs e)
        {
            textBox_уид.Text = Guid.NewGuid().ToString().ToUpper();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
