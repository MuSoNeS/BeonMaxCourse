using assignmentsFromTheBeonMaxCourse;
using courseBeonMax2._6;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

























//9.1 делегаты F_Delegation

static void WorkWithFiles()
{


    try
    {

        DirFileDemo();

    }
    catch (Exception ex)
    {

    }

    static void DirFileDemo()
    {
        File.Copy("test.txt", @"C:\Users\Ramil\Documents\test_copy.txt", overwrite: true);//если owerwrite true, то при наличии такого файла он будет перезатерт. Если false, то будет исключение

        File.Move("test_copy.txt", "test_copy_renamed.txt");

        File.Delete("test_copy.txt");

        if (File.Exists("test.txt"))
        {
            File.AppendAllText("test.txt", "exists");
        }

        // File.Replace("Один путь исходного файла", "Файл для переноса", "Бепакапчик") - перезапись содержимого одного файла в другой, третяя перегрузка - создание бекапа

        bool existsDir = Directory.Exists(@"C:\Users\Ramil\Documents");
        if (existsDir)
        {
            var files = Directory.EnumerateFiles(@"C:\Users\Ramil\Documents", "*.txt", SearchOption.AllDirectories);//поддерживает SearchPattern, для поиска по расширению или названию. SearchOption.AllDirectories позволяет искать файлы во вложенных папках в исходной директории
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            //Directory.Delete();
        }
        //Path.GetFullPath();
        //Path.GetDirectoryName();
        //Path.Combine чтоб собрать путь по кускам(через переменные)
    }
    //файловые системы

    string[] allLines = File.ReadAllLines("test.txt");
    string allText = File.ReadAllText("test.txt");

    IEnumerable<string> lines = File.ReadLines("test.txt");

    File.WriteAllText("test2.txt", "My name Ram");//создаст и запишет. Если файл есть, то перепишет

    File.WriteAllLines("test3.txt", new string[] { "My name\n", " \nRamilka" });

    string allText2 = File.ReadAllText("test2.txt");
    Console.WriteLine(allText2);

    Console.ReadLine();

    Stream fs = new FileStream("test5.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);//если вызван рид, то другие проги не смогут читать файл, та же история с двумя остальными функциями(write, readwrite)

    try
    {
        string str = "What the Hell";
        byte[] strInBytes = Encoding.ASCII.GetBytes(str);

        fs.Write(strInBytes, 0, strInBytes.Length);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fignya sluchilas{ex.ToString()}");
    }
    finally
    {
        fs.Close();
    }
    using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))//такое разрешено. Гарантирует, что Dispose будет вызван. Минус - отсуствие catch блока
    {
        byte[] temp = new byte[14];
        ASCIIEncoding encoding = new ASCIIEncoding();

        int len = 0;
        while ((len = readingStream.Read(temp, 0, temp.Length)) > 0)
        {
            string str = encoding.GetString(temp, 0, len);

            Console.WriteLine(str);
        }
    }
    using (Stream readingStream2 = new FileStream("test.txt", FileMode.Open, FileAccess.Read))//более генерализованный вид(слова автора)
    {
        byte[] temp2 = new byte[readingStream2.Length];
        ASCIIEncoding encoding = new ASCIIEncoding();

        int bytesToRead = (int)readingStream2.Length;
        int bytesRead = 0;

        while (bytesToRead > 0)
        {
            int n = readingStream2.Read(temp2, bytesRead, bytesToRead);

            if (n == 0)
                break;

            bytesRead += n;
            bytesToRead -= n;
        }

        string str = Encoding.ASCII.GetString(temp2, 0, temp2.Length);

        Console.WriteLine(str);

        Console.ReadLine();
    }
}
static void ExType()
{
    //6.1 Обработка исключений

    string name = null;

    if (name == null)
        throw new ArgumentNullException("Вызванное исключение");

    FileStream file = null;

    try
    {
        file = File.Open("temp.txt", FileMode.Open);
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Файл не найлен");
    }
    finally
    {
        if (file != null)
        { file.Dispose(); }
    }



    Console.WriteLine("Введите число > int32, для проверки одной ошибки. Строку, для проверки другой ошибки");
    try
    {
        int mizer = int.Parse(Console.ReadLine());

        Console.WriteLine(mizer);
    }
    catch (OverflowException ex)
    {
        Console.WriteLine($"Переполнение");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Базовая ошибка");
    }

}
static void IsA()
{
    Rect rect = new Rect() { Height = 2, Width = 5 };
    int rectArea = AreaCalc.CaclSquare(rect);
    Console.WriteLine(rectArea);

    Rect square = new Square() { Height = 2, Width = 10 };
}
static void CallingTroughInterfaces()
{
    //методы расширения
    //не правильный я пример тут сделал.
    List<int> list = new List<int>() { 1, 2, 3 };

    IBaseCollection_5_25 collection = new BaseList(4);
    collection.AddRange((IEnumerable<object>)list);
    collection.Add(1);
}
static void StreamAndInterfaces()
{

    //IBaseCollection collection = new BaseList(4);
    //collection.Add(1);
    //перед исполнением кода в наследнике, всегда вперед исполняется код внутри базового класса
    //еще есть :base(), который неявно присутствует при вызове наследника
    //если он есть, то мы обязаны бы были передать аргументы

    //Shape shape = new Shape(); -> Эт не сработает. Нельзя создавать экземпляр абстрактного класса, но можно создать массив
    Shape[] shapes = new Shape[2];//Что дает наследование? Можно работать с наследником используя базовый класс
    shapes[0] = new Triangle(10, 20, 30);
    shapes[1] = new Rectangle(5, 10);

    foreach (Shape shape in shapes)
    {
        shape.Draw();
        Console.WriteLine(shape.Perimeter());
    }

    ModelXTerminal terminal = new ModelXTerminal("123");
    terminal.Connect();
    Console.ReadLine();

    //полиморф эт типо контракт, в котором указано, что все наследники базового класса обязаны иметь методы этого базового класса






    //5.20. Константы: модификаторы const и readonly 
}
static void Constuctor()
{
    //5.19. Конструкторы


    Constructor cons = new Constructor("Квадратик");//конструктор - особый метод, который вызывается при создании экземпляра класса
                                                    //после того, как в конструкторе я передал значение фигуры - внешний код не может инициализировать экземпляр класса Конструктор без указания фигуры
    Console.WriteLine(cons);
}
static void BoxingAndUnboxing()
{
    //int x = 1;
    //object obj = x;//Boxing. Object = reference type, оборачивает х, таким образом, что значение х будет в кучу, а не в стек.

    //int y = (int)obj;//unboxing, разупаковка. Все типы наследуются от object

    double pi = 3.14;
    object obj1 = pi;

    int number = (int)obj1;//исключение. Можно явно привести к double (int)(double)obj1;
    Console.WriteLine(number);

    //работать с object не безопасно, generic лучше
}
static void Do(object obj)
{
    bool isPointRef = obj is PointRef;//проверка на тип. 
    if (isPointRef)
    {
        PointRef pt = (PointRef)obj;//привести object k PointRef;
        Console.WriteLine(pt.x);
    }
    else
    {
        //do smth.
    }

    PointRef pr = obj as PointRef;
    if (pr != null)
    {
        Console.WriteLine(pr.x);
    }
    else
    {
        //do smth
    }


}
static void NRE_NullableValTypesDemo()
{
    //5.17 NullReferenceException и Nullable-структуры
    //в экземпляре структуры по умолчанию не null, a 0.
    PointVal? pv = null;//структура не содержит null. C добавление "?" теперь переменная Nullable
    if (pv.HasValue)//чтобы избежать exception, если он не null, то сможем работать 
    {
        PointVal pv2 = pv.Value;//чтобы обратиться к такой структуре, нужно использовать Value
        Console.WriteLine(pv.Value.x);
        Console.WriteLine(pv.Value);

    }
    else
    {
        //зайдем, если в pv записан null
    }
    PointVal pv3 = pv.GetValueOrDefault();//Возвращает состояние по умолчанию(0), если структура содержит null. Если нет, то возвращает значение

    //PointRef c; Будет исключение, связаное с тем, что не указано никакой ссылки. 
    PointRef c = null;
    Console.WriteLine(c.x); //NullReferenceException
}
static void ReferenceType()
{

    int a = 1;
    int b = 2;

    Swap(ref a, ref b);//передача по ссылке с помощью ref

    var list = new List<int>();
    AddNumber(list);
    foreach (var item in list)
    {
        Console.WriteLine(item);
    }


    static void Swap(ref int a, ref int b)//Позволяет явно указать, откуда и какие значения я хочу забрать. Т.е. реф позволит использовать не копии, а оригиналы 
    {
        Console.WriteLine($"original a ={a}, b = {b}");
        int tmp = a;
        a = b;
        b = tmp;
        Console.WriteLine($"Swapped a = {a}, b = {b}");
    }




    static void AddNumber(List<int> numbers)
    {
        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
    }



    Console.WriteLine($" a = {a}, b = {b}");
}
static void StructsAndRef2()//обработка поведения структуры включающей в себя ссылочный тип данных(или в переменную, не суть)
{
    EvilStruct es1 = new EvilStruct();
    es1.PointRef = new PointRef() { x = 1, y = 2 };
    EvilStruct es2 = es1;

    Console.WriteLine($"es1.PointRef.X = {es1.PointRef.x}, es1.PointRef.Y {es1.PointRef.y}");
    Console.WriteLine($"es2.PointRef.X = {es2.PointRef.x}, es2.PointRef.Y {es2.PointRef.y}");

    es2.PointRef.x = 42;
    es2.PointRef.y = 45;
    Console.WriteLine($"es1.PointRef.X = {es1.PointRef.x}, es1.PointRef.Y {es1.PointRef.y}");
    Console.WriteLine($"es2.PointRef.X = {es2.PointRef.x}, es2.PointRef.Y {es2.PointRef.y}");

    Console.ReadLine();
    //5.13. Ссылочные типы и типы-значения
    //семантика класса при копировании - поведение при копировании
    PointVal a;//PointVal a = new PointVal();
    a.x = 1;
    a.y = 2;

    PointVal b = a;//в данном случае под каждую операцию выделялся свой участочек памяти(типы значений)(1)
                   //как я понял, здесь сохранится исходное значение переменной, но создатся еще одна(2)
                   //Если мне нужно сохранить исходные значения в классе, я могу его сделать структурой, тогда значения в нем будут для каждой новой операции сохранены(3)
    b.x = 7;
    b.y = 10;
    a.LogValues();
    b.LogValues();

    Console.WriteLine("After structs");
    //
    PointRef c = new PointRef();//PointVal a = new PointVal();
    c.x = 1;
    c.y = 2;

    PointRef d = c;// в этом же случае под одни и те же значения выделялась ссылка на участочек памяти(ссылочные типы)(1)
                   //здесь же все будет вертеться в одной переменной(2)
                   //здесь же мои значения будут переписаны входящими операциями(3)
    d.x = 7;
    d.y = 10;
    c.LogValues();
    c.LogValues();
}
static void StructsAndRef()
{
    //5.13. Ссылочные типы и типы-значения
    //семантика класса при копировании - поведение при копировании
    PointVal a;//PointVal a = new PointVal();
    a.x = 1;
    a.y = 2;

    PointVal b = a;//в данном случае под каждую операцию выделялся свой участочек памяти(типы значений)(1)
                   //как я понял, здесь сохранится исходное значение переменной, но создатся еще одна(2)
                   //Если мне нужно сохранить исходные значения в классе, я могу его сделать структурой, тогда значения в нем будут для каждой новой операции сохранены(3)
    b.x = 7;
    b.y = 10;
    a.LogValues();
    b.LogValues();

    Console.WriteLine("After structs");
    //
    PointRef c = new PointRef();//PointVal a = new PointVal();
    c.x = 1;
    c.y = 2;

    PointRef d = c;// в этом же случае под одни и те же значения выделялась ссылка на участочек памяти(ссылочные типы)(1)
                   //здесь же все будет вертеться в одной переменной(2)
                   //здесь же мои значения будут переписаны входящими операциями(3)
    d.x = 7;
    d.y = 10;
    c.LogValues();
    c.LogValues();
}
static void Calculator()
{//5.12 Optional Params
    static double CalcTriangle(double ab, double ac, int alpha, bool isRadians = false)//указываю параметр на тот случай, если его не передадут
    {
        if (isRadians)
        {
            return 0.5 * ab * ac * Math.Sin(alpha);
        }
        else
        {
            double rads = alpha * Math.PI / 180;
            return 0.5 * ab * ac * Math.Sin(rads);
        }
    }
}
static void StaticMod()
{
    //5.11. Модификатор static
    double result = PracticalTask.OverloadInTask(6, 6);
    Console.WriteLine(result);



}
static void PracticalTask5_7()
{
    //Урок 5.7. Практическое задание "Перегрузка"
    PracticalTask square = new PracticalTask();



    //double square1 = PracticalTask.OverloadInTask(ab: 10, ac: 20, alpha: 30);
    //double square2 = PracticalTask.OverloadInTask(a: 20, h: 44);

    //Console.WriteLine(square1);
    //Console.WriteLine(square2);
}
static void Params()
{
    //5.8 Ключевое слово params
    PracticalTask_5_8 calc = new PracticalTask_5_8();
    double avg = calc.Average(new int[] { 1, 2, 3, 4 });
    Console.WriteLine(avg);

    PracticalTask_5_8 calc2 = new PracticalTask_5_8();
    double avg2 = calc.Average2(1, 2, 3, 4);//получилось благодаря объявлению public double Average2(params int[] numbers)
    Console.WriteLine(avg2);



}
static void BadarrayStart()
{
    //4.7 Настраиваемые массивы
    Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });
    myArray.SetValue(2019, 1);//начинаем с 1, а не 0
    myArray.SetValue(2020, 2);
    myArray.SetValue(2021, 3);
    myArray.SetValue(2022, 4);

    Console.WriteLine(myArray.GetLowerBound(0));//стартовый индекс
    Console.WriteLine(myArray.GetUpperBound(0));//конечный индекс

    for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
    {
        Console.WriteLine(i);
    }
    //Массивы с 1 работают медленнее, с ними не удобно работать. Но иногда можно встретить в чужом коде подобное и необходимо быть готовым 
}
static void JaggedArray()
{
    int[][] jaggedArray = new int[4][];
    jaggedArray[0] = new int[1];
    jaggedArray[1] = new int[2];
    jaggedArray[2] = new int[3];
    jaggedArray[3] = new int[4];

    Console.WriteLine("Заполните массив");

    for (int i = 0; i < jaggedArray.Length; i++)
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            string st = Console.ReadLine();
            jaggedArray[i][j] = int.Parse(st);
        }
    }
    Console.WriteLine();
    Console.WriteLine("Введенные элементы");
    for (int i = 0; i < jaggedArray.Length; i++)
    {
        for (int j = 0; j < jaggedArray[i].Length; j++)
        {
            Console.Write(jaggedArray[i][j] + " ");

        }
        Console.WriteLine();
    }
}
static void MultiDimArrays()
{
    //4.5 Двумерные массивы(Матрица)
    //1 2 3 4

    //Двумерные(многомерные)

    //1 2 3 
    //4 5 6 
    //7 8 9 

    int[,] r1 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } }; //В объявление запятая в квадратных скобках. Затем количество строк и столбцов. Можно сразу проинициализировать
    int[,] r2 = { { 1, 2, 3, 4 }, { 4, 5, 6, 5 }, { 4, 5, 6, 8 }, { 4, 5, 6, 9 } };
    Console.WriteLine(r2.GetLength(1));

    for (int i = 0; i < r2.GetLength(0); i++)//выводит размер столбцов
    {
        for (int j = 0; j < r2.GetLength(1); j++)//строк
        {
            Console.Write(@"{" + r2[i, j] + "}");
        }
        Console.WriteLine();
    }
}
static void QueueAndStack()
{
    //stack абстрактный тип данных. Налагает правила. Реализует подход LIFO, кто последним пришел, тот первым ушел. 
    //FIFO первым пришел - первым ушел.

    var queue = new Queue<int>();
    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);
    queue.Enqueue(4);

    Console.WriteLine(queue.Peek());

    queue.Dequeue();

    Console.WriteLine(queue.Peek());

    foreach (var item in queue)
    {
        Console.WriteLine(item.ToString());
    }
    //var stack = new Stack<int>();
    //stack.Push(1);
    //stack.Push(2);
    //stack.Push(3);
    //stack.Push(4);


    //Console.WriteLine(Convert.ToString(stack.Peek()));//возвращает элемент, последний

    //stack.Pop();//удаляет и возвращает

    //Console.WriteLine(Convert.ToString(stack.Peek()));

    //foreach (var item in stack)
    //{
    //    Console.WriteLine(item);
    //}

}
static void DictionaryType()
{
    var people = new Dictionary<int, string>();
    people.Add(1, "John");
    people.Add(2, "Bob");
    people.Add(3, "Alice");

    people = new Dictionary<int, string>()
{
    { 1, "John"},
    { 2, "Bob"},
    { 3, "Alice"},
};
    string name = people[1];//доступ по ключу
    Console.WriteLine(name);


    //var keys = people.Keys;
    //foreach (var key in keys)
    //{
    //    Console.WriteLine(key);
    //}
    //var values = people.Values;
    //foreach (var value in values)


    foreach (var pair in people)
    {
        Console.WriteLine($"Keys: {pair.Key}, names: {pair.Value}");
    }

    Console.WriteLine(people.Count);
    bool containsKey = people.ContainsKey(2);
    bool containsValue = people.ContainsValue("John");
    Console.WriteLine(containsKey);
    Console.WriteLine(containsValue);

    people.Remove(1);//можно делать ветвление на элементе, возвращает тру в случае удаления элемента
    if (people.TryAdd(2, "Elias"))
    {
        Console.WriteLine("Added");
    }
    else
    {
        Console.WriteLine("Edded false");
    }

    if (people.TryGetValue(3, out string val))
    {
        Console.WriteLine(val);
    }
    else
    {
        Console.WriteLine("Fail to get");
    }
    people.Clear();

}
static void ListCollection()
{
    //4.2 List Collection
    var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12 };//поддерживает индексацию
    intList.Add(7);

    int[] intArray = { 1, 2, 3 };
    intList.AddRange(intArray);

    if (intList.Remove(1))//Если находит, то удаляет и возвращает true. Удаляет первое попадание
    {
        //do
    }
    else { }

    intList.RemoveAt(0);//удаляет по индексу

    intList.Reverse();

    bool contains = intList.Contains(3);

    int min = intList.Min();
    int max = intList.Max();
    Console.WriteLine($"min = {min}, max = {max}");

    int indexof = intList.IndexOf(2);
    int lastIndexOf = intList.LastIndexOf(2);
    Console.WriteLine($"{indexof} {lastIndexOf}");

    for (int i = 0; i < intList.Count; i++)
    {
        Console.WriteLine($"intList = {intList[i]}");
    }
    foreach (int item in intList)
    {
        Console.WriteLine($"intList = {item}");
    }

}
static void ClassArray()
{
    //4.2 ClassArray
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int index = Array.BinarySearch(numbers, 7);//Бинарный поиск, возвращает индекс 1 вхождения
    Console.WriteLine(index.ToString());

    int[] copy = new int[10];
    //Array.Copy(copy, numbers, copy.Length);//копирует все элементы. Уровень класса

    int[] anotherCopy = new int[10];
    //copy.CopyTo(anotherCopy,0);//Напрямую копирует, без использования Array. Уровень экземпляра

    Array.Reverse(numbers);//Реверс всех элементов
    foreach (var c in numbers)
        Console.WriteLine(c.ToString());

    Array.Clear(numbers, 0, numbers.Length);//очистить

    int[] a1;
    a1 = new int[10];
    int[] a2 = new int[5];
    int[] a3 = new int[5] { 1, 3, -2, 5, 10 };
    int[] a4 = { 1, 3, 2, 4, 5 };

    Array myArray = new int[5];
    Array myArray2 = Array.CreateInstance(typeof(int), 5);

    myArray2.SetValue(12, 0);
    Console.WriteLine(myArray2.GetValue(0));
}
static void Debugging()
{
    //3.8 отладка
    //точка остановы f9
    //f5, f10, f11
    //В режиме отладки исключения подсвечиваются студией
    // 2.20 Practical task "Heron`s formula"
    //Запросить у пользователя длины трёх сторон треугольника. Длины могут быть представлены дробными значениями.
    Console.WriteLine("Please enter the value of the first side of the triangle, write fractional numbers separated by commas");
    string a = Console.ReadLine();
    Console.WriteLine("Please enter the value of the seconnd side of the triangle, write fractional numbers separated by commas");
    string b = Console.ReadLine();
    Console.WriteLine("Please enter the value of the last side of the triangle, write fractional numbers separated by commas");
    string c = Console.ReadLine();
    //После получения длин сторон - использовать формулу Герона для вычисления площади треугольника.
    ////Чтобы жизнь не казалась мёдом, найдите формулу самостоятельно.(p = (a+b+c)/2)(S=sqrt(p(p-a)*(p-b)*(p-c))
    double aDub = double.Parse(a);
    double bDub = double.Parse(b);
    double cDub = double.Parse(c);
    double p = (aDub + bDub + cDub) / 2;
    Console.WriteLine(p);


    //После вычисления площади - вывести результат на консоль.
    double squareOfATriangle = Math.Sqrt(p * ((((p - aDub) * (p - bDub)) * (p - cDub))));
    Console.WriteLine($"Square of your triangle = {squareOfATriangle}");

    static double GetDouble()
    {
        return double.Parse(Console.ReadLine());
    }
}
static void SwitchCase()
{
    int mounth = int.Parse(Console.ReadLine());

    string season = String.Empty;

    switch (mounth)
    {
        case 12:
        case 1:
        case 2:
            season = "winter";
            break;
        case 3:
        case 4:
        case 5:
            season = "spring";
            break;
        case 6:
        case 7:
        case 8:
            season = "summer";
            break;
        case 9:
        case 10:
        case 11:
            season = "autumn";
            break;
        default:
            throw new Exception("error");
    }
    Console.WriteLine(season);



    Console.ReadLine();

    //3.7 switch\case
    int weddingYears = int.Parse(Console.ReadLine());

    string nameWedding = string.Empty;
    switch (weddingYears)
    {
        case 5:
            nameWedding = "Деревенная свадьба";
            break;
        case 10:
            nameWedding = "Оловяная свадьба";
            break;
        case 15:
            nameWedding = "Хрустальная свадьба";
            break;
        case 20:
            nameWedding = "Фарфоровая свадьба";
            break;
        case 25:
            nameWedding = "Серебряная свадьба";
            break;
        case 30:
            nameWedding = "Жемчужная свадьба";
            break;
        default:
            nameWedding = "Не знаю, как назвать :с";
            break;

    }
    Console.WriteLine(nameWedding);












}
static void BreakAndContinue()
{
    //3.6 Break and Continue
    int[] number = { -1, -2, -4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };

    int counter = 0;

    int[] numbers = { 0, 3, 2, 1, 5, 4, 6, 7, 8, 9 };
    char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

    foreach (int n in numbers)
    {
        if (n % 2 != 0)
            continue;
        Console.WriteLine(n.ToString());
    }
    Console.ReadLine();

    for (int i = 0; i < numbers.Length; i++)
    {
        Console.WriteLine($"Number = {numbers[i]} ");
        for (int j = 0; j < letters.Length; j++)
        {
            if (numbers[i] == j)
                break;
            Console.Write($"letters = {letters[j]} ");

        }
        Console.WriteLine();
    }

    Console.ReadLine();
    for (int i = 0; i < number.Length; i++)//вложенный for, всн пары чисел дадут 0
    {
        for (int j = i + 1; j < number.Length; j++)
        {
            if (counter == 3)
            {
                break;
            }
            for (int k = j + 1; k < number.Length; k++)
            {

                int atI = number[i];
                int atJ = number[j];
                int atK = number[k];
                if (atI + atJ + atK == 0)
                {
                    Console.WriteLine($"Triatplets({atI};{atJ};{atK}).Indexes({i};{j};{k})");
                    counter++;
                }
                if (counter == 3)
                {
                    break;
                }
            }
        }
    }

}
static void WhileAndDoWhile()
{
    //while and do while
    Console.WriteLine("Create a password");
    int passUserInput = int.Parse(Console.ReadLine());
    int pass = 0;
    while (pass != passUserInput)
    {
        Console.WriteLine("Check password");
        pass = int.Parse(Console.ReadLine());
    }
    Console.WriteLine("Gj");

}
static void ForAndForeach()
{
    //3.3&3.4 For and Foreach
    int[] number = { -1, -2, -4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };
    //for(int i = 0;i<number.Length;i++)
    //{
    //    Console.Write(number[i]+" ");
    //}
    //Console.WriteLine();
    //for(int i = number.Length - 1; i >= 0; i--)
    //{
    //    Console.Write(number[i]+" ");
    //}
    //Console.WriteLine();
    //for(int i = 0;i<number.Length; i++)//i, j, k
    //{
    //    if (number[i] % 2 == 0)
    //    {
    //        Console.Write(number[i]+" ");
    //    }
    //}
    //Console.WriteLine();
    //foreach(int k in number)
    //{
    //    Console.Write(number[k]+" ");
    //}
    for (int i = 0; i < number.Length; i++)//вложенный for, всн пары чисел дадут 0
    {
        for (int j = i + 1; j < number.Length; j++)
        {
            for (int k = j + 1; k < number.Length; k++)
            {

                int atI = number[i];
                int atJ = number[j];
                int atK = number[k];
                if (atI + atJ + atK == 0)
                {
                    Console.WriteLine($"Triatplets({atI};{atJ};{atK}).Indexes({i};{j};{k})");
                }
            }
        }
    }
}
static void DateTimeNow()
{

    DateTime now = DateTime.Now;
    Console.WriteLine(now.ToString());

    Console.WriteLine($"It`s {now.Date}, {now.Hour}:{now.Minute}:{now.Second}");

    DateTime dt = new DateTime(2016, 2, 28);//datetime понимает, как устроен календарь
    Console.WriteLine(dt.ToString());
    DateTime newDt = dt.AddDays(1);//создается новый экземпляр dt
    Console.WriteLine(newDt.ToString());

    TimeSpan ts = now - dt;
    Console.WriteLine(ts.TotalHours);//Total возвращает double, для целых чисел использовать просто Days, Hours и т.д.

}
static void IntroToArrays()
{
    //Введение в массивы
    int[] a1;//объявление массива
    a1 = new int[10];//присваиваем размер [10] +-40 байтов, по умолчанию каждый 0

    int[] a2 = new int[5];//короткое объявление

    int[] a3 = new int[5] { 1, -2, 4, 6, 10 };//Краткое объявление с присвоением значений

    int[] a4 = { 1, 3, 2, 4, 5, 6, 10 };//супер краткая запись с присвоением 
    Console.WriteLine(a4[0]);//Вывод элемента массива по индексу

    int number = a4[4];//Присвоение переменной значения массива по индексу
    Console.WriteLine(number);

    a4[4] = 6;
    Console.WriteLine(a4[4]);
    Console.WriteLine(a4.Length);//Длина массива
    Console.WriteLine(a4[a4.Length - 1]);//Последний элемент массива

    string s1 = "adadaad";
    char first = s1[0];
    char last = s1[s1.Length - 1];
    Console.WriteLine($"First {first}");
    Console.WriteLine($"Last {last}");
}
static void ClassMath()
{
    // 2.16 Class Math
    //Math.BigMul(int a, int b) Перемножает большие инты, выводит 32 битный long
    Console.WriteLine(Math.Pow(2, 3));
    Console.WriteLine(Math.Sqrt(2));
    Console.WriteLine(Math.Sqrt(8));

    Console.WriteLine(Math.Round(1.7));// Round от англ. Круглый -> Округление
    Console.WriteLine(Math.Round(1.4));//Округляет по мат. правилам. До 0.5 в меньшую сторону, после 0.5 в большую
    Console.WriteLine(Math.Round(1.5));
    Console.WriteLine(Math.Round(1.1));
    Console.WriteLine();
    Console.WriteLine(Math.Round(2.5));//Округляет 0.5 до 0
    Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));//MidpointRounding округляет в большую сторону 0.5 до 1
    Console.WriteLine(Math.Round(2.5, MidpointRounding.ToEven));//округляет 0.5 до 0 

}
static void Comments()
{
    // 2.15 Comments
    // a single line comment
    /*
     *
     * multi line comment
     * we can write here many words
     */
    // describe hows and whys! not whats!
    int a = 1;
    //self evident code, we not need 
    //we need to tweak the index to match the expected outcome(Типо умный коммент. Суть в том,
    //что нужно описывать процессы, которые вызываются тем или иным участком кода. 
    //Комменты так же можно оставлять над куском кода, которому даем объяснения. Мол, так правильнее
    a++;
}
static void CastingAndParsiing()
{
    //2.14 Приведение типов и парсинг
    byte b = 3;//0000 0011
    int i = b;//0000 0000 0000 0000 0000 0000 0000 0011
    long l = i;//0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011
    float f = i;
    Console.WriteLine(f);
    b = (byte)i;
    Console.WriteLine(b);
    i = (int)f;
    Console.WriteLine(i);
    f = 3.1f;
    i = (int)f;//потеря точности
    Console.WriteLine(i);

    string str = "1";
    //i = (int)str;//не работает
    i = int.Parse(str);//работает
    Console.WriteLine($"Parsed i = {i}");

    int x = 5;
    int result = x / 2;
    Console.WriteLine(result);//потеряет значение

    double resultD = (double)x / 2;
    Console.WriteLine(resultD);
}
static void WorkWithConsoleLol()
{
    //2.13 Работа с консолью
    //Console.WriteLine("Hi, please, tell me your name");

    //string name = Console.ReadLine();
    //string sentence = $"Your name is {name}";
    //Console.WriteLine(sentence);

    Console.WriteLine("Hi, please tell me your age");
    string input = Console.ReadLine();
    int age = int.Parse(input);//изменить тип данных при выводе

    string sentence = $"Your age is {age}";
    Console.WriteLine(sentence);
    Console.Clear();//очистить консоль
    Console.BackgroundColor = ConsoleColor.Green;//Фон
    Console.ForegroundColor = ConsoleColor.Blue;//знаки, строки

    Console.Write("New Style");
    Console.Write("New Style");
}
static void StringsEqual()
{
    //2.12 Сравнение строк
    string str1 = "abc";
    string str2 = "abc";
    bool areEqual = str1 == str2;
    Console.WriteLine(areEqual);

    areEqual = string.Equals(str1, str2, StringComparison.Ordinal);//Ординал берет байтовую презентацию каждого символа и сравнивает их
    areEqual = string.Equals(str1, str2, StringComparison.InvariantCulture);//Если в языке присутствуют особенности, то он их учитывает
    areEqual = string.Equals(str1, str2, StringComparison.CurrentCulture);//Типо, учитывает ту культуру, где ты есть
    Console.WriteLine(areEqual);
}
static void StringFormat()
{
    //2.11 Форматирование строк

    string name = "John";
    int age = 30;
    string str1 = string.Format("My name is {0} and i`m {1}", name, age);

    string str2 = $"My name is {name} and i`m {age}";//интерполирование строк

    string str3 = "My name is \nJohn";
    string str4 = "i`m \t30";
    string str5 = $"My name is{Environment.NewLine}John";//Для корректной работы на разных ОС
    string str6 = "I`m John and i`m a \"good\" programmer";

    string str7 = "C:\\pmp\\test_file.txt";
    string str8 = @"C:\pmp\test_file.txt";

    double answer = 42.08;
    /*string result = string.Format("{0:d}", answer);
    string result2 = string.Format("{0:d4}", answer);*/

    string result3 = string.Format("{0:f}", answer);
    string result4 = string.Format("{0:f4}", answer);

    //Console.WriteLine(result);
    //Console.WriteLine(result2);
    //Console.WriteLine(result3);
    //Console.WriteLine(result4);

    //Console.OutputEncoding = Encoding.UTF8;

    //double money = 12.8;
    //result3 = string.Format("{0:C}", money);
    //result4 = string.Format("{0:C2}", money);
    //Console.WriteLine(money.ToString("C2"));
    //Console.WriteLine(result4);
    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");//изменение валюты
    result4 = $"{answer:C2}";
    Console.WriteLine(result4);
}
static void StringBuilder()
{
    //2.10 String Builder


    StringBuilder sb = new StringBuilder();
    sb.Append("My ");
    sb.Append("name ");
    sb.Append("is ");
    sb.Append("John");
    sb.AppendLine("!");
    sb.AppendLine("Hello!");

    string str = sb.ToString();
    Console.WriteLine(str);
}
static void StringReplaceRemoveInsertRemoveTrim()
{
    //2.9 Изменение строк

    string nameConcat = string.Concat("My", " ", "name", " ", "is", " ", "John");
    Console.WriteLine(nameConcat);

    nameConcat = string.Join(" ", "My", "name", "is", "John");
    Console.WriteLine(nameConcat);

    nameConcat = nameConcat.Insert(0, "By the way, ");
    Console.WriteLine(nameConcat);

    nameConcat = nameConcat.Remove(0, 1);
    Console.WriteLine(nameConcat);

    string replaced = nameConcat.Replace('n', 'z');
    Console.WriteLine(replaced);

    string data = "12;28;34;25;64";
    string[] splitData = data.Split(';');
    string first = splitData[3];
    Console.WriteLine(first);

    char[] chars = nameConcat.ToCharArray();
    Console.WriteLine(chars[0]);
    Console.WriteLine(nameConcat[0]);

    string lower = nameConcat.ToLower();
    Console.WriteLine(lower);

    string upper = nameConcat.ToUpper();
    Console.WriteLine(upper);

    string john = " My name is John ";
    Console.WriteLine(john.Trim());
}
static void IsNullOrEmptyOrWhiteSpace()
{
    //2.8 Пустота строк
    string empty = "";
    string whiteSpaced = " ";//isNullOrWhiteSpace определяет пробелы в строке как пустоту, когда как isNullOrEmpty определяет пробел как заполнение
    string nullString = null;
    //nullString.Contains('a'); Выведет ошибку, null это ничто

    Console.WriteLine("InNullOrEmpty");
    bool isNullOrEmpty = string.IsNullOrEmpty(nullString);
    Console.WriteLine(isNullOrEmpty);

    isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
    Console.WriteLine(isNullOrEmpty);

    isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
    Console.WriteLine(isNullOrEmpty);
}
static void QueryIngStrings()
{//2.7. Базовый API (Описание способов взаимодействия одной компьютерной программы с другими) для работы со строкам
    string name = "abracadabra";
    bool containsA = name.Contains("a");
    bool containsB = name.Contains("b");
    Console.WriteLine(containsA);
    Console.WriteLine(containsB);

    bool endsWithAbra = name.EndsWith("abra");
    Console.WriteLine(endsWithAbra);

    bool startWithAbra = name.StartsWith("abra");
    Console.WriteLine(startWithAbra);

    int indexOfA = name.IndexOf('a');
    Console.WriteLine(indexOfA);

    int lastIndexOfR = name.LastIndexOf('r');
    Console.WriteLine(lastIndexOfR);

    Console.WriteLine(name.Length);

    string subStr = name.Substring(5);
    string subStrFromTo = name.Substring(0, 3);
    Console.WriteLine(subStrFromTo);
    Console.WriteLine(subStr);
}
static void StaticAndInstanceMembers()
{
    //2.6. Экземплярные и статические методы
    string name = "Abracadabra";
    bool containsA = name.Contains('a');
    bool containsE = name.Contains('e');

    Console.WriteLine(containsA);
    Console.WriteLine(containsE);

    string abc = string.Concat("a", "b", "c");//abc экземпляр, Метод Concat вызван на статический string.
    Console.WriteLine(abc);//результатом вызова метода на статический тип будет экземпляр типа, не статический

    Console.WriteLine(int.MinValue);

    int x = 1;
    string xStr = x.ToString();
    Console.WriteLine(xStr);
}
static void ComparisonOperators()
{
    int x = 1;
    int y = 2;

    bool areEqual = x == y;
    Console.WriteLine(areEqual);

    bool result = x < y;
    Console.WriteLine(result);

    result = x >= y;
    Console.WriteLine(result);

    result = x <= y;
    Console.WriteLine(result);

    result = x != y;
    Console.WriteLine(result);
}
static void MathOperations()
{
    int x = 1;
    int y = 2;
    int z = x + y;
    int k = x - y;
    int a = z + k - y;

    Console.WriteLine(z);
    Console.WriteLine(k);
    Console.WriteLine(a);

    int b = z * 2;
    int c = k / 2;
    Console.WriteLine(b);
    Console.WriteLine(c);//не тот тип данных, нужон double

    a = 4 % 2;
    b = 5 % 2;

    Console.WriteLine(a);
    Console.WriteLine(b);

    a = 3;
    a = a * a;
    //a = a * a * a;
    Console.WriteLine(a);

    a = 2 + 2 * 2;
    Console.WriteLine(a);

    a *= 2;
    Console.WriteLine(a);
    a /= 2;
    Console.WriteLine(a);
}
static void IncremetnDecrementDemo()
{
    // 2.5 Алгебраические операции

    int x = 1;

    x++;//постфиксная
    Console.WriteLine(x);


    ++x;//инфиксная
    Console.WriteLine(x);

    x--;
    Console.WriteLine(x);

    --x;
    Console.WriteLine(x);

    Console.WriteLine("learn about incre,ents");
    Console.WriteLine($"last x state is {x}");

    int j = x++;//вперед обработается операция приравнивания, затем прибавления
    Console.WriteLine(j);
    Console.WriteLine(x);

    j = ++x;//наоборот. Вперед идет прибавление, затем приравнивание
    Console.WriteLine(j);
    Console.WriteLine(x);

    x += 2;
    Console.WriteLine(x);

    j -= 2;
    Console.WriteLine(j);
}
static void Overflow()
{
    //2.4 переполнение
    checked  //обработка при переполнении(Unhandled exception. System.OverflowException: Arithmetic operation resulted in an overflow.) Такие конструкции влияют на скорость
             //Так же можно использовать настройку в VS
    {
        uint x = uint.MaxValue;

        Console.WriteLine(x);
        x = x + 1;//Переходя к максимальному значению переменной, мы переходим на его минимальное значение(0, в нашем случае)

        Console.WriteLine(x);

        x = x - 1;

        Console.WriteLine(x);
    }
}
static void VariablesScope()
{
    //области видимости переменных
    var a = 1;
    {
        var b = 2;
        {
            var c = 3;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
        }
        Console.WriteLine(a);
        Console.WriteLine(b);
        // Console.WriteLine(c);// переменная "с" отсутствует в данном контексте. Входит в область видимости "а" и "b", но не видит "с".
    }
    Console.WriteLine(a);
    //Console.WriteLine(b); //переменная "b" отсутствует в данном контексте. Входит в область видимости "а", но не видит ни "b", ни "с".
    // Console.WriteLine(c);// переменная "с" отсутствует в данном контексте. Входит в область видимости "а" и "b", но не видит "с".
}
static void Literals()
{
    // 2.3 Области видимости переменных
    //2.2 Литералы

    //Variables();
    int x = 0b11;
    int y = 0b1001;
    int k = 0b10001001;
    int m = 0b1000_1001;
    Console.WriteLine(x);
    Console.WriteLine(y);
    Console.WriteLine(k);
    Console.WriteLine(m);

    x = 0x11F;
    y = 0xFF0D;
    k = 0x1FAB30EF;
    m = 0x1FAB_30EF;

    Console.WriteLine();

    Console.WriteLine(x);
    Console.WriteLine(y);
    Console.WriteLine(k);
    Console.WriteLine(m);

    Console.WriteLine();

    Console.WriteLine(4.5e2);//4,5*10^2
    Console.WriteLine(3.1E-1);

    Console.WriteLine();

    Console.WriteLine('\x78');
    Console.WriteLine('\x5A');
    Console.WriteLine('\u0421');
}
static void Variables()
{
    //Создание переменных
    int x = -1;
    int y;
    y = 2;
    //Int32 x1 = -1;
    uint z = 1;
    //uint x2 = -1; ток положительные
    //float f  = 1.1; Дабл в флоат сконвертировать нельзя, нужна f в конце
    double d = 2.3;
    int x2 = 0;
    int y2 = new int();

    var a = 1;
    var b = 1.2;
    var c = "adc";
    //Dictionary<int,string> dict = new Dictionary<int,string>();
    //var dict = new Dictionary<uint, string>();
    decimal d2 = 3.0m;
    char c2 = 'a';
    string acd = "war";
    bool canMove = false;
    bool canDrive = true;
    object qq = 1;
    object ww = "s";
    object hh = 'w';
    Console.WriteLine(c2);

}

























