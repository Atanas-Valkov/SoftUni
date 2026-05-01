using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Utilities;
using NetPay.DataProcessor.ImportDtos;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using NetPay.Data.Models.Enums;
using Newtonsoft.Json;

using static System.Net.Mime.MediaTypeNames;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Household> householdsToImport = new List<Household>();

            ImportHouseholdsXmlDto[]? importHouseholdsXmlDto = XmlHelper
                .Deserialize<ImportHouseholdsXmlDto[]>(xmlString, "Households");

            if (importHouseholdsXmlDto != null)
            {
                foreach (ImportHouseholdsXmlDto householdsXmlDto in importHouseholdsXmlDto)
                {
                    if (!IsValid(householdsXmlDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicationCheck = context.Households
                        .Any(h => h.ContactPerson == householdsXmlDto.ContactPerson ||
                                           h.PhoneNumber == householdsXmlDto.PhoneNumber ||
                                           (h.Email != null && h.Email == householdsXmlDto.Email));

                    bool isExistInHouseholdsToImport = householdsToImport.
                        Any(h => h.ContactPerson == householdsXmlDto.ContactPerson ||
                        h.PhoneNumber == householdsXmlDto.PhoneNumber ||
                        (h.Email != null && h.Email == householdsXmlDto.Email));

                    if (isDuplicationCheck || isExistInHouseholdsToImport)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household newHousehold = new Household()
                    {
                        ContactPerson = householdsXmlDto.ContactPerson,
                        Email = householdsXmlDto.Email,
                        PhoneNumber = householdsXmlDto.PhoneNumber,
                    };

                    householdsToImport.Add(newHousehold);
                    sb.AppendLine(String.Format(SuccessfullyImportedHousehold, householdsXmlDto.ContactPerson));
                }

                ;
                context.Households.AddRange(householdsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
           StringBuilder sb = new StringBuilder();

           ICollection<Expense> expensesToImport = new List<Expense>();

           IEnumerable<ImportExpensesJsonDto>? importExpensesJsonDto = JsonConvert
               .DeserializeObject<ImportExpensesJsonDto[]>(jsonString);

           if (importExpensesJsonDto != null)
           {
               foreach (ImportExpensesJsonDto expenseJsonDto in importExpensesJsonDto)
               {
                   if (!IsValid(expenseJsonDto))
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   bool isHouseholdIdValid = context.Households
                       .Any(h => h.Id == expenseJsonDto.HouseholdId!.Value);

                   bool isServiceIdValid = context.Services
                       .Any(s => s.Id == expenseJsonDto.ServiceId!.Value);

                   if (!isHouseholdIdValid || !isServiceIdValid)
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   bool isDueDateValid = DateTime
                       .TryParseExact(expenseJsonDto.DueDate, 
                           "yyyy-MM-dd", 
                           CultureInfo.InvariantCulture,
                           DateTimeStyles.None,
                           out DateTime dueDateResult);

                   bool isPaymentStatusValid = Enum.TryParse<PaymentStatus>
                       (expenseJsonDto.PaymentStatus, out PaymentStatus paymentStatusResult);

                   if (!isDueDateValid || !isPaymentStatusValid)
                   {
                       sb.AppendLine(ErrorMessage);
                       continue;
                   }

                   Expense newExpense = new Expense()
                   {
                       ExpenseName = expenseJsonDto.ExpenseName,
                       Amount = expenseJsonDto.Amount!.Value,
                       DueDate = dueDateResult,
                       PaymentStatus = paymentStatusResult,
                       HouseholdId = expenseJsonDto.HouseholdId!.Value,
                       ServiceId = expenseJsonDto.ServiceId!.Value
                   };

                   expensesToImport.Add(newExpense);
                   sb.AppendLine(string.Format(SuccessfullyImportedExpense, expenseJsonDto.ExpenseName,
                       expenseJsonDto.Amount!.Value.ToString("F2")));
               }

               context.Expenses.AddRange(expensesToImport);
               context.SaveChanges();
           }

           return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
