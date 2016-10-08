using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    public class Coordinates
    {
        public int row;
        public int column;
        public Coordinates(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
    public abstract class Game
    {
      protected int[][] desk;

        public int this[int row, int colum]
        {
            get {
                var internalResult = ValueFromHistoryInternal(row, colum);
                if (internalResult != -1)
                    return internalResult;
                return desk[row][colum]; }
        }

        protected abstract Coordinates GetLocationInternal(int value);
        protected abstract int ValueFromHistoryInternal(int row, int column); 

        public Game(params int[] values)
        {
            double size = Math.Sqrt(values.Length);

            if (size != Math.Round(size))
                throw new ArgumentException("Number of values must shape a square.");
            if (Array.FindIndex(values, x => x == 0) == -1)
                throw new ArgumentException("Values must contain null");
            if (values.Length != values.Distinct().ToArray().Length)
                throw new ArgumentException("Values mustn't have duplicates");

            desk = FillDesk((int)size, values);
        }
        public Game(int[][] desk) { }

        public abstract Game Shift(int value);

        private int[][] FillDesk(int size, int[] values)
        {
            int[][] desk = new int[size][];
            for (int i = 0; i < size; ++i)
            {
                desk[i] = new int[size];
                for (int j = 0; j < size; ++j)
                    desk[i][j] = values[i * size + j];
            }
            return desk;
        }
        protected Coordinates GetLocation(int value)
        {
            var location = GetLocationInternal(value);
            if (location != null)
                return location;

            foreach (var row in desk)
            {
                int column = Array.FindIndex(row, x => x == value);
                if (column != -1)
                    return new Coordinates(Array.FindIndex(desk, x => x == row), column);
            }
            throw new IndexOutOfRangeException("Can't find the value");
        }
        
       
        protected Coordinates GetCoordsOfZero(Coordinates coordinates)
        {
            var location = GetLocationInternal(0);
            if (location != null)
                return location;
            var temp = new Coordinates(coordinates.row + 1, coordinates.column);
            if (IsZero(temp)) return temp;

            temp.row -= 2;
            if (IsZero(temp)) return temp;

            temp = new Coordinates(coordinates.row, coordinates.column + 1);
            if (IsZero(temp)) return temp;

            temp.column -= 2;
            if (IsZero(temp)) return temp;

            throw new ArgumentException("Can't find zero here");

        }
        private bool IsZero(Coordinates coordinates)
        {
            if (IsOutFromBorders(coordinates.column) || IsOutFromBorders(coordinates.row))
                return false;
            return desk[coordinates.row][coordinates.column] == 0;
        }
        private bool IsOutFromBorders(int coordinate)
        {
            if (coordinate < 0 || coordinate > desk.Length / 2)
                return true;
            return false;
        }
        protected void Swap(int[][] desk, Coordinates one, Coordinates two)
        {
            var temp = desk[one.row][one.column];
            SetValueToDesk(desk, one, desk[two.row][two.column]);
            SetValueToDesk(desk, two, temp);
        }
        private void SetValueToDesk(int[][] desk, Coordinates coordinates, int value)
        {
            desk[coordinates.row][coordinates.column] = value;
        }
      
    }
}
