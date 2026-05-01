using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportLocalSuppliersDto;

[XmlType("supplier")]
public class LocalSuppliersDto
{
    [XmlAttribute("id")]
    public string Id { get; set; } = null!;

    [Required]
    [XmlAttribute("name")] 
    public string Name { get; set; } = null!;

    [XmlAttribute("parts-count")]
    public int PartsCount { get; set; } 
}