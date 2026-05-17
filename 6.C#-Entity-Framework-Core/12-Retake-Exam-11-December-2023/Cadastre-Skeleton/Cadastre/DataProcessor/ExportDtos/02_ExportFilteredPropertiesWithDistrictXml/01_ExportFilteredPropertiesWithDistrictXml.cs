using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ExportDtos.ExportFilteredPropertiesWithDistrict;

[XmlType("Property")]
public class ExportFilteredPropertiesWithDistrictXml
{
    //<?xml version="1.0" encoding="utf-16"?>
    // <Properties>
    //   <Property postal-code="VA-90000">
    //     <PropertyIdentifier>VA-90000.003.005.005</PropertyIdentifier>
    //     <Area>2300</Area>
    //     <DateOfAcquisition>28/08/2008</DateOfAcquisition>
    //   </Property>
    //   <Property postal-code="ST-60000">
    //     <PropertyIdentifier>ST-60000.004.002.002</PropertyIdentifier>
    //     <Area>1150</Area>
    //     <DateOfAcquisition>14/06/2002</DateOfAcquisition>
    //   </Property>
    //   <Property postal-code="PL-40000">
    //     <PropertyIdentifier>PL-40000.002.004.004</PropertyIdentifier>
    //     <Area>1050</Area>
    //     <DateOfAcquisition>03/03/2010</DateOfAcquisition>
    //   </Property>
    // …
    // </Properties>
    //

    [XmlAttribute("postal-code")]
    public string PostalCode { get; set; } = null!;

    [XmlElement("PropertyIdentifier")]
    public string PropertyIdentifier { get; set; } = null!;

    [XmlElement("Area")]
    public int Area { get; set; }

    [XmlElement("DateOfAcquisition")]
    public string DateOfAcquisition { get; set; } = null!;
}