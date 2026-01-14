using BankLoan.Core.Contracts;
using BankLoan.Models.Bank;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loans;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;

namespace BankLoan.Core;

public class Controller : IController
{
    private readonly LoanRepository loans;
    private readonly BankRepository banks;

    public Controller()
    {
        this.loans = new LoanRepository();
        this.banks = new BankRepository();

    }

    public string AddBank(string bankTypeName, string name)
    {
        IBank bank;

        if (bankTypeName != nameof(BranchBank) &&
            bankTypeName != nameof(CentralBank))
        {
            return string.Format(ExceptionMessages.BankTypeInvalid);
        }

        if (bankTypeName == nameof(BranchBank))
        {
            bank = new BranchBank(name);
        }
        else
        {
            bank = new CentralBank(name);
        }

        return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
    }

    public string AddLoan(string loanTypeName)
    {
        ILoan loan;
        if (loanTypeName != nameof(StudentLoan) &&
            loanTypeName != nameof(MortgageLoan))
        {
            return string.Format(ExceptionMessages.LoanTypeInvalid);
        }

        if (loanTypeName == nameof(StudentLoan))
        {
            loan = new StudentLoan();
        }
        else
        {
            loan = new MortgageLoan();
        }

        return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
    }

    public string ReturnLoan(string bankName, string loanTypeName)
    {
        ILoan loaan = this.loans.FirstModel(loanTypeName);
        if (loaan == null)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
        }

        IBank bank = this.banks.FirstModel(bankName);
        bank.AddLoan(loaan);
        loans.RemoveModel(loaan);

        return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
    }

    public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
    {
        return string.Empty;
    }

    public string FinalCalculation(string bankName)
    {
        return string.Empty;
    }

    public string Statistics()
    {
        return string.Empty;
    }
}