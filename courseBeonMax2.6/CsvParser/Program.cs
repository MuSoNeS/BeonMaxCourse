using System.ComponentModel;
using System.Diagnostics.Contracts;

namespace CsvParser
{
   
    
   
    internal class Program
    {
        
        
        static void Main(string[] args)
        {

            var list = new List<string> {"1","2","3","4"  };
            var query = list.Where(c => c =="2").ToList();
            list.Remove("4");//отработает раньше Where. Он отложенный.Есть вариант вызова гриди оператора поверх,
                             //типо ToList. Звучит как костыль
            Console.WriteLine(list.Count()); 
            Console.ReadLine();



            CitiesAnalysis(@"C:\Users\Ramil\Desktop\BeonMaxCourse\courseBeonMax2.6\CsvParser\worldcities.csv");
            Console.ReadLine();
        }
        
        
        static void CitiesAnalysis(string file)
        {
            List<WorldCities> list = File.ReadAllLines(file)
                                          .Select(x => WorldCities.ParseCitiesScv(x))//принимает экзмепляр Класса, использует метод, результат заносит в х. возвращает IEnumerable WorldCities
                                          .Where(city => city.Population > 100000)//возвращает булеан
                                          .OrderByDescending(city => city.Population)
                                          .Take(1000)
                                          .ToList();

            Console.WriteLine($"Рейтинг городов по населению. Меньшее по соответствию:  {list.Min(x=>((int)x.Population))}") ;
            Console.WriteLine($"Большее: {list.Max(x => ((int)x.Population))}");
            Console.WriteLine($"Среднее: {list.Average(x => ((int)x.Population))}");


            //9.6 First, Last, Single

            Console.WriteLine(list.LastOrDefault(x => x.City == "Tokyo"));
            Console.WriteLine(list.FirstOrDefault(x => x.City == "Maoming")); 

            Console.WriteLine(list.First());//первый элемент в последовательности
            Console.WriteLine(list.Last());//последний
            Console.WriteLine(list.Single((x => x.City == "Zunyi")));//если единственный
            

        }

    }
}