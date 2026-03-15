
using System.Transactions;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using static EntityValidation.Color;
public class Color
{
    [Key]
    public int ColorId { get; set; }
    [Required]
    [MaxLength(ColorMaxLength)]
    public required string Name { get; set; }
}