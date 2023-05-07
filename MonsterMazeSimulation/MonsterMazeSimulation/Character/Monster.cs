using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMazeSimulation.Character
{
    public class Monster : Character
    {
        public Monster() : base()
        {
            SetValues();
        }
        
        public void PrintMonsterInformation(double powerValue)
        {
            Console.WriteLine($"You encountered {name}!\n\nThis monster has a skill array of \n");
            NeuralNetwork.PrintMatrix(values);
            Console.Write($"\nThis monster's total power is {powerValue}\n");
        }
    }
}
