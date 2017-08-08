using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;
using System.Net.Mail;

namespace LUSSIS.RawCode.BLL
{
    public class ManageCollectionPointBLL
    {

        //Created by Kavya

        LUSSdb context = new LUSSdb();
        public List<CollectionPoint> getCollectionPoints()
        {
            return context.CollectionPoints.ToList();
        }

        public List<StoreEmployee> getEmployees()
        {
            return context.StoreEmployees.Where(x => x.Position == "Clerk").ToList();
        }

        public List<StoreEmployee> getListedEmployees(int empId)
        {
            return context.StoreEmployees.Where(x => x.Position == "Clerk" && x.StoreEmpId != empId).ToList();
        }

        public List<CollectionPoint> getEmployeeCollectionPoints(int empId)
        {
            return context.CollectionPoints.Where(x => x.StoreEmpId == empId).ToList();
        }

        public CollectionPoint getCurStoreEmplyeeInDisbursement(int cpId)
        {
            return context.CollectionPoints.Where(x => x.CollectionPointId == cpId).First<CollectionPoint>();
        }

        public void UpdateStoreEmployeeInDisbursement(int cpId, String StoreEmpId)
        {
            CollectionPoint cp = context.CollectionPoints.Where(x => x.CollectionPointId == cpId).First<CollectionPoint>();
            cp.StoreEmpId = Int32.Parse(StoreEmpId);
            context.SaveChanges();
        }
        public Department GetCurrentDeptById(int depId)   // Used also in ViewCollectionItemsBLL.cs
        {
            return context.Departments.Where(x => x.DeptId == depId).FirstOrDefault();
        }

        public CollectionPoint getCollectionPointById(int id)
        {
            return context.CollectionPoints.Where(x => x.CollectionPointId == id).First<CollectionPoint>();
        }

        public void changeCollectionPoint(int cpId, int deptId)
        {
            Department cp = context.Departments.Where(x => x.DeptId == deptId).First<Department>();
            cp.CollectionPointId = cpId;
            context.SaveChanges();
        }

        public List<RequisitionItem> GetCollectionItems(Disbursement dis)
        {
            List<String> ListItem = null;

            List<Requisition> req = context.Requisitions.Where(x => x.Status == ((int)ReqStatus.APPROVED).ToString()).ToList<Requisition>();
            foreach (Requisition i in req)
            {
                foreach(RequisitionItem j in i.RequisitionItems)
                {
                   ListItem.Add(j.Item.Description);
                   ListItem.Add(j.Quantity.ToString());
                   ListItem.Add(j.Item.Unit);
                }
            }
            return new List<RequisitionItem>();
         }


        public List<RequisitionItem> GetAllApprovedRequsitionItemsByDepartment(Department dep)
        {
            //List <Requisition> req = context.Requisitions.Where(x => x.Status == ((ReqStatus.APPROVED).ToString()) && x.Employee.DeptId == dep.DeptId).ToList<Requisition>();
            List<RequisitionItem> reqitems = context.RequisitionItems.Where(y => y.Requisition.Status == ((ReqStatus.APPROVED).ToString()) && y.Requisition.Employee.DeptId == dep.DeptId).ToList();
            return reqitems;
        }

    }
} 