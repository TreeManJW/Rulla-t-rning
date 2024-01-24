using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int numberOfDice;
        private static int numberOfTries;
        private static int sumProb;
        private static int result = 0;
        private static Random randomizer = new Random(DateTime.Today.Millisecond);
        private static int counter = 1;
        // static async Task Initializer()
        //{
        //  Task[] rollDice = new Task[numberOfTries];

        //            for (int i = 0; i < numberOfTries; i++)
        //          {
        //            rollDice[i] = Dice();
        //      }

        //   await Task.WhenAll(rollDice);
        // }
        static async Task Dice()
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" + counter);
            counter++;
            int[] diceResults = new int[numberOfDice];
            for (int j = 0; j < numberOfDice; j++)
            {
                Console.WriteLine("Rolling dice nr " + j);
                diceResults[j] = randomizer.Next(1, 7);
                Console.WriteLine(diceResults[j]);
            }
;           Console.WriteLine("Looking for possible matches, please stand by!");
            if (diceResults.Sum(x => x) == sumProb)
            {
                    result++;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the probabilator dicer 1000. How many dice do you want to use the sum of? (default 4): ");
            bool parseTry = int.TryParse(Console.ReadLine(), out numberOfDice);
            if (!parseTry)
            {
                numberOfDice = 4;
            }

            Console.WriteLine("Thank you, the number of dice will be " + numberOfDice + ". How many times do you want to roll? (default 1000): ");
            parseTry = int.TryParse(Console.ReadLine(), out numberOfTries);
            if (!parseTry)
            {
                numberOfTries = 1000;
            }

            Console.WriteLine("Number of rolls set to " + numberOfTries + ". What result do you want to test probability for? (default 12): ");
            parseTry = int.TryParse(Console.ReadLine(), out sumProb);
            if (!parseTry)
            {
                sumProb = 12;
            }

            Parallel.For(0, numberOfTries, _ => Dice());

            float probability = (float)result / numberOfTries;
            Console.WriteLine("The program rolled a result of 12 a total of: " + result + " times and the probability was calculated to be a " + probability * 100 + "% chance to get a sum of " + sumProb + " with " + numberOfTries + " number of tries and " + numberOfDice + " dice.");
        }
    }
}
