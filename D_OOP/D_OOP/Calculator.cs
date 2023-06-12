using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class Calculator
    {
        public double CaclTriangleSquareByHeigthAndBase(double aDub, double bDub, double cDub) 
        {
            double p = (aDub + bDub + cDub) / 2;
            Console.WriteLine(p);


            //После вычисления площади - вывести результат на консоль.
            return Math.Sqrt(p * ((((p - aDub) * (p - bDub)) * (p - cDub))));
           
        }
        public double CaclTriangleSquareByHeigthAndBase(double b, double h)
        {
            return 0.5 * b * h;
        }
    }
}
