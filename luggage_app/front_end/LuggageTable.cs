using System;
using System.Windows.Forms;

namespace luggage_app.front_end
{
    public partial class LuggageTable : Form
    {
        private readonly ContainerRenderer _luggageTableRenderer;
        public LuggageTable()
        {
            InitializeComponent();
            _luggageTableRenderer = new ContainerRenderer(dataGridView1);
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddNewLuggage(_luggageTableRenderer).ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = _luggageTableRenderer.SelectedRow;
            if (row != null && _luggageTableRenderer.RowSize > 1)
            {
                new UpdateLuggage(_luggageTableRenderer, row).ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберете необходимую запись");
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = _luggageTableRenderer.SelectedRow;
            if (row != null && _luggageTableRenderer.RowSize > 1)
            {
                try
                {
                    _luggageTableRenderer.RemoveRow(Convert.ToInt32(row.Cells[0].Value));
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберете необходимую запись");
            }
        }
    }
}