using NetPay.Data.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Customer> customersToImport = new List<Customer>();

            ImportCustomersDto[]? importCustomersDto = XmlHelper
                .Deserialize<ImportCustomersDto[]>(xmlString, "Customers");

            if (importCustomersDto != null)
            {
                foreach (ImportCustomersDto customersDto in importCustomersDto)
                {

                    if (!IsValid(customersDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicationCheck = context.Customers
                        .Any(c => c.FullName == customersDto.FullName ||
                                  c.PhoneNumber == customersDto.PhoneNumber ||
                                       c.Email == customersDto.Email);

                    bool isExistCustomersToImport = customersToImport.
                        Any(c => c.FullName == customersDto.FullName ||
                        c.PhoneNumber == customersDto.PhoneNumber ||
                        c.Email == customersDto.Email);

                    if (isDuplicationCheck || isExistCustomersToImport)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer newCustomer = new Customer()
                    {
                        FullName = customersDto.FullName,
                        Email = customersDto.Email,
                        PhoneNumber = customersDto.PhoneNumber,
                    };

                    customersToImport.Add(newCustomer);
                    sb.AppendLine(string.Format(SuccessfullyImportedCustomer, newCustomer.FullName));
                }

                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Booking> bookingToImport = new List<Booking>();

            ImportBookingsDto[]? bookingToImportDto = JsonConvert
                .DeserializeObject<ImportBookingsDto[]>(jsonString);

            if (bookingToImportDto != null)
            {
                foreach (ImportBookingsDto bookingsDto in bookingToImportDto)
                {

                    if (!IsValid(bookingsDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer customer = context.Customers
                        .First(c => c.FullName == bookingsDto.CustomerName);

                    TourPackage tourPackage = context.TourPackages
                        .First(tp => tp.PackageName == bookingsDto.TourPackageName);

               

                    bool isDateTimeValid = DateTime.TryParseExact
                    (
                        bookingsDto.BookingDate,
                        "yyyy-MM-dd",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime bookingDateResult
                    );


                    if (!isDateTimeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Booking newBooking = new Booking()
                    {
                        BookingDate = bookingDateResult,
                        CustomerId = customer.Id,
                        TourPackageId = tourPackage.Id
                    };

                   
                    bookingToImport.Add(newBooking);
                    sb.AppendLine(String.Format(SuccessfullyImportedBooking,
                        bookingsDto.TourPackageName,
                        bookingDateResult.ToString("yyyy-MM-dd")));
                }
                context.Bookings.AddRange(bookingToImport);
                context.SaveChanges();
            }


            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
