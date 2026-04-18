using ProductShop.Data;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Models.Utilites;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            using ProductShopContext dbContext  = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            string xmlFileTe = ReadXmlFile("users.xml");

            string result = ImportUsers(dbContext, xmlFileTe);
            Console.WriteLine(result);

        }

        // 2.	Import Data
        // Query 1. Import Users

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ICollection<User> usersToImport = new List<User>();

            ImportUsersDto[]? importUserDtos = XmlHelper
                .Deserialize<ImportUsersDto[]>(inputXml, "Users");

            if (importUserDtos != null)
            {
                foreach (ImportUsersDto importUserDto in importUserDtos)
                {
                    if (!IsValid(importUserDto))
                    {
                        continue;
                    }

                    int? age = null;
                    if (importUserDto.Age != null)
                    {
                        bool isAgeParsable = int.TryParse(importUserDto.Age, out int ageValue);
                        if (!isAgeParsable)
                        {
                            continue;
                        }
                        age = ageValue;
                    }

                    User user = new User()
                    {
                        FirstName = importUserDto.FistName,
                        LastName = importUserDto.LastName,
                        Age = age
                    };
                    usersToImport.Add(user);    
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {usersToImport.Count} users";
        }

        private static string ReadXmlFile(string fileName)
        {
            string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string xmlFileText = File.ReadAllText(xmlFilePath + fileName);

            return xmlFileText;
        }
        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}