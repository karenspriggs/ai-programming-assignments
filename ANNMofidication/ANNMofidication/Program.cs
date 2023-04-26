using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANNMofidication
{
    class Program
    {

        static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        /*
         * The neural network will determine if an animal is a cat (can include big cats or domestic) based off of the following traits:
         * - Has whiskers
         * - Has pointed ears
         * - Has a long tail
         * - Is nocturnal
         * - Has fur
         * - Has the word "cat" in its name
         * 
         * The animals it is trained on are:
         * - Lion
         * - Tiger
         * - Tabby cat
         * - Pallas Cat
         * - Cheetah
         * - Snake
         * - Leopard
         * - Monkey
         * - Hawk
         * - Rabbit
         * - Armadillo
         * - Catfish
         * - Snail
         * 
         * It will determine whether or not the following animals are cats:
         * - Fox
         * - Sphinx Cat
         * - Goldfish
         */

        static void Main(string[] args)
        {
            var curNeuralNetwork = new NeuralNetWork(1, 6);

            Console.WriteLine("Synaptic weights before training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);

            var trainingInputs = new double[,] {
                { 1, 0, 1, 1, 1, 0 }, // Lion
                { 1, 0, 1, 1, 1, 0 }, // Tiger
                { 1, 1, 1, 1, 1, 1 }, // Tabby Cat
                { 1, 1, 1, 1, 1, 1 }, // Pallas Cat
                { 1, 1, 1, 1, 1, 0 }, // Cheetah
                { 1, 0, 1, 1, 1, 0 }, // Leopard
                

                { 0, 0, 1, 1, 0, 0 }, // Snake
                { 0, 0, 1, 1, 1, 0 }, // Monkey
                { 0, 0, 0, 1, 0, 0 }, // Hawk
                { 1, 1, 0, 0, 1, 0 }, // Rabbit
                { 0, 1, 1, 1, 0, 0 }, // Armadillo
                { 1, 0, 0, 0, 0, 1 }, // Catfish
                { 0, 0, 0, 0, 0, 0 } // Snail
            };

            var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 1,1,1,1,1,1,0,0,0,0,0,0,0} });

            curNeuralNetwork.Train(trainingInputs, trainingOutputs, 10000);

            Console.WriteLine("\nSynaptic weights after training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);


            // testing neural networks against a new problem 
            var output = curNeuralNetwork.Think(new double[,] { { 1, 1, 1, 1, 1, 0 } });
            // A fox has a lot of the traits listed so it will think it is a cat
            Console.WriteLine("\nConsidering if a fox is a cat [1, 1, 1, 1, 1, 0] => :");
            PrintMatrix(output);

            output = curNeuralNetwork.Think(new double[,] { { 1, 1, 1, 0, 1, 1 } });
            Console.WriteLine("\nConsidering if a sphynx cat is a cat [1, 1, 1, 0, 1, 1 ] => :");
            PrintMatrix(output);

            output = curNeuralNetwork.Think(new double[,] { { 0, 0, 0, 0, 0, 0 } });
            Console.WriteLine("\nConsidering if a goldfish is a cat [0, 0, 0, 0, 0, 0] => :");
            PrintMatrix(output);

            Console.Read();

        }
    }
}
