using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportLocalSuppliersDto;

[XmlRoot("suppliers")]
public class ExportLocalSuppliersDto
{
    [XmlElement("supplier")]
    public LocalSuppliersDto[] Suppliers { get; set; }
}