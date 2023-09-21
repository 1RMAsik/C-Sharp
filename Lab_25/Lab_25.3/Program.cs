
bool IsSimple(int n)
{
    if (n <= 1){ return false;}
    if (n == 2){ return true;}
    if (n % 2 == 0){ return false;}

    for (int i = 3; i * i <= n; i += 2)
    {
        if (n % i == 0)
        {
            return false;
        }
    }

    return true;
}


    int[] array = new int[8];
    Random random = new Random();
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = random.Next(2, 100);
        Console.WriteLine(array[i]);
    }

Parallel.ForEach(array, (item) =>
    {
        if (IsSimple(item))
        {
            Console.WriteLine("Число {0} простое", item);
        }
        else
        {
            Console.WriteLine("Число {0} не простое", item);
        }
    });