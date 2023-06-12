
using assignmentsFromTheBeonMaxCourse;
using System;
using System.Data;
using System.Security.Authentication;
using assignmentsFromTheBeonMaxCourse;




//Вы попробуете реализовать игру в крестики-нолики размером 3х3 - самые что ни на есть обыкновенные.

//Сделайте метод, который выводит на каждом ходу текущее положение с линейками, крестиками и ноликами

//(используйте буквы X и O в качестве крестиков и ноликов) -так игрокам будет удобнее ориентироваться.

//Также вам понадобится реализовать способ проверки наличия выигрышной комбинации. Подсказка: договоримся,

//что клетки поля будут пронумерованы от 0 до 8 и пользователи будут вводить индекс поля, чтобы поставить там крестик или нолик.

















static void GuessNumber()
{
    //угадайка 8.2
    GuessTheNumber ex = new GuessTheNumber();




    for (int i = 0; i <= ex.attempt; i++)
    {
        if (ex.inputGuessNumber < 0 || ex.inputGuessNumber > 10)
        {
            Console.WriteLine("Вы ввели число, не входящее в диапозон заданныx значений");

        }
        Console.WriteLine($"Попытка номер: {i}\n{ex.guessNumber}");
        ex.inputGuessNumber = Convert.ToInt32(Console.ReadLine());



        if (ex.inputGuessNumber < ex.randomazer)
        {
            Console.WriteLine("Ваше число меньше заданного");
        }
        if (ex.inputGuessNumber > ex.randomazer)
        {
            Console.WriteLine("Ваше число больше заданного");
        }
        if (ex.inputGuessNumber == ex.randomazer)
        {
            Console.WriteLine("Поздравляю, вы угадали!");
            break;
        }



    }

}
static void TryParseEx()
{
    //5.10. Выходные out-параметры
    //try do, try xxx
    Console.WriteLine("Enter the number");
    TryDivide tryDivide = new TryDivide();
    if (tryDivide.TryDivides(10, 2, out double result))
    {
        Console.WriteLine(result);
    }
    else
    {
        Console.WriteLine("failed");
    }
    string line = Console.ReadLine();
    //int number;  Можно так
    bool wasParsed = int.TryParse(line, out int number);//out - выходной аргумент, можно объявлять тип переменной после out
    if (wasParsed)
    {
        Console.WriteLine(number);
    }
    else
    {
        Console.WriteLine("Failed parse");
    }
}
static void PracticalTask5_7()
{
    //Урок 5.7. Практическое задание "Перегрузка"
    PracticalTask square = new PracticalTask();


    double ab = 2;
    double ac = 10;
    int alpha = 40;
    double a = 22;
    double h = 13;
    double square1 = square.OverloadInTask(ab, ac, alpha);
    double square2 = square.OverloadInTask(a, h);

    Console.WriteLine(square1);
    Console.WriteLine(square2);
}
//ЕЩЕ НЕ МОЙ УРОВЕНЬ, ВЕРНУТЬСЯ ПОЗЖЕ И РЕШИТЬ САМОСТОЯТЕЛЬНО ЗАДАЧУ 4.8
static void CArraysCollections (){
//    class RomanNumeral {

//        //Написать функцию, которая принимает на вход строку - римское число, а возвращает это число в арабском виде.
//        //Например, если передаём "XV" - должна вернуть 15, если передаём "IV" - должна вернуть 4.
//        private static Dictionary<char, int> map = new Dictionary<char, int>()
//{
//    {'I', 1 },
//    {'V', 5 },
//    {'X', 10 },
//    {'L', 50 },
//    {'C', 100 },
//    {'D', 500 },
//    {'M', 1000 },
//};


//        public static int Parse(string roman)
//    {  
//            int result = 0;
//        for(int i = 0; i < roman.Length; i++)
//            {
//                if(i+1<roman.Length && isSubtractive(roman[i], roman[i + 1]))
//                {
//                    result -= map[;
//                }
//            }
//    }

//        private static bool isSubtractive(char c1, char c2)
//        {
//            return map[c1] < map[c2];
//        }
//    }
//    //Вот список римских символов и их отображение на арабские числа:
//    //I - 1
//    //V - 5
//    //X - 10
//    //L - 50
//    //C - 100
//    //D - 500
//    //M - 1000

//    //Варианты типа IIIV = 5-3 = 2 мы не рассматриваем. Хотя Римляне и пользовались иногда такими видами записей,
//    //но есть разная информация о приемлимости оных. В нашем ДЗ такие варианты мы не рассматриваем. Вот выдержка из wiki:
//    //"Необходимо отметить, что другие способы «вычитания» недопустимы; так, число 99 должно быть записано как XCIX, но не как IC."

//    //Подсказка.Для решения надо реализовать два правила:
//    //Правила записи чисел римскими цифрами:
//    //-если большая цифра стоит перед меньшей, то они складываются (принцип сложения)
//    //-если меньшая цифра стоит перед большей, то меньшая вычитается из большей (принцип вычитания).

//    //Защиту от некорректного ввода реализовать по вашему желанию (можно не делать, но для тренировки всегда полезно).

}
static void ThreeAuthenticationAttempts()
{
    //3.12 practical task three authentication attempts
    //Запросить у пользователя логин и пароль. Дать пользователю только три попытки для ввода корректной пары логин\пароль.
    //Если пользователь произвёл корректный ввод, вывести на консоль: "Enter the System" и прекратить запрос логина\пароля.
    //Если пользователь ошибся трижды - вывести "The number of available tries have been exceeded" и прекратить запрос пары логин\пароль.
    int count = 0;
    bool cond = false;

    while (count != 3)
    {
        Console.WriteLine("Please enter your login");
        string login = Console.ReadLine();
        Console.WriteLine("Please enter your password");
        string pass = Console.ReadLine();
        if (login == "johnsilver" && pass == "qwerty" && count < 3)
        {
            Console.WriteLine("Enter the System");
            cond = true;
            break;
        }

        count++;
    }
    if (cond == false)
    {
        Console.WriteLine("The number of available tries have been exceeded");

    }

}
static void FactorialCalculation()
{
    //3.11 Factorial calculation
    //запросить у пользователя число, факториал которого необходимо вычислить и произвести вычисление.
    Console.WriteLine("Please enter the number whose factorial you want to calculate");
    int userFactorialInput = int.Parse(Console.ReadLine());
    int calculate = 1;
    for (int i = 1; i <= userFactorialInput; i++)
    {
        if (userFactorialInput == 0)
        {
            Console.WriteLine("1");
            break;
        }
        else if (userFactorialInput == 1)
        {

            break;
        }
        calculate *= i;

    }

    //Затем вывести результат вычисления.
    Console.WriteLine(calculate);
    //Восклицательный знак запрашивать не надо, кроме того, в C# такой операции нет. Для вычисления факториала надо производить перемножение.
}
static void AverageCalculation()
{
    //3.10 Practical task Average calculation
    //Запросить у пользователя не более 10 целых положительных чисел.
    Console.WriteLine("Please enter no more than 10 integers");
    //Пользователь может прекратить приём чисел, введя 0.
    Console.WriteLine("You can stop entering numbers by entering 0");


    int[] userInput = new int[10];
    int userOutput = 0;
    int jCountInUserOutputForeach = 0;

    for (int i = 0; i < 10; i++)
    {

        userInput[i] = int.Parse(Console.ReadLine());
        //После прекращения приёма целых чисел
        //(это происходит в случае если было введено 10 чисел, либо пользователь ввёл 0, чтобы не вводить все 10)
        if (userInput[i] == 0)
        {
            break;
        }
        else
        {
            if (userInput[i] % 3 == 0)
            {
                userOutput = userOutput + userInput[i];
                jCountInUserOutputForeach++;

            }
        }
    }


    int average = userOutput / jCountInUserOutputForeach;
    //подсчитать среднее значение целых положительных чисел кратных трём и вывести на консоль.
    Console.WriteLine(average);


    
}
static void FibonacciNumbers()
{
    //3.9 Practical task Fibonacci numbers
    //Числа Фибоначчи описываются следующей последовательностью: 1, 1, 2, 3, 5, 8, 13, 21…
    //Первые два числа - единицы. Все последующие числа вычисляются как сумма двух предыдущих.

    //Задание: запросить у пользователя кол-во чисел Фибоначчи, которое он хотел бы сгенерировать (вычислить), и, собственно,
    //произвести генерацию (вычисление). В процессе генерации записывать числа в массив. После генерации вывести вычисленные числа.


    Console.WriteLine("Please enter number of numbers");
    long counterToFor = long.Parse(Console.ReadLine());//8
    if (counterToFor < 0)
    {
        Console.WriteLine("Sorry you number is wrong");
    }
    else
    {
        long one = 1;
        long two = 0;

        for (int j = 0; j < counterToFor; j++)
        {
            long[] numbersOfFibonacci = new long[counterToFor];

            numbersOfFibonacci[j] = one + two;
            Console.WriteLine(numbersOfFibonacci[j]);
            one = two;
            two = numbersOfFibonacci[j];
        }
    }
}
static void FirstTask()
{
    //1.Запросить имя пользователя. Вывести Hello, [имя пользователя].
    Console.WriteLine("What is your name?");
    string userName = Console.ReadLine();
    Console.WriteLine($"Hello, {userName}! How are things at work?");

    //2. Запросить у пользователя два целых числа и сохранить в двух переменных. Вывести значения.
    Console.WriteLine("Please inter two integer");
    string firstInt = Console.ReadLine();
    string secondInt = Console.ReadLine();
    Console.WriteLine($"You intered first: {firstInt} and second: {secondInt}?");

    //Обменять значения переменных: например, если в переменной x было записано число 3, а в y число 5, сделать так, чтобы в y стало 3, а в x стало 5. Вывести значения после обмена.
    Console.WriteLine("Now i`ll swap them");
    string thirdInt = secondInt;
    string fourthInt = firstInt;
    Console.WriteLine($"Your first number will be {thirdInt} and your second number will be {fourthInt}");
    //3. Запросить у пользователя целое число. Вывести количество цифр числа. Например, в числе 156 - 3 цифры.
    Console.WriteLine("Please enter any number to count the number of characters");
    string input = Console.ReadLine();
    int count = input.Count();
    Console.WriteLine(count);
}
static void HeronsFormula()
{
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

}
static void BodyMassIndex()
{
    //2.20 Practical task "User Profile"
    //Запросить у пользователя: фамилию, имя, возраст, вес, рост.
    Console.WriteLine("Please tell your last name(letters), first name(letters), age(numbers), weight(numbers), height(numbers)");
    Console.WriteLine("Last name:");
    string userLastName = Console.ReadLine();
    Console.WriteLine("First name:");
    string userFirstName = Console.ReadLine();
    Console.WriteLine("Age:");
    double userAge = double.Parse(Console.ReadLine());
    Console.WriteLine("Weight:");
    double userWeight = double.Parse(Console.ReadLine());
    Console.WriteLine("Height:");
    double userHeigth = double.Parse(Console.ReadLine());
    //Рассчитать ИМТ (индекс массы тела) по формуле ИМТ = вес (кг) / (рост(м) * рост(м))
    double bMI = userWeight / (userHeigth * userHeigth);
    //Сформировать единую строку, в следующем формате:
    //Your profile:
    //Full Name: фамилия, имя
    //Age: рост
    //Weight: вес
    //Height: рост
    //Body Mass Index: ИМТ
    //Вывести сформированную строку на консоль.
    Console.WriteLine($"Your profile:\n" +
        $"Full name: {userLastName} {userFirstName}\n" +//Environment.NewLine
        $"Age: {userAge}\n" +
        $"Weight: {userWeight}\n" +
        $"Height: {userHeigth}\n" +
        $"Body Mass Index: {bMI}");
    

    
}
static void FindingTheMaximum()
{
    //3.2 Finding the maximum
    //Запросить у пользователя два целочисленных значения и найти максимум
    Console.WriteLine("Enter two integers");
    int first = int.Parse(Console.ReadLine());
    int second = int.Parse(Console.ReadLine());
    if (first > second)
    {
        Console.WriteLine(first);
    }
    else
    {
        Console.WriteLine(second);
    }
}