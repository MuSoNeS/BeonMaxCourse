using System.Runtime.CompilerServices;

namespace Linq
{
    public static class LinqEx
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException();
            foreach(var item in source) 
            { 
                action(item);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //статический класс не возвращающий значение с путем к директории
            //директори инфо, возвращает массив
            //сортировка Аррай.Сорт, есть перегрузка на 2 аргумента. 1 сам массив, затем Компарисон
            //сигнатура компарисон такова, что он принмает 2 экземпляра файл инфо. Сам он интовый
            //в ифе прописываешь, что если файлы равны, то возвращает 0, больше 1, меньше -1
            //затем цикл фор

            //DisplayLargestFilesWithoutLinq(@"C:\Users\Ramil\Desktop\Новая папка");
            DisplayLargestFileWithLinq(@"C:\Users\Ramil\Desktop\Новая папка");


          
        }
        private static void DisplayLargestFileWithLinq(string pathToDir)
        {
            new DirectoryInfo(pathToDir)
                .GetFiles()
                .OrderBy(file => file.Length)
                .Take(Range.All)
                .ForEach(file => Console.WriteLine($"{file.Name} weihgts {file.Length}"));

        }

        static long KeySelector(FileInfo file)
        {
            return file.Length;
        }

        private static void DisplayLargestFilesWithoutLinq(string pathToDir)
        {
            var dirInfo = new DirectoryInfo(pathToDir);
            FileInfo[] files = dirInfo.GetFiles();

            Array.Sort(files, FilesComparison);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.FullName} weights {file.Length}");
            }
        }
        //распределяет файлы по размеру. Длина в лонг 
        static int FilesComparison(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return -1;
            return  1;
        }
    }
}