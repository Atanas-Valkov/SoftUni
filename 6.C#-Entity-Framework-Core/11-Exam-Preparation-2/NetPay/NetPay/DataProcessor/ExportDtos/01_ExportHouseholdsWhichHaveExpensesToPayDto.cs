using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

[XmlType("Household")]
public class ExportHouseholdsWhichHaveExpensesToPayDto
{
    //<Households>                                         ==>XmlRoot 
    // <Household>                                         ==>XmlType 
    //   <ContactPerson>Alexander Ivanov</ContactPerson>   ==>XmlElement
    //   <Email>alexander.ivanov@example.com</Email>       ==>XmlElement
    //   <PhoneNumber>+144/123-123456</PhoneNumber>        ==>XmlElement
    //   <Expenses>                                        ==>XmlArr
    //     <Expense>                                       ==>XmlType
    //       <ExpenseName>Water Home</ExpenseName>         ==>XmlElement
    //       <Amount>50.50</Amount>                        ==>XmlElement
    //       <PaymentDate>2024-08-20</PaymentDate>         ==>XmlElement
    //       <ServiceName>Water</ServiceName>              ==>XmlElement
    //     </Expense>                                      ==>
    //     <Expense>                                       ==>
    //       <ExpenseName>Electricity Home</ExpenseName>   ==>
    //       <Amount>120.50</Amount>                       ==>
    //       <PaymentDate>2024-08-25</PaymentDate>         ==>
    //       <ServiceName>Electricity</ServiceName>        ==>
    //     </Expense>
    
    [XmlElement("ContactPerson")]
    public string ContactPerson { get; set; } = null!;

    
    [XmlElement("Email")]
    public string? Email { get; set; } 

    
    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; } = null!;

    [XmlArray("Expenses")] 
    public ExpensesToPayDto[] Expenses { get; set; } = null!;
}