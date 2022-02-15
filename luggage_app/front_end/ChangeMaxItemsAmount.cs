using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class ChangeMaxItemsAmount : Form
    {
        private readonly LuggageContainer _container;

        public ChangeMaxItemsAmount(LuggageContainer container)
        {
            _container = container;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var newMaxItemAmount = Convert.ToInt32(textBox1.Text);
                _container.MaxItemsAmount = newMaxItemAmount;
                Close();
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }
    }
}