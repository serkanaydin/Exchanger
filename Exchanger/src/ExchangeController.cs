using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchanger.src;

namespace Exchanger.src
{
    public enum ExchangeType{
        ForexExchange=1,
        BanknoteExchange =2
        }
    class ExchangeController
    {
        private List<Currency> CurrencyList;
        const String USER_EXIT = "quit";
        public ExchangeController(List<Currency> CurrencyList)
        {
            this.CurrencyList = CurrencyList;
            userInterface();
        }
        private void userInterface()
        {
            while (true)
            {
                Console.WriteLine("Write quit to exit, press 0 to continue");
                String input = Console.ReadLine();
                    
                if (input == USER_EXIT){
                    Environment.Exit(Environment.ExitCode);
                }
                exchange();
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
            float rate;
            if(decision == ExchangeType.ForexExchange)
                rate = (from.ForexSelling == 0 || from.ForexBuying == 0) ? -1 : from.ForexSelling / to.ForexBuying;
            else
                rate = (from.BanknoteSelling == 0 || from.BanknoteBuying == 0) ? -1 : from.BanknoteSelling / to.BanknoteBuying;
            try
            {
                if (rate == -1)
                    throw new InvalidCurrency(decision, from, to);
                float result = size * rate;
                Console.WriteLine($"Result:{result}");
            }
            catch(InvalidCurrency ex)
            {
                Console.WriteLine(ex.StackTrace);
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
