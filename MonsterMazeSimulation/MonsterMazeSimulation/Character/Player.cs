using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMazeSimulation.Character
{
    public class Player : Character
    {
        public Player() : base()
        {
            SetPlayerName();
            SetValues();

        }

        void SetPlayerName()
        {
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine($"Your name is: {name}. Press enter to continue...");
            Console.ReadKey();
        }

        public void PrintPlayerInformation(double power)
        {
            Console.Write($"{name} raises their sword, giving them {power} power.\n\nTheir power matrix is: \n\n");
            NeuralNetwork.PrintMatrix(values);
        }
    }
}
