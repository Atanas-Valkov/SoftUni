using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ProductShop.DTOs.Import;

public class ImportUsersDto
{
    // "firstName": "Eugene",
    // "lastName": "Stewart",
    // "age": 65

    [JsonProperty("firstName")]
    public string? FirstName { get; set; }

    [Required]
    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("age")]
    public int? Age { get; set; }
    

}