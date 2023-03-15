using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class Granola : MachineOutput
    {
        public static Granola Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Granola();
                }

                return instance;
            }
        }

        static Granola instance;

        public Granola()
        {
            this.name = "Granola";
            this.price = 0.75M;
        }
    }
}
