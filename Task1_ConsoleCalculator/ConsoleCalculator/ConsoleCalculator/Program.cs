using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CalculatorLibrary;

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine("Консольный калькулятор");

            while (true)
            {
                double firstValue = GetNumberFromUser("Введите первое число:");
                char operation = GetOperatorFromUser("Выберите операцию (+, -, *, /)");
                double secondValue = GetNumberFromUser("Введите второе число:");

                try
                {
                    double result = 0;
                    switch (operation)
                    {
                        case '+':
                            result = calculator.Add(firstValue, secondValue);
                            break;
                        case '-':
                            result = calculator.Subtract(firstValue, secondValue);
                            break;
                        case '*':
                            result = calculator.Multiply(firstValue, secondValue);
                            break;
                        case '/':
                            result = calculator.Divide(firstValue, secondValue);
                            break;
                        default:
                            Console.WriteLine("Ошибка. Неизвестное действие");
                            break;
                    }
                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }



                while (true)
                {
                    Console.WriteLine("\nВыполнить еще одну операцию? (да/нет): ");
                    string choise = Console.ReadLine().ToLower();
                    if (choise == "да" || choise == "д")
                    {
                        Console.WriteLine();
                        break;
                    }
                    if (choise == "нет" || choise == "н")
                    {
                        Console.WriteLine("Спасибо за использование калькулятора! Нажмите любую клавишу для выхода.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine("Пожалуйста, введите 'да' или 'нет'.");
                }
            }
        }


        private static double GetNumberFromUser(string message)
        {
            double number;
            Console.WriteLine(message + " ");
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка. Введено не число. Попробуйте снова");
                Console.WriteLine(message + " ");
            }
            return number;
        }

        private static char GetOperatorFromUser(string message)
        {
            char operation;
            Console.WriteLine(message + " ");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length == 1 && "+-*/".Contains(input))
                {
                    operation = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка. Введите одну из операций: +, -, *, /");
                    Console.WriteLine(message + " ");
                }
            }
            return operation;
        }
    }
}
