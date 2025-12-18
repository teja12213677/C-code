using System.Runtime.CompilerServices;

using System;

public class teja{
    static bool IsPrime(int n)
    {
        if (n % 2 == 0) return false;

        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    static void run()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        if (IsPrime(num))
            Console.WriteLine($"{num}  Prime");
        else
            Console.WriteLine($"{num} NOT Prime");
    }
}