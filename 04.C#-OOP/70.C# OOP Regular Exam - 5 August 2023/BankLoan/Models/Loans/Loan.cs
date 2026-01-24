using BankLoan.Models.Contracts;

namespace BankLoan.Models.Loans;

public abstract class Loan : ILoan
{
    private int interestRate;
    private double amount;

    protected Loan(int interestRate, double amount)
    {
        this.InterestRate = interestRate;
        this.Amount = amount;
    }

    public int InterestRate
    {
        get=> this.interestRate;
        private set => this.interestRate = value;
    }

    public double Amount
    {
        get => this.amount;
        private set => this.amount = value;
    }
}