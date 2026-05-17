using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.DataProcessor.ExportDtos.ExportFilteredPropertiesWithDistrict;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Text.Json.Nodes;
using NetPay.Data.Utilities;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            ExportPropertiesWithTheirOwnersDto[] exportPropertiesWithOwnersQuery = dbContext.Properties
                .AsNoTracking()
                .Where(p => p.DateOfAcquisition >= new DateTime(2000, 01, 01))
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new ExportPropertiesWithTheirOwnersDto()
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                        .OrderBy(pc => pc.Citizen.LastName)
                        .Select(pc => new CitizenDto()
                        {
                            LastName = pc.Citizen.LastName,
                            MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                        })
                        .ToArray()
                })
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject
            (
                exportPropertiesWithOwnersQuery,
                Formatting.Indented
            );

            return jsonResult;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            ExportFilteredPropertiesWithDistrictXml[] exportPropertiesQuery = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(P => P.Area)
                .ThenBy(p=> p.DateOfAcquisition)
                .Select(p => new ExportFilteredPropertiesWithDistrictXml()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
                })
                .ToArray();

            string xmlResult = XmlHelper.Serialize(exportPropertiesQuery, "Properties");

            return xmlResult;
        }
    }
}