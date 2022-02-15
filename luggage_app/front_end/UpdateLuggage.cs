using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class UpdateLuggage : Form
    {
        private readonly LuggageContainer _container;
        private readonly ContainerRenderer _containerRenderer;
        private readonly int _id;

        public UpdateLuggage(LuggageContainer container, ContainerRenderer containerRenderer, DataGridViewRow luggageRow)
        {
            _container = container;
            _containerRenderer = containerRenderer;
            _id = Convert.ToInt32(luggageRow.Cells[0].Value);
            InitializeComponent(luggageRow);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var passengerSurname = textBox1.Text;
                var code = textBox2.Text;
                var weight = Convert.ToDouble(textBox4.Text);
                var itemsAmount = Convert.ToInt32(textBox3.Text);
                var luggage = new Luggage(passengerSurname, code, itemsAmount, weight);
                _container.Update(_id, luggage);
                _containerRenderer.Render(_container.LuggageList);
                Close();
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
    }
}