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

        }

        void TakeInput()
        {

        }

        string GetElementInput()
        {
            Console.WriteLine("Please enter the next element of the list");
            string choice = Console.ReadLine();

            if (choice == "")
            {
                Console.WriteLine("You did not enter a character, try again");
                GetElementInput();
            }

            Console.WriteLine($"The next element you entered was {choice.Substring(0, 1)}");

            return choice.Substring(0, 1);
        }

        void MakePermutations()
        {

        }

        void MakePermutatiosnOfLength(int length)
        {
            int count = 0;


        }

        void MakePartitions()
        {

        }

        void MakeCombinations()
        {

        }
    }
}
