using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace assignmentsFromTheBeonMaxCourse
{



    public class PracticalTask
    {
        //Добавить перегрузку, которая принимает длины двух смежных сторон (double) и величину угла между ними. Величину угла принимать как int.
        public double OverloadInTask(double ab, double ac, int alpha)
        {
            //Метод должен рассчитывать площадь по формуле: 0.5 * ab * ac * sin(alpha)
            return (0.5 * ab * ac) * (Math.Sin(alpha*(Math.PI/180)));//угон син в радианах, перевожу в градусы. Исправление ошибок 

        }
        public double OverloadInTask(double a, double h)
        {
            return 0.5 * a * h; 
        }
    }
}
