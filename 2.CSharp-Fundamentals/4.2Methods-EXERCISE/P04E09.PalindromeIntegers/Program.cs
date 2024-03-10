namespace P04E09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = "";
            PalindromeOrNot(number);
        }
        static void PalindromeOrNot(string number)
        {
            while ((number = Console.ReadLine()) != "END")
            {
                string firstHalf = number.Substring(0, number.Length / 2);
                char[] arr = number.ToCharArray();
                Array.Reverse(arr);

                string temp = new string(arr);
                string secondHalf = temp.Substring(0, temp.Length / 2);

                bool result = firstHalf.Equals(secondHalf);
                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }
}