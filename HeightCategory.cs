using System;

public class HeightCategory
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter height:");

        int height = int.Parse(Console.ReadLine());

        if (height < 150)
        {
            Console.WriteLine("Dwarf");
        }
        else if (height >= 150 && height < 165)
        {
            Console.WriteLine("Average");
        }
        else if (height >= 165 && height < 190)
        {
            Console.WriteLine("Taller");
        }
        else
        {
            Console.WriteLine("Abnormal");
        }
    }
}


