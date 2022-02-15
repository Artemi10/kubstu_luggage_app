using System;
using System.Windows.Forms;

namespace luggage_app.front_end
{
    public partial class ChangeWeightDelta : Form
    {
        private readonly Analytics2 _analytics2;
        
        public ChangeWeightDelta(Analytics2 analytics2)
        {
            _analytics2 = analytics2;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var averageWeight = Convert.ToDouble(textBox1.Text);
                if (averageWeight >= 0)
                {
                    _analytics2.WeightDelta = averageWeight;
                    Close();
                }
                else
                {
                    MessageBox.Show("Данные введены неверно");
                }
            }
            catch
            {
                MessageBox.Show("Данные введены неверно");
            }
        }
    }
}