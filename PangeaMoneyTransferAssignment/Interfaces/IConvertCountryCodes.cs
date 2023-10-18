
namespace PangeaMoneyTransferAssignment.Interfaces
{
    /// <summary>
    /// Converts country codes to currency codes. 
    /// </summary>
    public interface IConvertCountryCodes
    {
        public string ConvertCountryToCurrency(string countryCode);
    }
}
