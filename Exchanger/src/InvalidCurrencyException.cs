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
                case ExchangeType.ForexExchange: Console.WriteLine($"Exchange error for Forex Exchange: {from.ForexSelling} ForexBuying: {to.ForexBuying}");
                         break;
                case ExchangeType.BanknoteExchange:
                    Console.WriteLine($"Exchange error For Banknote Exchange: {from.BanknoteSelling} ForexBuying: {to.BanknoteBuying}");
                    break;

            }
        }
    }
}
