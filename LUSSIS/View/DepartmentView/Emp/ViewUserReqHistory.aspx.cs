using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.View.DepartmentView.Emp
{
    public partial class ViewUserReqHistory : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected string ChangeStatus(string status)
        {
            return rs.ChangeStatus(status);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                if (!IsPostBack)
                {
                    int empid = Convert.ToInt32(Session["empId"]);
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                    this.BindGrid(emp);
                }
            }
        }

        //Bind the data to gridview
        private void BindGrid(Employee emp)
        {
            using (context = new LUSSdb())
            {
                List<Requisition> lreqs = rs.GetOwnReq(emp);
                gvReqHistory.DataSource = lreqs;
                gvReqHistory.DataBind();
            }
        }

        //gvReqHistory: ButtonField 'details' click (CommandName="reqDetails")
        protected void gvReqHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "reqDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvReqHistory.Rows[index];
                int ReqId = Int32.Parse(row.Cells[0].Text);
                Session["View"] = "own";
                string status = (row.Cells[1].FindControl("Label1") as Label).Text;

                if (status == "PENDING")
                    Response.Redirect("ManageReq.aspx?rid=" + ReqId);
                else if (status == "CANCELLED" || status == "REJECTED")
                    Response.Redirect("ViewReq.aspx?rid=" + ReqId);
                else
                    Response.Redirect("ViewReqConfirm.aspx?rid=" + ReqId);
            }
        }

        //Change pages in gridview
        protected void gvReqHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            using (context = new LUSSdb())
            {
                gvReqHistory.PageIndex = e.NewPageIndex;
                int empid = Convert.ToInt32(Session["empId"]);
                Employee emp = context.Employees.Where(em => em.EmpId == empid).ToList().First();
                this.BindGrid(emp);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/DepartmentView/Home.aspx");
        }
    }
}