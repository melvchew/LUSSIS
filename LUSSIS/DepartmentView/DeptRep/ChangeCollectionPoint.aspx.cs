using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.DepartmentView.DeptRep
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
        //Session ID needed for current dept

        static int curDeptId;
        Service s = new Service();
        Department dept = new Department();
        static int cpId = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["DepartmentId"] = 1;
            curDeptId = Convert.ToInt32(Session["DepartmentId"]);
            dept = s.GetCurrentDeptById(curDeptId);
            getCurrentCollectionPoint(dept.CollectionPointId);
        }

        public void getCurrentCollectionPoint(int cpId)
        {
            CollectionPoint ccp = s.getCollectionPointById(cpId);
            CurCP.Text = ccp.Description;
            CurCT.Text = ccp.CollectionTime;
        }

        public void getChangedCollectionPointTime(int id)
        {
            CollectionPoint ccp = s.getCollectionPointById(id);
            ChangedCT.Text = ccp.CollectionTime;
            cpId = id;
        }

        protected void CollectionPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            getChangedCollectionPointTime(Convert.ToInt32(CollectionPoints.SelectedValue));
        }

        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            s.changeCollectionPoint(cpId, curDeptId);
            Response.Write("<script>alert('Collection Point Changed Successfully')</script>");
            getChangedCollectionPointTime(cpId);
            getCurrentCollectionPoint(cpId);
            s.SendChangeNotification(new Department(), curDeptId);
            //s.notification(s.getEmployees());
        }
    }
}




/*if (sender is RadioButton)
   {
       RadioButton radioButton = (RadioButton)sender;
       if (radioButton.Checked)
       {
           getCollectionPointTime(1);
       }

       ChangedCT.Text = "AAAAA";
       if (ScienceSchool.Checked == true)
       {
getColl
