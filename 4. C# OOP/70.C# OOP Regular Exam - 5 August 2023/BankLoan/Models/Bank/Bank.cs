using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;   
using System.Linq;
using System.Text;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models.Bank;

public abstract class Bank : IBank
{
    private string name;
    private int capacity;

    private readonly List<ILoan> loans;
    private readonly List<IClient> clients;

    protected Bank(string name, int capacity)
    {
        this.Name = name;
        this.Capacity = capacity;

        this.loans = new List<ILoan>();
        this.clients = new List<IClient>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
            }

            this.name = value;
        }

    }

    public int Capacity
    {
        get => this.capacity;
        private set => this.capacity = value;
    }
    public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();
    public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

    public double SumRates()
    {
        return this.loans.Sum(l => l.InterestRate);
    }

    public void AddClient(IClient Client)
    {
        if (this.Capacity > this.clients.Count)
        {
            this.clients.Add(Client);
        }
        else
        {
            throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
        }
    }

    public void RemoveClient(IClient Client)
    {
        this.clients.Remove(Client);
    }

    public void AddLoan(ILoan loan)
    {
        this.loans.Add(loan);
    }

    public string GetStatistics()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
        sb.Append($"Clients: ");

        if (this.Clients.Count == 0)
        {
            sb.AppendLine("none");
        }
        else
        {
            sb.AppendLine(string.Join(", ", this.Clients.Select(c => c.Name)));
        }

        sb.AppendLine($"Loans: {this.loans.Count} , Sum of Rates:  {SumRates()}");

        return sb.ToString().TrimEnd();
    }
}