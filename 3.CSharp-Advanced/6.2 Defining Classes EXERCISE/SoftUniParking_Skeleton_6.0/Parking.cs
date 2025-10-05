using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking;

public class Parking
{
    private readonly Dictionary<string, Car> cars;
    private readonly int capacity;

    public int Count
    {
        get => this.cars.Count;
    }

    public Parking(int capacity)
    {
        this.cars = new Dictionary<string, Car>();
        this.capacity = capacity;
    }

    public string AddCar(Car car)
    {
        if (this.cars.ContainsKey(car.RegistrationNumber))
        {
            return $"Car with that registration number, already exists!";
        }

        if (this.capacity <= this.cars.Keys.Count )
        {
            return $"Parking is full!";
        }

        this.cars[car.RegistrationNumber] = car;
        return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
    }

    public string RemoveCar(string registrationNumber)
    {
        if (!this.cars.Remove(registrationNumber))
        {
            return $"Successfully removed {registrationNumber}";
        }

        return $"Car with that registration number, doesn't exist!";
    }

    public Car GetCar(string RegistrationNumber)
    {
        return this.cars[RegistrationNumber];
    }

    public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
    {
        foreach (var regNumber in RegistrationNumbers)
        {
            this.RemoveCar(regNumber);
        }

    }
}