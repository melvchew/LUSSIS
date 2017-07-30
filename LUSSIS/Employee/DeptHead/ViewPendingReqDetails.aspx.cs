using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.Employee.DeptHead
{
    public partial class ViewPendingReqDetails : System.Web.UI.Page
    {
        Service s = new Service();
        Requisition req;
        Employee emp;
        Employee boss;
        int bossid;
        Department dept;

        protected void Page_Load(object sender, EventArgs e)
        {


            //Get Employee Object of boss
            bossid = 1;
            //get user ID from session

            //Create Requisition object with ID pass from previous page
            //req = s.GetReq(6); //Hardcoded for testing
            req = s.GetReq(Convert.ToInt16(Request.QueryString["ReqId"]));

            //Employee that raised requisition
            emp = s.GetEmpByID(req.EmpId);


            List<Item> itemList = s.GetItemList();
            List<Employee> Lemp = s.GetEmployees();

            //Bind the grid view with the requisition items
            List<RequisitionItem> ListItems = s.GetListOfRequisitionItems(req);
            GridView_PendingReq.DataSource = ListItems.Select(o => new { Name = itemList.FirstOrDefault(x => x.ItemId == o.ItemId).Description, Quantity = o.Quantity });
            GridView_PendingReq.DataBind();

            //Bind the text of the label using req obj
            Label_RaisedBy.Text = Lemp.FirstOrDefault(x => x.EmpId == req.EmpId).Name;
            Label_ReqDate.Text = req.SubmitDate.ToString();
            Label_ReqID.Text = req.ReqId.ToString();
            Label_EmpComments.Text = req.EmpComments;
        }

        protected void Button_Approve_Click(object sender, EventArgs e)
        {
            //Get comments
            req.ApproverComments = TextBox_HeadComment.Text;
            //Approve requisition
            s.ApproveReq(req, bossid);

            //Send Notification
            s.SendRequisitionStatusUpdate(emp, req);

            //Direct to ViewPendingRequisition
            Response.Redirect("ViewPendingRequisition.aspx");

        }

        protected void Button_Reject_Click(object sender, EventArgs e)
        {
            //Get Comments
            req.ApproverComments = TextBox_HeadComment.Text;
            //Reject requisition
            s.RejectReq(req, bossid);

            //Send Notification
            s.SendRequisitionStatusUpdate(emp, req);

            //Direct to ViewPendingRequisition
            Response.Redirect("ViewPendingRequisition.aspx");

        }
    }
}