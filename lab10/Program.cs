using System;
using System.IO;

class Program
{
    private static StreamWriter logger;

    static void Main(string[] args)
    {
        InitializeLogger();

        Console.Write("Введите натуральное число N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Log("Некорректный ввод. Введите натуральное число больше 0.");
            CloseLogger();
            return;
        }

        Console.Write("Введите количество попыток k: ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0)
        {
            Log("Некорректный ввод. Введите натуральное число больше 0.");
            CloseLogger();
            return;
        }

        int secretNumber = new Random().Next(1, N + 1);
        Log($"Загадано число от 1 до {N}");

        for (int i = 1; i <= k; i++)
        {
            Console.Write($"Попытка {i}. Введите ваш вариант: ");
            if (!int.TryParse(Console.ReadLine(), out int userGuess))
            {
                Log("Некорректный ввод. Введите целое число.");
                i--;
                continue;
            }

            if (userGuess == secretNumber)
            {
                Log($"Поздравляем! Вы угадали число {secretNumber}!");
                break;
            }
            else
            {
                Log(userGuess < secretNumber ? "Загаданное число больше." : "Загаданное число меньше.");
            }

            if (i == k)
            {
                Log($"Попытки закончились. Загаданное число было: {secretNumber}");
            }
        }

        CloseLogger();
    }

    private static void InitializeLogger()
    {
        logger = new StreamWriter("log.txt");
        Log("Игра началась");
    }

    private static void Log(string message)
    {
        string logMessage = $"{DateTime.Now} - {message}";
        Console.WriteLine(logMessage);
        logger.WriteLine(logMessage);
    }

    private static void CloseLogger()
    {
        logger.Close();
    }
}