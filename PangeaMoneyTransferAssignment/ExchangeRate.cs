using PangeaMoneyTransferAssignment.Enums;

namespace PangeaMoneyTransferAssignment
{
    public class ExchangeRate
    {
        public string Currency;
        public PaymentMethod PaymentMethod;
        public DeliveryMethod DeliveryMethod;
        public double Rate;
        public DateTime AquiredDate;

        public ExchangeRate(string currency, PaymentMethod paymentMethod, DeliveryMethod deliveryMethod, double rate, DateTime aquiredDate)
        {
            Currency = currency;
            PaymentMethod = paymentMethod;
            DeliveryMethod = deliveryMethod;
            Rate = rate;
            AquiredDate = aquiredDate;
        }
    }
}
