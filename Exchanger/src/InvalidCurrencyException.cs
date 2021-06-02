using System;
using System.Collections.Generic;
using System.Text;

namespace Exchanger.src
{
    [Serializable]
    class InvalidCurrency : Exception
    {
        public InvalidCurrency(ExchangeType decision,Currency from,Currency to)
        {
            switch (decision)
            {
                case ExchangeType.ForexExchange: Console.WriteLine($"Exchange error for Forex Exchange; ForexSelling: {from.ForexSelling} ForexBuying: {to.ForexBuying}"
                    + " Forex exchange is not available for " + ((from.ForexSelling==0)? from.code:to.code));
                         break;
                case ExchangeType.BanknoteExchange:
                    Console.WriteLine($"Exchange error For Banknote Exchange: {from.BanknoteSelling} ForexBuying: {to.BanknoteBuying}"
                    + "Banknote exchange is not available for " + ((from.BanknoteSelling == 0) ? from.code : to.code));
                    break;

            }
        }
    }
}
