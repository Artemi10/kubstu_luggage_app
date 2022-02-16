using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using luggage_app.back_end;

namespace luggage_app.front_end
{
     public class ContainerRenderer
    {
        private readonly DataGridView _dataGridView;
         
        public ContainerRenderer(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }
        
        public int RowSize => _dataGridView.RowCount;
        
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

        public void Render(List<(int, Luggage)> luggageList)
        {
            _dataGridView.Rows.Clear();
            var rows = luggageList
                .Select(pair =>
                    new object[]
                    {
                        pair.Item1,
                        pair.Item2.PassengerSurname,
                        pair.Item2.Code,
                        pair.Item2.Weight,
                        pair.Item2.ItemsAmount
                    }).ToArray();
            for (var i = 0; i < rows.Length; i++)
            {
                _dataGridView.Rows.Add(rows[i]);
                _dataGridView.Rows[i].ReadOnly = true;
            }
        }   
    }
}