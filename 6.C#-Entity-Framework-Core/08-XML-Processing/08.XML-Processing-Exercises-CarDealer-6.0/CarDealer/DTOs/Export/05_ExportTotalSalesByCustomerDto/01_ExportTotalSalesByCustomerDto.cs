using CarDealer.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportTotalSalesByCustomerDto;

[XmlRoot("customers")]
public class ExportTotalSalesByCustomerDto
{
    [XmlElement("customer")]
    public ExportCustomerDto[] Customers { get; set; } = null!;
}