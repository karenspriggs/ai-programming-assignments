using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineFSM
{
    public class Transaction
    {
        public decimal currentPrice = 0;

        public static Transaction Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Transaction();
                }

                return instance;
            }
        }

        static Transaction instance;

        public Transaction()
        {
            ResetTransaction();
        }

        public void ResetTransaction()
        {
            this.currentPrice = 0;
        }

        public void AddQuarter()
        {
            this.currentPrice += 0.25M;
        }
    }
}
