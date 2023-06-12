using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    
    public class Piont2D
    {
        private const double speed = 10;//const при объявлении относится к примитиву, как правило и нужно сразу присвоить значение.
                                     //Теперь это значение ничем не изменить
        private readonly double speed2 = 10;//модифицировать ее никак нельзя, но можно инициализировать из конструктора

        public Piont2D(double speed, double speed2)
        {
            //this.speed = speed;//не могу работать с константой
            this.speed2 = speed2;//могу работать с ридонли
        }
        private int x;
        private int y;

        public Piont2D(int x, int y)
        {
            this.x = x;//разделяю ключевым словом поле класса от дубля-аргумента
            this.y = y;
        }


    }
    //конструкторы призваны защитить начальное состояние объекта 
    public class Constructor
    {
        public string Figurine { get; private set; }
        public int Field { get; private set; }

        //public Constructor()//нужен для защиты состояния класса
        //{

        //}

        public Constructor(string figurine)//не принимает аргументов. Может принимать аргументы как метод
        {
            Figurine = figurine;

        }
        public Constructor(string figurine, int field)
        {
            Figurine = figurine;
            Field = field;//перегрузка так же работает 

        }

    }
    

    
}
