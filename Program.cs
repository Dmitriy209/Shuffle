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
                        ShuffleCards();
                        break;

                    default:
                        Shuffle(MakeArrayLine(userInput));
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Вы вышли из программы.");
        }

        static void Shuffle(char[] symbols)
        {
            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = symbols.Length;

            char tempElement;

            for (int i = 0; i < symbols.Length; i++)
            {
                int indexRandom = random.Next(minLimitRandom, maxLimitRandom);

                tempElement = symbols[i];
                symbols[i] = symbols[indexRandom];
                symbols[indexRandom] = tempElement;
            }

            Console.WriteLine("Получилась белиберда:");
            Console.WriteLine();

            foreach (char symbol in symbols)
                Console.Write(symbol);

            Console.WriteLine();
        }

        static void ShuffleCards()
        {
            string[] cards = { "J", "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "Q", "K", "A" };

            Console.WriteLine($"Изначальная колода:");
            ShowDeck(cards);

            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = cards.Length;

            string tempElement;

            for (int i = 0; i < cards.Length; i++)
            {
                int indexRandom = random.Next(minLimitRandom, maxLimitRandom);

                tempElement = cards[i];
                cards[i] = cards[indexRandom];
                cards[indexRandom] = tempElement;
            }

            Console.WriteLine("Ваша колода, сэр.");
            ShowDeck(cards);
        }

        static char[] MakeArrayLine(string line)
        {
            char[] arrayLine = new char[line.Length];

            for (int i = 0; i < line.Length; i++)
                arrayLine[i] = line[i];

            return arrayLine;
        }

        static void ShowDeck(string[] deck)
        {
            string space = " ";

            foreach (string card in deck)
                Console.Write(card + space);

            Console.WriteLine();
        }
    }
}
