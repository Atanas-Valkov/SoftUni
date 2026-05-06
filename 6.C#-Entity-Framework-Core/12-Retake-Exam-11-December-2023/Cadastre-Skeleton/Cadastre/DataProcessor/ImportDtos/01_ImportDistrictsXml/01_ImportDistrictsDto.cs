using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlRoot("Districts")]
public class ImportDistrictsDto
{
    //<Districts>
    // <District Region="SouthWest">
    // 	<Name>Sofia</Name>
    // 	<PostalCode>SF-10000</PostalCode>
    // 	<Properties>
    // 		<Property>
    // 			<PropertyIdentifier>SF-10000.001.001.001</PropertyIdentifier>
    // 			<Area>71</Area>
    // 			<Details>One-bedroom apartment</Details>
    // 			<Address>Apartment 5, 23 Silverado Street, Sofia</Address>
    // 			<DateOfAcquisition>15/03/2022</DateOfAcquisition>
    // 		</Property>			
    // 		<Property>
    // 			<PropertyIdentifier>SF-10000.003.002.001</PropertyIdentifier>
    // 			<Area>120</Area>
    // 			<Details>Spacious two-bedroom apartment near central park</Details>
    // 			<Address>Apartment 8, 47 Green Street, Sofia</Address>
    // 			<DateOfAcquisition>01/02/2022</DateOfAcquisition>
    // 		</Property>

    [XmlArray("District")]
    public DistrictDto[] District { get; set; } = null!;
}