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
    public partial class OrderItems : System.Web.UI.Page
    {
        StockManagementBLL bll = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindGrid();
            }
        }

        private void bindGrid()
        {

            gvItems.DataSource = bll.GetCatalogueItemList();
            gvItems.DataBind();

            List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];
            foreach (GridViewRow row in gvItems.Rows)
            {
                int id = Convert.ToInt32((row.FindControl("hfItemId") as HiddenField).Value);
                if (orderList.FirstOrDefault(x => x.PurchaseOrderItem.ItemId == id) != null)
                {
                    (row.FindControl("ckbSelect") as CheckBox).Checked = true;
                }
            }

        }

        protected void btnAddToOrderList_Click(object sender, EventArgs e)
        {
            List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];

            foreach (GridViewRow row in gvItems.Rows)
            {
                int id = Convert.ToInt32((row.FindControl("hfItemId") as HiddenField).Value);
                Item item = bll.GetItem(id);
                if ((row.FindControl("ckbSelect") as CheckBox).Checked)
                {
                    //if the item is not in the list
                    var v = orderList.FirstOrDefault(x => x.PurchaseOrderItem.ItemId == id);
                    if (v == null)
                    {
                        PurchaseOrderItem poi = new PurchaseOrderItem
                        {
                            ItemId = item.ItemId,
                            OrderQty = item?.ReorderQty ?? 1
                        };
                        orderList.Add(new OrderListItem
                        {
                            PurchaseOrderItem = poi
                        });
                    }
                }
                else
                {
                    //if the item is in the list, remove that item
                    var v = orderList.FirstOrDefault(x => x.PurchaseOrderItem.ItemId == id);
                    if (v != null)
                    {
                        orderList.Remove(v);
                    }
                }
            }
            if (orderList.Count == 0)
            {
                Response.Write(" <script language=JavaScript> alert('Need to choose at least one item.'); </script>");
                return;
            }
            else
            {
                Session["OrderList"] = orderList;

                Response.Redirect("OrderList.aspx");
            }

        }

        protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItems.PageIndex = e.NewPageIndex;

            bindGrid();
        }
    }
}