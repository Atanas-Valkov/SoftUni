namespace BankLoan.Models.Bank;

public class CentralBank : Bank
{
    private const int capacity = 50;
    public CentralBank(string name) 
        : base(name, capacity)
    {
    }
}