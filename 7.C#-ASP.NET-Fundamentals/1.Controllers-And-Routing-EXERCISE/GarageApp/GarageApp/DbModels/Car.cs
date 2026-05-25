using GarageApp.DbModels.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GarageApp.Common.EntityValidation;
using static GarageApp.Common.EntityValidation.Car;


namespace GarageApp.DbModels;

public class Car
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(MinMakeLength)]
    [MaxLength(MaxMakeLength)]
    public string Make { get; set; } = null!;

    [Required]
    [MinLength(MinModelLength)]
    [MaxLength(MaxModelLength)]
    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public TypeCar TypeCar { get; set; }

    public bool IsAvailable { get; set; }

    [ForeignKey(nameof(Garage))]
    public Guid GarageId { get; set; }

    public virtual Garage Garage { get; set; } = null!;
}