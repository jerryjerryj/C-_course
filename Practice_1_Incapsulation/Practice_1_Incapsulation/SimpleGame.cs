using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1_Incapsulation
{
    public class SimpleGame : Game
    {
       
        public SimpleGame(params int[] values): base(values){}

        public void Shift(int value)
        {
            var location = GetLocation(value);
            var locationToChangeWith = GetCoordsOfZero(location);
            Swap(desk, location, locationToChangeWith);
        }
      
       
    }
}
