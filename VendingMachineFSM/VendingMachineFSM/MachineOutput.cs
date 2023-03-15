using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class MachineOutput
    {
        public string Name { get { return name; } set { name = value; } }
        public decimal Price { get { return price; } set { price = value; } }

        protected string name;
        protected decimal price;

        public virtual string Describe()
        {
            return $"{name}, which costs ${price}";
        }
    }
}
