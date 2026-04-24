using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export._03_ExportCategoriesByProductsCountDto;

[XmlType("Category")]
public class ExportCategoriesByProductsCountDto
{
    //<Categories>                                  // xmlRoot
    //   <Category>                                 // xmlArray
    //     <name>Garden</name>                      // xmlElement  
    //     <count>23</count>
    //     <averagePrice>800.150869</averagePrice>
    //     <totalRevenue>18403.47</totalRevenue>
    //   </Category>
    //   <Category>
    //     <name>Weapons</name>
    //     <count>22</count>
    //     <averagePrice>671.073181</averagePrice>
    //     <totalRevenue>14763.61</totalRevenue>
    //   </Category>
    // ...
    // </Categories>
    // 


    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;

    [XmlElement("count")]
    public int Count { get; set; }

    [XmlElement("averagePrice")]
    public decimal AveragePrice { get; set; }

    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }


}