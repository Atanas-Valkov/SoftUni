using CarDealer.Data;
using CarDealer.DTOs.Export.ExportCarsFromMakeBmwDto;
using CarDealer.DTOs.Export.ExportCarsWithDistanceDto;
using CarDealer.DTOs.Export.ExportGetCarsWithTheirListOfPartsDto;
using CarDealer.DTOs.Export.ExportLocalSuppliersDto;
using CarDealer.DTOs.Export.ExportTotalSalesByCustomerDto;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Models.Utilites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {

            using CarDealerContext dbContext = new CarDealerContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            //Query 9.Import Suppliers
            //string xmlFileText = ReadXmlFile("suppliers.xml");
            //string result = ImportSuppliers(dbContext, xmlFileText);

            //Query 10.Import Parts
            //string xmlFileText = ReadXmlFile("parts.xml");
            //string result = ImportParts(dbContext, xmlFileText);

            //Query 11. Import Cars
            //string xmlFileText = ReadXmlFile("cars.xml");
            //string result = ImportCars(dbContext, xmlFileText);

            //Query 12.Import Customers
            //string xmlFileText = ReadXmlFile("customers.xml");
            //string result = ImportCustomers(dbContext, xmlFileText);

            //Query 13.Import Sales
            //string xmlFileText = ReadXmlFile("sales.xml");
            //string result = ImportSales(dbContext, xmlFileText);

            //Query 14. Export Cars With Distance
            //string result = GetCarsWithDistance(dbContext);
            //WriteXmlFile("cars.xml", result);

            //Query 15. Export Cars from Make BMW
            //string result = GetCarsFromMakeBmw(dbContext);
            //WriteXmlFile("bmw-cars.xml",result);

            //Query 16. Export Local Suppliers
            //string result = GetLocalSuppliers(dbContext);
            //WriteXmlFile("local-suppliers.xml", result);

            //Query 17.Export Cars with Their List of Parts
            //string result = GetCarsWithTheirListOfParts(dbContext);
            //WriteXmlFile("cars-and-parts.xml", result);

            //Query 18. Export Total Sales by Customer
            string result = GetTotalSalesByCustomer(dbContext);
            WriteXmlFile("customers-total-sales.xml", result);

            Console.WriteLine(result);


        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            ImportSuppliersDto[]? importSuppliersDtos = XmlHelper
                .Deserialize<ImportSuppliersDto[]>(inputXml, "Suppliers");

            if (importSuppliersDtos != null)
            {
                foreach (ImportSuppliersDto importSuppliersDto in importSuppliersDtos)
                {
                    if (!IsValid(importSuppliersDto))
                    {
                        continue;
                    }

                    bool isImporterValidation = bool.TryParse(importSuppliersDto.IsImporter, out bool resultValidation);

                    Supplier newSupplier = new Supplier()
                    {
                        Name = importSuppliersDto.Name,
                        IsImporter = resultValidation
                    };

                    suppliersToImport.Add(newSupplier);
                }

                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {suppliersToImport.Count}"; ;
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IEnumerable<int> existingSuppliersIds = context.Suppliers
                .AsNoTracking()
                .Select(s => s.Id)
                .ToList();

            ICollection<Part> partsToImport = new List<Part>();

            ImportPartsDtos[]? importPartsDtos = XmlHelper
                .Deserialize<ImportPartsDtos[]>(inputXml, "Parts");

            if (importPartsDtos != null)
            {
                foreach (ImportPartsDtos partsDto in importPartsDtos)
                {
                    if (!IsValid(partsDto))
                    {
                        continue;
                    }

                    bool isValidPrice = decimal.TryParse(partsDto.Price, out decimal priceResult);
                    bool isValidQuantity = int.TryParse(partsDto.Quantity, out int quantityResult);
                    bool isValidSupplierId = int.TryParse(partsDto.SupplierId, out int supplierIdResult);

                    if (!existingSuppliersIds.Contains(supplierIdResult))
                    {
                        continue;
                    }

                    if (!isValidPrice || !isValidQuantity)
                    {
                        continue;
                    }

                    Part newPart = new Part()
                    {
                        Name = partsDto.Name,
                        Price = priceResult,
                        Quantity = quantityResult,
                        SupplierId = supplierIdResult
                    };

                    partsToImport.Add(newPart);
                }

                context.Parts.AddRange(partsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {partsToImport.Count}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IEnumerable<int> existingPartsId = context.Parts
                .Select(p => p.Id)
                .ToHashSet();


            ICollection<Car> carsToImport = new List<Car>();
            ICollection<PartCar> partsToImports = new List<PartCar>();

            ImportCarsDto[]? carsDto = XmlHelper
                .Deserialize<ImportCarsDto[]>(inputXml, "Cars");

            if (carsDto != null)
            {
                foreach (ImportCarsDto carDto in carsDto)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isValidTraveledDistance = long.TryParse(carDto.TraveledDistance, out long traveledDistanceResult);


                    if (!isValidTraveledDistance)
                    {
                        continue;
                    }

                    Car newCar = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistanceResult
                    };

                    carsToImport.Add(newCar);

                    foreach (PartDto partDto in carDto.Parts.DistinctBy(p => p.PartId))
                    {
                        if (!existingPartsId.Contains(partDto.PartId))
                        {
                            continue;
                        }

                        PartCar newPartCar = new PartCar()
                        {
                            PartId = partDto.PartId,
                            Car = newCar
                        };
                        partsToImports.Add(newPartCar);
                    }
                }

                context.Cars.AddRange(carsToImport);
                context.PartsCars.AddRange(partsToImports);

                context.SaveChanges();
            }

            return $"Successfully imported {carsToImport.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ICollection<Customer> customersToImport = new List<Customer>();

            ImportCustomersDto[]? customersDto = XmlHelper
                .Deserialize<ImportCustomersDto[]>(inputXml, "Customers");

            if (customersDto != null)
            {
                foreach (ImportCustomersDto customerDto in customersDto)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isValidBirthDate = DateTime.TryParseExact(customerDto.BirthDate,
                        "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime birthDateResult);

                    bool isValidIsYoungDriver = bool.TryParse(customerDto.IsYoungDriver,
                        out bool isYoungDriverResult);

                    if (!isValidBirthDate || !isValidIsYoungDriver)
                    {
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDateResult,
                        IsYoungDriver = isYoungDriverResult
                    };

                    customersToImport.Add(newCustomer);
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {customersToImport.Count}";
        }

        //Query 13.Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            HashSet<int> existCarId = context.Cars
                .Select(c => c.Id)
                .ToHashSet();
            HashSet<int> existCustomerId = context.Customers
                .Select(c => c.Id)
                .ToHashSet();

            ICollection<Sale> salesToImport = new List<Sale>();

            ImportSalesDto[]? salesDtos = XmlHelper
                .Deserialize<ImportSalesDto[]>(inputXml, "Sales");

            if (salesDtos != null)
            {
                foreach (ImportSalesDto saleDto in salesDtos)
                {

                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    bool isValidDiscount = decimal.TryParse(saleDto.Discount, NumberStyles.Number,
                        CultureInfo.InvariantCulture, out decimal discountResult);
                    bool isValidCarId = int.TryParse(saleDto.CarId, out int carIdResult);
                    bool isValidCustomerId = int.TryParse(saleDto.CustomerId, out int customerIdResult);



                    if (!isValidDiscount || !isValidCarId || !isValidCustomerId)
                    {
                        continue;
                    }

                    if (!existCarId.Contains(carIdResult))
                    {
                        continue;
                    }

                    Sale newSale = new Sale()
                    {
                        Discount = discountResult,
                        CarId = carIdResult,
                        CustomerId = customerIdResult
                    };

                    salesToImport.Add(newSale);
                }

                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {salesToImport.Count}";
        }

        //Query 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsWithDistanceDto[] carsWithDistanceQuery = context.Cars
                .AsNoTracking()
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Select(c => new ExportCarsWithDistanceDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            string result = XmlHelper.Serialize(carsWithDistanceQuery, "cars");
            return result;
        }

        //Query 15. Export Cars from Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportSingleCarFromMakeBmwDto[] carsFromMakeBmwQuery = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportSingleCarFromMakeBmwDto()
                {
                    Id = c.Id.ToString(),
                    Model = c.Model.ToString(),
                    TravelDistance = c.TraveledDistance.ToString()

                })
                .Take(10)
                .ToArray();

            string xmlResult = XmlHelper.Serialize(carsFromMakeBmwQuery, "cars");
            return xmlResult;
        }

        //Query 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            LocalSuppliersDto[] localSuppliersQuery = context.Suppliers
                .AsNoTracking()
                .Where(c => !c.IsImporter)
                .Select(s => new LocalSuppliersDto()
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count()

                })
                .ToArray();

            string result = XmlHelper.Serialize(localSuppliersQuery, "suppliers");

            return result;
        }

        //Query 17. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            CarsWithListOfPartsDto[] carsWithListOfPartsQuery = context.Cars
                .AsNoTracking()
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .Select(c => new CarsWithListOfPartsDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    Parts = c.PartsCars
                        .Select(pc => new PartsDto()
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(pc => pc.Price)
                        .ToArray()
                })
                .ToArray();

            string result = XmlHelper.Serialize(carsWithListOfPartsQuery, "cars");
            return result;
        }

        //Query 18. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomerQuery = context.Customers
                .AsNoTracking()
                .Where(c => c.Sales.Any())
                .Select(c => new ExportCustomerDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                        
                })
                .ToArray();

            string result = XmlHelper.Serialize(totalSalesByCustomerQuery, "customers");

            return result;
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