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
    public class Game
    {
        public int[][] desk { get; private set; }

        public Game(params int[] values)
        {
            double size = Math.Sqrt(values.Length);

            if (size != Math.Round(size))
                throw new ArgumentException("Number of values must shape a square.");
            if(Array.FindIndex(values,x=>x == 0)==-1)
                throw new ArgumentException("Values must contain null");
            if(values.Length!= values.Distinct().ToArray().Length)
                throw new ArgumentException("Values mustn't have duplicates");

            desk = FillDesk((int)size, values);
        }
        public Coordinates GetLocation(int value)
        {
            foreach (var row in desk)
            {
                 int column = Array.FindIndex(row, x => x == value);
                 if (column != -1)
                    return new Coordinates( Array.FindIndex(desk, x => x == row), column);
            }
            throw new IndexOutOfRangeException("Can't find the value");
        }
        private int[][] FillDesk(int size, int[] values)
        {
            int[][] desk = new int[size][]; 
            for (int i = 0; i < size; ++i)
            {
                desk[i] = new int[size];
                for (int j = 0; j < size; ++j)
                    desk[i][j] = values[i*size + j];
            }
            return desk;
        }
        public void Shift(int value)
        {
            try
            {
                var location = GetLocation(value);
                var locationToChangeWith = FindZero(location);
                Swap(desk, location, locationToChangeWith);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Can't perform shifting");
            }
        }
        private Coordinates FindZero(Coordinates coordinates)
        {
            var temp = new Coordinates(coordinates.row + 1, coordinates.column);
            if (CheckIsZero(temp)) return temp;

            temp.row -= 2;
            if (CheckIsZero(temp)) return temp;

            temp = new Coordinates(coordinates.row, coordinates.column + 1);
            if (CheckIsZero(temp)) return temp;

            temp.column -= 2;
            if (CheckIsZero(temp)) return temp;

            throw new ArgumentException("Can't find zero here"); 

        }
        private bool CheckIsZero(Coordinates coordinates)
        {
            return desk[coordinates.row][coordinates.column] == 0;
        }
        private void Swap(int[][] desk, Coordinates one, Coordinates two)
        {
            // better desk to class?
            int temp = desk[one.column][one.row];
            desk[one.column][one.row] = desk[two.column][two.row];
            desk[two.column][two.row] = temp;
        }
    }
}
