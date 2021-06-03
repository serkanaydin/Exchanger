using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exchanger.src
{
    class Currency
    {
        public String code { get; }
        public String name { get; }
        public String currencyName { get; }
        public float ForexBuying { get; }
        public float ForexSelling { get; }
        public float BanknoteSelling { get; }
        public float BanknoteBuying { get; }

        private float getForexExchangeRate(Currency to)
        {   
            float rate = (this.ForexSelling / to.ForexBuying);
            if (rate == 0 || float.IsPositiveInfinity(rate))
                throw new InvalidCurrency(ExchangeType.ForexExchange,this,to);
            return rate;
        }
   
        private float getBanknoteExchangeRate(Currency to)
        {
            float rate = (this.BanknoteSelling / to.BanknoteBuying);
            if (rate == 0 || float.IsPositiveInfinity(rate))
                throw new InvalidCurrency(ExchangeType.BanknoteExchange, this, to);
            return rate;
        }


        public float getExchangeRate(ExchangeType decision, Currency to)
        {
            switch(decision){
                case ExchangeType.ForexExchange: return(getForexExchangeRate(to)); break;
                case ExchangeType.BanknoteExchange: return (getBanknoteExchangeRate(to)); break;
                default: return 0;
            }  
        }

        public Currency(String code,String name,String currencyName, float ForexBuying, float ForexSelling,  float BanknoteBuying, float BanknoteSelling)
        {
            this.code = code;
            this.name = name;
            this.currencyName = currencyName;

            this.ForexBuying = ForexBuying;
            this.ForexSelling = ForexSelling;

            this.BanknoteBuying = BanknoteBuying;
            this.BanknoteSelling = BanknoteSelling;
        }
    }
}
