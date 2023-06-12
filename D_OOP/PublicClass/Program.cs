using D_OOP;//добавил неймспейс из другой сборки в эту, чтобы вызывать методы и классы

namespace PublicClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character characterInProgram = new Character();//Зависимости->Добавить ссылку на проект
            characterInProgram.Hit(10);
            Console.WriteLine(characterInProgram.Health);
        }
    }
}