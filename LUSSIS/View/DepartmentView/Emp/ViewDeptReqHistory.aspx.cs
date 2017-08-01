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
    public partial class ViewDeptReqHistory : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (context = new LUSSdb())
                {
                    int empid = Convert.ToInt32(Session["empId"]);
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).First();
                    Department dept = context.Departments.Where(d => d.DeptId == emp.DeptId).ToList().First();
                    this.BindGrid(dept);
                }
            }

        }

        private void BindGrid(Department dept)
        {
            using (context = new LUSSdb())
            {
                List<Requisition> lreqs = rs.GetDeptReq(dept);

                gvDeptReq.DataSource = lreqs;

                gvDeptReq.DataBind();

                droplistEmp.DataSource = rs.GetEmpName(dept);

                droplistEmp.DataBind();
            }
        }

        private void BindGridByReqlist(List<Requisition> lreqs)
        {
            gvDeptReq.DataSource = lreqs;

            gvDeptReq.DataBind();
        }

        //gvDeptReq: ButtonField 'details' click (CommandName="reqDetails")
        protected void gvDeptReq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "reqDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                String loginName = "Odelia Halm"; //need to connect to login!!!!

                GridViewRow row = gvDeptReq.Rows[index];
                int ReqId = Int32.Parse(row.Cells[0].Text);
                Session["View"] = "dept";
                if (row.Cells[2].Text == "PENDING" && row.Cells[1].Text == loginName)
                    Response.Redirect("ManageReq.aspx?rid=" + ReqId);
                else if (row.Cells[2].Text == "CANCELLED" || (row.Cells[2].Text == "PENDING" && row.Cells[1].Text != loginName))
                    Response.Redirect("ViewReq.aspx?rid=" + ReqId);
                else
                    Response.Redirect("ViewReqConfirm.aspx?rid=" + ReqId);
            }
        }

        protected void gvDeptReq_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            using (context = new LUSSdb())
            {
                gvDeptReq.PageIndex = e.NewPageIndex;

                int empid = Convert.ToInt32(Session["empId"]);
                Employee emp = context.Employees.Where(em => em.EmpId == empid).First();
                Department dept = context.Departments.Where(d => d.DeptId == emp.DeptId).ToList().First();


                string empname = droplistEmp.SelectedItem.Text;
                List<Requisition> lreqs = new List<Requisition>();

                if (empname != "")
                {
                    lreqs = context.Requisitions.Where(r => r.Employee.Name == empname).ToList();
                    this.BindGridByReqlist(lreqs);
                }
                else if (empname == "")
                {
                    this.BindGrid(dept);
                }

                droplistEmp.Text = empname;
            }
        }

        protected void droplistEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (context = new LUSSdb())
            {
                string empname = droplistEmp.SelectedItem.Text;
                if (empname != "")
                {
                    List<Requisition> lreqs = context.Requisitions.Where(r => r.Employee.Name == empname).ToList();
                    this.BindGridByReqlist(lreqs);
                }
                else
                {
                    int empid = Convert.ToInt32(Session["empId"]);
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).First();
                    Department dept = context.Departments.Where(d => d.DeptId == emp.DeptId).ToList().First();
                    this.BindGrid(dept);
                }
                droplistEmp.Text = empname;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/DepartmentView/Home.aspx");
        }
    }
}