using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export.ExportProductsInRangeDto;

[XmlType("Product")]
public class ExportProductsInRangeDto
{
    //<Products>                             ======> XmlRootElement 
    // <Product>                             ======> XmlType
    //   <name>TRAMADOL HYDROCHLORIDE</name> ======> XmlElement
    //   <price>516.48</price>               ======> XmlElement
    //   <buyer> </buyer>                    ======> XmlElement
    // </Product>                            ======> XmlElement
    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("price")]
    public decimal Price { get; set; }

    [XmlElement("buyer")]
    public string? Buyer { get; set; }

}