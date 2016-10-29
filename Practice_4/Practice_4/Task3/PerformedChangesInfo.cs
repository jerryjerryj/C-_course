using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4.Task3
{
   // or do 1 class with all? 
    abstract class PerformedChangesInfo {}
    class ChangedCell : PerformedChangesInfo
    {
        public int row { get; set; }
        public int column { get; set; }
        public int? changedValue { get; set; }

        public ChangedCell(int row, int column, int? changedValue)
        {
            this.row = row;
            this.column = column;
            this.changedValue = changedValue;
        }
    }
    abstract class ChangedField : PerformedChangesInfo
    {
        public int insertedFieldIndex { get; set; }
        public ChangedField(int insertedFieldIndex)
        {
            this.insertedFieldIndex = insertedFieldIndex;
        }
    }
    class ChangedRowField : ChangedField
    {
        public ChangedRowField(int insertedFieldIndex)
            : base(insertedFieldIndex) { }        
    }
    class ChangedColumnField : ChangedField
    {
        public ChangedColumnField(int insertedFieldIndex)
            : base(insertedFieldIndex) { }
    }
}
