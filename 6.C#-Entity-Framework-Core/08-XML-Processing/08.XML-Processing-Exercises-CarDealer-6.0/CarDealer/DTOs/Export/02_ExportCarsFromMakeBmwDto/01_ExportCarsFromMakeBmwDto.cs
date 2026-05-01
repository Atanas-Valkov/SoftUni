using System.Xml.Serialization;

namespace CarDealer.DTOs.Export.ExportCarsFromMakeBmwDto;

[XmlRoot("cars")]
public class ExportCarsFromMakeBmwDto
{
    //<cars>
    //   <ExportSingleCarFromMakeBmwDto id="26" model="1M Coupe" traveled-distance="39826890" />
    //   <ExportSingleCarFromMakeBmwDto id="28" model="E67" traveled-distance="476830509" />
    //   <ExportSingleCarFromMakeBmwDto id="24" model="E88" traveled-distance="27453411" />
    //   ...
    // </cars>
    // 
    [XmlElement("ExportSingleCarFromMakeBmwDto")]
    public ExportSingleCarFromMakeBmwDto[] Car { get; set; } = null!;

}