using System;
using System.Collections.Generic;

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

            int size;
            Console.WriteLine("Enter size");
            int.TryParse(Console.ReadLine(), out size);

            ExchangeType decision;
            do
            {
                Console.WriteLine("Forex(1) or banknote(2)");
                ExchangeType.TryParse(Console.ReadLine(), out decision);
            } while (!(decision == ExchangeType.ForexExchange || decision == ExchangeType.ForexExchange));

            doCalculations(size, from, to, decision);
            
        }
        private void doCalculations(int size,Currency from, Currency to,ExchangeType decision)
        {
            float rate=0;

            switch (decision)
            {
                case ExchangeType.ForexExchange:
                    rate = from.ForexSelling / to.ForexBuying;
                    break;
                case ExchangeType.BanknoteExchange:
                    rate = from.BanknoteSelling / to.BanknoteBuying;
                    break;
            }
        
            try
            {
                if (rate == 0)
                    throw new InvalidCurrency(decision, from, to);
                float result = size * rate;
                Console.WriteLine($"Result:{result}");
            }
            catch(InvalidCurrency ex){
                Console.WriteLine($"Please enter valid currencies for {decision}"); }         
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
