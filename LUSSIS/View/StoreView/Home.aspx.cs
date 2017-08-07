using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.View.StoreView
{
    public partial class Home : System.Web.UI.Page
    {
        HomePageBLL bll = new HomePageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int eId = Convert.ToInt32(Session["storeEmpId"]);
            StoreEmployee currentStoreEmp = bll.GetStoreEmployee(eId);
            lblUserName.Text = currentStoreEmp.Name;

            if (User.IsInRole("StoreClerk"))
            {
                List<Item> itemList = bll.GetLowStock();
                litClerkLowStockTotal.Text = itemList.Count.ToString();

                gvClerkLowStock.DataSource = itemList.Take(5).ToList();
                gvClerkLowStock.DataBind();

                List<RequisitionItem> reqItemList = bll.GetApprovedRequisitionItems();
                litClerkReqItemTotal.Text = reqItemList.Select(x => x.Quantity).Sum().ToString();

                gvClerkReqItem.DataSource = reqItemList.GroupBy(x => x.Item).Select(g => new
                {
                    Item = g.Key,
                    Quantity = g.Sum(x => x.Quantity)
                }).Take(5).ToList();
                gvClerkReqItem.DataBind();
            } else if (User.IsInRole("StoreSupervisor"))
            {
                List<Item> itemList = bll.GetLowStock();
                litSupLowStockTotal.Text = itemList.Count.ToString();

                gvSupLowStock.DataSource = itemList.Take(5).ToList();
                gvSupLowStock.DataBind();

                List<RequisitionItem> reqItemList = bll.GetApprovedRequisitionItems();
                litSupReqItemTotal.Text = reqItemList.Select(x => x.Quantity).Sum().ToString();

                gvSupReqItem.DataSource = reqItemList.GroupBy(x => x.Item).Select(g => new
                {
                    Item = g.Key,
                    Quantity = g.Sum(x => x.Quantity)
                }).Take(5).ToList();
                gvSupReqItem.DataBind();

                
               
            }
        }
    }
}