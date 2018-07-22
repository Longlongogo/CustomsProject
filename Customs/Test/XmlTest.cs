using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1.Test
{
    public class Group
    {
        /* Set the element name and namespace of the XML element.
        By applying an XmlElementAttribute to an array,  you instruct
        the XmlSerializer to serialize the array as a series of XML
        elements, instead of a nested set of elements. */

        [XmlElementAttribute(
        ElementName = "Members",
        Namespace = "http://www.w3.org/2000/09/xmldsig#", Form =System.Xml.Schema.XmlSchemaForm.Qualified)]//, Prefix = ""
        public Employee[] Employees;

        [XmlElement(DataType = "double",
        ElementName = "Building")]
        public double GroupID;

        [XmlElement(DataType = "hexBinary")]
        public byte[] HexBytes;


        [XmlElement(DataType = "boolean")]
        public bool IsActive;

        [XmlElement(Type = typeof(Manager))]
        public Employee Manager;

        [XmlElement(typeof(int),
        ElementName = "ObjectNumber"),
        XmlElement(typeof(string),
        ElementName = "ObjectString")]
        public ArrayList ExtraInfo;
    }

    public class Employee
    {
        public string Name;
        //XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
        //public void aaa()
        //{
        //    xmlSerializerNamespaces.Add("ceb", "http://www.chinaport.gov.cn/ceb");
        //    xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        //}
    }

    public class Manager : Employee
    {
        public int Level;
    }
}
