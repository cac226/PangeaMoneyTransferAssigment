namespace PangeaMoneyTransferAssignment
{
    public class Program
    {
        /*
         Things that are incomplete based on the assignemnt: 
        
        1. Integrating this with a localhost accessible HTTP handler (including serializing the data to be sent to a client)
        
        2. Unit tests -- The logic in ExchangeRateGetter is flexible enough (it's not direcly linked to reading JSONs), where it may be worth unit testing. However, 
        there are scenarios in which most of the unit test worthy logic gets removed (e.g if the API that we eventually get exchange rate data from has its own validation logic), 
        so it is probably not worth writing unit tests right now. 

        3. Exhcange Rate Adjustments -- this would be added to "ExchangeRateConverter.cs" (see file + comment for exact location) 

         */
        public static void Main(string[] args)
        {
            string jsonLocation = "C:\\Users\\caitl\\source\\repos\\PangeaMoneyTransferAssignment\\PangeaMoneyTransferAssignment\\JSON\\";
            string jsonName = "Example1.json";
            string countryCode = "MEX";

            MoneyTransferAPI moneyTransferAPI = MoneyTransferFactory.CreateMoneyTransferAPI(Path.Combine(jsonLocation, jsonName));
            List<ExchangeRateResponse> result = moneyTransferAPI.GetAllExchangeRateData(countryCode);

            foreach (ExchangeRateResponse exchangeRateResponse in result)
            {
                Console.WriteLine(exchangeRateResponse.ToString());
                Console.WriteLine();
            }
        }
    }
}
