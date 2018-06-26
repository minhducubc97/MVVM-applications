using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PraceXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader xmlReader = XmlReader.Create("../../Xml/Book.xml");
            while(xmlReader.Read())
            {
                if (xmlReader.IsStartElement())
                {
                    // return only when you have START tag
                    switch(xmlReader.Name.ToString())
                    {
                        case "author":
                            Console.WriteLine("Author: " + xmlReader.ReadElementContentAsString());
                            break;
                        case "title":
                            Console.WriteLine("Title: " + xmlReader.ReadElementContentAsString());
                            break;
                        case "genre":
                            Console.WriteLine("Genre: " + xmlReader.ReadElementContentAsString());
                            break;
                        case "price":
                            Console.WriteLine("Price: " + xmlReader.ReadElementContentAsString());
                            break;
                        case "publish_date":
                            Console.WriteLine("Publish Date: " + xmlReader.ReadElementContentAsDateTime().ToShortDateString());
                            break;
                        case "description":
                            Console.WriteLine("Publish Date: " + xmlReader.ReadElementContentAsString());
                            break;
                    } 
                }
            }
            Console.ReadKey();
        }
    }
}