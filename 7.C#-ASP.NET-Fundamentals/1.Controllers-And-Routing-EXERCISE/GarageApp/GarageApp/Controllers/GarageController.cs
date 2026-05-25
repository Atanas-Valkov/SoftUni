using System.Runtime.Serialization;
using GarageApp.Data;
using GarageApp.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers;

public class GarageController : Controller
{
    private readonly GarageAppDbContext dbContext;

    // 1. Constructor injection => НАЙ-ЧЕАТО използваният и препоръчителен начин за внедряване на
    //    зависимости в ASP.NET Core. Той осигурява ясен и лесен за разбиране начин за предоставяне на
    //    зависимостите на контролера чрез конструктора му.

    // 1.1 В този пример, когато ASP.NET Core създава инстанция на GarageController,той автоматично
    //     инжектира инстанция на GarageAppDbContext и я предоставя на конструктора.у

    // 1.2 GarageController се създава когато user изпише URL /Garage/Index
    public GarageController(GarageAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    //2. Property injection => МНОГО МАЛКО СРЕЩАН В ASP.NET Core
    // public GarageAppDbContext GarageAppDbContext { get; set; }


    // 3. Method injection   => не е толкова често срещано в ASP.NET Core, но може да се използва в
    // някои случаи, например при специфични действия или операции, които изискват достъп до
    // зависимостта само за определен метод.

    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Garage> allGarages = dbContext.Garages
            .Include(g => g.Cars)
            .AsSplitQuery()
            .AsNoTracking()
            .ToArray();

        return this.View(allGarages);
    }


    [HttpGet]
    public IActionResult Details(string? id)
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            return View("BadRequest");
        }

        bool isGuidValid = Guid.TryParse(id, out Guid guidResult);
        if (!isGuidValid)
        {
            return View("BadRequest");
        }

        Garage? garage = dbContext.Garages
            .Include(g=>g.Cars)
            .SingleOrDefault(g=> g.Id == guidResult);
        if (garage == null)
        {
            return View("BadRequest");
        }

        return View(garage);
    }
}