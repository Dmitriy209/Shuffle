using System;

namespace Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ButtonExit = "exit";
            const string ButtonShuffleCards = "shufflecards";

            bool isRunning = true;

            string[] cards = { "J", "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "Q", "K", "A" };

            while (isRunning)
            {
                Console.WriteLine($"Введите {ButtonExit}, чтобы выйти.\n" +
                    $"Введите {ButtonShuffleCards}, чтобы перемешать колоду карт.\n" +
                    $"Введите что угодно, чтобы получилась белиберда.");
                string userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;

                    case ButtonShuffleCards:
                        ShuffleCards(cards);
                        break;

                    default:
                        ShuffleLine(MakeArrayLine(userInput));
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Вы вышли из программы.");
        }

        static string[] Shuffle(string[] symbols)
        {
            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = symbols.Length;

            string tempElement;

            for (int i = 0; i < symbols.Length; i++)
            {
                int indexRandom = random.Next(minLimitRandom, maxLimitRandom);

                tempElement = symbols[i];
                symbols[i] = symbols[indexRandom];
                symbols[indexRandom] = tempElement;
            }

            return symbols;
        }

        static void ShuffleLine(string[] line)
        {
            line = Shuffle(line);

            Console.WriteLine("Получилась белиберда:");

            ShowArray(line);
        }

        static void ShuffleCards(string[] cards)
        {
            string space = " ";

            Console.WriteLine($"Изначальная колода:");
            ShowArray(cards, space);

            cards = Shuffle(cards);

            Console.WriteLine("Ваша колода, сэр.");
            ShowArray(cards, space);
        }

        static string[] MakeArrayLine(string line)
        {
            string[] arrayLine = new string[line.Length];

            for (int i = 0; i < line.Length; i++)
                arrayLine[i] = Convert.ToString(line[i]);

            return arrayLine;
        }

        static void ShowArray(string[] array, string separator = "")
        {
            foreach (string element in array)
                Console.Write(element + separator);

            Console.WriteLine();
        }
    }
}
