using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string jsonFileName = "categories-products.json";
            string jsonFileText = File.ReadAllText(jsonFilePath + jsonFileName);

            // Query 01 // string result = ImportUsers(context, jsonFileText);
            // Query 02 // string result = ImportProducts(context, jsonFileText);
            // Query 03 // string result = ImportCategories(context, jsonFileText);
            // Query 04 // string result = ImportCategoryProducts(context, jsonFileText);
            // Query 05 // string result = GetProductsInRange(context);
            // Query 06 // string result = GetSoldProducts(context);
            // Query 07 // string result = GetCategoriesByProductsCount(context);

            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);

        }

        //  1.	Import Data

        //  Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ICollection<User> usersToImport = new List<User>();

            IEnumerable<User>? usersDtos = JsonConvert
                .DeserializeObject<IEnumerable<User>>(inputJson);

            if (usersDtos != null)
            {
                foreach (User userDto in usersDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userDto.Age
                    };
                    usersToImport.Add(user);
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {usersToImport.Count}";
        }

        //Query 2. Import Products

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ICollection<Product> productsToImport = new List<Product>();

            IEnumerable<Product>? productsDtos = JsonConvert
                .DeserializeObject<IEnumerable<Product>>(inputJson);

            if (productsDtos != null)
            {
                foreach (Product productDto in productsDtos)
                {
                    if (!IsValid(productDto))
                    {
                        continue;
                    }

                    Product newProduct = new Product()
                    {
                        Name = productDto.Name,
                        Price = productDto.Price,
                        SellerId = productDto.SellerId,
                        BuyerId = productDto.BuyerId
                    };

                    productsToImport.Add(newProduct);
                }
                context.Products.AddRange(productsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {productsToImport.Count}";
        }

        // Query 3. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<Category> categoriesToImport = new List<Category>();

            IEnumerable<ImportCategoriesDto>? categoriesDtos =
                JsonConvert.DeserializeObject<ImportCategoriesDto[]>(inputJson);

            if (categoriesDtos != null)
            {
                foreach (ImportCategoriesDto categoryDto in categoriesDtos)
                {
                    if (!IsValid(categoryDto))
                    {
                        continue;
                    }
                    Category newCategory = new Category()
                    {
                        Name = categoryDto.Name
                    };

                    categoriesToImport.Add(newCategory);
                }

                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesToImport.Count}";
        }

        // Query 4. Import Categories and Products

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ICollection<CategoryProduct> categoryProductsToImport = new List<CategoryProduct>();

            IEnumerable<ImportCategorysProductsDto>? categoryProductsDtos = JsonConvert.
                DeserializeObject<IEnumerable<ImportCategorysProductsDto>>(inputJson);

            if (categoryProductsDtos != null)
            {
                foreach (ImportCategorysProductsDto categoryProductsDto in categoryProductsDtos)
                {
                    if (!IsValid(categoryProductsDto))
                    {
                        continue;
                    }

                    if (!context.Categories.Any(c => c.Id == categoryProductsDto.CategoryId) ||
                        !context.Products.Any(p => p.Id == categoryProductsDto.ProductId))
                    {
                        continue;
                    }

                    CategoryProduct newCategoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductsDto.CategoryId,
                        ProductId = categoryProductsDto.ProductId
                    };

                    categoryProductsToImport.Add(newCategoryProduct);
                }

                context.CategoriesProducts.AddRange(categoryProductsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoryProductsToImport.Count}";
        }

        // 2.	Export Data

        //5. Export Products in Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(products, Formatting.Indented);
            return jsonResult;
        }

        //Query 6. Export Sold Products

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProductsQuery = context.Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(pr => new
                        {
                            name = pr.Name,
                            price = pr.Price,
                            buyerFirstName = pr.Buyer.FirstName,
                            buyerLastName = pr.Buyer.LastName

                        })

                })
                .ToList();

            string result = JsonConvert.SerializeObject(soldProductsQuery, Formatting.Indented);

            return result;

        }

        //Query 7. Export Categories by Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesQuery = context
                .Categories
                .AsNoTracking()
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count,
                    averagePrice = c.CategoriesProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("F2"),

                })
                .ToList();

            string result = JsonConvert.SerializeObject(categoriesQuery, Formatting.Indented);
            return result;
            ;
        }

        //Query 8. Export Users and Products
            public static string GetUsersWithProducts(ProductShopContext context)
            {
                var users = context.Users
                    .AsNoTracking()
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Count(p => p.BuyerId != null),
                            products = u.ProductsSold
                                .Where(p => p.BuyerId != null)
                                .Select(p => new
                                {
                                    name = p.Name,
                                    price = p.Price
                                })
                                .ToArray()
                        }
                    })
                    .OrderByDescending(u => u.soldProducts.count)
                    .ToArray();

                var usersWithProductsQuery = new
                {
                    usersCount = users.Length,
                    users = users
                };

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                };

                string result = JsonConvert.SerializeObject(usersWithProductsQuery, settings);

                return result;
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