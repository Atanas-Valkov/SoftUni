using System.Xml.Serialization;

namespace ProductShop.DTOs.Export._04_GetUsersWithProductsDto;

[XmlType("SoldProductsInfo")]
public class ExportSoldProductsInfoDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")] 
    public ExportProductsInfoDto[] Products { get; set; } = null!;
}