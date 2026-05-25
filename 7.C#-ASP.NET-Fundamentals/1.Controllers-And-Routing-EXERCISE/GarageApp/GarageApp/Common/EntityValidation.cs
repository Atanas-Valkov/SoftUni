namespace GarageApp.Common;

public class EntityValidation
{
    public static class Car
    {
        public const int MinMakeLength = 2;
        public const int MaxMakeLength = 60;

        public const int MinModelLength = 1;
        public const int MaxModelLength = 60;
    }

    public static class Garage
    {
        public const int MinNameLength = 1;
        public const int MaxNameLength = 70;

        public const int MinLocationLength = 2;
        public const int MaxLocationLength = 200;


    }
}