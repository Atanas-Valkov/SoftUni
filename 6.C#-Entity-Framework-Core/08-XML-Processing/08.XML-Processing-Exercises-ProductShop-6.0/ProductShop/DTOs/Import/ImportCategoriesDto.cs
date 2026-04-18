using ProductShop.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import;

[XmlType("Category")]
public class ImportCategoriesDto
{
    //<Categories>             ====> XmlRoot Node 
    // <Category>              ====> XmlType
    //     <name>Drugs</name>  ====> XmlElement
    // </Category>             ====>

    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;
}