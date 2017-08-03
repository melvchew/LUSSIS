using LUSSIS.RawCode.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS
{
    public partial class Redirect2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LUSSdb context = new LUSSdb();

            //List<Department> deptList = trendAnalysisBizLogic.getDepartmentList();

            IIdentity id = User.Identity;
            dynamic profile = ProfileBase.Create(id.Name);
            int empId = Convert.ToInt32(Session["empId"]);
            Employee emp = context.Employees.Where(x => x.EmpId == empId).First();
            Department dept = context.Departments.Where(x => x.DeptId == emp.DeptId).First();
            int deptRepId = dept.DeptRep;
            int? actingheadID = dept.ActingHead;
            string r = Convert.ToString(deptRepId);
            string ah = Convert.ToString(actingheadID);
            DateTime? ahStartDate = dept.AHStartDate;
            DateTime? ahEndDate = dept.AHEndDate;

            if (User.IsInRole("StoreClerk") ||
                User.IsInRole("StoreManager") ||
                User.IsInRole("StoreSupervisor"))
            {
                Session["storeEmpId"] = profile.empId;

            }

            else if (User.IsInRole("DeptEmp") ||
                User.IsInRole("DeptRep") ||
                 User.IsInRole("DeptHead") ||
                  User.IsInRole("DeptActingHead"))
            {
                Session["empId"] = profile.empId;


            }

            if (Session["empId"] == null && Session["storeEmpId"] == null)
                Response.Redirect("Login.aspx");

            else
            {

                if (User.IsInRole("StoreClerk"))
                {
                    Response.Redirect("~/View/StoreView/Home.aspx");
                }
                else if (User.IsInRole("StoreManager"))
                {
                    Response.Redirect("~/View/StoreView/Home.aspx");
                }
                else if (User.IsInRole("StoreSupervisor"))
                {
                    Response.Redirect("~/View/StoreView/Home.aspx");
                }
                else if (User.IsInRole("DeptEmp"))
                {
                    if (r != profile.empId && actingheadID == null)
                    {
                        Response.Redirect("~/View/DepartmentView/Home.aspx");
                    }
                    //DateTime? startDate = dept.AHStartDate;
                    //DateTime? endDate = dept.AHEndDate;
                    else if (r == profile.empId)
                    {
                        Roles.AddUserToRole(id.Name, "DeptRep");
                        Roles.RemoveUserFromRole(id.Name, "DeptEmp");
                        Response.Redirect("~/View/DepartmentView/Home.aspx");
                    }
                    else if (ah == profile.empId)
                    {
                        if (DateTime.Today >= ahStartDate)
                        {
                            Roles.AddUserToRole(id.Name, "DeptActingHead");
                            Roles.RemoveUserFromRole(id.Name, "DeptEmp");
                            Response.Redirect("~/View/DepartmentView/Home.aspx");
                        }
                    }
                    else
                        Response.Redirect("~/View/DepartmentView/Home.aspx");
                }
                else if (User.IsInRole("DeptActingHead"))
                {
                    if (actingheadID == null || ah != profile.empId || DateTime.Today > ahEndDate)
                    {
                        Roles.AddUserToRole(id.Name, "DeptEmp");
                        Roles.RemoveUserFromRole(id.Name, "DeptActingHead");

                    }
                    Response.Redirect("~/View/DepartmentView/Home.aspx");
                }
                else if (User.IsInRole("DeptRep"))
                {
                    if (deptRepId != profile.empId)
                    {
                        Roles.AddUserToRole(id.Name, "DeptEmp");
                        Roles.RemoveUserFromRole(id.Name, "DeptRep");
                    }
                    Response.Redirect("~/View/DepartmentView/Home.aspx");
                }
                else if (User.IsInRole("DeptHead"))
                {
                    Response.Redirect("~/View/DepartmentView/Home.aspx");
                }
           }
        }
    }
}