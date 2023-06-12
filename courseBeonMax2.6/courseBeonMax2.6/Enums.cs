using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }
    public enum Race : int
    {
        Elf = 0,
        Ork = 1,
        Terrain = 2
    }
    public class Character 
    {
        string Race;

        public Character(Race ork)
        {
        }
    }        

        
}
