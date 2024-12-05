using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "mynum.txt";
        bool exit = false;

        Console.WriteLine("Горкун Олександр");

        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати числа у файл");
            Console.WriteLine("2. Вивести вміст файлу");
            Console.WriteLine("3. Обчислити суму чисел із файлу");
            Console.WriteLine("4. Вийти");
            Console.Write("Виберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AppendNumbersToFile(filePath);
                    break;
                case "2":
                    DisplayFileContents(filePath);
                    break;
                case "3":
                    CalculateSumFromFile(filePath);
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    // Додавання чисел у файл
    static void AppendNumbersToFile(string filePath)
    {
        Console.WriteLine("Введіть дробові числа (через Enter). Для завершення введіть 'q'.");
        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            while (true)
            {
                Console.Write("Число: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "q") break;

                if (double.TryParse(input, out double number))
                {
                    writer.WriteLine(number);
                }
                else
                {
                    Console.WriteLine("Некоректне значення. Спробуйте ще раз.");
                }
            }
        }
        Console.WriteLine("Числа успішно додано у файл.");
    }

    // Виведення вмісту файлу
    static void DisplayFileContents(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        Console.WriteLine("\nВміст файлу:");
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    // Обчислення суми чисел із файлу
    static void CalculateSumFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено.");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        List<double> numbers = new List<double>();
        double sum = 0;

        Console.WriteLine("\nВміст файлу та обчислення:");
        for (int i = 0; i < lines.Length; i++)
        {
            if (double.TryParse(lines[i], out double number))
            {
                numbers.Add(number);
                sum += number;
                Console.WriteLine($"{i + 1,2} element – {number,8:F2}");
            }
            else
            {
                Console.WriteLine($"{i + 1,2} element – Некоректні дані: \"{lines[i]}\"");
            }
        }

        Console.WriteLine(new string('*', 25));
        Console.WriteLine($"Summa = {sum,8:F2}");
    }
}
