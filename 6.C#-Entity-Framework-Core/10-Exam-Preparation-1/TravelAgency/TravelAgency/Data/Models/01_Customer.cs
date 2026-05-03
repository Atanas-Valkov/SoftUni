using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using static TravelAgency.Common.EntityValidation.Customer;

namespace TravelAgency.Data.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(FullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [MaxLength(EmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(PhoneNumberMaxLength)]
    public string PhoneNumber { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; }
        = new List<Booking>();
}
