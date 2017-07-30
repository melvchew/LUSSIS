using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Melvin
{
    public class StockManagement
    {

        //Melvin

        public List<Item> GetItemList()
        {
            {
                return ctx.Items.ToList();
            }
        }
    }
}