using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("CategoryProduct")]
public class ImportCategoryProductsDto
{
    //<CategoryProducts>
    // <CategoryProduct>
    //     <CategoryId>4</CategoryId>
    //     <ProductId>1</ProductId>
    // </CategoryProduct>

    [Required]
    [XmlElement("CategoryId")]
    public string CategoryId { get; set; } = null!;

    [Required]
    [XmlElement("ProductId")]
    public string ProductId { get; set; } = null!;



}