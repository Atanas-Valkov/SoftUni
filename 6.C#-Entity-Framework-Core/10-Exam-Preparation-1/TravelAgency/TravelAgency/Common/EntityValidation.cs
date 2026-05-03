using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Runtime.CompilerServices;
using TravelAgency.Data.Models;

namespace TravelAgency.Common;

public class EntityValidation
{ 
    public static class Customer
    {
        public const int FullNameMinLength = 4;
        public const int FullNameMaxLength = 60;

        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 50;

        
        public const int PhoneNumberMaxLength = 13;

        public const string PhoneNumberRegEx = @"^\+\d{12}$";
    }

    public static class Guide
    {
        public const int FullNameMinLength = 4;
        public const int FullNameMaxLength = 60;
    }

    public static class TourPackage
    {
        public const int PackageNameMinLength = 2;
        public const int PackageNameMaxLength = 40;

        public const int DescriptionMaxLength = 200;

        public const int PriceMinLength = 1;

    }
}