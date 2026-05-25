using GarageApp.Data;
using GarageApp.DbModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers;

public class CarsController : Controller
{
    private readonly GarageAppDbContext dbContext;

    public CarsController(GarageAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index()
    {
        IEnumerable<Car> allCars = dbContext.Cars
            .Include(c => c.Garage)
            .AsNoTracking()
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .ThenByDescending(c => c.Year)
            .ToArray();

        return View(allCars);
    }


    public IActionResult Details(int? id)
    {
        if (!id.HasValue || id < 0 )
        {
            return View("BadRequest");
        }

        Car? car = dbContext.Cars
            .Include(c => c.Garage)
            .AsNoTracking()
            .SingleOrDefault(c => c.Id == id);

        if (car == null)
        {
            return NotFound();
        }    

        return View(car);
    }

    public IActionResult Search(string? make)
    {
        IQueryable<Car> carsQuery = dbContext.Cars
            .Include(c=>c.Garage)
            .AsNoTracking()
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .ThenByDescending(c => c.Year)
            .ThenBy(c => c.TypeCar);

        if (!String.IsNullOrWhiteSpace(make) )
        {
            carsQuery = carsQuery
                .Where(c => c.Make.ToLower().Contains(make.ToLower()));
        }

        IEnumerable<Car> cars = carsQuery.ToArray();

        return View("Index", cars);
    }
}