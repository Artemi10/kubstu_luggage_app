using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class Analytics2 : Form
    {
        private readonly ContainerRenderer _render;
        private readonly LuggageContainer _container;
        public double WeightDelta;
        public Analytics2(LuggageContainer container)
        {
            _container = container;
            WeightDelta = 5.0;
            InitializeComponent();
            _render = new ContainerRenderer(dataGridView1);
            _render.Render(_container.GetLuggageWhereAverageWeightInRange(WeightDelta));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ChangeWeightDelta(this);
            form.Closed += (_, _) =>
            {
                _render.Render(_container.GetLuggageWhereAverageWeightInRange(WeightDelta));
                label1.Text = $"Багаж, средний вес одной вещи которого отличается не более чем на {WeightDelta.ToString("0.##")} кг от общего среднего веса";
            };
            form.ShowDialog();
        }
    }
}