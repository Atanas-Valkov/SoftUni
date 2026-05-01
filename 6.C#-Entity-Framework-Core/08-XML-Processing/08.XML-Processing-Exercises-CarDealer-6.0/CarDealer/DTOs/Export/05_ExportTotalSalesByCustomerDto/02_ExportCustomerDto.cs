using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportTotalSalesByCustomerDto;

[XmlType("customer")]
public class ExportCustomerDto
{
    [Required]
    [XmlAttribute("full-name")]
    public string FullName { get; set; } = null!;

    [XmlAttribute("bought-cars")]
    public int BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
    public decimal SpentMoney { get; set; }
}