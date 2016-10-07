using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    class Program
    {
        static void Print(SimpleGame game)
        {
            Console.WriteLine();
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                    Console.Write(game[i, j]);
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            var imEGame = new ImmutableEconomicGame(1, 2, 3, 0);
            var temp = imEGame.Shift(3);
            //var imGame = new ImmutableGame(1, 2, 3, 0);
            //var smt = imGame.Shift(3);
            
            //var game = new Game(1, 2, 3, 0);

            //while (true)
            //{
            //    Print(game);
            //    var number = Int32.Parse(Console.ReadKey().KeyChar.ToString());
            //    game.Shift(number);
            //}
        }
    }
}
