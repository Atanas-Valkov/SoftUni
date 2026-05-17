using Cadastre.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor.ExportDtos;

public class CitizenDto
{
    [JsonProperty]
    public string LastName { get; set; } = null!;

    [JsonProperty("MaritalStatus")]
    public string MaritalStatus { get; set; } = null!;
}