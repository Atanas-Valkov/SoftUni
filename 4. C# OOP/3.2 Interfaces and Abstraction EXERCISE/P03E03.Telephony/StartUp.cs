namespace P03E03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] websites = Console
               .ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var phoneNumber in phoneNumbers)
            {
                ICallable callable = null;

                if (phoneNumber.Length == 10)
                {
                    callable = new Smartphone();
                   
                }
                else if (phoneNumber.Length == 7)
                {
                    callable = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(callable.Calling(phoneNumber));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            foreach (var url in websites)
            {
                try
                {
                    IBrowsable browsable = new Smartphone();
                    Console.WriteLine(browsable.Browsing(url));
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
