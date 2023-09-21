using System.Xml.Linq;


namespace ConsoleApplication1
{
    class dictionary
    {
        public string language { get; set; }
        public int Words { get; set; }

        public dictionary(string language, int Words)
        {
            this.language = language;
            this.Words = Words;
        }

    }

    class Programm
    {


        static void Main()
        {
            XDocument d = XDocument.Load("2.xml");
            XElement root = d.Root;

            foreach (XElement u in root.Elements())
            {
                Console.WriteLine(u.Element("language").Value + " " + u.Element("Words").Value);

            }

            Console.WriteLine("Введите язык и количество слов: ");
            XElement e = new XElement( "dictionary",new XElement("language", Console.ReadLine()), new XElement("Words", Console.ReadLine()));
            root.Add(e);
            d.Save("2.xml");
            foreach (XElement u in root.Elements())
            {
                Console.WriteLine(u.Element("language").Value + " " + u.Element("Words").Value);

            }


        }
    }
}
        

