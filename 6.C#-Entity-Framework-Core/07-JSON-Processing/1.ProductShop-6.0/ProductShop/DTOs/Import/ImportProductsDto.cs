using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportProductsDto
{
    //   "Name": "Care One Hemorrhoidal",
    //   "Price": 932.18,
    //   "SellerId": 25,
    //   "BuyerId": 24

    [Required]
    [JsonProperty("Name")]
    public string Name { get; set; } = null!;

    
    [JsonProperty("Price")]   
    public decimal Price { get; set; }


    [JsonProperty("SellerId")]
    public int SellerId { get; set; }

    [JsonProperty("BuyerId")]
    public int BuyerId { get; set; }
}