namespace P06E06.SpeedRacing
{
    internal class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionFor1km;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public bool Drive(double TravelledDistance)
        {
            double fuelNeeded = TravelledDistance * FuelConsumptionPerKilometer;
            if (fuelNeeded <= FuelAmount)
            {
                FuelAmount -= fuelNeeded;
                this.TravelledDistance += TravelledDistance;
                return true;
            }

            return false;
        }
    } 
