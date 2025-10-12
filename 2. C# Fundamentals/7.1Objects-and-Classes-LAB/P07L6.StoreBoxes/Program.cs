using System.Diagnostics;

namespace P07L6.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Box> boxes = new List<Box>();
            string input = " ";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] productInfo = input.Split();
                string serialNumber = productInfo[0];
                string itemName = productInfo[1];
                double itemQuantity = double.Parse(productInfo[2]);
                double price = double.Parse(productInfo[3]);

                Item item = new Item(itemName, price);
                Box box = new Box(item,itemQuantity, serialNumber);
                boxes.Add(box);
            }

            foreach (Box box in boxes.OrderByDescending(x=>x.priceForBox))
            {
                Console.WriteLine(box.serialNumber);
                Console.WriteLine($"-- {box.item.name} - ${box.item.price:F2}: {box.itemQuantity}");
                Console.WriteLine($"-- ${box.priceForBox:F2}");
            }
        }
    }
    public class Item
    {
        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public string name { get; set; }
        public double price { get; set; }
    }

    public class Box
    {
        public Box(Item item, double itemQuantity, string serialNumber)
        {
            this.item = item;
            this.itemQuantity = itemQuantity;
            this.serialNumber = serialNumber;
        }
        public string serialNumber { get; set; }
        public Item item { get; set; }
        public double itemQuantity { get; set; }
        public double priceForBox => item.price * itemQuantity;
    }
}