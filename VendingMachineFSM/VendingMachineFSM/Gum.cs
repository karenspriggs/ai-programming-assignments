using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class Gum : MachineOutput
    {
        public static Gum Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Gum();
                }

                return instance;
            }
        }

        static Gum instance;

        public Gum()
        {
            this.name = "Gum";
            this.price = 0.50M;
        }
    }
}
