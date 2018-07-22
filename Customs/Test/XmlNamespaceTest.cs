using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace ConsoleApp1.Test
{
    public class XmlNamespaceTest
    {
        public static void SerializeObject(string filename)
        {
            XmlSerializer s = new XmlSerializer(typeof(Books));
            // Writing a file requires a TextWriter.
            TextWriter t = new StreamWriter(filename);

            /* Create an XmlSerializerNamespaces object and add two
            prefix-namespace pairs. */
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("books", "http://www.cpandl.com");
            ns.Add("money", "http://www.cohowinery.com");
            ns.Add("aaaaa", "http://www.aaaaaaa.com");

            // Create a Book instance.
            Book b = new Book();
            b.TITLE = "A Book Title";
            Price p = new Price();
            p.price = (decimal)9.95;
            p.currency = "US Dollar";
            b.PRICE = p;
            Books bks = new Books();
            bks.Book = b;
            s.Serialize(t, bks, ns);
            t.Close();
        }
    }


    [XmlRoot(Namespace = "http://www.cpandl.com")]
    public class Books
    {
        [XmlElement(Namespace = "http://www.cohowinery.com")]
        public Book Book;
    }

    public class Book
    {
        [XmlElement(Namespace = "http://www.cpandl.com")]
        public string TITLE;
        [XmlElement(Namespace = "http://www.cohowinery.com")]
        public Price PRICE;
    }

    public class Price
    {
        [XmlAttribute(Namespace = "http://www.cpandl.com")]
        public string currency;
        [XmlElement(Namespace = "http://www.cohowinery.com")]
        public decimal price;
    }
}
