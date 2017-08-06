using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using System.Data;

namespace LUSSIS.View.DepartmentView.Rep
{
    public partial class ViewCollectionItems : System.Web.UI.Page
    {
           

        protected void Page_Load(object sender, EventArgs e)
        {
            ManageCollectionPointBLL mcp = new ManageCollectionPointBLL();
            RolesManagementBLL rm = new RolesManagementBLL(); 
         
            //// 1. Department ID 2. Disbursement ID => get in Session
            int count = 0;
            // HttpContext.Current.Session["DepartmentId"] = 1; // assign value to session variable
            //Label6.Text = Session["DepartmentId"].ToString();  //get Session Variable Value
            Employee emp = rm.GetEmpByID(Convert.ToInt32(Session["empId"]));
            Department dep = rm.GetDeptByUser(emp);
            Label2.Text = dep.CollectionPoint.Description;
            //Disbursement d = mcp.GetRequisitionById(Id);

            List<RequisitionItem> approvedRequsitionItemsByDepartment = mcp.GetAllApprovedRequsitionItemsByDepartment(dep);

            
            List<IGrouping<int,RequisitionItem>> x = approvedRequsitionItemsByDepartment.GroupBy(d => d.ItemId).ToList();

            List<grpReq> grp = new List<grpReq>();
            for(int i=0; i< x.Count; i++)
            {
                IGrouping<int, RequisitionItem> temp = x[i];
                int totalQuantity = temp.Select(qty => qty.Quantity).Sum();
                Item item = temp.Select(it => it.Item).FirstOrDefault();
                grpReq grpRq = new grpReq(item, totalQuantity);
                grp.Add(grpRq);
            }

            Label1.Text =  dep.CollectionPoint.CollectionTime + " AM";
            Label3.Text = dep.CollectionPoint.StoreEmployee.Name;
            Label4.Text = dep.CollectionPoint.StoreEmployee.Phone;


            DataTable dt = new DataTable();
            List<grpReq> list = grp;
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("#"), new DataColumn("Item Description"), new DataColumn("Quantity"), new DataColumn("Unit") });
            for (int i = 0; i < list.Count ; i++)
            {
                grpReq tmp = list[i];
                dt.Rows.Add(i + 1, tmp.item.Description, tmp.quantity, tmp.item.Unit);
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    public class grpReq
    {
        public Item item { get; set; }

        public int quantity { get; set; }

        public grpReq(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
