using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using static Cadastre.Common.EntityValidation.Property;
namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("Property")]
public class PropertiesDto
{
    [Required]
    [MinLength(PropertyIdentifierMinLength)]
    [MaxLength(PropertyIdentifierMaxLength)]
    [XmlElement("PropertyIdentifier")]
    public string PropertyIdentifier { get; set; } = null!;

    [Required]
    [XmlElement("Area")]
    public int Area { get; set; } 

    [Required]
    [MinLength(DetailsMinLength)]
    [MaxLength(DetailsMaxLength)]
    [XmlElement("Details")]
    public string Details { get; set; } = null!;

    [Required]
    [MinLength(AddressMinLength)]
    [MaxLength(AddressMaxLength)]
    [XmlElement("Address")]
    public string Address { get; set; } = null!;

    [Required]
    [XmlElement("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; } = null!;

}