using GarageApp.Common;
using System;
using GarageApp.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration;

public class GarageEntityConfiguration : IEntityTypeConfiguration<Garage>
{
    private readonly Garage[] Garages =
    {
        new Garage
        {
            Id = Guid.Parse("fd048be6-8b26-4e87-be6a-52eea8410577"),
            Name = "Central Garage",
            Location = "Main Street 1"
        },
        new Garage
        {
            Id = Guid.Parse("6eb61664-d5f8-4030-9a8a-b41a1553b975"),
            Name = "Westside Garage",
            Location = "West Avenue 24"
        },
        new Garage
        {
            Id = Guid.Parse("e24b1d1d-8eea-4030-a740-d508e2d93252"),
            Name = "Airport Garage",
            Location = "Airport Road 7"
        }

    };

    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.HasData(Garages);
    }
}