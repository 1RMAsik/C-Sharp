using System.Collections.Generic;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class dictionary
    {
        private string language { get; set; }
        private int words { get; set; }

        public dictionary(string language, int words)
        {
            this.language = language;
            this.words = words;
        }
        
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<dictionary> collectionDecoration = new List<dictionary>();
            
        }
    }
}