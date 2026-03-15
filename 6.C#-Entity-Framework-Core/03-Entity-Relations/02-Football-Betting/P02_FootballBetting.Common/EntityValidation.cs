namespace P02_FootballBetting.Common
{
    public static class EntityValidation
    {
        public static class Team
        {
            public const int NameMaxLength = 100;

            public const int LogoUrlLength = 2048;

            public const int InitialsLength = 5;

        }

        public static class Color
        {
            public const int ColorMaxLength = 20;

        }

        public static class Town
        {
            public const int NameMaxLength = 20;
        }

        public static class Country
        {
            public const int NameMaxLength = 56;
        }

        public static class Player
        {
            public const int NameMaxLength = 100;

            public const int MaxSquadNumber = 100;

        }

        public static class Position
        {
            public const int NameMaxLength = 30;
        }

        public static class Game
        {
            public const int MaxResultLength = 7;

        }


        public static class User
        {
            public const int UsernameMaxLength = 50;
            public const int NameMaxLength = 100;
            public const int PasswordMaxLength = 256;
            public const int EmailMaxLength = 256;
        }

    }

}