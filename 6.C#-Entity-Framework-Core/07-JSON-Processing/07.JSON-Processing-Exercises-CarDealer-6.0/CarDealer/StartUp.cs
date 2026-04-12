using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();
            // context.Database.EnsureDeleted();
            // context.Database.EnsureCreated();
            // Console.WriteLine(Directory.GetCurrentDirectory());

            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string jasonFileName = "sales.json";
            string jsonFileText = File.ReadAllText(jsonFilePath + jasonFileName);

            // Query 9  // string result = ImportSuppliers(context, jsonFileText);
            // Query 10 // string result = ImportParts(context, jsonFileText);
            // Query 11 // string result = ImportCars(context, jsonFileText);
            // Query 12 // string result = ImportCustomers(context, jsonFileText);
            // Query 13 // string result = ImportSales(context, jsonFileText);
            // Query 14 // string result = GetOrderedCustomers(context);
            // Query 15 // string result = GetCarsFromMakeToyota(context);
            // Query 16 // string result = GetLocalSuppliers(context);
            // Query 17 //string result = GetCarsWithTheirListOfParts(context);
            string result = GetTotalSalesByCustomer(context);
            // Query 19 // string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        // Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ICollection<Supplier> supplierToAdd = new List<Supplier>();



            IEnumerable<ImportSupplierDto>? supplierDtos = JsonConvert
                .DeserializeObject<ImportSupplierDto[]>(inputJson);

            if (supplierDtos != null)
            {
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isImporterValidation =
                        bool.TryParse(supplierDto.IsImporter, out bool isImporter);

                    if (!isImporterValidation)
                    {
                        continue;
                    }

                    Supplier newSupplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter
                    };
                    supplierToAdd.Add(newSupplier);
                }

                context.Suppliers.AddRange(supplierToAdd);
                context.SaveChanges();
            }

            return $"Successfully imported {supplierToAdd.Count}.";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ICollection<Part> partsToAdd = new List<Part>();

            ICollection<int> existingSuppliers = context.Suppliers
                .OrderBy(s => s.Id)
                .Select(s => s.Id)
                .ToList();

            IEnumerable<ImportPartsDto>? partsDtos = JsonConvert
                .DeserializeObject<ImportPartsDto[]>(inputJson);

            if (partsDtos != null)
            {
                foreach (ImportPartsDto partsDto in partsDtos)
                {
                    if (!IsValid(partsDto))
                    {
                        continue;
                    }

                    bool supplierIdValidation = int.TryParse(partsDto.SupplierId, out int supplierId);

                    if ((!supplierIdValidation) || (!existingSuppliers.Contains(supplierId)))
                    {
                        continue;
                    }

                    Part newPart = new Part()
                    {
                        Name = partsDto.Name,
                        Price = partsDto.Price,
                        Quantity = partsDto.Quantity,
                        SupplierId = supplierId
                    };
                    partsToAdd.Add(newPart);
                }

                context.Parts.AddRange(partsToAdd);
                context.SaveChanges();
            }

            return $"Successfully imported {partsToAdd.Count}.";
        }

        // Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ICollection<Car> carsToImport = new List<Car>();
            ICollection<PartCar> partsCarsToImport = new List<PartCar>();

            IEnumerable<ImportCarsDto>? carsDtos = JsonConvert
                .DeserializeObject<ImportCarsDto[]>(inputJson);

            if (carsDtos != null)
            {

                foreach (ImportCarsDto carDto in carsDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    Car newCar = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    carsToImport.Add(newCar);

                    foreach (int partsId in carDto.PartsIds.Distinct())
                    {
                        if (!context.Parts.Any(p => p.Id == partsId))
                        {
                            continue;
                        }

                        PartCar newPartCar = new PartCar()
                        {
                            PartId = partsId,
                            Car = newCar
                        };
                        partsCarsToImport.Add(newPartCar);
                    }
                }

                context.Cars.AddRange(carsToImport);
                context.PartsCars.AddRange(partsCarsToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {carsToImport.Count}.";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ICollection<Customer> customersToImport = new List<Customer>();

            IEnumerable<ImportCustomersDto>? customerDtos =
                JsonConvert.DeserializeObject<ImportCustomersDto[]>(inputJson);

            if (customerDtos != null)
            {
                foreach (ImportCustomersDto customerDto in customerDtos)
                {

                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool birthDateValidation = DateTime.TryParseExact(customerDto.BirthDate,
                        "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime birthDate);

                    bool isYoungDriverValidation = bool.TryParse(customerDto.IsYoungDriver,
                        out bool isYoungDriver);

                    if (!birthDateValidation || !isYoungDriverValidation)
                    {
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToImport.Add(newCustomer);
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {customersToImport.Count}.";
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }


        //public static string ImportSales(CarDealerContext context, string inputJson)
        //{
        //    ICollection<Sale> salesToImport = new List<Sale>();

        //    IEnumerable<ImportSalesDto>? salesDtos = JsonConvert
        //        .DeserializeObject<ImportSalesDto[]>(inputJson);

        //    if (salesDtos != null)
        //    {
        //        foreach (ImportSalesDto salesDto in salesDtos)
        //        {
        //            bool isCarExisting = context.Cars.Any(c => c.Id == salesDto.CarId);

        //            if (!isCarExisting)
        //            {
        //                continue;
        //            }

        //            bool isCustomerIdExisting = context
        //                .Customers
        //                .Any(cu => cu.Id == salesDto.CustomerId);

        //            if (!isCustomerIdExisting)
        //            {
        //                continue;
        //            }

        //            Sale newSale = new Sale()
        //            {
        //                CarId = salesDto.CarId,
        //                CustomerId = salesDto.CustomerId,
        //                Discount = salesDto.Discount
        //            };

        //            salesToImport.Add(newSale);
        //        }

        //        context.Sales.AddRange(salesToImport);
        //        context.SaveChanges();
        //    }

        //    return $"Successfully imported {salesToImport.Count}.";
        //}

        //3.	Export Data

        // Query 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {

            var orderedCustomersQuery = context.Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var orderedCustomersForExport = orderedCustomersQuery
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(orderedCustomersForExport, Formatting.Indented);

            return jsonResult;
        }

        // Query 15. Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCarsQuery = context.Cars
                .AsNoTracking()
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(toyotaCarsQuery, Formatting.Indented);

            return jsonResult;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliersQuery = context.Suppliers
                .AsNoTracking()
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(localSuppliersQuery, Formatting.Indented);
            return jsonResult;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsTheirPartsQuery = context.Cars
                .AsNoTracking()
                .Select(c => new
                {
                    Car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Part = new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        }
                    })

                })
                .ToList();

            var carsTheirPartsToExport = carsTheirPartsQuery
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Car.Make,
                        Model = c.Car.Model,
                        TraveledDistance = c.Car.TraveledDistance
                    },

                    parts = c.parts
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2")
                        })


                })
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(carsTheirPartsToExport, Formatting.Indented);

            return jsonResult;
        }

        //Query 18. Export Total Sales by Customer

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersTotalSalesQuery = context.Customers
                .AsNoTracking()
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.SelectMany(c => c.Car.PartsCars
                        .Select(p => p.Part.Price)) 
                })
                .ToList();

            var customersTotalSalesToExport = customersTotalSalesQuery
                .Select(c => new
                {
                    c.fullName,
                    c.boughtCars,
                    spentMoney = c.spentMoney.Sum()
                })
                .OrderByDescending(d => d.spentMoney)
                .ThenByDescending(d => d.boughtCars)
                .ToList();

            string jsonResult = JsonConvert.SerializeObject(customersTotalSalesToExport, Formatting.Indented);

            return jsonResult;
        }



        //Query 19. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var top10Sales = context
                .Sales
                .AsNoTracking()
                .Select(s => new
                {
                    Car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),

                })
                .Take(10)
                .ToList();

            var salesExportDtos = top10Sales
                .Select(s => new
                {
                    car = s.Car,
                    customerName = s.CustomerName,
                    discount = s.Discount.ToString("F2"),
                    price = s.Price.ToString("F2"),
                    priceWithDiscount = (s.Price - (s.Price * (s.Discount / 100))).ToString("F2")
                })
                .ToList();
            string jsonResult = JsonConvert.SerializeObject(salesExportDtos, Formatting.Indented);

            return jsonResult;
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