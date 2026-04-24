using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export._04_GetUsersWithProductsDto;

[XmlType("User")]
public class ExportUsersDto
{
    [XmlElement("firstName")]
    public string? FirstName { get; set; }

    [Required]
    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;


    [XmlElement("age")]
    public int? Age { get; set; }

    [XmlElement("SoldProducts")] 
    public ExportSoldProductsInfoDto SoldProductsInfo { get; set; } = null!;
}