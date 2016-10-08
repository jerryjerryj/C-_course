using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    public class History
    { 
       public Coordinates coordinates;
       public int value;
       public History(Coordinates coordinates, int value)
       {
           this.coordinates = coordinates;
           this.value = value;
       }
        
    }
    public class ImmutableEconomicGame : ImmutableGame 
    {
        public ImmutableEconomicGame(params int[] values) : base(values) { }
        public ImmutableEconomicGame(int[][] desk) : base(desk) { }
        public ImmutableEconomicGame(int[][] desk, List<History> history) : base(desk) 
        {
            this.history = history;
        }

        private List<History> history = new List<History>();

        public override Game Shift(int value)
        {
            var first = GetLocation(value);
            var second = GetCoordsOfZero(first);
            var newHistory = new List<History>(history);
            AddValuesToHistory(newHistory, first, second);
            return new ImmutableEconomicGame(desk, newHistory);
        }
        private void AddValuesToHistory(List<History> history, Coordinates first, Coordinates second)
        {
            var valueFirst = GetValueFromCoordinates(first);
            var valueSecond = GetValueFromCoordinates(second);
            history.Add(new History(first, valueSecond ));
            history.Add(new History(second, valueFirst ));
        }
        private int GetValueFromCoordinates(Coordinates coordinates)
        {
            int value = ValueFromHistoryInternal(coordinates.row, coordinates.column);
            if (value == -1)
                value = desk[coordinates.row][coordinates.column];
            return value;
        }
        protected override Coordinates GetLocationInternal(int value)
        {
            var foundedLocation = history.FindLast(x => x.value == value);
            if (foundedLocation != null)
                return foundedLocation.coordinates;
            return null;
        }

        protected override int ValueFromHistoryInternal(int row, int column)
        {
            var foundedValue = history.FindLast(x => (x.coordinates.column == column) && (x.coordinates.row == row));
            if (foundedValue != null)
                return foundedValue.value;
            return -1;
        }
        
    }
}
