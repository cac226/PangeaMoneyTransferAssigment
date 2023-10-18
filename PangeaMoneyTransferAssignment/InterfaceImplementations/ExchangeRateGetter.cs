using PangeaMoneyTransferAssignment.Interfaces;

namespace PangeaMoneyTransferAssignment.InterfaceImplementations
{
    public class ExchangeRateGetter : IGetExchangeRates
    {
        private List<ExchangeRate> rates;

        private ExchangeRateGetter(List<ExchangeRate> rates)
        {
            this.rates = rates;
        }

        public static ExchangeRateGetter Create(List<ExchangeRate> rates)
        {
            if(!areValidExchangeRates(rates))
            {
                throw new ArgumentException("Invalid exchange rate data");
            }
            return new ExchangeRateGetter(rates);
        }

        private static bool areValidExchangeRates(List<ExchangeRate> rates)
        {
            // This method could be fleshed out more (e.g. validating that the currency code refers to a real currency, as opposed to just being 3 letters)
            // but this is a start 
            foreach (var rate in rates)
            {
                // validate currency 
                if(rate.Currency.Length != 3)
                {
                    return false;
                }

                //validate rate 
                if(rate.Rate <= 0)
                {
                    return false;
                }

                // validate aquired date 
                if(DateTime.Now < rate.AquiredDate)
                {
                    return false;
                }

                // There is no invalid combination of PaymentMethod/DeliveryMethod, so we do not need to test for that 
            }
            return true;
        }

        public List<ExchangeRate> GetExchangeRates(string currencyCode)
        {
            List<ExchangeRate> allPossibleRates = rates.Where(rate => rate.Currency == currencyCode).ToList();
            List<ExchangeRate> relevantRates = pruneRates(allPossibleRates);
            return relevantRates;
        }

        /// <summary>
        /// Removes outdated rates -- there should be at most one rate of each payment + delivery type,
        /// so if there are duplicates, we should only use the most recent one
        /// </summary>
        /// <param name="rates"></param>
        /// <returns></returns>
        private List<ExchangeRate> pruneRates(List<ExchangeRate> rates)
        {
            List<ExchangeRate> result = rates.GroupBy(rate => new { rate.DeliveryMethod, rate.PaymentMethod })
                                             .Select(rateGroup => getMostRecentRate(rateGroup.ToList()))
                                             .ToList();

            return result;
        }

        private ExchangeRate getMostRecentRate(List<ExchangeRate> allRates)
        {
            ExchangeRate mostRecentRate = allRates.OrderByDescending(rate => rate.AquiredDate).First();

            return mostRecentRate;
        }
    }
}
