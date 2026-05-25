using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GarageApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialMigrationCardAndGarages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), "West Avenue 24", "Westside Garage" },
                    { new Guid("e24b1d1d-8eea-4030-a740-d508e2d93252"), "Airport Road 7", "Airport Garage" },
                    { new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), "Main Street 1", "Central Garage" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "GarageId", "IsAvailable", "Make", "Model", "TypeCar", "Year" },
                values: new object[,]
                {
                    { 1, new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), true, "Toyota", "Corolla", 1, 2018 },
                    { 2, new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), false, "Honda", "Civic", 1, 2020 },
                    { 3, new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), true, "Ford", "Focus", 2, 2016 },
                    { 4, new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), true, "BMW", "X5", 3, 2021 },
                    { 5, new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), false, "Audi", "A4", 1, 2019 },
                    { 6, new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), true, "Volkswagen", "Golf", 2, 2017 },
                    { 7, new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"), true, "Mercedes", "C-Class", 1, 2022 },
                    { 8, new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), false, "Nissan", "Leaf", 99, 2020 },
                    { 9, new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), true, "Mazda", "3", 2, 2015 },
                    { 10, new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"), true, "Jeep", "Wrangler", 18, 2014 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("e24b1d1d-8eea-4030-a740-d508e2d93252"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("6eb61664-d5f8-4030-9a8a-b41a1553b975"));

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: new Guid("fd048be6-8b26-4e87-be6a-52eea8410577"));
        }
    }
}
