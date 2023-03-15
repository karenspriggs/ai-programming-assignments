using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class Quarter : MachineOutput
    {
        public static Quarter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Quarter();
                }

                return instance;
            }
        }

        static Quarter instance;

        public Quarter()
        {
            this.name = "Quarter";
            this.price = 0.25M;
        }

        public override string Describe()
        {
            return $"You got a {name}, which gave you back ${price}";
        }
    }
}
