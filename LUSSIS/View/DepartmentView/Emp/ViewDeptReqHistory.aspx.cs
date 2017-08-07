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
        //EF model
        LUSSdb context;
        //BLL methods
        RequisitionBLL rs = new RequisitionBLL();

        //Change to dept display status
        protected string ChangeStatus(string status)
        {
            return rs.ChangeStatus(status);
        }

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

        //Bind the data to gridview and dropdown list
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

        //Bind the data by requisition list
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
                using(context=new LUSSdb())
                {
                    //Get login employee object
                    int index = Convert.ToInt32(e.CommandArgument);
                    int empid = Convert.ToInt32(Session["empId"]);
                    Employee emp = context.Employees.Where(em => em.EmpId == empid).First();

                    String loginName = emp.Name;
                    //Get the current row
                    GridViewRow row = gvDeptReq.Rows[index];
                    int ReqId = Int32.Parse(row.Cells[0].Text);
                    Session["View"] = "dept";

                    //Get requisition status
                    string status = (row.Cells[2].FindControl("Label1") as Label).Text;

                    //redirect to different pages denpend on the status
                    if (status == "PENDING" && row.Cells[1].Text == loginName)
                        Response.Redirect("ManageReq.aspx?rid=" + ReqId);
                    else if (status == "CANCELLED" || status== "REJECTED" || (status == "PENDING" && row.Cells[1].Text != loginName))
                        Response.Redirect("ViewReq.aspx?rid=" + ReqId);
                    else
                        Response.Redirect("ViewReqConfirm.aspx?rid=" + ReqId);
                }
            }       
        }

        //Change pages in gridview
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

                //if employee name exsits
                if (empname != "")
                {
                    lreqs = context.Requisitions.Where(r => r.Employee.Name == empname).ToList();
                    this.BindGridByReqlist(lreqs);
                }
                else
                {
                    this.BindGrid(dept);
                }

                droplistEmp.Text = empname;
            }
        }

        //Change the searching employee name in the dropdown list
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