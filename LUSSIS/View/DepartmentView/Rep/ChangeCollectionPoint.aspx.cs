using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.DepartmentView.Rep
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
        //Session ID needed for current dept

        static int curDeptId;
        RolesManagementBLL rm = new RolesManagementBLL();
        ManageCollectionPointBLL mcp = new ManageCollectionPointBLL();
        Department dept = new Department();
        static int cpId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            Employee emp = rm.GetEmpByID(Convert.ToInt32(Session["empId"]));
            Department dep = rm.GetDeptByUser(emp);
            curDeptId = dep.DeptId;
            dept = mcp.GetCurrentDeptById(curDeptId);
            getCurrentCollectionPoint(dept.CollectionPointId);
        }

        public void getCurrentCollectionPoint(int cpId)
        {
            CollectionPoint ccp = mcp.getCollectionPointById(cpId);
            CurCP.Text = ccp.Description;
            CurCT.Text = ccp.CollectionTime;
        }

        public void getChangedCollectionPointTime(int id)
        {
            CollectionPoint ccp = mcp.getCollectionPointById(id);
            ChangedCT.Text = ccp.CollectionTime;
            cpId = id;
        }

        protected void CollectionPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            getChangedCollectionPointTime(Convert.ToInt32(CollectionPoints.SelectedValue));
        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            mcp.changeCollectionPoint(cpId, curDeptId);
            Response.Write("<script>alert('Collection Point Changed Successfully')</script>");
            getChangedCollectionPointTime(cpId);
            getCurrentCollectionPoint(cpId);
            mcp.SendChangeNotification(new Department(), curDeptId);
            //s.notification(s.getEmployees());
        }
    }
}




