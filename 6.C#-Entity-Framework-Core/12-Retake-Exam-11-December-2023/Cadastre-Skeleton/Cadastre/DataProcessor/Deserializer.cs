using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using NetPay.Data.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.DataProcessor.ImportDtos.ImportCitizens;
    using System.ComponentModel.DataAnnotations;
    using System.Net.NetworkInformation;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";

        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";

        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<District> districtsToImport = new List<District>();

            DistrictDto[]? importDistrictDto = XmlHelper
                .Deserialize<DistrictDto[]>(xmlDocument, "Districts");

            if (importDistrictDto != null)
            {
                foreach (DistrictDto districtDto in importDistrictDto)
                {
                    if (!IsValid(districtDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicateNameCheck = dbContext.Districts.Any(d => d.Name == districtDto.Name);

                    bool isDuplicateNameInDistrictsToImport = districtsToImport.Any(d => d.Name == districtDto.Name);

                    bool isRegionValid = Enum.TryParse(districtDto.Region, out Region regionResult);

                    if (isDuplicateNameCheck || isDuplicateNameInDistrictsToImport || !isRegionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    District newDistrict = new District()
                    {
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode,
                        Region = regionResult
                    };

                    foreach (PropertiesDto property in districtDto.Properties)
                    {
                        if (!IsValid(property))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isPropertyIdentifierExist = dbContext.Properties
                            .Any(p => p.PropertyIdentifier == property.PropertyIdentifier);

                        bool isPropertyIdentifierExistInCurrentDistrict = newDistrict.Properties
                            .Any(p => p.PropertyIdentifier == property.PropertyIdentifier);

                        bool isAddressExist = dbContext.Properties
                            .Any(p => p.Address == property.Address );

                        bool isAddressExistInCurrentDistrict = newDistrict.Properties
                            .Any(p => p.Address == property.Address);

                        if (isPropertyIdentifierExist ||
                            isPropertyIdentifierExistInCurrentDistrict ||
                            isAddressExist ||
                            isAddressExistInCurrentDistrict)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isAreaValid = int.TryParse(property.Area, out int areaResult);

                        bool isDateTimeValid = DateTime.TryParseExact
                        (
                            property.DateOfAcquisition,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime dateOfAcquisitionResult
                        );

                        if (!isAreaValid || !isDateTimeValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Property newProperty = new Property()
                        {
                            PropertyIdentifier = property.PropertyIdentifier,
                            Area = areaResult,
                            Details = property.Details,
                            Address = property.Address,
                            DateOfAcquisition = dateOfAcquisitionResult
                        };

                        newDistrict.Properties.Add(newProperty);
                    }

                    districtsToImport.Add(newDistrict);
                    sb.AppendLine(string.Format(
                        SuccessfullyImportedDistrict,
                        districtDto.Name,
                        newDistrict.Properties.Count));
                }
            }

            dbContext.AddRange(districtsToImport);
            dbContext.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Citizen> citizensToImport = new List<Citizen>();

            ImportCitizensDto[]? citizensDto = JsonConvert
                .DeserializeObject<ImportCitizensDto[]>(jsonDocument);

            if (citizensDto != null)
            {
                foreach (ImportCitizensDto citizen in citizensDto)
                {
                    if (!IsValid(citizen))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isMaritalStatusValid =
                        Enum.TryParse(citizen.MaritalStatus, out MaritalStatus maritalStatusResult);

                    bool isDateValid = DateTime.TryParseExact
                    (
                        citizen.BirthDate,
                        "dd-MM-yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime dateResult
                    );

                    if (!isMaritalStatusValid || !isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Citizen newCitizen = new Citizen()
                    {
                        FirstName = citizen.FirstName,
                        LastName = citizen.LastName,
                        BirthDate = dateResult,
                        MaritalStatus = maritalStatusResult,
                    };

                    foreach (int propertiesCitizens in citizen.Properties)
                    {
                        bool isPropertyIdValid = dbContext.Properties
                            .Any(p => p.Id == propertiesCitizens);

                        if (!isPropertyIdValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        PropertyCitizen newPropertiesCitizens = new PropertyCitizen()
                        {
                            Citizen = newCitizen,
                            PropertyId = propertiesCitizens
                        };

                        newCitizen.PropertiesCitizens.Add(newPropertiesCitizens);
                    }

                    citizensToImport.Add(newCitizen);
                    sb.AppendLine(string.Format
                    (
                        SuccessfullyImportedCitizen,
                        citizen.FirstName,
                        citizen.LastName,
                        newCitizen.PropertiesCitizens.Count
                    ));
                }

                ;

                dbContext.Citizens.AddRange(citizensToImport);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}