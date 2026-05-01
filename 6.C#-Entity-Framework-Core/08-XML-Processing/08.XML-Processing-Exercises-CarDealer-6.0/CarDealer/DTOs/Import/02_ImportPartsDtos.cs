using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Part")]
public class ImportPartsDtos
{
    //<Parts>
    // <Part>
    //     <name>Bonnet/hood</name>
    //     <price>1001.34</price>
    //     <quantity>10</quantity>
    //     <supplierId>17</supplierId>
    // </Part>
    // <Part>
    //     <name>Unexposed bumper</name>
    //     <price>1003.34</price>
    //     <quantity>10</quantity>
    //     <supplierId>12</supplierId>
    // </Part>
    // <Part>
    //     <name>Exposed bumper</name>
    //     <price>1400.34</price>
    //     <quantity>10</quantity>
    //     <supplierId>13</supplierId>
    // </Part>

    [Required]
    [XmlElement("name")]
    public string Name { get; set; } = null!;


    [XmlElement("price")]
    public string Price { get; set; } = null!;


    [XmlElement("quantity")]
    public string Quantity { get; set; } = null!;

    [XmlElement("supplierId")] 
    public string SupplierId { get; set; } = null!;

}