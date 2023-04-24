using System;
//test review
namespace hw2
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите задачу (1-4) или введите 'q' для выхода:");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                int taskNumber;
                if (int.TryParse(input, out taskNumber) && taskNumber >= 1 && taskNumber <= 4)
                {
                    switch (taskNumber)
                    {
                        case 1:
                            Task1();
                            break;

                        case 2:
                            Task2();
                            break;

                        case 3:
                            Task3();
                            break;

                        case 4:
                            Task4();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 4 или 'q' для выхода.");
                }

                Console.WriteLine();
            }
        }

        // Генерация текста с цифрами
        static string GenerateTextWithDigitsAndSpaces(int length)
        {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

        // Задача 1
        static void Task1()
        {
            string text = GenerateTextWithDigitsAndSpaces(30);
            Console.WriteLine("Сгенерированный текст: " + text);

            int sum = 0;
            int? maxDigit = null;
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    int digit = int.Parse(c.ToString());
                    sum += digit;
                    maxDigit = maxDigit.HasValue ? Math.Max(maxDigit.Value, digit) : digit;
                }
            }

            Console.WriteLine("Сумма цифр: " + (maxDigit.HasValue ? sum.ToString() : "В тексте нет цифр"));
            Console.WriteLine("Максимальная цифра: " + (maxDigit.HasValue ? maxDigit.ToString() : "В тексте нет цифр"));
        }

        // Задача 2
        static void Task2()
        {
            string text = "   " + GenerateTextWithDigitsAndSpaces(30);
            Console.WriteLine("Сгенерированный текст: " + text);

            int? maxDigit = null;
            int? index = null;
            int nonSpaceIndex = 0;

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c != ' ')
                {
                    if (char.IsDigit(c))
                    {
                        int digit = int.Parse(c.ToString());
                        if (!maxDigit.HasValue || digit > maxDigit.Value)
                        {
                            maxDigit = digit;
                            index = nonSpaceIndex;
                        }
                    }
                    nonSpaceIndex++;
                }
            }

            Console.WriteLine("Индекс максимальной цифры: " + (index.HasValue ? index.ToString() : "В тексте нет цифр"));
        }

        // Генерация количества страниц для книг
        static int[] GeneratePageCounts(int numBooks)
        {
            int[] pageCounts = new int[numBooks];
            for (int i = 0; i < numBooks; i++)
            {
                pageCounts[i] = random.Next(1, 1001);
            }

            return pageCounts;
        }

        // Задача 3
        static void Task3()
        {
            int[] pages = GeneratePageCounts(100);
            Console.WriteLine("Сгенерированные количества страниц: " + string.Join(", ", pages));

            int maxPages = -1;

            foreach (int pageCount in pages)
            {
                maxPages = Math.Max(maxPages, pageCount);
            }

            Console.WriteLine("Максимальное количество страниц: " + maxPages);
        }

        // Генерация максимальных скоростей автомобилей
        static int[] GenerateCarSpeeds(int numCars)
        {
            int[] carSpeeds = new int[numCars];

            for (int i = 0; i < numCars; i++)
            {
                carSpeeds[i] = random.Next(100, 301);
            }

            return carSpeeds;
        }

        // Задача 4
        static void Task4()
        {
            int[] maxSpeeds = GenerateCarSpeeds(40);
            Console.WriteLine("Сгенерированные максимальные скорости: " + string.Join(", ", maxSpeeds));

            int fastestCar = -1;
            int firstIndex = -1;
            int lastIndex = -1;

            for (int i = 0; i < maxSpeeds.Length; i++)
            {
                if (maxSpeeds[i] > fastestCar)
                {
                    fastestCar = maxSpeeds[i];
                    firstIndex = i;
                    lastIndex = i; // Обновляем последний индекс, когда найден новый самый быстрый автомобиль
                }
                else if (maxSpeeds[i] == fastestCar)
                {
                    lastIndex = i; // Обновляем последний индекс, если текущий автомобиль имеет такую же максимальную скорость, как самый быстрый
                }
            }

            Console.WriteLine("Индекс самого быстрого автомобиля (первый): " + firstIndex);
            Console.WriteLine("Индекс самого быстрого автомобиля (последний): " + lastIndex);
        }

    }
}
