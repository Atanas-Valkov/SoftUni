using System.Text.Json.Serialization;

namespace ProductShop.DTOs.Import;

public class ImportCategorysProductsDto
{
    // "CategoryId": 4,
    // "ProductId": 1

    [JsonPropertyName("CategoryId")]
    public int CategoryId { get; set; }
    [JsonPropertyName("ProductId")]
    public int ProductId { get; set; }
        
}