using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterMazeSimulation.Character;
namespace MonsterMazeSimulation
{
    public class MonsterMaker
    {
        string[] namePrefixes = { "Mischevious", "Terrifying", "Cowardly", "Cackling", "Mysterious" };
        string[] nameSuffixes = { "Goblin", "Bat", "Mimic", "Imp", "Minotaur"};

        Random random = new Random();

        public Monster CreateMonster()
        {
            Monster monster = new Monster();

            monster.name = GenerateMonsterName();

            return monster;
        }

        string GenerateMonsterName()
        {
            string name = "The ";

            int indexOne = random.Next(0, namePrefixes.Length);
            int indexTwo = random.Next(0, nameSuffixes.Length);

            name = $"{namePrefixes[indexOne]} {nameSuffixes[indexTwo]}";

            return name;
        }
    }
}
