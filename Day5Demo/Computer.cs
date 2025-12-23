using System;
public class Computer
{
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int HardDiskSize { get; set; }
    public int GraphicCard { get; set; }
}
public class Desktop : Computer
{
    public int MonitorSize { get; set; }
    public int PowerSupplyVolt { get; set; }

    public double DesktopPriceCalculation()
    {
        int ProcessorCost = 0;
        if (Processor == "i3")
            ProcessorCost = 1500;
        else if (Processor == "i5")
            ProcessorCost = 3000;
        else if (Processor == "i7")
            ProcessorCost = 4500;
        double Price = ProcessorCost + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (MonitorSize * 250) + (PowerSupplyVolt * 20);
        return Price;
    }
}

public class Laptop : Computer
{
    public int DisplaySize { get; set; }
    public int BatteryVolt { get; set; }
    public double LaptopPriceCalculation()
    {
        int ProcessorCost = 0;
        if (Processor == "i3")
            ProcessorCost = 2500;
        else if (Processor == "i5")
            ProcessorCost = 5000;
        else if (Processor == "i7")
            ProcessorCost = 6500;
        double Price = ProcessorCost + (RamSize * 200) + (HardDiskSize * 1500) + (GraphicCard * 2500) + (DisplaySize * 250) + (BatteryVolt * 20);
        return Price;
    }
}

public class Application
{
    public static void Main(string[] args)
    {
        Console.WriteLine("1.Desktop");
        Console.WriteLine("2.Laptop");
        Console.WriteLine("Choose an option");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            Desktop d = new Desktop();
            Console.WriteLine("Enter the Processor: ");
            d.Processor = Console.ReadLine();
            Console.WriteLine("Enter the RamSize: ");
            d.RamSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the hard disk size : ");
            d.HardDiskSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the graphic card size: ");
            d.GraphicCard = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the monitor size: ");
            d.MonitorSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Power size volt: ");
            d.PowerSupplyVolt = int.Parse(Console.ReadLine());
            double p = d.DesktopPriceCalculation();
            Console.WriteLine("Desktop price is: " + p);
        }
        else if (choice == 2)
        {
            Laptop l = new Laptop();
            Console.WriteLine("Enter the Processor: ");
            l.Processor = Console.ReadLine();
            Console.WriteLine("Enter the RamSize: ");
            l.RamSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the hard disk size : ");
            l.HardDiskSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the graphic card size: ");
            l.GraphicCard = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the display size: ");
            l.DisplaySize = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the battery volt: ");
            l.BatteryVolt = int.Parse(Console.ReadLine());
            double s = l.LaptopPriceCalculation();
            Console.WriteLine("Laptop price: " + s);
        }
    }
}