using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Car")]
public class ImportCarsDto
{
    //<Cars>
    // <Car>
    //   <make>Opel</make>
    //   <model>Omega</model>
    //   <traveledDistance>176664996</traveledDistance>
    //   <parts>
    //     <partId id="38"/>
    //     <partId id="102"/>
    //     <partId id="23"/>
    //     <partId id="116"/>
    //     <partId id="46"/>
    //     <partId id="68"/>
    //     <partId id="88"/>
    //     <partId id="104"/>
    //     <partId id="71"/>
    //     <partId id="32"/>
    //     <partId id="114"/>
    //   </parts>
    // </Car>

    [Required]
    [XmlElement("make")]
    public string Make { get; set; } = null!;

    [Required]
    [XmlElement("model")]
    public string Model { get; set; } = null!;

    [XmlElement("traveledDistance")] 
    public string TraveledDistance { get; set; } = null!;

    [XmlArray("parts")] 
    public PartDto[] Parts { get; set; } = null!;
}

[XmlType("partId")]
public class PartDto
{
    [XmlAttribute("id")]
    public int PartId { get; set; }
}

