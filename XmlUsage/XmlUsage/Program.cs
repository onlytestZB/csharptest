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
            ZDCUNZU zdcunzu = new ZDCUNZU();
            foreach (XElement item in doc.Root.Descendants("DATA"))
            {
                            
                if(item.Attribute("DATANAME").Value== "TDFLMJ_Transition")
                {
                    foreach(XElement row in item.Descendants("ROW"))
                    {
                        ZhengCunZu add_zu = new ZhengCunZu();
                      
                       
                        add_zu.Zheng = row.Attribute("XIANG").Value;
                        add_zu.Cun = row.Attribute("CUN").Value;
                        add_zu.Zu = row.Attribute("ZU").Value;
                        
                        foreach(XElement dl in row.Descendants("TDFLMJ"))
                        {
                            add_zu.dlinfo[dl.Attribute("DLDM").Value] += Convert.ToInt32(dl.Attribute("DLMJ").Value);
                        }
                        zdcunzu.addRow(add_zu);
                       
                    }
                }
            }
            zdcunzu.display();
            Console.ReadKey();
        }
    }

}
