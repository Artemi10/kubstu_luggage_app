using System;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
    public partial class LuggageTable : Form
    {
        private readonly ContainerRenderer _luggageTableRenderer;
        private readonly LuggageContainer _luggageContainer;
        public LuggageTable()
        {
            InitializeComponent();
            _luggageTableRenderer = new ContainerRenderer(dataGridView1);
            _luggageContainer = new LuggageContainer();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddNewLuggage(_luggageContainer, _luggageTableRenderer).ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = _luggageTableRenderer.SelectedRow;
            if (row != null && _luggageTableRenderer.RowSize > 1)
            {
                new UpdateLuggage(_luggageContainer, _luggageTableRenderer, row).ShowDialog();
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
                    var id = Convert.ToInt32(row.Cells[0].Value);
                    _luggageContainer.Remove(id);
                    _luggageTableRenderer.Render(_luggageContainer.LuggageList);
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
        
        private void отчёт1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Analytics(_luggageContainer, _luggageTableRenderer).ShowDialog();
        }

        private void отчёт2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Analytics2(_luggageContainer).ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ChangeMaxWeight(_luggageContainer).ShowDialog();
        }
    }
}