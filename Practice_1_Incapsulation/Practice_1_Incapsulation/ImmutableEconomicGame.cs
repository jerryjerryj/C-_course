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

        private List<History> history = new List<History>();

        public ImmutableEconomicGame Shift(int value)
        {
            var first = GetLocation(value);
            var second = GetCoordsOfZero(first);
            AddValueToHistory(history, first, second);
            AddValueToHistory(history, second, first);
            return this;
        }
        private void AddValueToHistory(List<History> history, Coordinates from, Coordinates to)
        {
            history.Add(new History(to, desk[from.row][from.column]));
        }
        //todo getlocation, indexer, virtual(?) sift
    }
}
