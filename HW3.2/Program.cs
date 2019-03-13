using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3._2
{
    class Program
    {
        public static Dictionary<string, int> students = new Dictionary<string, int>();
        public static void InvalidInputMessage()
        {
            Console.WriteLine("Input has wrong format! Desired format: 'Surname:Mark'");
            Console.WriteLine("Mark should be a number from 1 to 5'");
        }
        public static void Run()
        {
            Console.WriteLine("Please enter students and their marks: (enter 'stop' to finish)");
            while (true)
            {
                string inputString = Console.ReadLine();
                if (inputString == "stop")
                {
                    break;
                }
                string[] surname_key = inputString.Split(new char[] { ':' });
                if (surname_key.Length > 2)
                {
                    InvalidInputMessage();
                    continue;
                }
                string studentSurname = surname_key[0];
                if (!isCharAndDigit(studentSurname))
                {
                    InvalidInputMessage();
                    continue;
                }
                var isMarkParsed = int.TryParse(surname_key[1], out var studentMark);
                if (!isMarkParsed)
                {
                    InvalidInputMessage();
                    continue;
                }
                if (studentMark < 1 || studentMark > 5)
                {
                    Console.WriteLine("Mark should be a number from 1 to 5. Try again");
                    continue;
                }
                students.Add(studentSurname, studentMark);
            }
            Console.WriteLine();
            DictionaryDisplay();

        }

        public static void ShowMark(int mark)
        {
            if (students.ContainsValue(mark))
            {
                Console.WriteLine($"Students with {mark} mark:");
                foreach (var item in students)
                {
                    if (item.Value == mark)
                    {
                        Console.Write($"{item.Key}" + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine($"There are no students with {mark} mark");
            }
            Console.WriteLine();
        }

        public static bool ShowStudent(string inputString, out bool isOK)
        {
            try
            {
                Console.WriteLine($"Student {inputString} received a {students[inputString]}");
            }
            catch (System.Collections.Generic.KeyNotFoundException e)
            {
                Console.WriteLine("Input has wrong format");
                return isOK = false;
            }
            return isOK = true;
        }

        public static void DictionaryDisplay()
        {
            while (true)
            {
                Console.WriteLine("Please enter surname to see student's mark or a mark to see all students with it:");
                Console.WriteLine("Or enter 'exit' to exit");
                string inputString = Console.ReadLine();
                if (inputString == "exit")
                {
                    Environment.Exit(0);
                }
                var isMark = int.TryParse(inputString, out var mark);
                if (isMark == true)
                {
                    ShowMark(mark);
                }
                else
                {
                    bool isOK;
                    ShowStudent(inputString, out isOK);
                    if (!isOK)
                    {
                        continue;
                    }
                }
            }
        }

        //этот метод остался из прошлой реализации

        //public static bool isDigit(string str)
        //{
        //    for(int i = 0; i < str.Length; i++)
        //    {
        //        if(str[i] >= '0' && str[i] <= '9')
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
        //метод, который проверяет фамилию на наличие цифр. 
        //Если фамилия состоит более чем на 50% из цифр - просим ввести новую фамилию
        //Мы вчера обсуждали разрешены ли цифры в фамилии и я сделал update своего метода
        public static bool isCharAndDigit(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
                {
                    continue;
                }
                else
                {
                    count++;
                }
            }
            if (count > str.Length / 2)
            {
                return false;
            }
            count = 0;
            return true;
        }
        static void Main(string[] args)
        {
            Run();

            Console.ReadLine();
        }
    }
}
