using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Models.Utilites;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            using ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //string xmlFileText = ReadXmlFile("users.xml");
            //string result = ImportUsers(dbContext, xmlFileText);

            //xmlFileText = ReadXmlFile("products.xml");
            //result = ImportProducts(dbContext, xmlFileText);

            //xmlFileText = ReadXmlFile("categories.xml");
            //result = ImportCategories(dbContext, xmlFileText);

            string xmlFileText = ReadXmlFile("categories-products.xml");
            string result = ImportCategoryProducts(dbContext, xmlFileText);

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

        //Query 2. Import Products

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            ICollection<Product> productsToImport = new List<Product>();

            ImportProductsDto[]? importProductsDtos = XmlHelper
                .Deserialize<ImportProductsDto[]>(inputXml, "Products");

            if (importProductsDtos != null)
            {
                foreach (ImportProductsDto importProductsDto in importProductsDtos)
                {
                    if (!IsValid(importProductsDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(importProductsDto.Price, out decimal priceResult);
                    bool isSellerIdValid = int.TryParse(importProductsDto.SellerId, out int selleIdResult);
                    bool isBuyerIdValid = TryParseNullableInt(importProductsDto.BuyerId, out int? buyerIdResult);

                    if (!isPriceValid || !isSellerIdValid || !isBuyerIdValid)
                    {
                        continue;
                    }

                    Product newProduct = new Product()
                    {
                        Name = importProductsDto.Name,
                        Price = priceResult,
                        SellerId = selleIdResult,
                        BuyerId = buyerIdResult
                    };

                    productsToImport.Add(newProduct);
                }

                context.Products.AddRange(productsToImport);
                context.SaveChanges();

            }

            return $"Successfully imported {productsToImport.Count}";
        }

        //Query 3. Import Categories 

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            ICollection<Category> categoryToImport = new List<Category>();

            ImportCategoriesDto[]? importCategoriesDtos = XmlHelper
                .Deserialize<ImportCategoriesDto[]>(inputXml, "Categories");

            if (importCategoriesDtos != null)
            {
                foreach (ImportCategoriesDto importCategoriesDto in importCategoriesDtos)
                {
                    if (!IsValid(importCategoriesDto))
                    {
                        continue;
                    }

                    Category newCategory = new Category()
                    {
                        Name = importCategoriesDto.Name
                    };

                    categoryToImport.Add(newCategory);
                }

                context.Categories.AddRange(categoryToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoryToImport.Count}";
        }


        //Query 4. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            ICollection<CategoryProduct> categoryProductToImport = new List<CategoryProduct>();

            IEnumerable<int> existingCategoryIds = context
                .Categories
                .AsNoTracking()
                .Select(c => c.Id)
                .ToList();

            IEnumerable<int> existingProductIds = context
                .Products
                .AsNoTracking()
                .Select(p => p.Id)
                .ToList();

            ImportCategoryProductsDto[]? categoryProductsDtos = XmlHelper
            .Deserialize<ImportCategoryProductsDto[]>(inputXml, "CategoryProducts");

            if (categoryProductsDtos != null)
            {
                foreach (ImportCategoryProductsDto importCPDto in categoryProductsDtos)
                {
                    if (!IsValid(importCPDto))
                    {
                        continue;
                    }

                    bool isCategoryIdValid =
                        int.TryParse(importCPDto.CategoryId, out int categoryIdResult);
                    bool isProductIdValid =
                        int.TryParse(importCPDto.ProductId, out int productIdResult);

                    if (!isCategoryIdValid || !isProductIdValid)
                    {
                        continue;
                    }

                    if (!existingCategoryIds.Contains(categoryIdResult)
                        || !existingProductIds.Contains(productIdResult))
                    {
                        continue;
                    }

                    CategoryProduct newCategoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryIdResult,
                        ProductId = productIdResult
                    };
                    categoryProductToImport.Add(newCategoryProduct);
                }

                context.CategoryProducts.AddRange(categoryProductToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoryProductToImport.Count}";
        }


        private static bool TryParseNullableInt(string? input, out int? nullableInt)
        {
            int? outValue = null;

            if (input != null)
            {
                bool isInputValid = int.TryParse(input, out int ageValue);

                if (!isInputValid)
                {
                    nullableInt = outValue;
                    return false;
                }
                outValue = ageValue;
            }
            nullableInt = null;
            return true;
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