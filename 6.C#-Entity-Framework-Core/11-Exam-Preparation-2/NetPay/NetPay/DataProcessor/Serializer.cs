using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.Data.Utilities;
using NetPay.DataProcessor.ExportDtos;
using Newtonsoft.Json;



namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {


            ExportHouseholdsWhichHaveExpensesToPayDto[] query = context
                .Households
                .AsNoTracking()
                .Include(h => h.Expenses)
                .ThenInclude(h => h.Service)
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .OrderBy(h => h.ContactPerson)
                .ToArray()
                .Select(h => new ExportHouseholdsWhichHaveExpensesToPayDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid)
                        .Select(e => new ExpensesToPayDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2"),
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName

                        })
                        .OrderBy(e => e.PaymentDate)
                        .ThenBy(e => e.Amount)
                        .ToArray()

                })
                .ToArray();

            string xmlResult = XmlHelper
                .Serialize(query, "Households");
            return xmlResult;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var exportAllServicesWithSuppliersQuery = context.Services
                .AsNoTracking()
                .Include(s => s.SuppliersServices)
                .ThenInclude(s => s.Supplier)
                .OrderBy(s => s.ServiceName)
                .Select(s => new
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => ss.Supplier)
                        .OrderBy(sup => sup.SupplierName)
                        .Select(sup => new
                        {
                            sup.SupplierName,

                        })
                        .ToArray()

                })
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(exportAllServicesWithSuppliersQuery, Formatting.Indented);

            return jsonResult;
        }
    }
}
