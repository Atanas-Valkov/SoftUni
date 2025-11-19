namespace P03E03.Telephony;

public class Smartphone : ICallable, IBrowsable
{
    public string Calling(string phoneNumber)
    {
        if (phoneNumber.Any(c => !char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}"; 
    }

    public string Browsing(string website)
    {
        if (website.Any(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {website}!";
    }
}