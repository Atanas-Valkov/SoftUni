using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("Product")]
public class ImportProductsDto
{
    //Products>                              ======> XmlRootElement
    // <Product>                             ======> XmlType
    //     <name>Care One Hemorrhoidal</name>======> XmlElement
    //     <price>932.18</price>             ======> XmlElement
    //     <sellerId>25</sellerId>           ======> XmlElement
    //     <buyerId>24</buyerId>             ======> XmlElement
    // </Product>

    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement("price")]
    public string Price { get; set; } = null!;
    [Required]
    [XmlElement("sellerId")]
    public string SellerId { get; set; } = null!;

    [XmlElement("buyerId")]
    public string? BuyerId { get; set; } 
}