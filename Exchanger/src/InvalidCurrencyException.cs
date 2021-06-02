using System;
using System.Collections.Generic;
using System.Text;

namespace Exchanger.src
{
    [Serializable]
    class InvalidCurrency : Exception
    {
        public InvalidCurrency(int decision,Currency from,Currency to)
        {
            switch (decision)
            {
                case 1: Console.WriteLine($"Exchange error ForexSelling: {from.ForexSelling} ForexBuying: {to.ForexBuying}");
                         break;
                case 2:
                    Console.WriteLine($"Exchange error ForexSelling: {from.BanknoteSelling} ForexBuying: {to.BanknoteBuying}");
                    break;

            }
        }
    }
}
