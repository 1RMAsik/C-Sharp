using System.Collections;

internal class Programm
{
    static void Main()
    {
        ArrayList a = new ArrayList();
        a.Add("Никита");
        a.Add("Самойлов");
        a.Add("Ильич");
        a.Add("PZ-56");
        a.Add(19);
        a[0] = "Матвей";
        a.Remove("Ильич");
        foreach (var I in a)
        {
            
            
            Console.WriteLine(I + " ");
        }
    }
}