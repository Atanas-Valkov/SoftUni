namespace P01_StudentSystem.Common
{
    public class EntityValidation
    {
        public class Student
        {
                public const int NameMaxLength = 100;
                public const int PhoneNumberMaxLength = 20;
        }

        public class Course
        {
            public const int NameMaxLength = 80;
            public const int DescriptionMaxLength = 200;
        }

        public class Resource
        {
            public const int NameMaxLength = 90;
            public const int UrlMaxLength = 200;
        }

        public class Homework
        {
            public const int ContentMaxLength = 250;
        }

    }
}