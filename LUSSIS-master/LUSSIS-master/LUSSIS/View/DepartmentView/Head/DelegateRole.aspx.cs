using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.Khin;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.DepartmentView.Head
{
    public partial class DelegateRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RolesManagementBLL b = new RolesManagementBLL();

                ddActingHead.DataSource = b.getEmployeeListByDept(1);//ID depends on login user
                ddActingHead.DataTextField = "Name";
                ddActingHead.DataValueField = "EmpId";
                ddActingHead.DataBind();
                ddActingHead.Items.Insert(0, new ListItem(String.Empty, string.Empty));
                ddActingHead.SelectedIndex = 0;

                ddDeptRepre.DataSource = b.getEmployeeListByDept(1);//ID depends on login user
                ddDeptRepre.DataTextField = "Name";
                ddDeptRepre.DataValueField = "EmpId";
                ddDeptRepre.DataBind();



                if (b.getCurrentActingHead(1) != null)
                {
                    Employee currentActingHead = b.getCurrentActingHead(1);//ID depends on login user
                    lblCurrentActingHead.Text = currentActingHead.Name.ToString();
                    ddActingHead.SelectedValue = currentActingHead.EmpId.ToString();
                }
                else
                {
                    lblCurrentActingHead.Text = "There is no Department Acting Head.";
                }
                if (b.getCurrentDeptRep(1) != null)
                {
                    Employee currentDeptRep = b.getCurrentDeptRep(1);//ID depends on login user
                    lblCurrentDeptRep.Text = currentDeptRep.Name.ToString();
                    ddDeptRepre.SelectedValue = currentDeptRep.EmpId.ToString();
                }
                else
                {
                    lblCurrentDeptRep.Text = "There is no Department Representative.";
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddActingHead.SelectedValue == ddDeptRepre.SelectedValue)
            {
                lblerror.Text = "Acting Head and Department Representative can't be same.";
            }
            else if (ddActingHead.SelectedValue != "")
            {
                if (txtFromDate.Text == "")
                {
                    lblerror.Text = "Date need to choose.";
                }
                else if (txtToDate.Text == "")
                {
                    lblerror.Text = "Date need to choose.";
                }
                else if (DateTime.Compare(DateTime.Now, DateTime.Parse(txtFromDate.Text)) > 0)
                {
                    lblerror.Text = "From date must be later than current date";
                }
                else if (DateTime.Compare(DateTime.Parse(txtFromDate.Text), DateTime.Parse(txtToDate.Text)) > 0)
                {
                    lblerror.Text = "To date must be later than From date";
                }
                else
                {
                    RolesManagementBLL b = new RolesManagementBLL();
                    Department d = new Department();
                    d.DeptId = 1;// ID depends on login user
                    d.ActingHead = Convert.ToInt32(ddActingHead.SelectedValue);
                    d.DeptRep = Convert.ToInt32(ddDeptRepre.SelectedValue);
                    d.AHStartDate = DateTime.Parse(txtFromDate.Text);
                    d.AHEndDate = DateTime.Parse(txtToDate.Text);
                    bool update = b.delegateRoles(d);
                    if (update)
                    {
                        lblerror.Text = "Delegate Successful";
                    }
                    else
                    {
                        lblerror.Text = "Delegate Fail";
                    }
                }
            }

            else
            {
                RolesManagementBLL b = new RolesManagementBLL();
                Department d = new Department();
                d.DeptId = 1;// ID depends on login user
                d.DeptRep = Convert.ToInt32(ddDeptRepre.SelectedValue);
                bool update = b.delegateRoles(d);
                if (update)
                {
                    lblerror.Text = "Delegate Successful";
                }
                else
                {
                    lblerror.Text = "Delegate Fail";
                }
            }
        }
    }
}