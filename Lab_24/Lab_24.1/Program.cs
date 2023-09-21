using System;
using System.Threading;

class Program
{
    static void Main()
    {
        
        Thread currentThread = Thread.CurrentThread;
        string name = currentThread.Name;
        ThreadPriority priority = currentThread.Priority;
        ThreadState state = currentThread.ThreadState;

        
        Console.WriteLine("Текущий поток:");
        Console.WriteLine("Имя: {0}", name);
        Console.WriteLine("Приоритет: {0}", priority);
        Console.WriteLine("Статус: {0}", state);
        Console.WriteLine();

       
        Console.Write("Введите имя текущего потока: ");
        string Name = Console.ReadLine();

       
        Thread newThread = new Thread(() => { Console.WriteLine("Успех!"); });
        newThread.Name = Name;
        newThread.Start();

       
        name = newThread.Name;
        priority = newThread.Priority;
        state = newThread.ThreadState;

        // Вывод информации о новом потоке
        Console.WriteLine("Новый поток:");
        Console.WriteLine("Имя: {0}", name);
        Console.WriteLine("Приоритет: {0}", priority);
        Console.WriteLine("Статус: {0}", state);
    }
}