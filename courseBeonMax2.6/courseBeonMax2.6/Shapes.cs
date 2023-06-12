using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    

    public abstract class Shape//абстрактные методы не умеют реализации и наследники обязаны их переопределять. 
        //виртуальные мы можем переопределить, либо не переопределять
    {
        public Shape()
        {
            Console.WriteLine("Shape Created");
        }
        public abstract void Draw();//внутри абстрактного класса можно объявлять и виртуальные, и обычные методы

        public abstract double Area();

        public abstract double Perimeter();

    }

    public class Triangle : Shape
    {
        private readonly double ab;
        private readonly double bc;
        private readonly double ac;
        public Triangle(double ab, double bc, double ac)
        {
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;

        }

        public override double Area()
        {
            double s = (ab + bc+ac)/2;
            return Math.Sqrt(s*(s-ab)*(s-bc)*(s-ac));
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }

        public override double Perimeter()
        {
            return ab + bc + ac;
        }
    }
    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;

            Console.WriteLine("Rectangle Created");
        }

        public override double Area()
        {
            return width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Perimeter()
        {
            return 2*(width+height);
        }
    }
}
