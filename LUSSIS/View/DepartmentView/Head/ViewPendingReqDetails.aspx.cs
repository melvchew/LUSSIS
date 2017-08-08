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
    public partial class ViewPendingReqDetails : System.Web.UI.Page
    {
        RolesManagementBLL rmBLL = new RolesManagementBLL();
        EmailBLL eBLL = new EmailBLL();
        RequisitionBLL rBLL = new RequisitionBLL();
        StockManagementBLL sBLL = new StockManagementBLL();

        
        Requisition req;
        Employee emp;


        //Employee boss;
        Employee boss;
        //int bossid;
        //Department dept;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Approve.BackColor = System.Drawing.Color.FromArgb(255, 39, 174, 96);
            Button_Reject.BackColor = System.Drawing.Color.FromArgb(255, 192, 57, 43);

            //Get Employee Object of boss
            //bossid = 1;
            boss = rmBLL.GetEmpByID(Convert.ToInt32(Session["empId"]));
            //get user ID from session

            //Create Requisition object with ID pass from previous page
            //req = s.GetReq(6); //Hardcoded for testing
            req = rBLL.GetReq(Convert.ToInt16(Request.QueryString["ReqId"]));

            //Employee that raised requisition
            emp = rmBLL.GetEmpByID(req.EmpId);


            List<Item> itemList = sBLL.GetItemList();
            List<Employee> Lemp = rmBLL.GetEmployees();

            //Bind the grid view with the requisition items
            List<RequisitionItem> ListItems = rBLL.GetListOfRequisitionItems(req);
            GridView_PendingReq.DataSource = ListItems.Select(o => new { Name = itemList.FirstOrDefault(x => x.ItemId == o.ItemId).Description, Quantity = o.Quantity });
            GridView_PendingReq.DataBind();

            //Bind the text of the label using req obj
            Label_RaisedBy.Text = Lemp.FirstOrDefault(x => x.EmpId == req.EmpId).Name;
            Label_ReqDate.Text = String.Format("{0:D}", req.SubmitDate);
            Label_ReqID.Text = req.ReqId.ToString();
            Label_EmpComments.Text = req.EmpComments;
        }

        protected void Button_Approve_Click(object sender, EventArgs e)
        {
            //Get comments
            req.ApproverComments = TextBox_HeadComment.Text;
            if(req.ApproverComments.Length > 50)
            {
                //string comments = "Comments is too long!";
                HttpContext.Current.Response.Write("<script>alert('Comments are too long!')</script>");
                return;
            }
            //Approve requisition
            rBLL.ApproveReq(req, boss.EmpId);

            //Send Notification
            eBLL.SendRequisitionStatusUpdate(emp, req);

            //Direct to ViewPendingRequisition
            Response.Redirect("ViewPendingReq.aspx");

        }

        protected void Button_Reject_Click(object sender, EventArgs e)
        {
            //Get comments
            req.ApproverComments = TextBox_HeadComment.Text;
            if (req.ApproverComments.Length > 50)
            {
                //string comments = "Comments is too long!";
                HttpContext.Current.Response.Write("<script>alert('Comments are too long!')</script>");
                return;
            }
            //Reject requisition
            rBLL.RejectReq(req, boss.EmpId);

            //Send Notification
            eBLL.SendRequisitionStatusUpdate(emp, req);

            //Direct to ViewPendingRequisition
            Response.Redirect("ViewPendingReq.aspx");

        }
    }
}