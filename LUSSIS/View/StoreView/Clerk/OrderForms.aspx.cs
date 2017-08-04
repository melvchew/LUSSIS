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
    public partial class OrderForms : System.Web.UI.Page
    {
        StockManagementBLL bll = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();

                lblConfirmMsg.Text = "The following orders will be sent to manager for approval.";
            }
        }

        private void BindRepeater(List<PurchaseOrder> poList = null)
        {
            if (poList == null)
            {
                List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];
                string[] date = Request["expectedDate"].Split('-');
                DateTime expectedDate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
                int empId = Convert.ToInt32(Session["storeEmpId"]);
                StoreEmployee currentStoreEmp = bll.GetStoreEmployeeList().FirstOrDefault(x => x.StoreEmpId == empId);
                poList = bll.GenerateOrderForms(orderList, currentStoreEmp, expectedDate);
            }

            repPurchaseOrderForm.DataSource = poList;
            repPurchaseOrderForm.DataBind();

        }

        protected decimal GetItemPrice(int itemId, string supplierId)
        {
            Item item = bll.GetItem(itemId);
            if (item.Supplier1Id == supplierId)
            {
                return item.Supplier1Price;
            }
            else if (item.Supplier2Id == supplierId)
            {
                return item.Supplier2Price;
            }
            else if (item.Supplier3Id == supplierId)
            {
                return item.Supplier3Price;
            }
            else
            {
                return 0;
            }
        }

        protected void repPurchaseOrderForm_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GridView gv = (GridView)e.Item.FindControl("gvPurchaseOrders");
                decimal total = 0;
                foreach (GridViewRow row in gv.Rows)
                {
                    total += Convert.ToDecimal((row.FindControl("lblAmount") as Label).Text);
                }

                (e.Item.FindControl("lblTotal") as Label).Text = total.ToString();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            bll = new StockManagementBLL();

            List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];
            string[] date = Request["expectedDate"].Split('-');
            DateTime expectedDate = new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0]));
            int empId = Convert.ToInt32(Session["storeEmpId"]);
            StoreEmployee currentStoreEmp = bll.GetStoreEmployeeList().FirstOrDefault(x => x.StoreEmpId == empId);
            List<PurchaseOrder> poList = bll.GenerateOrderForms(orderList, currentStoreEmp, expectedDate);

            poList = bll.SubmitPurchaseOrders(poList);

            BindRepeater(poList);

            btnConfirm.Visible = false;
            lblConfirmMsg.Text = "The following orders forms has been sent to manager for approval.";
        }

        protected Item GetItem(int itemId)
        {
            return bll.GetItemList().FirstOrDefault(x => x.ItemId == itemId);
        }

        protected Supplier GetSupplier(string suppId)
        {
            return bll.GetSupplierList().FirstOrDefault(x => x.SupplierId == suppId);
        }
    }
}