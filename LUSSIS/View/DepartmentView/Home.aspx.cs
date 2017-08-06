using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;

namespace LUSSIS.View.DepartmentView
{
    public partial class Home : System.Web.UI.Page
    {
        HomePageBLL bll = new HomePageBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int eId = Convert.ToInt32(Session["empId"]);
            Employee currentEmp = bll.GetDeptEmployee(eId);
            lblUserName.Text = currentEmp.Name;

            if (User.IsInRole("DeptEmp"))
            {
                List<ConsolidateItem> conItemList = bll.GetRequiredConItemList(eId).Take(5).ToList();
                litDeptEmpUndelTotal.Text = conItemList.Select(x => x.Qty).Sum().ToString();

                //fill up grid
                gvDeptEmpUndelItems.DataSource = conItemList;
                gvDeptEmpUndelItems.DataBind();

                //get pending reqs
                List<Requisition> pendingReqList = bll.GetPendingRequitions(eId).Take(5).ToList();
                litDeptEmpPendingToal.Text = pendingReqList.Count.ToString();

                //fill up grid
                gvDeptEmpPendingTotal.DataSource = pendingReqList;
                gvDeptEmpPendingTotal.DataBind();
            } else if (User.IsInRole("DeptRep"))
            {
                List<ConsolidateItem> conItemList = bll.GetRequiredConItemList(eId).Take(5).ToList();
                litDeptRepUndelTotal.Text = conItemList.Select(x => x.Qty).Sum().ToString();

                //fill up grid
                gvDeptRepUndelItems.DataSource = conItemList;
                gvDeptRepUndelItems.DataBind();

                //get pending reqs
                List<Requisition> pendingReqList = bll.GetPendingRequitions(eId);
                litDeptRepPendingToal.Text = pendingReqList.Count.ToString();

                //fill up grid
                gvDeptRepPendingTotal.DataSource = pendingReqList;
                gvDeptRepPendingTotal.DataBind();
            } else if (User.IsInRole("DeptHead"))
            {
                List<Requisition> pendingReqList = bll.GetPendingRequitions(depId:currentEmp.DeptId);
                litDeptHeadPendingReqTotal.Text = pendingReqList.Count.ToString();

                gvDeptHeadPendingReq.DataSource = pendingReqList;
                gvDeptHeadPendingReq.DataBind();

                Department currentDept = bll.GetDepartment(currentEmp.DeptId);
                litDeptHeadCurrentRep.Text =  bll.GetDeptEmployee(currentDept.DeptRep).Name;
                litDeptHeadCurrentAH.Text = currentDept.ActingHead == null ? "none" : bll.GetDeptEmployee((int)currentDept.ActingHead).Name;

            } else if (User.IsInRole("DeptActingHead"))
            {
                List<Requisition> pendingReqList = bll.GetPendingRequitions(depId: currentEmp.DeptId);
                litDeptAHPendingReqTotal.Text = pendingReqList.Count.ToString();

                gvDeptAHPendingReq.DataSource = pendingReqList;
                gvDeptAHPendingReq.DataBind();
            }
        }
    }
}