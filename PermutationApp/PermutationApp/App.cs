using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationApp
{
    class App
    {
        List<string> elementList = new List<string>();

        public App()
        {
            Run();
        }

        public void Run()
        {
            char[] inputArray = GetElementInput();
            PrintPermutations(inputArray);
        }

        char[] GetElementInput()
        {
            Console.WriteLine("Please enter 5 characters and then hit enter to submit:");
            char[] inputArray = Console.ReadLine().ToCharArray();

            if (inputArray.Length != 5)
            {
                Console.WriteLine("You did not enter 5 characters, please try again.");
                GetElementInput();
            }

            return inputArray;
        }

        void PrintPermutations(char[] symbolArray)
        {
            Console.WriteLine("Permutation list:");
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"5P{i}:");
                Permute(symbolArray, 0, i, new List<char>());
                Console.WriteLine($" Amount of permutations: {FindPermutationCount(symbolArray.Length, i)}");
            }

            Console.WriteLine("Ordered partition list:");

            Console.WriteLine("Combination list:");
            for(int i = 1; i <=5; i++)
            {
                Console.WriteLine($"5C{i}:");
                Console.WriteLine($" Amount of combinations: {FindCombinationCount(symbolArray.Length, i)}");
            }
        }

        void Permute(char[] symbolArray, int startingIndex, int length, List<char> results)
        {
            if (length == 0)
            {
                Console.WriteLine(results.ToString());
            }else
            {
                for(int i = startingIndex; i <= symbolArray.Length - length; i++)
                {
                    results[results.Count - length] = symbolArray[i];
                    Permute(symbolArray, i+1, length-1, results);
                }
            }
        }

        void MakePartitions()
        {

        }

        void MakeCombinations()
        {

        }

        int FindFactorial(int number)
        {
            int result = number;

            // Factorial of 0 is 1
            if (number == 0)
            {
                return 1;
            }

            for (int i = number - 1; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        // Amount of permutations is N! / (N-R)!
        int FindPermutationCount(int number, int taken)
        {
            return FindFactorial(number) / FindFactorial(number - taken);
        }

        // Amount of partitions depends on the amount of repeated elements
        int FindPartitionCount(char[] symbolArray, int number)
        {
            int currentDenominator = 1;

            // Storing the amount of each char found in dictionary
            Dictionary<char, int> foundChars = new Dictionary<char, int>();

            // Go through the array to add the elements to the dictionary
            foreach(Char c in symbolArray)
            {
                // If it was already found prior, add one to the count
                if (foundChars.ContainsKey(c))
                {
                    foundChars[c] += 1;
                }else
                {
                    foundChars.Add(c, 1);
                }
            }

            // The denominator is the product of the factorial of the count
            // of each of the elements
            foreach(KeyValuePair<char, int> pair in foundChars)
            {
                currentDenominator *= FindFactorial(pair.Value);
            }

            return FindFactorial(number)/currentDenominator;
        }

        // Amount of combinations is (N! / (N-R)!) / R!
        // Which is also the amount of permutations divided by R!
        int FindCombinationCount(int number, int taken)
        {
            return FindPermutationCount(number,taken)/FindFactorial(taken);
        }
    }
}
