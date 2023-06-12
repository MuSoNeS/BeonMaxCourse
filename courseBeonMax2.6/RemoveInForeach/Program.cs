namespace RemoveInForeach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RemoveInForeach();
            //RemoveInFor();
            RemoveAll();
        }
        static void RemoveAll()//лучший способ
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list.RemoveAll(x => x %2!= 0);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void RemoveInFor()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            for(int i = 0; i < list.Count; i++) //смещает индексы при каждой итерации 
            {                                   //Удаляя 1 по 0 индексу, он сместит 2 на 0 индекс.
                                                //Но, т.к. 0 индекс он уже прошел, он пропустит не обработанную 2.
                                                //И так будет продолжаться
                var item = list[i];
                if (item<=3)
                {
                    list.Remove(item);
                    i--;//не забывать модифицировать итератор цикла, чтоб он проходил нужные элементы
                    //так же рабочий метод эт проход цикла с конца
                }
            }
            Console.WriteLine(list.Count==2);
        }
        static void RemoveInForeach()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            foreach (int i in list) //foreach защищен от модификация листа
            {
                if(i %2 == 0)
                {
                    list.RemoveAt(i);
                }
            }
            Console.WriteLine(list.Count);
        }
    }
}