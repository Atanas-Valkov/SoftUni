using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop.DTOs.Export._04_GetUsersWithProductsDto;

[XmlRoot("Users")]
public class ExportGetUsersWithProductsDto
{
    //<UsersDto>
    //   <count>54</count>
    //   <users>
    //     <User>
    //       <firstName>Dale</firstName>
    //       <lastName>Galbreath</lastName>
    //       <age>31</age>
    //       <SoldProductsInfo> 
    //         <count>9</count>
    //         <products>
    //           <Product>
    //             <name>Fair Foundation SPF 15</name>
    //             <price>1394.24</price>
    //           </Product>
    //           <Product> 
    //             <name>Finasteride</name>
    //             <price>1374.01</price>
    //           </Product>
    //           <Product>
    //             <name>EMEND</name>
    //             <price>1365.51</price>
    //           </Product>
    // ...
    // </UsersDto>

    [XmlElement("count")]
    public int  Count { get; set; }
    [XmlArray("users")]
    public ExportUsersDto[] UsersDto { get; set; }

}