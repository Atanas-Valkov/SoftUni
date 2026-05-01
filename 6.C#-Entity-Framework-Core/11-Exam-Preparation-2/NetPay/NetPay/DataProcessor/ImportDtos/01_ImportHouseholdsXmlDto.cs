using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static NetPay.Common.EntityValidation.Household;

namespace NetPay.DataProcessor.ImportDtos;

[XmlType("Household")]
public class ImportHouseholdsXmlDto
{
    //<Households>
    // <Household phone="+144/123-123456">
    // 	<ContactPerson>Alexander Ivanov</ContactPerson>
    // 	<Email>alexander.ivanov@example.com</Email>
    // </Household>

    [Required]
    [XmlElement("ContactPerson")]
    [MinLength(ContactPersonMinLength)]
    [MaxLength(ContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;

    
    [XmlElement("Email")]
    [MinLength(EmailMinLength)]
    [MaxLength(EmailMaxLength)]
    public string? Email { get; set; } = null!;

    [Required]
    [XmlAttribute("phone")]
    [MinLength(PhoneNumberLength)]
    [MaxLength(PhoneNumberLength)]
    [RegularExpression(PhoneNumberRegEx)]
    public string PhoneNumber { get; set; } = null!;
}