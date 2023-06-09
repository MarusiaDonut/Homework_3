﻿using System.Collections;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Homework_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            getData();
        }
        
        static void getData()
        {
            Console.WriteLine("Уравнение a * x^2 + b * x + c = 0");
            Dictionary<string, string> data = new();
            string message = "";

            string a = "";
            string b = "";
            string c = "";
            try
            {
                Console.WriteLine("Введите значение a:");
                a = Console.ReadLine();

                Console.WriteLine("Введите значение b:");
                b = Console.ReadLine();

                Console.WriteLine("Введите значение c:");
                c = Console.ReadLine();

                int aNumber = int.Parse(a);
                int bNumber = int.Parse(b);
                int cNumber = int.Parse(c);
                if (aNumber == 0)
                {
                    throw new NegativeDisException("\nПараметр А не должен быть = 0\n");
                }
                CalculateData(aNumber, bNumber, cNumber);
            }
            catch (FormatException e)
            {
                if (!(int.TryParse(a, out int numberA)))
                {
                    message = "Неверный формат параметра A";
                    data.Add("a", a);
                }
                else if (!(int.TryParse(b, out int numberB)))
                {
                    message = "Неверный формат параметра B";
                    data.Add("b", b);
                }
                else if (!(int.TryParse(c, out int numberC)))
                {
                    message = "Неверный формат параметра C";
                    data.Add("c", c);
                }

                FormatData(message, Severity.Error, data);
            }
            catch (NegativeDisException)
            {
                message = "Дискриминант меньше 0.";
                FormatData(message, Severity.Warning, data);
            }
            catch (OverflowException)
            {
                message = "Необходимо вводить значения в диапазоне -2147483648 до 2147483647";
                FormatData(message, Severity.Info, data);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так. Введите другие данные");
            }
        }

        static void FormatData(string message, Severity severity, Dictionary<string, string> data)
        {
            if (severity.ToString() == "Error")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                
            }
            else if (severity.ToString() == "Warning")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("--------------------------------------------------");
            foreach (string key in data.Keys)
            {
                Console.WriteLine(key + " = " + data[key]);
            }
            Console.ResetColor();
        }

        static void CalculateData(int a, int b, int c)
        {
            double discriminant = Math.Pow(b, 2) - (4 * a * c);
            Console.WriteLine("\nДискриминант = {0}", Convert.ToString(discriminant));
            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
                double x2 = (-b - Math.Sqrt(discriminant)) / 2 * a;
                Console.WriteLine("x1 = {0}, x2 = {1}", Convert.ToString(x1), Convert.ToString(x2));
            }
            else if (discriminant == 0)
            {
                double x = (-b + Math.Sqrt(discriminant)) / 2 * a;
                Console.WriteLine("x = {0}", Convert.ToString(x));
            }
            else
            {
                throw new NegativeDisException("Вещественных значений не найдено");
            }
        }
    }
}