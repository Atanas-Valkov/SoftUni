using System.ComponentModel.DataAnnotations;
using static NetPay.Common.EntityValidation;
using static NetPay.Common.EntityValidation.Service;
namespace NetPay.Data.Models;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ServiceNameMixLength)]
    public string ServiceName { get; set; } = null!;

    public virtual ICollection<SupplierService> SuppliersServices { get; set; }
        = new List<SupplierService>();

    public virtual ICollection<Expense> Expenses { get; set; }
        = new List<Expense>();
}