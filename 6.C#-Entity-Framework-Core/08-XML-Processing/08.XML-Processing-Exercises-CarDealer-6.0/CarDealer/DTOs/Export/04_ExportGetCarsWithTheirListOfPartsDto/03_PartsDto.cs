using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportGetCarsWithTheirListOfPartsDto;

[XmlType("part")]
public class PartsDto
{
    [Required]
    [XmlAttribute("name")]
    public string Name { get; set; } = null!;

    [Required]
    [XmlAttribute("price")] 
    public decimal Price { get; set; }


}