using GarageApp.DbModels;
using GarageApp.DbModels.Enum;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration;

public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
{
    private readonly Car[] Cars =
    {
            new Car
            {
                Id = 1,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2018,
                TypeCar = TypeCar.Sedan,
                IsAvailable = true,
                GarageId = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577")
            },
            new Car
            {
                Id = 2,
                Make = "Honda",
                Model = "Civic",
                Year = 2020,
                TypeCar = TypeCar.Sedan,
                IsAvailable = false,
                GarageId = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577")
            },
            new Car
            {
                Id = 3,
                Make = "Ford",
                Model = "Focus",
                Year = 2016,
                TypeCar = TypeCar.Hatchback,
                IsAvailable = true,
                GarageId = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975")
            },
            new Car
            {
                Id = 4,
                Make = "BMW",
                Model = "X5",
                Year = 2021,
                TypeCar = TypeCar.SUV,
                IsAvailable = true,
                GarageId = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975")
            },
            new Car
            {
                Id = 5,
                Make = "Audi",
                Model = "A4",
                Year = 2019,
                TypeCar = TypeCar.Sedan,
                IsAvailable = false,
                GarageId = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975")
            },
            new Car
            {
                Id = 6,
                Make = "Volkswagen",
                Model = "Golf",
                Year = 2017,
                TypeCar = TypeCar.Hatchback,
                IsAvailable = true,
                GarageId = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975")
            },
            new Car
            {
                Id = 7,
                Make = "Mercedes",
                Model = "C-Class",
                Year = 2022,
                TypeCar = TypeCar.Sedan,
                IsAvailable = true,
                GarageId = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975")
            },
            new Car
            {
                Id = 8,
                Make = "Nissan",
                Model = "Leaf",
                Year = 2020,
                TypeCar = TypeCar.Other,
                IsAvailable = false,
                GarageId = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577")
            },
            new Car
            {
                Id = 9,
                Make = "Mazda",
                Model = "3",
                Year = 2015,
                TypeCar = TypeCar.Hatchback,
                IsAvailable = true,
                GarageId = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577")
            },
            new Car
            {
                Id = 10,
                Make = "Jeep",
                Model = "Wrangler",
                Year = 2014,
                TypeCar = TypeCar.OffRoader,
                IsAvailable = true,
                GarageId = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577")
            }
    };

    public void Configure(EntityTypeBuilder<Car> builder)
    {

        builder
            .HasData(Cars);
    }
}