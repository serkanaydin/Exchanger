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
