using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public class PracticalTask_5_8
    {

        public double Average(int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }
        public double Average2(params int[] numbers)//обязан идти последним с params
        {
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            return (double)sum / numbers.Length;
        }

    }
}
namespace assignmentsFromTheBeonMaxCourse
{



    public class PracticalTask
    {
        //Добавить перегрузку, которая принимает длины двух смежных сторон (double) и величину угла между ними. Величину угла принимать как int.
        public static double OverloadInTask(double ab, double ac, int alpha)
        {
            //Метод должен рассчитывать площадь по формуле: 0.5 * ab * ac * sin(alpha)
            return (0.5 * ab * ac) * (Math.Sin(alpha * (Math.PI / 180)));//угон син в радианах, перевожу в градусы. Исправление ошибок 

        }
        public static double OverloadInTask(double a, double h)
        {
            return 0.5 * a * h;
        }
    }
}