using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class ExportUserDto
{
    // <UsersDto>                           ==> XmlRoot                               
    //   <User>                          ==> XmlType
    //     <firstName>Almire</firstName> ==> XmlElement
    //     <lastName>Ainslee</lastName>  ==> XmlElement
    //     <soldProducts>                ==> XmlArray
    //       <Product>                   ==> XmlType
    //         <name>Ampicillin</name>   ==> XmlElement
    //         <price>674.63</price>     ==> XmlElement
    //       </Product>
    //       <Product>
    //         <name>Strattera</name>
    //         <price>658.54</price>
    //       </Product>
    //       <Product>
    //         <name>Aspergillus repens</name>
    //         <price>1231.42</price>
    //       </Product>
    //     </soldProducts>
    //   </User>
    // ...
    // </UsersDto>
    // 

    [XmlElement("firstName")]
    public string? FirstName { get; set; }

    [Required]
    [XmlElement("lastName")]
    public string LastName { get; set; } = null!;

    [XmlArray("soldProducts")]
    public ExportSoldProductsDto[] SoldProducts { get; set; } = null!;                       

}