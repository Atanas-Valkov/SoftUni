using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("LocalSuppliersDto")]
public class ImportSuppliersDto
{
    //<Suppliers>
    // <LocalSuppliersDto>
    //     <name>3M Company</name>
    //     <isImporter>true</isImporter>
    // </LocalSuppliersDto>
    // <LocalSuppliersDto>
    //     <name>Agway Inc.</name>
    //     <isImporter>false</isImporter>
    // </LocalSuppliersDto>
    // <LocalSuppliersDto>
    //     <name>Anthem, Inc.</name>
    //     <isImporter>true</isImporter>
    // </LocalSuppliersDto>

    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("isImporter")]
    public string IsImporter { get; set; } = null!;

}