using System.IO;

static void Main(string[] args){
    StreamWriter sw = new StreamWriter(@"D:\C#\Lab17\num.txt");
    Console.WriteLine("Введите числа");
    for(int i = 0; i<10; i++){
        int x = int.Parse(Console.ReadLine());
        sw.WriteLine(x);
    }
    sw.Close();
}