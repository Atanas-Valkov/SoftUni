using System.ComponentModel.DataAnnotations;
using static GarageApp.Common.EntityValidation.Garage;
namespace GarageApp.DbModels;

public class Garage
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MinLength(MinNameLength)]
    [MaxLength(MaxNameLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(MinLocationLength)]
    [MaxLength(MaxLocationLength)]
    public string Location { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; }
        = new List<Car>();

}