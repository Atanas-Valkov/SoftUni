namespace P03E03.Telephony;

public class StationaryPhone : ICallable
{
    public string Calling(string phoneNumber)
    {
        if (phoneNumber.Any(c => !char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Dialing... {phoneNumber}";
    }
}