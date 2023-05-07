using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterMazeSimulation.Character;

namespace MonsterMazeSimulation
{
    public class Game
    {
        Player playerCharacter;
        MonsterMaker monsterMaker;
        NeuralNetwork neuralNetwork;

        bool hasPlayerLost;
        int monstersDefeated;
        float difficultyModifier = 1f;

        public Game()
        {
            monsterMaker = new MonsterMaker();
            neuralNetwork = new NeuralNetwork(1, 6);

            Start();
        }

        void TrainANN()
        {
            double[,] trainingInputs = new double[,]
            {
                { 0, 0, 0, 0, 0, 0 },
                { 1, 1, 1, 1, 1, 1 },
                { 0, 0, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 0, 0 },
                { 0, 0, 1, 1, 0, 0 },
                { 1, 0, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 1 },
                { 1, 1, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 0, 1 },
                { 1, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 1, 1 },
                { 0, 1, 0, 1, 1, 1 }
            };

            double[,] trainingOutputs = NeuralNetwork.MatrixTranspose(new double[,] { {1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0} });
            neuralNetwork.Train(trainingInputs, trainingOutputs, 100000);
        }

        void Start()
        {
            TrainANN();

            playerCharacter = new Player();
            SelectDifficulty();

            hasPlayerLost = false;
            monstersDefeated = 0;

            Console.Clear();

            while (!hasPlayerLost)
            {
                MakeEncounter();
            }

            Finish();
        }

        void MakeEncounter()
        {
            Monster currentMonster = monsterMaker.CreateMonster();

            double playerValue = neuralNetwork.Think(playerCharacter.values)[0, 0];
            playerValue *= difficultyModifier;
            double monsterValue = neuralNetwork.Think(currentMonster.values)[0, 0];

            currentMonster.PrintMonsterInformation(monsterValue);
            Console.WriteLine("");
            playerCharacter.PrintPlayerInformation(playerValue);
            Console.WriteLine("");
            

            if (playerValue >= monsterValue)
            {
                monstersDefeated++;
                Console.WriteLine("You defeated a monster! Press enter to continue...");
            } else
            {
                Console.WriteLine("You died! Press enter to continue...");
                hasPlayerLost = true;
            }

            Console.ReadKey();
            Console.Clear();
        }

        void Finish()
        {
            Console.WriteLine($"You have died after killing {monstersDefeated} monsters");
            Console.WriteLine("Play again? Enter yes or no");

            string answer = Console.ReadLine().ToLower();

            if (answer != "yes" && answer != "no" && answer != "y" && answer != "n")
            {
                Console.WriteLine("That is not a valid answer please hit enter and select again\n");
                Console.ReadKey();
                Finish();
            }

            switch (answer)
            {
                case ("yes"):
                case ("y"):
                    Console.Clear();
                    Start();
                    break;
                case ("no"):
                case ("n"):
                    Console.WriteLine("Thank you for playing!");
                    Console.ReadKey();
                    break;
            }
        }

        void SelectDifficulty()
        {
            Console.Clear();
            Console.WriteLine("Please enter the number of the difficulty level you would like to select:\n1) Easy\n2) Regular\n3) Hard");
            string input = Console.ReadLine();

            if (input != "1" && input != "2" && input != "3")
            {
                Console.WriteLine("That is not a valid difficulty level, please hit enter and select again\n");
                Console.ReadKey();
                SelectDifficulty();
            }

            switch (input)
            {
                case ("1"):
                    difficultyModifier = 1;
                    break;
                case ("2"):
                    difficultyModifier = 0.95f;
                    break;
                case ("3"):
                    difficultyModifier = 0.9f;
                    break;
            }
        }
    }
}
