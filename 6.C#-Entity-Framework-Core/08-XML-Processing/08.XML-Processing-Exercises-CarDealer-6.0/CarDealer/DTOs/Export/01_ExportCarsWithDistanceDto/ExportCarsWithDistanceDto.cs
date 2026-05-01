using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportCarsWithDistanceDto;

[XmlType("ExportSingleCarFromMakeBmwDto")]
public class ExportCarsWithDistanceDto
{
    [Required]
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [Required]
    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveled-distance")]
    public long TraveledDistance { get; set; }
}