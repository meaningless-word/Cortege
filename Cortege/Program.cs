using System;

namespace Cortege
{
    class Program
    {
        static void Main(string[] args)
        {
            var User = GetAllAbout();
            Console.WriteLine("\n{0}\n", new string('-', 20));
            ShowAllAbout(User);
            Console.ReadKey();
        }

        static (string Name, string Family, int Age, string[] Pets, string[] favColors) GetAllAbout()
        {
            (string Name, string Family, int Age, string[] Pets, string[] favColors) Person;

            Console.WriteLine("Введите имя пользователя");
            Person.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию пользователя");
            Person.Family = Console.ReadLine();

            string sAge;
            int iAge;
            do
            {
                Console.WriteLine("Введите возраст цифрами");
                sAge = Console.ReadLine();
            } while (!CheckNum(sAge, out iAge));
            Person.Age = iAge;

            Console.WriteLine("Словом \"есть\" подтвердите наличие питомца. Любые другие варианты будут приняты за отказ");
            string sHavePets = Console.ReadLine();
            if (sHavePets == "есть")
            {
                string sNumberOfPets;
                int iNumberOfPets;
                do
                {
                    Console.WriteLine("Введите количество питомцев цифрами");
                    sNumberOfPets = Console.ReadLine();
                } while (!CheckNum(sNumberOfPets, out iNumberOfPets));
                Person.Pets = GetStringArray(iNumberOfPets, "кличку питомца");
            }
            else Person.Pets = new string[0];

            string sNumberOfColors;
            int iNumberOfColors;
            do
            {
                Console.WriteLine("Введите количество любимых цветов цифрами");
                sNumberOfColors = Console.ReadLine();
            } while (!CheckNum(sNumberOfColors, out iNumberOfColors));
            Person.favColors = GetStringArray(iNumberOfColors, "любимый цвет");

            return Person;
        }

        static void ShowAllAbout((string Name, string Family, int Age, string[] Pets, string[] favColors) Person)
        {
            Console.WriteLine("Информация о пользователе:");
            Console.WriteLine("Имя: {0}\nФамилия: {1}\nВозраст: {2}\n", Person.Name, Person.Family, Person.Age);
            Console.WriteLine("Питомцев {0}", Person.Pets.Length == 0 ? "нет" : Person.Pets.Length.ToString());
            for (int i = 0; i < Person.Pets.Length; i++)
                Console.WriteLine(Person.Pets[i]);
            Console.WriteLine("Любимых цветов: {0}", Person.favColors.Length);
            for (int i = 0; i < Person.favColors.Length; i++)
                Console.WriteLine(Person.favColors[i]);
        }

        static bool CheckNum(string sNum, out int iNum)
        {
            if (int.TryParse(sNum, out int i))
            {
                if (i > 0)
                {
                    iNum = i;
                    return true;
                }
            }
            
            iNum = 0;
            return false;
        }

        static string[] GetStringArray(int quantity, string title)
        {
            var result = new string[quantity];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите {0} {1}", title, i + 1);
                result[i] = Console.ReadLine();
            }

            return result;
        }
    }
}
