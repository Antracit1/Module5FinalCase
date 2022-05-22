using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5FinalCase
{
    class Program
    {
        static (string Name, string Surname, int Age, int PetsQuantity, string[] Pets, int ColorsQuantity, string[] Colors) CollectUserInfo()
        {
            (string Name, string Surname, int Age, int PetsQuantity, string[] Pets, int ColorsQuantity, string[] Colors) User;

            User.Name = ReadString("Напишите свое имя");
            User.Surname = ReadString("Напишите свою фамилию");

            User.Age = ReadPositiveIntegerNumber("Напишите свой возраст в цифрах");

            Console.WriteLine("Есть ли у Вас питомцы? да/нет");
            string pet = Console.ReadLine();
            if (pet == "да")
            {
                User.PetsQuantity = ReadPositiveIntegerNumber("Сколько у Вам питомцев?");
                User.Pets = ReadStringArray(User.PetsQuantity, "Кличка вашего питомца № {0}"); 
            }
            else
            {
                User.PetsQuantity = 0;
                User.Pets = new string[0];
            }

            User.ColorsQuantity = ReadPositiveIntegerNumber("Введите кол-во любимых цветов цифрой, минимум один цвет");
            Console.WriteLine("Какие Ваши любимые цвета?");

            User.Colors = ReadStringArray(User.ColorsQuantity, "Ваш любимый цвет № {0}"); 

            return User;
        }

        static string[] ReadStringArray(int numberOfElements, string messageFormat)
        {
            string[] result = new string[numberOfElements];
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(messageFormat, i + 1);
                result[i] = Console.ReadLine();
            }

            return result;
        }

        static string ReadString(string message)
        {
            Console.WriteLine(message);
            string result = Console.ReadLine();

            return result;
        }

        static int ReadPositiveIntegerNumber(string message)
        {
            Console.WriteLine(message);

            int result = -1;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Введите целое число");
                }
                else if (result <= 0)
                {
                    Console.WriteLine("Вводимое число должно быть больше ноля, повторите ваш ввод:");
                }
            } while (result <= 0);

            return result;
        }

        static void ShowUserInfo((string Name, string Surname, int Age, int PetsQuantity, string[] Pets, int ColorsQuantity, string[] Colors) User)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"АНКЕТА ПОЛЬЗОВАТЕЛЯ:\r\n\r\nИмя: {User.Name} {User.Surname}");
            Console.WriteLine($"Возраст: {User.Age} лет/года");
            if (User.PetsQuantity > 0)
            {
                ShowStringArray(User.Pets, "Ваши питомцы");
            }
            else
            {
                Console.WriteLine("Питомцев нет");
            }
            ShowStringArray(User.Colors, "Ваши любимые цвета:");
        }

        static void ShowStringArray(string[] array, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"->{array[i]}");
            }
        }

        static void Main(string[] args)
        {
            var User = CollectUserInfo();
            ShowUserInfo(User);

            Console.ReadKey();

        }

    }

} 

