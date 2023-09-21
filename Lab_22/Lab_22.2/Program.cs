internal class Programm
{
    static void Main()
    {
        Random r = new Random();
        Console.WriteLine("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());
        List<int> l1 = new List<int>();

        int[] m = new int[n];
        for (int i = 0; i < n; i++)
        {
            l1.Add(r.Next(0,10));
        }

        

        List<string> l2 = new List<string>();
        l2.Add("Баклажанище");
        l2.Add("Гиппо");
        l2.Add("Мусульман");
        string MaxStr = "";
        for (int i = 0; i < n; i++)
        {
            if (l2[i].Length > MaxStr.Length)
            {
                MaxStr = l2[i];
                
            }
            
        }

        
        foreach (var v in l1)
        {
            Console.WriteLine(v + " ");
            
            
        }
        Console.WriteLine(l1.Max());
        foreach (var v1 in l2)
        {
            Console.WriteLine(v1 + " ");
            
        }
        Console.WriteLine(MaxStr);
    }
}