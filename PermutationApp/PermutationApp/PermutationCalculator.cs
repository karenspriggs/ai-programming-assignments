using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationApp
{
    class PermutationCalculator
    {
        /// <summary>
        /// Recursively creates an array of string permutations of the character array
        /// </summary>
        /// <param name="inputArray">The array of characters to create permutations with</param>
        /// <param name="resultsList">The list of strings containing all the valid permutations</param>
        /// <param name="current">The current permutation that is being built, in char array form</param>
        /// <param name="usageDict">Dictionary that keeps track of which elements have been used for the permutation being built</param>
        /// <param name="currentIndex">The current index at which the permutation is being added to while being built</param>
        /// <param name="length">The amount of elements that are being picked for this permutation (the length of each permutation)</param>
        /// <returns></returns>
        public static List<string> RecursivePermuter(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, int length)
        {
            // If the index we are at is equal to the length, that means that we can stop looking as we have already found a permutation
            // with the right amount of elements chosen, so add it to the list of results
            if (currentIndex == length)
            {
                // Make a string out of the current char array
                string perm = new string(current);
                resultsList.Add(perm);
                return resultsList;
            }

            BuildPerm(inputArray, resultsList, current, usageDict, currentIndex, length);

            return resultsList;
        }

        /// <summary>
        ///  Method that recursively makes ordered partitions of the array of characters, built off of the functionality
        ///  of the permutation finder as it is a similar process, but elements that have the same value are not considered
        ///  unique for the purposes of the order of the elements in the permutation
        /// </summary>
        /// <param name="inputArray">The array of characters to create permutations with</param>
        /// <param name="resultsList">The list of strings containing all the valid partitions</param>
        /// <param name="current">The current partition that is being built, in char array form</param>
        /// <param name="usageDict">Dictionary that keeps track of which elements have been used for the permutation being built</param>
        /// <param name="currentIndex">The current index at which the permutation is being added to while being built</param>
        /// <param name="existingPerms">A hashset containing all the existing permutations, used to check for repeated elements where the set
        /// has 2 of the same element</param>
        /// <returns></returns>
        public static List<string> RecursivePartitioner(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, HashSet<string> existingPerms)
        {
            // Since ordered partitions are the length of the set, there is no need to check for any length
            // other than the length of the element list
            if (currentIndex == inputArray.Length)
            {
                // Make a string out of the current char array
                string perm = new string(current);

                // Check to see if the permutation is already in the hash set, if not then add the permutation
                // to the results list and the hash set
                // We are using a hash set because it is more efficient in checking if an element exists than a list is
                if (!existingPerms.Contains(perm))
                {
                    resultsList.Add(perm);
                    existingPerms.Add(perm);
                }
            }

            BuildPerm(inputArray, resultsList, current, usageDict, currentIndex, existingPerms);

            return resultsList;
        }

        public static List<string> RecursiveCombinations(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, int length, HashSet<string> existingPerms)
        {
            // If the index we are at is equal to the length, that means that we can stop looking as we have already found an ordered partition
            // with the right amount of elements chosen, so add it to the list of results
            if (currentIndex == length)
            {
                // Make a string out of the current char array
                string perm = new string(current);

                // Check to see if the permutation is already in the hash set, if not then add the permutation
                // to the results list and the hash set
                // Similar to the partitions but the checking is more strict as a different order of elements does not make a 
                // combination distinct from another
                if (!IsAlreadyInHashSet(existingPerms,perm))
                {
                    resultsList.Add(perm);
                    existingPerms.Add(perm);
                }

                return resultsList;
            }

            BuildPerm(inputArray, resultsList, current, usageDict, currentIndex, length, existingPerms);

            return resultsList;
        }

        static void BuildPerm(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, int length)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                // If this is the first time checking for this element, the key wont be in the dictionary so add it, but since it hasn't been used yet
                // then add it with the value of false
                if (!usageDict.ContainsKey(i))
                {
                    usageDict.Add(i, false);
                }

                // If the element hasn't been used this iteration, then you can use it
                // By keeping track of which elements have been used, you can use the process of elimination to figure
                // out what the next element of the permutation can be
                if (!usageDict[i])
                {
                    // Saves the element for i in the current index
                    current[currentIndex] = inputArray[i];
                    // It has been used, now update the dictionary
                    usageDict[i] = true;
                    // Recursively call it again with the index iterated by 1 to find the next element
                    RecursivePermuter(inputArray, resultsList, current, usageDict, currentIndex + 1, length);
                    // Set it back to false now that we are done with this permutation so it can be used when finding the next one
                    usageDict[i] = false;
                }
            }
        }

        static void BuildPerm(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, HashSet<string> existingPerms)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                // If this is the first time checking for this element, the key wont be in the dictionary so add it, but since it hasn't been used yet
                // then add it with the value of false
                if (!usageDict.ContainsKey(i))
                {
                    usageDict.Add(i, false);
                }

                // If the element hasn't been used this iteration, then you can use it
                // By keeping track of which elements have been used, you can use the process of elimination to figure
                // out what the next element of the permutation can be
                if (!usageDict[i])
                {
                    // Saves the element for i in the current index
                    current[currentIndex] = inputArray[i];
                    // It has been used, now update the dictionary
                    usageDict[i] = true;
                    // Recursively call it again with the index iterated by 1 to find the next element
                    RecursivePartitioner(inputArray, resultsList, current, usageDict, currentIndex + 1, existingPerms);
                    // Set it back to false now that we are done with this permutation so it can be used when finding the next one
                    usageDict[i] = false;
                }
            }
        }

        static void BuildPerm(char[] inputArray, List<string> resultsList, char[] current, Dictionary<int, bool> usageDict, int currentIndex, int length, HashSet<string> existingPerms)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                // If this is the first time checking for this element, the key wont be in the dictionary so add it, but since it hasn't been used yet
                // then add it with the value of false
                if (!usageDict.ContainsKey(i))
                {
                    usageDict.Add(i, false);
                }

                // If the element hasn't been used this iteration, then you can use it
                // By keeping track of which elements have been used, you can use the process of elimination to figure
                // out what the next element of the permutation can be
                if (!usageDict[i])
                {
                    // Saves the element for i in the current index
                    current[currentIndex] = inputArray[i];
                    // It has been used, now update the dictionary
                    usageDict[i] = true;
                    // Recursively call it again with the index iterated by 1 to find the next element
                    RecursiveCombinations(inputArray, resultsList, current, usageDict, currentIndex + 1, length, existingPerms);
                    // Set it back to false now that we are done with this permutation so it can be used when finding the next one
                    usageDict[i] = false;
                }
            }
        }

        /// <summary>
        /// Helper function to see if a string (permutation) is already in the hash set that we are using
        /// to keep track of permutations that have already been made
        /// </summary>
        /// <param name="setToCheck">The hash set we want to look at to find a match</param>
        /// <param name="permutation">Permutation that we want to check for a match with</param>
        /// <returns></returns>
        static bool IsAlreadyInHashSet(HashSet<string> setToCheck, string permutation)
        {
            // We want to use SetEquals so we will be converting the permutation to a hash set
            HashSet<char> permutationSet = new HashSet<char>(permutation);

            // Search for a match for the string in the hash set 
            foreach(String element in setToCheck)
            {
                // They have to be the same length to be equal, then use the SetEquals 
                // since it will see if it has the same elements + count of each elements
                // regardless of order
                if (element.Length == permutation.Length)
                {
                    // Only convert to hash set if the length is equal since if they are a 
                    // different length it won't be equal anyways so no need to check
                    HashSet<char> elementSet = new HashSet<char>(element);
                    
                    if (elementSet.SetEquals(permutationSet))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
