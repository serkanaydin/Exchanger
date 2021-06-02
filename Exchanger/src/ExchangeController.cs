using System;
using System.Collections.Generic;
using System.Threading;

namespace Exchanger.src
{
    public enum ExchangeType
    {
        ForexExchange=1,
        BanknoteExchange =2
    }

    class ExchangeController
    {
        private List<Currency> CurrencyList;

        public ExchangeController(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
            userInterface();
        }
        private void userInterface()
        {
            ConsoleKeyInfo cki;

            while (true)
            {
                Console.WriteLine("Press esc to exit, enter to continue");
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.Escape: Environment.Exit(Environment.ExitCode); continue;
                    case ConsoleKey.Enter: exchange(); continue;
                }
            }
        }
        private void exchange()
        {
            Currency from = getCurrency("Enter base currency code(Ex:USD) ");
            Currency to = getCurrency("Enter quote currency code(Ex:USD)");


            ExchangeType decision;
            do
            {
                Console.WriteLine("Forex(1) or banknote(2)");
                ExchangeType.TryParse(Console.ReadLine(), out decision);
            } while (!(decision == ExchangeType.ForexExchange || decision == ExchangeType.BanknoteExchange));

            
            try
            {
                getExchangeRate(from, to, decision,out float rate);
                if (rate == 0 || float.IsPositiveInfinity(rate))
                    throw new InvalidCurrency(decision, from, to);
                Console.WriteLine("Enter size");
                int.TryParse(Console.ReadLine(), out int size);
                Console.WriteLine($"Result:{rate * size}");
            }
            catch (InvalidCurrency ex)
            {
                Console.WriteLine($"Please enter valid currencies for {decision}");
            }
        }

        private void getExchangeRate(Currency from, Currency to, ExchangeType decision,out float rate)
        {
            rate = 0;
            switch (decision)
            {
                case ExchangeType.ForexExchange:
                    rate = from.ForexSelling / to.ForexBuying;
                    break;
                case ExchangeType.BanknoteExchange:
                    rate = from.BanknoteSelling / to.BanknoteBuying;
                    break;
            }
        }
        private Currency getCurrency(String message)
        {
            Console.WriteLine(message);
            var str = Console.ReadLine().ToUpper();

            foreach (Currency cur in CurrencyList)
            {
                if (cur.code == str)
                    return cur;
            }
            return getCurrency(message);
        }

    }
}
