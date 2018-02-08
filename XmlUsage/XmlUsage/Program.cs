using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(".\\test.xml");
            

            foreach(XElement item in doc.Root.Descendants("DATA"))
            {
                            
                if(item.Attribute("DATANAME").Value== "TDFLMJ_Transition")
                {
                    foreach(XElement row in item.Descendants("ROW"))
                    {
                        foreach(XAttribute att in row.Attributes())
                        {
                            Console.Write("{0}:{1}",att.Name,att.Value);
                        }                      
                        Console.WriteLine();
                        foreach(XElement dl in row.Descendants("TDFLMJ"))
                        {
                            foreach (XAttribute dl_att in dl.Attributes())
                            {
                                Console.WriteLine("{0}:{1}",dl_att.Name,dl_att.Value);
                            }
                            Console.WriteLine();
                        }
                       
                    }
                }
            }
            
            Console.ReadKey();
        }
    }
    
}
