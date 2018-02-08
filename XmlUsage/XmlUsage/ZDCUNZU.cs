using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlUsage
{
    public class ZDCUNZU
    {
        public String Zheng;
        public String Cun;
        public List<ZhengCunZu> zu;
        public ZDCUNZU()
        {
            zu = new List<ZhengCunZu>();
        }
        public void addRow(ZhengCunZu addzu)
        {
            Zheng = "abcgit test3";
            zu.Add(addzu);
        }
    }
    public class ZhengCunZu
    {
       
        public String Zu;
        public Dictionary<string, int> dlinfo;
        public ZhengCunZu()
        {
            Zu = "";
            for(int i=1;i<4;i++)
            {
                dlinfo.Add("01" + i,0);
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
