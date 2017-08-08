using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS
{
    public partial class LoginTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request["username"];
            string password = Request["password"];
            string deptId = Request["deptId"];
            string empId = "";

            bool success = Membership.ValidateUser(username, password);

            if (success)
            {
                dynamic profile = ProfileBase.Create(username);
                empId = profile.empId;
                
                if(deptId != "")
                {
                    using(LUSSdb context = new LUSSdb())
                    {
                        int id = Convert.ToInt32(deptId);
                        int eid = Convert.ToInt32(empId);
                        if (context.Departments.FirstOrDefault(x => x.DeptId == id).DeptRep != eid)
                        {
                            success = false;
                        }
                    }
                }
            }

            string json = "{\"Success\":\""+ success + "\", \"EmpId\":\""+ empId + "\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}