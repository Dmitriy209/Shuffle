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
                    $"Или что угодно, чтобы перемешать колоду карт.\n");
                string userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;

                    default:
                        ShuffleCards(cards);
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

        static void ShuffleCards(string[] cards)
        {
            string space = " ";

            string[] cardsMix = new string[cards.Length];

            for (int i = 0; i < cards.Length; i++)
                cardsMix[i] = cards[i];

            Console.WriteLine($"Изначальная колода:");
            ShowArray(cards, space);

            cardsMix = Shuffle(cardsMix);

            Console.WriteLine("Ваша колода, сэр.");
            ShowArray(cardsMix, space);
        }

        static void ShowArray(string[] array, string separator = "")
        {
            foreach (string element in array)
                Console.Write(element + separator);

            Console.WriteLine();
        }
    }
}
