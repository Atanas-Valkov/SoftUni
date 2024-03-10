namespace P07E6.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicles>vehicles = new List<Vehicles>();

            
            string info;
            while((info= Console.ReadLine()) != "end")
            {
            
                 if (info == "End")
                 {
                    break;
                 } 
                 string[] vehiclesInfo = info.Split(" ").ToArray();
            
                 string type= vehiclesInfo[0];
                 string model = vehiclesInfo[1];
                 string color = vehiclesInfo[2];
                 double hp = double.Parse(vehiclesInfo[3]);
            
                Vehicles vehicle1 = new Vehicles(type,model,color,hp);
            
                vehicles.Add(vehicle1);
            
            }

            List<string> someVihicle = new List<string>();
            string secondPart; 
            while ((secondPart = Console.ReadLine()) != "Close the Catalogue")
            {
                if (secondPart == "Close the Catalogue")
                {
                    break;
                }
              

                someVihicle.Add(secondPart);
            }






        }
    }

    public class Vehicles
    {
        public Vehicles(string type, string model, string color, double hp)
        {
            Type = type;
            Model = model;
            Color = color;
            Hp = hp;
        }

        public string Type { get; set; }

        public string Model { get; set; }

        public string  Color { get; set; }

        public double Hp { get; set; }



    }

}