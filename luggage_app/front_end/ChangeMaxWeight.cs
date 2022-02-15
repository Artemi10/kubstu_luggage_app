using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class ChangeMaxWeight : Form
    {
        private readonly LuggageContainer _container;
        public ChangeMaxWeight(LuggageContainer container)
        {
            _container = container;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var newMaxWeight = Convert.ToDouble(textBox1.Text);
                _container.MaxWeight = newMaxWeight;
                Close();
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }
    }
}