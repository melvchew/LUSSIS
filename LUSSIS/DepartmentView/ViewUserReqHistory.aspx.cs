using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.HUXIAOXI;
using LUSSIS.RawCode.DAL;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.Employee
{
    public partial class ViewUserReqHistory : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                if (!IsPostBack)
                {
                    int empid = 4; //Need connect to login info
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                    this.BindGrid(emp);
                }
            }
        }

        private void BindGrid(Employee emp)
        {
            using (context = new LUSSdb())
            {
                List<Requisition> lreqs = rs.GetOwnReq(emp);
                gvReqHistory.DataSource = lreqs;
                gvReqHistory.DataBind();
            }
        }

        protected void gvReqHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "reqDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvReqHistory.Rows[index];
                int ReqId = Int32.Parse(row.Cells[0].Text);
                Session["View"] = "own";
                if (row.Cells[1].Text == "PENDING")
                    Response.Redirect("ManageReq.aspx?rid=" + ReqId);
                else if (row.Cells[1].Text == "CANCELLED")
                    Response.Redirect("ViewReq.aspx?rid=" + ReqId);
                else
                    Response.Redirect("ViewReqConfirm.aspx?rid=" + ReqId);
            }
        }

        protected void gvReqHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            using (context = new LUSSdb())
            {
                gvReqHistory.PageIndex = e.NewPageIndex;
                int empid = 4;
                Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                this.BindGrid(emp);
            }
        }
    }
}