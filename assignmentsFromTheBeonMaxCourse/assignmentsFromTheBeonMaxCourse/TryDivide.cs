using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentsFromTheBeonMaxCourse
{
    public class TryDivide
    {
        public bool TryDivides(double divisible, double divisor, out double result)
        {
            result = 0;
            if (divisible==0)
            {
                return false;
            }
            result = divisible/divisor;
            return true;
        }
        

    }
}

