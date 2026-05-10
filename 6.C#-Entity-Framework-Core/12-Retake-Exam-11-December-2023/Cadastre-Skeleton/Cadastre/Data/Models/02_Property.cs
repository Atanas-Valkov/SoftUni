using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using static Cadastre.Common.EntityValidation;
using static Cadastre.Common.EntityValidation.Property;

namespace Cadastre.Data.Models;

public class Property
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PropertyIdentifierMaxLength)]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    [Range(AreaMinValue, AreaMaxValue)]
    public int Area { get; set; } 

    [Required]
    [MaxLength(DetailsMaxLength)]
    public string Details { get; set; } = null!;

    [Required]
    [MaxLength(AddressMaxLength)]
    public string Address { get; set; } = null!;

    public DateTime DateOfAcquisition { get; set; }

    [ForeignKey(nameof(District))]
    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
        = new List<PropertyCitizen>();
}