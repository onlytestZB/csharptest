using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace wpsusage
{
    public class ZDCUNZU
    {

        public List<ZhengCunZu> AllZu;
        protected XDocument doc;
        public ZDCUNZU()
        {
            AllZu = new List<ZhengCunZu>();
        }
        public ZDCUNZU(String srcfile)
        {
            AllZu = new List<ZhengCunZu>();
            doc = XDocument.Load(srcfile);
            
            foreach (XElement item in doc.Root.Descendants("DATA"))
            {

                if (item.Attribute("DATANAME").Value == "TDFLMJ_Transition")
                {
                    foreach (XElement row in item.Descendants("ROW"))
                    {
                        ZhengCunZu add_zu = new ZhengCunZu();


                        add_zu.Zheng = row.Attribute("XIANG").Value;
                        add_zu.Cun = row.Attribute("CUN").Value;
                        add_zu.Zu = row.Attribute("ZU").Value;

                        foreach (XElement dl in row.Descendants("TDFLMJ"))
                        {
                            add_zu.dlinfo[dl.Attribute("DLDM").Value] += Convert.ToInt32(dl.Attribute("DLMJ").Value);
                        }
                        this.addRow(add_zu);
                    }
                }
            }
        }
        public void addRow(ZhengCunZu addzu)
        {
            bool flag = true;
            foreach (ZhengCunZu zu in AllZu)
            {
                if (zu.Zheng == addzu.Zheng && zu.Cun == addzu.Cun && zu.Zu == addzu.Zu)
                {
                    flag = false;
                    foreach (KeyValuePair<string, int> p in addzu.dlinfo)
                    {
                        zu.dlinfo[p.Key] += p.Value;
                    }
                }
            }
            if (flag)
            {
                AllZu.Add(addzu);
            }
        }
        public void display()
        {
            foreach (ZhengCunZu zu in AllZu)
            {
                Console.WriteLine("{0}{1}{2}:", zu.Zheng, zu.Cun, zu.Zu);
                foreach (KeyValuePair<string, int> p in zu.dlinfo)
                {

                    if (p.Value != 0)
                    {
                        Console.WriteLine("{0}:{1}", p.Key, p.Value);
                    }
                }
            }

        }
    }
    public class ZhengCunZu
    {
        public String Zheng;
        public String Cun;
        public String Zu;
        public Dictionary<string, int> dlinfo;
        public ZhengCunZu()
        {
            Zheng = "";
            Cun = "";
            Zu = "";
            dlinfo = new Dictionary<string, int>();
            for (int i = 1; i < 4; i++)
            {
                dlinfo.Add("01" + i, 0);
            }
            for (int i = 1; i < 4; i++)
            {
                dlinfo.Add("02" + i, 0);
            }
            for (int i = 1; i < 4; i++)
            {
                dlinfo.Add("03" + i, 0);
            }
            for (int i = 1; i < 4; i++)
            {
                dlinfo.Add("04" + i, 0);
            }
            for (int i = 1; i < 8; i++)
            {
                dlinfo.Add("10" + i, 0);
            }
            for (int i = 1; i < 10; i++)
            {
                dlinfo.Add("11" + i, 0);
            }
            for (int i = 1; i < 8; i++)
            {
                dlinfo.Add("12" + i, 0);
            }
            for (int i = 1; i < 6; i++)
            {
                dlinfo.Add("20" + i, 0);
            }
        }
    }
}
