using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static NetPay.Common.EntityValidation.Expense;

namespace NetPay.DataProcessor.ImportDtos;

public class ImportExpensesJsonDto
{
    //  {
    //   "ExpenseName": "Electricity Home",
    //   "Amount": 120.50,
    //   "DueDate": "2024-08-25T00:00:00",
    //   "PaymentStatus": "Unpaid",
    //   "HouseholdId": 1,
    //   "ServiceId": 1
    // },

    [Required]
    [JsonProperty("ExpenseName")]
    [MinLength(ExpenseNameMinLength)]
    [MaxLength(ExpenseNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [Required]
    [JsonProperty("Amount")]
    [Range(typeof(decimal), AmountMinValue , AmountMaxValue)]
    public decimal? Amount { get; set; }

    [Required]
    [JsonProperty("DueDate")]
    public string DueDate { get; set; } = null!;

    [Required]
    [JsonProperty("PaymentStatus")]
    public string PaymentStatus { get; set; } = null!;

    [Required]
    [JsonProperty("HouseholdId")]
    public int? HouseholdId { get; set; }

    [Required]
    [JsonProperty("ServiceId")]
    public int? ServiceId { get; set; }
}