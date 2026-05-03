using Microsoft.EntityFrameworkCore;

using NetPay.Data.Utilities;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            ExportGuidesWithSpanishLanguageXmlDto[] exportGuidesWithSpanishQuery = context.Guides
                .AsNoTracking()
                .Include(g => g.TourPackagesGuides)
                .ThenInclude(g => g.TourPackage)
                .Where(g => g.Language == Language.Spanish)
                .OrderByDescending(g => g.TourPackagesGuides.Count) // !??!?!
                .OrderBy(g => g.FullName)
                .Select(g => new ExportGuidesWithSpanishLanguageXmlDto()
                {
                    FullName = g.FullName,
                    TourPackage = g.TourPackagesGuides
                        .OrderByDescending(tp => tp.TourPackage.Price)
                        .ThenBy(tp => tp.TourPackage.PackageName)
                        .Select(tp => new TourPackages()
                        {
                            Name = tp.TourPackage.PackageName,
                            Description = tp.TourPackage.Description,
                            Price = tp.TourPackage.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray();

            string xmlResult = XmlHelper.Serialize(exportGuidesWithSpanishQuery, "Guides");


            return xmlResult;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var exportCustomersQuery = context.Customers
                .AsNoTracking()
                .Include(c => c.Bookings)
                .ThenInclude(b => b.TourPackage)
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .OrderByDescending(c => c.Bookings.Count(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .ThenBy(c => c.FullName)
                .Select(c => new 
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new 
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()
                })
                .ToArray();
            


            string jsonResult = JsonConvert.SerializeObject
                (
                    exportCustomersQuery,
                    Formatting.Indented
                );

            return jsonResult;
        }
    }
}
