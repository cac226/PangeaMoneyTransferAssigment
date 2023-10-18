using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PangeaMoneyTransferAssignment.Interfaces;

namespace PangeaMoneyTransferAssignment.Stubs
{
    internal class CountryCodeConverter : IConvertCountryCodes
    {
        private Dictionary<string, string> countryToCurrencyCodes;

        private CountryCodeConverter(Dictionary<string, string> countryToCurrencyCodes)
        {
            this.countryToCurrencyCodes = countryToCurrencyCodes;
        }

        public static CountryCodeConverter CreateDefault()
        {
            Dictionary<string, string> countryToCurrency = new Dictionary<string, string>
            {
                { "MEX", "MXN" },
                { "IND", "INR" },
                { "PHL", "PHP" },
                { "GTM", "GTQ" }
            };

            return new CountryCodeConverter(countryToCurrency);
        }

        public string ConvertCountryToCurrency(string countryCode)
        {
            if(countryToCurrencyCodes.ContainsKey(countryCode))
            {
                return countryToCurrencyCodes[countryCode];
            }
            throw new KeyNotFoundException("Unknown country code");
        }
    }
}
