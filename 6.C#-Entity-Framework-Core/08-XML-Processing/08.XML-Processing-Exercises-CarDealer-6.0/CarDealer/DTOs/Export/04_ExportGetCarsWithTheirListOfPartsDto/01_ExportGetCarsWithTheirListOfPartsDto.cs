using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportGetCarsWithTheirListOfPartsDto;

[XmlRoot("cars")]
public class ExportGetCarsWithTheirListOfPartsDto
{
    [XmlElement("car")]
    public CarsWithListOfPartsDto[] Cars { get; set; }
}