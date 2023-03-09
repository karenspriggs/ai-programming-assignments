using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationApp
{
    class FactorialCalculator
    {
        /// <summary>
        /// Helper function for finding factorials
        /// </summary>
        /// <param name="number">Number that you want to find the factorial for</param>
        /// <returns></returns>
        public static int FindFactorial(int number)
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

        /// <summary>
        /// The amount of permutations is N! / (N-R)! - this method calculates that
        /// </summary>
        /// <param name="number">The set size</param>
        /// <param name="taken">The amount taken from the set for every permutation (length of permutation)</param>
        /// <returns></returns>
        public static int FindPermutationCount(int number, int taken)
        {
            return FindFactorial(number) / FindFactorial(number - taken);
        }

        /// <summary>
        /// Amount of partitions depends on the amount of repeated elements
        /// </summary>
        /// <param name="symbolArray">The array to check so you can find the amount of repeated elements</param>
        /// <returns></returns>
        public static int FindPartitionCount(char[] symbolArray)
        {
            int currentDenominator = 1;

            // Storing the amount of each char found in dictionary
            Dictionary<char, int> foundChars = new Dictionary<char, int>();

            // Go through the array to add the elements to the dictionary
            foreach (Char c in symbolArray)
            {
                // If it was already found prior, add one to the count
                if (foundChars.ContainsKey(c))
                {
                    foundChars[c] += 1;
                }
                else
                {
                    foundChars.Add(c, 1);
                }
            }

            // The denominator is the product of the factorial of the count
            // of each of the elements
            foreach (KeyValuePair<char, int> pair in foundChars)
            {
                currentDenominator *= FindFactorial(pair.Value);
            }

            return FindFactorial(symbolArray.Length) / currentDenominator;
        }

        /// <summary>
        /// This method calculates the amount of combinations, which is (N! / (N-R)!) / R!
        /// Which is also the amount of permutations divided by R!
        /// This count also assumes that every element of the set is unique
        /// </summary>
        /// <param name="number">The set size</param>
        /// <param name="taken">The amount taken from the set for every permutation (length of permutation)</param>
        /// <returns></returns>
        public static int FindCombinationCount(int number, int taken)
        {
            return FindPermutationCount(number, taken) / FindFactorial(taken);
        }
    }
}
