namespace BankLoan.Models.Loans;

public class MortgageLoan : Loan
{
    private const int interestRate = 3;
    private const double amount = 50_000;
    public MortgageLoan() 
        : base(interestRate, amount)
    {
    }
}