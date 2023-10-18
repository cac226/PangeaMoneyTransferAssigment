using PangeaMoneyTransferAssignment.InterfaceImplementations;
using PangeaMoneyTransferAssignment.JSON;
using PangeaMoneyTransferAssignment.Stubs;

namespace PangeaMoneyTransferAssignment
{
    /// <summary>
    /// Handles creation of MoneyTransferAPI
    /// </summary>
    public class MoneyTransferFactory
    {
        public static MoneyTransferAPI CreateMoneyTransferAPI(string jsonFileLocation)
        {
            CountryCodeConverter countryCodeConverter = CountryCodeConverter.CreateDefault();
            PartnerExchangeRate[] partnerExchangeRate = ExchangeRateJsonReader.ReadJson(jsonFileLocation);
            List<ExchangeRate> exchangeRates = ExchangeRateConverter.Convert(partnerExchangeRate);
            ExchangeRateGetter exchangeRateGetter = ExchangeRateGetter.Create(exchangeRates);

            return new MoneyTransferAPI(countryCodeConverter, exchangeRateGetter);
        }
    }
}
