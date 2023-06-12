using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public struct EvilStruct
    {
        public int x;
        public int y;

        public PointRef PointRef;
    }

    public struct PointVal
    {public struct EvilStruct
{
    public int x;
    public int y;

    public PointRef PointRef;
}
        public int x; 
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

    }

    public class PointRef
    {
        public int x;
        public int y;

        public void LogValues()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }

    }




}
