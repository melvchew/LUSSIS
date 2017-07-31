using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.StoreView.Clerk
{
    public partial class ViewAllReq : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL bizlogic;
        List<Department> deptList;
        protected void Page_Load(object sender, EventArgs e)
        {
            bizlogic = new RequisitionBLL();
            //context = new LUSSdbEntities();

            //DropDownList1.Items.Clear();

            if (!IsPostBack)
            {
                using (context = new LUSSdb())
                {
                    deptList = context.Departments.ToList<Department>();
                    DropDownList1.DataSource = deptList;
                    DropDownList1.DataTextField = "DeptName";
                    DropDownList1.DataValueField = "DeptId";
                    DropDownList1.DataBind();
                    GridView1.DataSource = bizlogic.GetRequisitionList();
                    GridView1.DataBind();
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            bizlogic = new RequisitionBLL();
            int deptID = Int32.Parse(DropDownList1.SelectedValue);
            Label1.Text = "Showing requisitions from: " + DropDownList1.SelectedItem;
            GridView1.DataSource = bizlogic.GetRequisitionListByDepartment(deptID);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)

                Label2.Text = "No results found!";

            else

                Label2.Text = "";

        }
    }
}
