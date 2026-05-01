using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportGetCarsWithTheirListOfPartsDto;

[XmlType("car")]
public class CarsWithListOfPartsDto
{
    [Required]
    [XmlAttribute("make")]
    public string Make { get; set; } = null!;

    [Required]
    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [Required]
    [XmlAttribute("traveled-distance")]
    public long TraveledDistance { get; set; }

    [Required]
    [XmlArray("parts")]
    public PartsDto[] Parts { get; set; } = null!;
}