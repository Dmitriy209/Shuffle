using System;

namespace Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ButtonExit = "exit";

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"Введите {ButtonExit}, чтобы выйти или что-нибудь ещё.");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ButtonExit:
                        isRunning = false;
                        break;
                    default:
                        char[] userInputMix = Shuffle(userInput);


                        break;
                }
            }
        }

        static char[] Shuffle(string line)
        {
            Random random = new Random();

            int minLimitRandom = 0;
            int maxLimitRandom = line.Length;

            char[] lineMix = new char[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                int indexMix = random.Next(minLimitRandom, maxLimitRandom);
                int char symbolMix = ;

                lineMix[indexMix] = line[i];
            }

                

            

            return lineMix;
        }
    }
}