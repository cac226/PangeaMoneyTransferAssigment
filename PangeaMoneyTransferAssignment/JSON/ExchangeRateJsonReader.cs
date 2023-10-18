using System.Text.Json;

namespace PangeaMoneyTransferAssignment.JSON
{
    internal class ExchangeRateJsonReader
    {
        public static PartnerExchangeRate[] ReadJson(string jsonFileLocation)
        {
            string jsonText = File.ReadAllText(jsonFileLocation);

            SerializablePartnerDataJson rawData = JsonSerializer.Deserialize<SerializablePartnerDataJson>(jsonText);
            return rawData.PartnerRates;
        }
    }
}
