using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterMazeSimulation.Character
{
    public class Character
    {
        Random random = new Random();

        public string name;
        public double[,] values = { { 0, 0, 0, 0, 0, 0 } };

        public Character()
        {

        }

        public Character(string _name, double[,] _values)
        {
            this.name = _name;
            this.values = _values;
        }

        protected void SetValues()
        {
            for (int i = 0; i < 6; i++)
            {
                int bin = random.Next(0, 2);

                values[0,i] = bin;
            }
        }
    }
}
