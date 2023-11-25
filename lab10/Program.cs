using System;
using System.IO;

class Program
{
    private static StreamWriter logger;

    static void Main(string[] args)
    {
        // Инициализация логгера
        InitializeLogger();

        // Просим пользователя ввести число N
        Console.Write("Введите натуральное число N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Log("Некорректный ввод. Введите натуральное число больше 0.");
            CloseLogger();
            return;
        }

        // Просим пользователя ввести количество попыток k
        Console.Write("Введите количество попыток k: ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0)
        {
            Log("Некорректный ввод. Введите натуральное число больше 0.");
            CloseLogger();
            return;
        }

        // Загадываем число от 1 до N
        int secretNumber = new Random().Next(1, N + 1);
        Log($"Загадано число от 1 до {N}");

        // Проводим игру
        for (int i = 1; i <= k; i++)
        {
            // Просим пользователя ввести число
            Console.Write($"Попытка {i}. Введите ваш вариант: ");
            if (!int.TryParse(Console.ReadLine(), out int userGuess))
            {
                Log("Некорректный ввод. Введите целое число.");
                i--; // Отменяем попытку, так как ввод был некорректным
                continue;
            }

            // Проверяем, угадал ли пользователь
            if (userGuess == secretNumber)
            {
                Log($"Поздравляем! Вы угадали число {secretNumber}!");
                break;
            }
            else
            {
                // Сообщаем пользователю, больше или меньше его число
                Log(userGuess < secretNumber ? "Загаданное число больше." : "Загаданное число меньше.");
            }

            // Если попытки закончились, завершаем игру
            if (i == k)
            {
                Log($"Попытки закончились. Загаданное число было: {secretNumber}");
            }
        }

        // Закрываем логгер
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
