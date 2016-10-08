using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    public class ImmutableGame : Game
    {

        public ImmutableGame(params int[] values) :base(values) { }

        public ImmutableGame(int[][] desk) : base(desk)
        {
            this.desk = desk;
        }

        public override Game Shift(int value)
        {
            var copy = GetCopy(desk);
            var location = GetLocation(value);
            var locationToChangeWith = GetCoordsOfZero(location);
            Swap(copy, location, locationToChangeWith);
            return new ImmutableGame(copy);
        }
        private int[][] GetCopy(int[][] array)
        {
            var result = new int[array.Length][];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = new int[desk[i].Length];
                Array.Copy(desk[i], result[i], desk[i].Length);
            }
            return result;
        }

        protected override Coordinates GetLocationInternal(int value)
        {
            return null;
        }
        protected override int ValueFromHistoryInternal(int row, int column)
        {            
            return -1;
        }
    }
}
