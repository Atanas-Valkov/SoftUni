using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos;

[XmlType("Guide")]
public class ExportGuidesWithSpanishLanguageXmlDto
{
    //<Guides>                                                       ==>XmlRoot
    // <Guide>                                                       ==>XmlType
    // 	<FullName>Alex Johnson</FullName>                            ==>XmlElement
    // 	<TourPackages>                                               ==>XmlElement
    // 		<TourPackage>                                            ==>XmlType
    // 			<Name>Horse Riding Tour</Name>                       ==>XmlElement
    // 			<Description>Experience</Description>                ==>XmlElement
    // 			<Price>199.99</Price>                                ==>XmlElement
    
    [XmlElement("FullName")]
    public string FullName { get; set; } = null!;


    [XmlArray("TourPackages")]
    public TourPackages[] TourPackage { get; set; } = null!;




}