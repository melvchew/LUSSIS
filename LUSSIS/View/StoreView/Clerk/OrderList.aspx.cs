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
    public partial class OrderList : System.Web.UI.Page
    {
        StockManagementBLL bll = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

                UpdateList();


            }
        }
        protected Item GetItem(int itemId)
        {
            return bll.GetItemList().FirstOrDefault(x => x.ItemId == itemId);
        }
        protected void BindGrid()
        {
            List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];
            gvOrderList.DataSource = orderList;
            gvOrderList.DataBind();
            decimal totalAmount = 0;

            //setting radio buttons
            foreach (GridViewRow row in gvOrderList.Rows)
            {
                int id = Convert.ToInt32((row.FindControl("hfItemId") as HiddenField).Value);

                OrderListItem oli = orderList.First(x => x.PurchaseOrderItem.ItemId == id);
                Item item = bll.GetItem(oli.PurchaseOrderItem.ItemId);
                if (oli.Supplier == null)
                {
                    (row.FindControl("rbtnSupplier1") as RadioButton).Checked = true;
                    totalAmount += item.Supplier1Price * oli.PurchaseOrderItem.OrderQty;
                }
                else if (oli.Supplier.SupplierId == item.Supplier1Id)
                {
                    (row.FindControl("rbtnSupplier1") as RadioButton).Checked = true;
                    totalAmount += item.Supplier1Price * oli.PurchaseOrderItem.OrderQty;
                }
                else if (oli.Supplier.SupplierId == item.Supplier2Id)
                {
                    (row.FindControl("rbtnSupplier2") as RadioButton).Checked = true;
                    totalAmount += item.Supplier2Price * oli.PurchaseOrderItem.OrderQty;
                }
                else
                {
                    (row.FindControl("rbtnSupplier3") as RadioButton).Checked = true;
                    totalAmount += item.Supplier3Price * oli.PurchaseOrderItem.OrderQty;
                }
            }

            lblTotalAmount.Text = $"{totalAmount:C2}";
        }

        protected string GetSupplierName(int itemId, int pos)
        {
            string suppName = "No Supplier";

            if (pos == 0)
            {
                suppName = bll.GetItem(itemId).Supplier.CompanyName;
            }
            else if (pos == 1)
            {
                suppName = bll.GetItem(itemId).Supplier1.CompanyName;
            }
            else if (pos == 2)
            {
                suppName = bll.GetItem(itemId).Supplier2.CompanyName;
            }


            return suppName;
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderItems.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            UpdateList();
            BindGrid();

        }

        private void UpdateList()
        {
            List<OrderListItem> orderList = (List<OrderListItem>)Session["OrderList"];

            foreach (GridViewRow row in gvOrderList.Rows)
            {
                int id = Convert.ToInt32((row.FindControl("hfItemId") as HiddenField).Value);
                OrderListItem oli = orderList.First(x => x.PurchaseOrderItem.ItemId == id);
                oli.PurchaseOrderItem.OrderQty = Convert.ToInt32((row.FindControl("txtQty") as TextBox).Text);
                if ((row.FindControl("rbtnSupplier1") as RadioButton).Checked)
                {
                    string suppId = bll.GetItemList().FirstOrDefault(x => x.ItemId == oli.PurchaseOrderItem.ItemId).Supplier1Id;
                    oli.Supplier = bll.GetSupplierList().First(x => x.SupplierId == suppId);
                }
                else if ((row.FindControl("rbtnSupplier2") as RadioButton).Checked)
                {
                    string suppId = bll.GetItemList().FirstOrDefault(x => x.ItemId == oli.PurchaseOrderItem.ItemId).Supplier2Id;
                    oli.Supplier = bll.GetSupplierList().First(x => x.SupplierId == suppId);
                }
                else
                {
                    string suppId = bll.GetItemList().FirstOrDefault(x => x.ItemId == oli.PurchaseOrderItem.ItemId).Supplier3Id;
                    oli.Supplier = bll.GetSupplierList().First(x => x.SupplierId == suppId);
                }

                if (Convert.ToInt32((row.FindControl("txtQty") as TextBox).Text) == 0)
                {
                    orderList.Remove(oli);
                }
            }

            Session["OrderList"] = orderList;
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect($"OrderForms.aspx?expectedDate={txtExpectedDate.Text}");

        }
    }
}