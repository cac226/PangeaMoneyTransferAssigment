using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PangeaMoneyTransferAssignment.Enums;

namespace PangeaMoneyTransferAssignment
{
    public class ExchangeRateResponse
    {
        public string CurrencyCode;
        public string CountryCode;
        public double PangeaRate;
        public string PaymentMethod;
        public string DeliveryMethod;

        public ExchangeRateResponse(string currencyCode, 
                              string countryCode, 
                              double pangeaRate, 
                              PaymentMethod paymentMethod, 
                              DeliveryMethod deliveryMethod)
        {
            CurrencyCode = currencyCode;
            CountryCode = countryCode;
            PangeaRate = pangeaRate;
            PaymentMethod = paymentMethod.ToString();
            DeliveryMethod = deliveryMethod.ToString();
        }

        public ExchangeRateResponse(string countryCode, ExchangeRate exchangeRate)
        {
            CurrencyCode = exchangeRate.Currency;
            CountryCode = countryCode;
            PangeaRate = exchangeRate.Rate;
            PaymentMethod = exchangeRate.PaymentMethod.ToString();
            DeliveryMethod = exchangeRate.DeliveryMethod.ToString();
        }

        public static List<ExchangeRateResponse> ConvertToResponse(string countryCode, List<ExchangeRate> exchangeRates)
        {
            List<ExchangeRateResponse> response = exchangeRates.Select(rate => new ExchangeRateResponse(countryCode, rate)).ToList();

            return response;
        }

        public string ToString()
        {
            return CountryCode + "\n" + CurrencyCode + "\n" + PangeaRate + "\n" + PaymentMethod + "\n" + DeliveryMethod;
        }
    }
}
