using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using static Cadastre.Common.EntityValidation.District;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class DistrictDto
{
    [Required]
    [MinLength(NameMinLength)]
    [MaxLength(NameMaxLength)]
    [XmlElement("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(PostalCodeMinLength)]
    [MaxLength(PostalCodeMaxLength)]
    [RegularExpression(PostalCodeRegEx)]
    [XmlElement("PostalCode")]
    public string PostalCode { get; set; } = null!;

    [Required]
    [XmlAttribute("Region")]
    public string Region { get; set; } = null!;


    [XmlArray ("Properties")]
    public PropertiesDto[] Properties { get; set; } = null!;

}