using System.ComponentModel.DataAnnotations;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;


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
            string jasonFileName = "cars.json";
            string jsonFileText = File.ReadAllText(jsonFilePath + jasonFileName);

            //Query 9 // string result = ImportSuppliers(context, jsonFileText);
            //Query 10 // string result = ImportParts(context, jsonFileText);

            string result = ImportCars(context, jsonFileText);


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



        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}