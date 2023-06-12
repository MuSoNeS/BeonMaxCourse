
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
bool isTooLow = bMI <= 18.5;
bool isNormal = bMI > 18.5 && bMI < 25;
bool isAboveNormal = bMI >= 25 && bMI <= 30;
bool isTooFat = bMI > 30;
bool isFat = isAboveNormal || isTooFat;
if (isFat)
{
    Console.WriteLine("You`d better lose weeight");
}
else
{
    Console.WriteLine("Oh, you`r in a good shape!");
}
