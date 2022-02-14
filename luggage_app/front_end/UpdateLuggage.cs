using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class UpdateLuggage : Form
    {
        private readonly ContainerRenderer _containerRenderer;
        private readonly int _id;

        public UpdateLuggage(ContainerRenderer containerRenderer, DataGridViewRow luggageRow)
        {
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
                var weight = Convert.ToDouble(textBox3.Text);
                var itemsAmount = Convert.ToInt32(textBox4.Text);
                var luggage = new Luggage(passengerSurname, code, itemsAmount, weight);
                _containerRenderer.UpdateRow(_id, luggage); 
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