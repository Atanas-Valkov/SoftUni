using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("User")]
public class ImportUsersDto
{
    // <UsersDto>
    // <User>
    //     <firstName>Chrissy</firstName>
    //     <lastName>Falconbridge</lastName>
    //     <age>50</age>
    // </User>

    [XmlElement("firstName")]
    public string? FistName { get; set; }
    [Required]
    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;
    [XmlElement("age")]
    public string? Age { get; set; }
}