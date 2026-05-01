using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportCarsFromMakeBmwDto;

[XmlType("car")]
public class ExportSingleCarFromMakeBmwDto
{
    [Required]
    [XmlAttribute("id")] 
    public string Id { get; set; } = null!;

    [Required]
    [XmlAttribute("model")]
    public string Model { get; set; } = null!;

    [Required]
    [XmlAttribute("traveled-distance")] 
    public string TravelDistance { get; set; } = null!;
}