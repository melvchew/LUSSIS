using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.ZhangJinshan
{
    public class ReportBLL
    {
        public List<Item> GetLowStock()
        {
            List<Item> l2 = new List<Item>();
            List<Item> l1 = new List<Item>();
            l1 = GetAllStockStatus();
            for (int i = 0; i <= l1.Count - 1; i++)
            {
                if (l1[i].StockBalance < l1[i].ReorderLvl)
                {
                    l2.Add(l1[i]);
                }
            }
            return l2;
        }

        public List<Item> GetAllStockStatus()
        {
            List<Item> l2 = new List<Item>();
            try
            {
                LUSSdb entity = new LUSSdb();
                l2 = entity.Items.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

            return l2;
        }
    }
}