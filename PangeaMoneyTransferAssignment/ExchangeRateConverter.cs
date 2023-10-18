using PangeaMoneyTransferAssignment.Enums;
using PangeaMoneyTransferAssignment.JSON;

namespace PangeaMoneyTransferAssignment
{
    internal class ExchangeRateConverter
    {
        public static List<ExchangeRate> Convert(PartnerExchangeRate[] partnerData)
        {
            List<ExchangeRate> result = partnerData.Select(convertExchangeRate).ToList();

            return result;
        }

        private static ExchangeRate convertExchangeRate(PartnerExchangeRate rate)
        {
            try
            {
                PaymentMethod paymentMethod = Enum.Parse<PaymentMethod>(rate.PaymentMethod, true);
                DeliveryMethod deliveryMethod = Enum.Parse<DeliveryMethod>(rate.DeliveryMethod, true);

                // TODO: convert rates -- we need to adjust the exchange rate from the partner rate to the pangea rate. 

                ExchangeRate exchangeRate = new ExchangeRate(rate.Currency, paymentMethod, deliveryMethod, rate.Rate, rate.AcquiredDate);
                return exchangeRate;
            }
            catch
            {
                throw new ArgumentException("Unsupported PaymentMethod and/or DeliveryMethod in JSON");
            }

        }
    }
}
