using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class AddNewLuggage : Form
    {
        private readonly LuggageContainer _container;
        private readonly ContainerRenderer _luggageTableRenderer;

        public AddNewLuggage(LuggageContainer container, ContainerRenderer luggageTableRenderer)
        {
            _container = container;
            _luggageTableRenderer = luggageTableRenderer;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var passengerSurname = textBox1.Text;
                var code = textBox2.Text;
                var weight = Convert.ToDouble(textBox3.Text);
                var itemsAmount = Convert.ToInt32(textBox4.Text);
                var luggage = new Luggage(passengerSurname, code, itemsAmount, weight);
                _container.Add(luggage);
                _luggageTableRenderer.Render(_container.LuggageList);
                reset_Form();
            }
            catch (LuggageException exception)
            {
                MessageBox.Show(exception.Message);
            }
            catch 
            {
                MessageBox.Show("Данные введены неверно");
            }
        }

        private void reset_Form()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}