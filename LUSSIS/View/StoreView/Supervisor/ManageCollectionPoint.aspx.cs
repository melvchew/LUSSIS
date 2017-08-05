using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.View.StoreView.Supervisor
{
    public partial class ManageCollectionPoint : System.Web.UI.Page
    {
        static int cp1, cp2, cp3, cp4, cp5, cp6;

        ManageCollectionPointBLL mcp = new ManageCollectionPointBLL();
        //public void validate(int curSelEmp, int fixedEmp)
        //{
        //    if (StationeryStoreAdministrationBuilding.SelectedValue == MedicalSchool.SelectedValue)
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Red;
        //        MedicalSchool.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Black;
        //        MedicalSchool.ForeColor = System.Drawing.Color.Black;
        //    }
        //}
        //protected void StationeryStoreAdministrationBuilding_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (StationeryStoreAdministrationBuilding.SelectedValue == MedicalSchool.SelectedValue)
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Red;
        //        MedicalSchool.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Black;
        //        MedicalSchool.ForeColor = System.Drawing.Color.Black;
        //    }
        //    if (StationeryStoreAdministrationBuilding.SelectedValue == ScienceSchool.SelectedValue)
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Red;
        //        ScienceSchool.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        StationeryStoreAdministrationBuilding.ForeColor = System.Drawing.Color.Black;
        //        ScienceSchool.ForeColor = System.Drawing.Color.Black;
        //    }

        //}

        //protected void ManagementSchool_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ManagementSchool.SelectedValue == EngineeringSchool.SelectedValue ||
        //            ManagementSchool.SelectedValue == UniversityHospital.SelectedValue)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        //protected void MedicalSchool_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (StationeryStoreAdministrationBuilding.SelectedValue == MedicalSchool.SelectedValue ||
        //            MedicalSchool.SelectedValue == ScienceSchool.SelectedValue)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        //protected void EngineeringSchool_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (
        //            ManagementSchool.SelectedValue == EngineeringSchool.SelectedValue ||
        //            EngineeringSchool.SelectedValue == UniversityHospital.SelectedValue)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        //protected void ScienceSchool_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (StationeryStoreAdministrationBuilding.SelectedValue == ScienceSchool.SelectedValue ||
        //            MedicalSchool.SelectedValue == ScienceSchool.SelectedValue)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        //protected void UniversityHospital_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ManagementSchool.SelectedValue == UniversityHospital.SelectedValue ||
        //            EngineeringSchool.SelectedValue == UniversityHospital.SelectedValue)
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Red;
        //        Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
        //        return;
        //    }
        //    else
        //    {
        //        Label2.ForeColor = System.Drawing.Color.Black;
        //    }
        //}

        LUSSdb context = new LUSSdb();
        CollectionPoint d = new CollectionPoint();
        List<CollectionPoint> list = new List<CollectionPoint>();



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                list = mcp.getCollectionPoints();
                List<int> idList = new List<int>();
                List<String> timingList = new List<string>();
                int i = 0;
                foreach (var cp in list)
                {
                    i++;
                    switch (i)
                    {
                        case 1:
                            cp1 = cp.CollectionPointId;
                            CPT1.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT1.Text);
                            break;
                        case 2:
                            cp2 = cp.CollectionPointId;
                            CPT2.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT2.Text);
                            break;
                        case 3:
                            cp3 = cp.CollectionPointId;
                            CPT3.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT3.Text);
                            break;
                        case 4:
                            cp4 = cp.CollectionPointId;
                            CPT4.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT4.Text);
                            break;
                        case 5:
                            cp5 = cp.CollectionPointId;
                            CPT5.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT5.Text);
                            break;
                        case 6:
                            cp6 = cp.CollectionPointId;
                            CPT6.Text = cp.CollectionTime + " AM";
                            timingList.Add(CPT6.Text);
                            break;
                    }
                }


                //Assigning Store Employee Name to Text Fields
                StationeryStoreAdministrationBuilding.DataSource = mcp.getEmployees();
                StationeryStoreAdministrationBuilding.DataBind();
                StationeryStoreAdministrationBuilding.DataTextField = "Name";
                StationeryStoreAdministrationBuilding.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp1);
                StationeryStoreAdministrationBuilding.SelectedValue = d.StoreEmpId.ToString();
                StationeryStoreAdministrationBuilding.DataBind();

                ManagementSchool.DataSource = mcp.getEmployees();
                ManagementSchool.DataBind();
                ManagementSchool.DataTextField = "Name";
                ManagementSchool.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp2);
                ManagementSchool.SelectedValue = d.StoreEmpId.ToString();
                ManagementSchool.DataBind();

                MedicalSchool.DataSource = mcp.getEmployees();
                MedicalSchool.DataBind();
                MedicalSchool.DataTextField = "Name";
                MedicalSchool.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp3);
                MedicalSchool.SelectedValue = d.StoreEmpId.ToString();
                MedicalSchool.DataBind();

                EngineeringSchool.DataSource = mcp.getEmployees();
                EngineeringSchool.DataBind();
                EngineeringSchool.DataTextField = "Name";
                EngineeringSchool.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp4);
                EngineeringSchool.SelectedValue = d.StoreEmpId.ToString();
                EngineeringSchool.DataBind();

                ScienceSchool.DataSource = mcp.getEmployees();
                ScienceSchool.DataBind();
                ScienceSchool.DataTextField = "Name";
                ScienceSchool.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp5);
                ScienceSchool.SelectedValue = d.StoreEmpId.ToString();
                ScienceSchool.DataBind();

                UniversityHospital.DataSource = mcp.getEmployees();
                UniversityHospital.DataBind();
                UniversityHospital.DataTextField = "Name";
                UniversityHospital.DataValueField = "StoreEmpId";
                d = mcp.getCurStoreEmplyeeInDisbursement(cp6);
                UniversityHospital.SelectedValue = d.StoreEmpId.ToString();
                UniversityHospital.DataBind();
            }
        }



        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            //Validate if store clerk is assigned properly
            try
            {
                if (StationeryStoreAdministrationBuilding.SelectedValue == MedicalSchool.SelectedValue ||
                    StationeryStoreAdministrationBuilding.SelectedValue == ScienceSchool.SelectedValue ||
                    MedicalSchool.SelectedValue == ScienceSchool.SelectedValue ||
                    ManagementSchool.SelectedValue == EngineeringSchool.SelectedValue ||
                    ManagementSchool.SelectedValue == UniversityHospital.SelectedValue ||
                    EngineeringSchool.SelectedValue == UniversityHospital.SelectedValue)
                {
                    Response.Write("<script>alert('Store Employee Cannot be in different place at the same time!')</script>");
                    return;
                }
                else
                {
                    //Update Database
                mcp.UpdateStoreEmployeeInDisbursement(cp1, StationeryStoreAdministrationBuilding.SelectedValue);
                    mcp.UpdateStoreEmployeeInDisbursement(cp2, ManagementSchool.SelectedValue);
                    mcp.UpdateStoreEmployeeInDisbursement(cp3, MedicalSchool.SelectedValue);
                    mcp.UpdateStoreEmployeeInDisbursement(cp4, EngineeringSchool.SelectedValue);
                    mcp.UpdateStoreEmployeeInDisbursement(cp5, ScienceSchool.SelectedValue);
                    mcp.UpdateStoreEmployeeInDisbursement(cp6, UniversityHospital.SelectedValue);
                    Response.Write("<script>alert('Updated Successfully')</script>");
                }
            }
            catch (Exception excep)
            {
                Response.Write("<script>alert('Error')</script>");
            }
        }
    }
}