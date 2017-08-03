using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class ViewOrder : System.Web.UI.Page
    {
        StockManagementBLL bll = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(false);
            }
        }

        private void BindGrid(bool onlyPending)
        {
            gvOrders.DataSource = bll.GetPurchaseOrders(onlyPending);
            gvOrders.DataBind();
        }
    }
}