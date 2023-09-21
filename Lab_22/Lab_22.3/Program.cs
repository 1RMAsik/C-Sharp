namespace ConsoleApplication1
{
    class Dictionary : IComparable <Dictionary>
    {
        public string language { get; set; }
        public int words { get; set; }

        public Dictionary(string language, int words)
        {
            this.language = language;
            this.words = words;
        }

        public int CompareTo(Dictionary o)
        {
            
            return language.CompareTo(o.language);
        
            
        }

       
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Dictionary> l1 = new List<Dictionary>();
            l1.Add(new Dictionary("Russian" ,3000));
            l1.Add(new Dictionary("Chinese", 3200));
            l1.Add(new Dictionary("Belarusian", 2800));
            l1.Sort();
            foreach (var  dictionary in l1)
            {
                Console.WriteLine(dictionary.language + " " + dictionary.words);
                
            }
        }
    }
}