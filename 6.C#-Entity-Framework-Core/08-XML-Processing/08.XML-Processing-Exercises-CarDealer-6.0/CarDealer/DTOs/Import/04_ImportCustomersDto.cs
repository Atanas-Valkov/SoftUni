using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Customer")]
public class ImportCustomersDto
{
    //<c>
    // <Customer>
    //     <name>Emmitt Benally</name>
    //     <birthDate>1993-11-20T00:00:00</birthDate>
    //     <isYoungDriver>true</isYoungDriver>
    // </Customer>

    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("birthDate")]
    public string BirthDate { get; set; } = null!;

    [XmlElement("isYoungDriver")]
    public string IsYoungDriver { get; set; } = null!;
}