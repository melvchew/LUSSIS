using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.BLL;

namespace LUSSIS.View.DepartmentView.Head
{
    public partial class ViewPendingReq : System.Web.UI.Page
    {
        RolesManagementBLL rmBLL = new RolesManagementBLL();
        EmailBLL eBLL = new EmailBLL();
        RequisitionBLL rBLL = new RequisitionBLL();
        StockManagementBLL sBLL = new StockManagementBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Label_PageTitle.Text = "Pending Requisitions";

            try
            {
                //Get User Data from Session, Create User object
                //Employee head = s.GetEmpByID(SessionParam)
                //Create Dept object using User object
                //Department dept = s.GetDeptByUser(head);
                Department dept = rmBLL.GetDeptByID(1); //hardcoded
                //Department dept = s.GetDeptByID(Session.Param)

                //Get List of employees
                List<Employee> Lemp = rmBLL.GetEmployees();

                //Get Pending requisitions based on department
                List<Requisition> Lreq = rBLL.GetPendingReqByDepartment(dept);

                //Bind Data from Lreq to Grid View
                GridView_VPR.DataSource = Lreq.Select(o => new { ReqId = o.ReqId, SubmitDate = o.SubmitDate, Name = Lemp.FirstOrDefault(x => x.EmpId == o.EmpId).Name });
                GridView_VPR.DataBind();
            }
            catch
            {

            }

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Direct to pendingdetail page including the ReqID selected
            String value = GridView_VPR.Rows[GridView_VPR.SelectedIndex].Cells[0].Text;
            Response.Redirect("ViewPendingReqDetails.aspx?ReqId=" + value); //pass the value to the next page.

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Direct to pendingdetail page including the ReqID selected
            String value = GridView_VPR.Rows[GridView_VPR.SelectedIndex].Cells[0].Text;
            Response.Redirect("ViewPendingReqDetails.aspx?ReqId=" + value); //pass the value to the next page.

        }
    }
}
