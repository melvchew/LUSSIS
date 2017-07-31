using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.BLL.data.Kavya;
using LUSSIS.RawCode.DAL;
using System.Net.Mail;


namespace LUSSIS.RawCode.BLL.data.Kavya
{
    public class ManageCollectionPointBLL
    {

        LUSSdb context = new LUSSdb();
        public List<CollectionPoint> getCollectionPoints()
        {
            return context.CollectionPoints.ToList();
        }

        public List<StoreEmployee> getEmployees()
        {
            return context.StoreEmployees.Where(x => x.Position == "Clerk").ToList();
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
        public Disbursement GetDisbursementByID(int id)
        {
            return context.Disbursements.Where(x => x.DisbursementId == id).First<Disbursement>();
        }

        public List<String> GetCollectionItemList(DateTime disDate, Department dep)
        {
            List<String> list = new List<String>();
            Disbursement d = new Disbursement();
            d = context.Disbursements.FirstOrDefault(x => x.DisburseDate == disDate && x.Department.DeptId == dep.DeptId);
            foreach (var item in d.DisburseReqItems)
            {
                list.Add(item.Item.Description);
                list.Add(item.RetrieveQty.ToString());
                list.Add(item.Item.Unit);
            }
            return list;
        }


        public void SendChangeNotification(Department dept, int deptId)
        {
            dept = GetCurrentDeptById(deptId);
            {
                List<StoreEmployee> ListStoreEmp = getEmployees();

                if (ListStoreEmp == null)
                {
                    //throw Exception;
                }

                foreach (var emp in ListStoreEmp)
                {
                    if (emp != null)
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailMessage mm = new MailMessage("lusissa44@gmail.com", "eliza.rkz@gmail.com"); //emp.Email);
                        mm.Subject = "Collection Point Changed " + dept.DeptName;
                        mm.Body = $"{dept.DeptName} has changed the current collection point to {dept.CollectionPoint.Description}\n\nThis is an auto generated email, please do not reply to this email";

                        client.Send(mm);
                    }
                }
            }
        }
    }
}
