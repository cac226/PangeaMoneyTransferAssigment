using PangeaMoneyTransferAssignment.Interfaces;

namespace PangeaMoneyTransferAssignment
{
    public class MoneyTransferAPI
    {
        private IConvertCountryCodes countryCodeConverter;
        private IGetExchangeRates exchangeRateGetter;

        public MoneyTransferAPI(IConvertCountryCodes countryCodeConverter, IGetExchangeRates exchangeRateGetter)
        {
            this.countryCodeConverter = countryCodeConverter;
            this.exchangeRateGetter = exchangeRateGetter;
        }

        public List<ExchangeRateResponse> GetAllExchangeRateData(string countryCode)
        {
            string currencyCode = countryCodeConverter.ConvertCountryToCurrency(countryCode);

            List<ExchangeRate> exchangeRates = exchangeRateGetter.GetExchangeRates(currencyCode);

            List<ExchangeRateResponse> response = ExchangeRateResponse.ConvertToResponse(countryCode, exchangeRates);

            return response;
        }
    }
}
