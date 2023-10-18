
namespace PangeaMoneyTransferAssignment.Interfaces
{
    /// <summary>
    /// Gets exchange rates corresponding to a given currency code
    /// </summary>
    public interface IGetExchangeRates
    {
        public List<ExchangeRate> GetExchangeRates(string currencyCode);
    }
}
