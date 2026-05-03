using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static TravelAgency.Common.EntityValidation.Customer;
namespace TravelAgency.DataProcessor.ImportDtos;

[XmlType("Customer")]
public class ImportCustomersDto
{
    //<Customers>                               ==>XmlRoot
    // <Customer phoneNumber="+357683444233">   ==>XmlType => XmlAttribute
    // 	<FullName>Robert Simons</FullName>      ==>XmlElement
    // 	<Email>robert.simons@mail.dm</Email>    ==>XmlElement
    // </Customer>


    [Required]
    [XmlElement("FullName")]
    [MinLength(FullNameMinLength)]
    [MaxLength(FullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [XmlElement("Email")]
    [MinLength(EmailMinLength)]
    [MaxLength(EmailMaxLength)]
    public string? Email { get; set; }


    [Required]
    [XmlAttribute("phoneNumber")]
    [MaxLength(PhoneNumberMaxLength)]
    [RegularExpression(PhoneNumberRegEx)]
    public string PhoneNumber { get; set; } = null!;
}