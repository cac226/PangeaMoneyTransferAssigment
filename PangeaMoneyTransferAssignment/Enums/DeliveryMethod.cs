/*
 NOTE: I opted to make delivery method + payment methods enums because I expect there 
to be very few valid delivery/payment methods. 

Although currency code/country code also could have been an enum (as there are a finite known 
number of them), I opted not to make it an enum because a) if this code were to be integrated 
into a larger system, an enum like that probably already exists and b) writing out a complete
enum like that sounds very annoying, and updating it also seems very annoying, so we don't want 
to create/maintain it unless it's absolutely necessary. 
 */

namespace PangeaMoneyTransferAssignment.Enums
{
    /// <summary>
    /// Represents valid delivery methods (i.e. methods of giving USD to be converted to another currency) 
    /// </summary>
    public enum DeliveryMethod
    {
        CASH,
        DEBIT,
        DEPOSIT
    }
}
