namespace BankLoan.Models.Loans;

public class StudentLoan : Loan
{
    private const int interestRate = 1;
    private const int amount = 10_000;

    public StudentLoan() 
        : base(interestRate, amount)
    {
    }
}