using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.RawCode.BLL.data.Melvin
{
    public class StockManagement
    {

        //Melvin
        LUSSdb ctx = new LUSSdb();
        public List<Item> GetItemList()
        {
            {
                return ctx.Items.ToList();
            }
        }
    }
}