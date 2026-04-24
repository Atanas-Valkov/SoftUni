using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export._04_GetUsersWithProductsDto;

[XmlType("Product")]
public class ExportProductsInfoDto
{
    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [Required] [XmlElement("price")] 
    public string Price { get; set; } = null!;

}