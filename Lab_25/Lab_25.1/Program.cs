using System;
using System.Threading;

class Program
{
       static void Main(string[] args)
        {   Task task = new Task(Display);
            Task task2 = new Task(Num);
            Task task3 = new Task(Name);
            task.Start();
            
            task2.Start();
            
            task3.Start();
            Task.WaitAny(task2, task, task3);
            Console.WriteLine("Завершение метода Main");
            Console.ReadLine();
        }
        static void Display()
        {   Console.WriteLine("Начало работы метода Display");
            Console.WriteLine("Завершение работы метода Display");
        }

        static void Num()
        {
            
            for (int i = 1; i < 11; i++)
            {
               
                Console.WriteLine(i);
               
            }
            
        }

        static void Name()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Никита");
            }
            
        }
    

}
