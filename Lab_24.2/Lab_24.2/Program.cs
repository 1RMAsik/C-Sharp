using System;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread thread = new Thread(CountNumbers);
        Console.WriteLine("Текущий поток: {0}", thread.ThreadState);
        thread.Start();
        Console.WriteLine("Текущий поток: {0}", thread.ThreadState);

        while (thread.IsAlive)
        {
            Console.WriteLine("Текущий статус: {0}", thread.ThreadState);
            Thread.Sleep(100);
        }
    }

    static void CountNumbers()
    {
        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(1000);
        }
    }
}