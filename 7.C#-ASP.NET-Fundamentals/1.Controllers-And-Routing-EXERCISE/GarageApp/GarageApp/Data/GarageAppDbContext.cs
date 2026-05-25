using GarageApp.DbModels;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Data;

public class GarageAppDbContext : DbContext
{
    public GarageAppDbContext(DbContextOptions<GarageAppDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public virtual DbSet<Car> Cars { get; set; } = null!;

    public virtual DbSet<Garage> Garages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageAppDbContext).Assembly);
    }
}

//====================================================================================================
// 1.OnModelCreating какво правихме Тук.
// 2.С Fluent API може да конфигурираме връзките между таблиците, да задаваме ограничения,
//   да дефинираме ключове и други аспекти на модела. Това е особено полезно,
//   когато искаме да настроим поведението на базата данни по специфичен начин,
//   който не може да бъде постигнат само с Data Annotations.

// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     base.OnModelCreating(modelBuilder);
//
// }
//====================================================================================================
// 1.OnConfiguring също не ми трябва, защото когато DbContext се използва през
//   Dependency Injection Container в ASP.NET Core приложения,
//   то той се конфигурира през DbContextOptions, които се подават в конструктора.
// 2.Това е стандартният начин за конфигуриране на DbContext в ASP.NET Core приложения.
// 3.Ако искахме да конфигурираме контекста директно тук, можехме да го направим в OnConfiguring метода,
//   но това не е най-добрият подход за ASP.NET Core приложения,
//   тъй като обикновено използваме Dependency Injection за конфигуриране на контекста.

// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     base.OnConfiguring(optionsBuilder);
// }
//====================================================================================================