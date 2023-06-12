using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public class Rect
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Square:Rect 
    {

    }

    public static class AreaCalc
    {
        public static int CaclSquare(Square square)
        {
            return square.Height * square.Height;
        }
        public static int CalcSquare(Rect rect)
        {
            return rect.Width * rect.Height;
        }

        internal static int CaclSquare(Rect rect)
        {
            return rect.Width * rect.Height;
        }
    }
}