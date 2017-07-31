/*
 * Developed By : Kavya Elizabeth James 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LUSSIS.Department
{
    public partial class ManageCollectionPoint : System.Web.UI.Page
    {

        static int cp1, cp2, cp3, cp4, cp5, cp6;

        Service s = new Service();
        LUSS2 context = new LUSS2();
        CollectionPoint d = new CollectionPoint();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<CollectionPoint> list = s.getCollectionPoints();
                int i = 0;
                foreach (var cp in list)
                {
                    i++;
                    switch (i)
                    {
                        case 1:
                            cp1 = cp.CollectionPointId;
                            CPT1.Text = cp.CollectionTime + " AM";
                            break;
                        case 2:
                            cp2 = cp.CollectionPointId;
                            CPT2.Text = cp.CollectionTime + " AM";
                            break;
                        case 3:
                            cp3 = cp.CollectionPointId;
                            CPT3.Text = cp.CollectionTime + " AM";
                            break;
                        case 4:
                            cp4 = cp.CollectionPointId;
                            CPT4.Text = cp.CollectionTime + " AM";
                            break;
                        case 5:
                            cp5 = cp.CollectionPointId;
                            CPT5.Text = cp.CollectionTime + " AM";
                            break;
                        case 6:
                            cp6 = cp.CollectionPointId;
                            CPT6.Text = cp.CollectionTime + " AM";
                            break;
                    }
                }
                StationeryStoreAdministrationBuilding.DataSource = s.getEmployees();
                StationeryStoreAdministrationBuilding.DataBind();
                StationeryStoreAdministrationBuilding.DataTextField = "Name";
                StationeryStoreAdministrationBuilding.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp1);
                StationeryStoreAdministrationBuilding.SelectedValue = d.StoreEmpId.ToString();
                StationeryStoreAdministrationBuilding.DataBind();

                ManagementSchool.DataSource = s.getEmployees();
                ManagementSchool.DataBind();
                ManagementSchool.DataTextField = "Name";
                ManagementSchool.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp2);
                ManagementSchool.SelectedValue = d.StoreEmpId.ToString();
                ManagementSchool.DataBind();

                MedicalSchool.DataSource = s.getEmployees();
                MedicalSchool.DataBind();
                MedicalSchool.DataTextField = "Name";
                MedicalSchool.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp3);
                MedicalSchool.SelectedValue = d.StoreEmpId.ToString();
                MedicalSchool.DataBind();

                EngineeringSchool.DataSource = s.getEmployees();
                EngineeringSchool.DataBind();
                EngineeringSchool.DataTextField = "Name";
                EngineeringSchool.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp4);
                EngineeringSchool.SelectedValue = d.StoreEmpId.ToString();
                EngineeringSchool.DataBind();

                ScienceSchool.DataSource = s.getEmployees();
                ScienceSchool.DataBind();
                ScienceSchool.DataTextField = "Name";
                ScienceSchool.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp5);
                ScienceSchool.SelectedValue = d.StoreEmpId.ToString();
                ScienceSchool.DataBind();

                UniversityHospital.DataSource = s.getEmployees();
                UniversityHospital.DataBind();
                UniversityHospital.DataTextField = "Name";
                UniversityHospital.DataValueField = "StoreEmpId";
                d = s.getCurStoreEmplyeeInDisbursement(cp6);
                UniversityHospital.SelectedValue = d.StoreEmpId.ToString();
                UniversityHospital.DataBind();
            }
        }



        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            s.UpdateStoreEmployeeInDisbursement(cp1, StationeryStoreAdministrationBuilding.SelectedValue);
            s.UpdateStoreEmployeeInDisbursement(cp2, ManagementSchool.SelectedValue);
            s.UpdateStoreEmployeeInDisbursement(cp3, MedicalSchool.SelectedValue);
            s.UpdateStoreEmployeeInDisbursement(cp4, EngineeringSchool.SelectedValue);
            s.UpdateStoreEmployeeInDisbursement(cp5, ScienceSchool.SelectedValue);
            s.UpdateStoreEmployeeInDisbursement(cp6, UniversityHospital.SelectedValue);
            Response.Write("<script>alert('Updated Successfully')</script>");
        }

        public bool checkForNine(int userId)
        {
            int cp1 = context.CollectionPoints.Where(x => x.CollectionPointId == 1).First<CollectionPoint>().StoreEmpId;
            int cp3 = context.CollectionPoints.Where(x => x.CollectionPointId == 3).First<CollectionPoint>().StoreEmpId;
            int cp4 = context.CollectionPoints.Where(x => x.CollectionPointId == 5).First<CollectionPoint>().StoreEmpId;

            List<int> empIdList = new List<int>() { cp1, cp3, cp4 };

            if (empIdList.Contains(userId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkForEleven(int userId)
        {
            int cp1 = context.CollectionPoints.Where(x => x.CollectionPointId == 2).First<CollectionPoint>().StoreEmpId;
            int cp3 = context.CollectionPoints.Where(x => x.CollectionPointId == 4).First<CollectionPoint>().StoreEmpId;
            int cp4 = context.CollectionPoints.Where(x => x.CollectionPointId == 5).First<CollectionPoint>().StoreEmpId;

            List<int> empIdList = new List<int>() { cp1, cp3, cp4 };

            if (empIdList.Contains(userId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}