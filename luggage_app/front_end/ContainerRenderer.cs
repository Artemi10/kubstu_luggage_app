using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
     public class ContainerRenderer
    {
        private readonly DataGridView _dataGridView;
        private readonly LuggageContainer _container;

        public ContainerRenderer(DataGridView dataGridView, LuggageContainer container)
        {
            _dataGridView = dataGridView;
            _container = container;
        }
        
        public ContainerRenderer(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
            _container = new LuggageContainer();
        }

        public double MaxWeight => _container.MaxWeight;

        public DataGridViewRow SelectedRow
        {
            get
            {
                for (var i = 0; i < _dataGridView.RowCount; i++)
                {
                    var row = _dataGridView.Rows[i];
                    if (row.Selected) return row;
                }
                return null;
            }
        }

        public int RowSize => _dataGridView.RowCount;

        public void AddRow(Luggage luggage)
        {
            _container.Add(luggage);
            Render(_container.LuggageList);
        }

        public void RemoveRow(int id)
        {
            _container.Remove(id);
            Render(_container.LuggageList);
        }

        public void UpdateRow(int id, Luggage luggage)
        {
            _container.Update(id, luggage);
            Render(_container.LuggageList);
        }

        private void Render(List<(int, Luggage)> luggageList)
        {
            _dataGridView.Rows.Clear();
            foreach (var row in luggageList.Select(pair => new[]
            {
                pair.Item1.ToString(),
                pair.Item2.PassengerSurname,
                pair.Item2.Code,
                pair.Item2.ItemsAmount.ToString(),
                pair.Item2.Weight.ToString()
            }))
            {
                _dataGridView.Rows.Add(row);
            }
            for (var i = 0; i < _dataGridView.RowCount; i++)
            {
                _dataGridView.Rows[i].ReadOnly = true;
            }
        }
    }
}