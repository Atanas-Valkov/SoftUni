using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Cadastre.Common.EntityValidation.Citizen;

namespace Cadastre.DataProcessor.ImportDtos.ImportCitizens;

public class ImportCitizensDto
{
    //[
    // {
    //   "FirstName": "Ivan",
    //   "LastName": "Georgiev",
    //   "BirthDate": "12-05-1980",
    //   "MaritalStatus": "Married",
    //   "Properties": [ 17, 29 ]
    // },
    // {
    //   "FirstName": "Stefan",


    [Required]
    [MinLength(FirstNameMinLength)]
    [MaxLength(FirstNameMaxLength)]
    [JsonProperty("FirstName")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(LastNameMinLength)]
    [MaxLength(LastNameMaxLength)]
    [JsonProperty("LastName")]
    public string LastName { get; set; } = null!;

    [Required]
    [JsonProperty("BirthDate")]
    public string BirthDate { get; set; } = null!;

    [Required]
    [JsonProperty("MaritalStatus")]
    public string MaritalStatus { get; set; } = null!;
    
    [JsonProperty("Properties")]
    public int[] Properties { get; set; } = null!;


}