using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Export._03_ExportCategoriesByProductsCountDto;
using ProductShop.DTOs.Export._04_GetUsersWithProductsDto;
using ProductShop.DTOs.Export.ExportProductsInRangeDto;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Models.Utilites;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

            using ProductShopContext dbContext = new ProductShopContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            // Query 1. Import UsersDto
            //string xmlFileText = ReadXmlFile("users.xml");
            //string result = ImportUsers(dbContext, xmlFileText);

            //2.Import Products
            //xmlFileText = ReadXmlFile("products.xml");
            //result = ImportProducts(dbContext, xmlFileText);

            //Query 3. Import Categories 
            //xmlFileText = ReadXmlFile("categories.xml");
            //result = ImportCategories(dbContext, xmlFileText);

            //Query 4. Import Categories and Products
            //xmlFileText = ReadXmlFile("categories-products.xml");
            //result = ImportCategoryProducts(dbContext, xmlFileText);

            //Query 5.Export Products In Range
            //string result = GetProductsInRange(dbContext);
            //WriteXmlFile("products-in-range.xml", result);

            //Query 6.Export Sold Products
            //result = GetSoldProducts(dbContext);
            //WriteXmlFile("users-sold-products.xml", result);

            //Query 7.Export Categories By Products Count
            //string result = GetCategoriesByProductsCount(dbContext);
            //WriteXmlFile("categories-by-products.xml", result);

            //Query 8. Export UsersDto and Products
            string result = GetUsersWithProducts(dbContext);
            WriteXmlFile("users-and-products.xml", result);
            Console.WriteLine(result);
        }

        // 2.	Import Data
        // Query 1. Import UsersDto
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ICollection<User> usersToImport = new List<User>();

            ImportUsersDto[]? importUserDtos = XmlHelper
                .Deserialize<ImportUsersDto[]>(inputXml, "UsersDto");

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
                    ;

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

        //3.   Export Data
        //Query 5. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            ExportProductsInRangeDto[] productsInRangeQuery = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName

                })
                .ToArray();

            string xmlResult = XmlHelper.Serialize(productsInRangeQuery, "Products");
            return xmlResult;
        }

        //Query 6. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserDto[] soldProductsQuery = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(sp => new ExportSoldProductsDto()
                        {
                            Name = sp.Name,
                            Price = sp.Price,

                        }).ToArray()
                })
                .ToArray();

            string xmlResult = XmlHelper.Serialize(soldProductsQuery, "UsersDto");
            return xmlResult;
        }

        //Query 7. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDto[] soldCategoriesQuery = context.Categories
                .Select(c => new ExportCategoriesByProductsCountDto
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)

                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            string xmlResult = XmlHelper.Serialize(soldCategoriesQuery, "Categories");

            return xmlResult;
        }

        //Query 8. Export UsersDto and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            ExportGetUsersWithProductsDto rootDto = new ExportGetUsersWithProductsDto()
            {
                Count = context.Users
                    .Include(u => u.ProductsSold)
                    .AsNoTracking()
                    .Count(u => u.ProductsSold.Any()),
                UsersDto = context.Users
                    .Include(u => u.ProductsSold)
                    .AsNoTracking()
                    .Where(u => u.ProductsSold.Any())
                    .Select(u => new ExportUsersDto()
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProductsInfo = new ExportSoldProductsInfoDto()
                        {
                            Count = u.ProductsSold.Count,
                            Products = u.ProductsSold
                                .OrderByDescending(p => p.Price)
                                .Select(p => new ExportProductsInfoDto()
                                {
                                    Name = p.Name,
                                    Price = p.Price.ToString("F2")
                                })
                                .ToArray()

                        }

                    })
                    .OrderByDescending(u => u.SoldProductsInfo.Count)
                    .Take(10)
                    .ToArray(),

            };

            string xmlResult = XmlHelper.Serialize(rootDto, "Users");

            return xmlResult;
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

            nullableInt = outValue;
            return true;
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }

        private static string ReadXmlFile(string fileName)
        {
            string xmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string xmlFileText = File.ReadAllText(xmlFilePath + fileName);

            return xmlFileText;
        }

        private static void WriteXmlFile(string fileName, string xmlContent)
        {
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            File.WriteAllText(outputFilePath + fileName, xmlContent, Encoding.Unicode);

        }
    }
}