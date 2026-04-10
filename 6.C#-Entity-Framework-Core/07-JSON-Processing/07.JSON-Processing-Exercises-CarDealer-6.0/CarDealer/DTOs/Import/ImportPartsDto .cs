using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CarDealer.DTOs.Import;

public class ImportPartsDto
{
    //"name": "Bonnet/hood",
    // "price": 1001.34,
    // "quantity": 10,
    // "supplierId": 17

    [Required]
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [Required]
    [JsonProperty("supplierId")]
    public string SupplierId { get; set; } = null!;



}