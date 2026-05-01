
using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NetPay.Common.EntityValidation.Expense;

namespace NetPay.Data.Models;

public class Expense
{
    
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ExpenseNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [Column(TypeName = AmountValueRange)]
    public decimal Amount { get; set; }

    public DateTime DueDate { get; set; }

    public PaymentStatus PaymentStatus { get; set; }

    [ForeignKey(nameof(Household))]
    public int HouseholdId { get; set; }
    public virtual Household Household { get; set; } = null!;

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; } = null!;

    
}