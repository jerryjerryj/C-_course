using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task3
{
    class DataModel : ObservableDataModel
    {
        private List<List<int?>> table = new List<List<int?>>();

        public void Put(int row, int column, int value)
        {
            if (Check(row, column))
            {
                table[row][column] = value;
                NotifyObserversOnChange(new ChangedCell(row, column, value));
            }
            else NotifyObserversOnError(new ArgumentException("Cell [" + row + ";" + column + "] does not exist"));
            
        }
        private bool Check(int row, int column)
        {
            if (row >= 0 && column >= 0 && table.Count > row && table[row].Count > column)
                return true;
            return false;
        }

        /*OPTIONAL*/
        //public void Put(int row, int column, int value)
        //{
        //    try
        //    {
        //        table[row][column] = value;
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        NotifyObserversOnError(new ArgumentException("Cell [" + row + ";" + column + "] does not exist"));
        //        return;
        //    }
        //    NotifyObserversOnChange(new ChangedCell(row, column, value));
        //}

        public void InsertRow(int rowIndex)
        {
            table.Insert(rowIndex, new List<int?>());

            NotifyObserversOnChange(new ChangedRowField(rowIndex));
        }
        public void InsertColumn(int columnIndex)
        {
            foreach (var t in table)
                t.Insert(columnIndex, null);
            NotifyObserversOnChange(new ChangedColumnField(columnIndex));
        }
        public int? Get(int row, int column)
        {
            return table[row][column];
        }
    }
}
