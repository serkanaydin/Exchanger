using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;
using Exchanger.src;

namespace Exchanger
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Currency> currenyList = initialize();
            ExchangeController excControl = new ExchangeController(currenyList);
        }

        static List<Currency> initialize()
        {
            CultureInfo en = new CultureInfo("en-EN");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"https://www.tcmb.gov.tr/kurlar/today.xml");
            XmlNodeList parentNode = xmlDoc.GetElementsByTagName("Currency");

            List<Currency> CurrencyList = new List<Currency>();

            foreach (XmlNode childrenNode in parentNode)
            {
                String code = childrenNode.Attributes["Kod"].Value;
                String name = childrenNode.SelectSingleNode("Isim").InnerText;
                String currencyName = childrenNode.SelectSingleNode("CurrencyName").InnerText;

                float.TryParse((childrenNode.SelectSingleNode("ForexBuying").InnerText), NumberStyles.Currency,
                en.NumberFormat, out float ForexBuying);

                float.TryParse(childrenNode.SelectSingleNode("ForexSelling").InnerText, NumberStyles.Currency,
                en.NumberFormat, out float ForexSelling);

                float.TryParse(childrenNode.SelectSingleNode("BanknoteBuying").InnerText, NumberStyles.Currency,
                en.NumberFormat, out float BanknoteBuying);

                float.TryParse(childrenNode.SelectSingleNode("BanknoteSelling").InnerText, NumberStyles.Currency,
                en.NumberFormat, out float BanknoteSelling);

                CurrencyList.Add(new Currency(code, name, currencyName, ForexBuying, ForexSelling, BanknoteBuying, BanknoteSelling));
            }
            return CurrencyList;
        }
    }
}

