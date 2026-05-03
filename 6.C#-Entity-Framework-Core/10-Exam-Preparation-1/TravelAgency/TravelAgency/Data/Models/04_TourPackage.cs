using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static TravelAgency.Common.EntityValidation.TourPackage;

namespace TravelAgency.Data.Models;

public class TourPackage
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PackageNameMaxLength)]
    public string PackageName { get; set; } = null!;
    
    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    [MinLength(PriceMinLength)]
    public decimal Price { get; set; }


    public virtual ICollection<Booking> Bookings { get; set; }
        = new List<Booking>();

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    = new List<TourPackageGuide>();

}