using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class Analytics : Form
    {
        private readonly ContainerRenderer _renderer;
        private readonly LuggageContainer _container;
        public Analytics(LuggageContainer container, ContainerRenderer renderer)
        {
            _renderer = renderer;
            _container = container;
            InitializeComponent();
            new ContainerRenderer(dataGridView1).Render(_container.LuggageWithOverWeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _container.RemoveOverWeight();
            _renderer.Render(_container.LuggageList);
            Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var changeMaxItemsAmount = new ChangeMaxItemsAmount(_container);
            changeMaxItemsAmount.Closed += (_, _) => 
                label2.Text = $"Число владельцев с количеством вещей больше {_container.MaxItemsAmount} равно {_container.GetPassengerAmountWithMaxItemsAmount()}";
            changeMaxItemsAmount.ShowDialog();
        }
    }
}