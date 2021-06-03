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
                float rate= from.getExchangeRate(decision,to);
                Console.WriteLine("Enter size");
                int.TryParse(Console.ReadLine(), out int size);
                Console.WriteLine($"Result:{rate * size}");
            }
            catch (InvalidCurrency ex)
            {
                Console.WriteLine($"Invalid exchange request for {decision}");
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
