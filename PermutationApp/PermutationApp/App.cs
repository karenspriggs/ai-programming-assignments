using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationApp
{
    class App
    {
        public App()
        {
            Run();
        }

        void Run()
        {
            char[] inputArray = GetElementInput();
            PrintInfo(inputArray);
        }

        void PrintInfo(char[] inputArray)
        {
            PrintPermutations(inputArray);
            PrintPartitions(inputArray);
            PrintCombinations(inputArray);
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the elements from the user, by having them type all 5 in at once
        /// If they do not enter enough or too many, the method calls itself again
        /// </summary>
        /// <returns></returns>
        char[] GetElementInput()
        {
            Console.WriteLine("Please enter 5 unique characters and then hit enter to submit:");
            char[] inputArray = Console.ReadLine().ToCharArray();

            if (inputArray.Length != 5)
            {
                Console.WriteLine("You did not enter 5 characters, please try again.");
                GetElementInput();
            }

            if (HasRepeatedElements(inputArray))
            {
                Console.WriteLine("You did not enter all unique characters, please try again.");
                GetElementInput();
            }

            return inputArray;
        }

        /// <summary>
        /// Checks to see if the array being passed in has any repeated elements
        /// </summary>
        /// <param name="inputArray"></param>
        /// <returns></returns>
        bool HasRepeatedElements(char[] inputArray)
        {
            for(int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    if (i != j)
                    {
                        if (inputArray[i] == inputArray[j])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Writes the sets of permutations from nP1 through nPn to the console
        /// </summary>
        /// <param name="symbolArray"></param>
        void PrintPermutations(char[] symbolArray)
        {
            Console.WriteLine("\nPermutation list:");
            for(int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n5P{i}:\n");

                List<string> permutationResults = PermutationCalculator.RecursivePermuter(symbolArray, new List<string>(), new char[i], new Dictionary<int,bool>(), 0, i);

                Console.Write("Set: {");
                foreach(String s in permutationResults)
                {
                    Console.Write($" {s} ");
                }
                Console.Write("}\n");

                Console.WriteLine($"\nAmount of permutations: {FactorialCalculator.FindPermutationCount(symbolArray.Length, i)}");
            }
        }

        /// <summary>
        /// Writes the ordered partitions of the set to the console
        /// </summary>
        /// <param name="symbolArray"></param>
        void PrintPartitions(char[] symbolArray)
        {
            Console.WriteLine("\nOrdered partition list:\n");

            Console.WriteLine($"Amount of ordered partitions {FactorialCalculator.FindPartitionCount(symbolArray)}");
            List<string> partitionResults = PermutationCalculator.RecursivePartitioner(symbolArray);
            Console.Write("Set: {");
            foreach (String s in partitionResults)
            {
                Console.Write($" {s} ");
            }
            Console.Write("}\n");
        }

        /// <summary>
        /// Writes the sets of combinations from nC1 to nCn to the console
        /// </summary>
        /// <param name="symbolArray"></param>
        void PrintCombinations(char[] symbolArray)
        {
            Console.WriteLine("\nCombination list:\n");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"5C{i}:\n");

                List<string> combinationResults = PermutationCalculator.RecursiveCombinations(symbolArray, i);

                Console.Write("Set: {");
                foreach(String s in combinationResults)
                {
                    Console.Write($" {s} ");
                }
                Console.Write("}\n");

                Console.WriteLine($" Amount of combinations: {FactorialCalculator.FindCombinationCount(symbolArray.Length, i)}");
            }
        }
    }
}
