namespace D_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {//перегрузка метода. Заносим под одним названием два метода с разным количеством аргументов
            
            //метод по количеству переданных аргументов сам определяет, каким способом подсчета воспользоваться
            //нельзя перегружать по параметрам. Тип возвращаемых значений менять незя
            Calculator calc = new Calculator();
            double square1 = calc.CaclTriangleSquareByHeigthAndBase(10,20);//благодаря передаче свойство, мы смогли прочесть значение из приватной переменной.
            double square2 = calc.CaclTriangleSquareByHeigthAndBase(40, 20, 30);
            
            Console.WriteLine($"1 = {square1}, 2 = {square2}");
            //но возможность изменять ее заблокировали путем "private set", передавая в него тот самый value
        }
    }
}