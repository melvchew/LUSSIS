using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.BLL;

namespace LUSSIS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAndroid" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAndroid.svc or ServiceAndroid.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAndroid : IServiceAndroid
    {
        RequisitionBLL rBLL = new RequisitionBLL();
        StockManagementBLL smBLL = new StockManagementBLL();
        RolesManagementBLL rmBLL = new RolesManagementBLL();
        
        public List<WCFRequisition> ListPending(string id)
        {
            //LUSS ctx = new EF.LUSS();
            Employee user = rmBLL.GetEmpByID(Convert.ToInt16(id));
            Department dept = rmBLL.GetDeptByUser(user);
            //List<Requisition> Lreq = ctx.Requisitions.Where(x => x.Status == "PENDING").ToList<Requisition>();
            List<Requisition> Lreq = rBLL.GetPendingReqByDepartment(dept);
            List<WCFRequisition> LWCFreq = new List<WCFRequisition>();
            foreach (Requisition r in Lreq)
            {
                Employee emp = rmBLL.GetEmpByID(r.EmpId);
                //Employee emp = ctx.Employees.Where(x => x.EmpId == r.EmpId).FirstOrDefault<Employee>();
                WCFRequisition WCFr = WCFRequisition.Make(r.ReqId, r.EmpId, emp.Name, r.SubmitDate.ToString(), r.ApproveBy, r.ApproveDate.ToString(), r.Status, r.EmpComments, r.ApproverComments);
                LWCFreq.Add(WCFr);
            }
            return LWCFreq;
        }


        public WCFRequisition GetRequisition(string id)
        {
            //LUSSdb ctx = new LUSS();
            Requisition r = rBLL.GetReq(Convert.ToInt16(id));
            //Requisition r = ctx.Requisitions.Where(x => x.ReqId.ToString() == id).First<Requisition>();
            Employee emp = rmBLL.GetEmpByID(r.EmpId);
            WCFRequisition WCFr = WCFRequisition.Make(r.ReqId, r.EmpId, emp.Name, r.SubmitDate.ToString(), r.ApproveBy, r.ApproveDate.ToString(), r.Status, r.EmpComments, r.ApproverComments);
            return WCFr;
        }


        public List<WCFRequisitionItem> GetReqItems(string id)
        {
            //LUSS ctx = new EF.LUSS();
            Requisition r = rBLL.GetReq(Convert.ToInt16(id));
            List<RequisitionItem> Lreqitems = rBLL.GetListOfRequisitionItems(r);
            List<Item> Litems = smBLL.GetItemList();
            //List <RequisitionItem> Lreqitems = ctx.RequisitionItems.Where(x => x.ReqId.ToString() == id).ToList<RequisitionItem>();
            List<WCFRequisitionItem> LWCFreqItems = new List<WCFRequisitionItem>();
            foreach (RequisitionItem reqitem in Lreqitems)
            {
                //Item item = ctx.Items.Where(x => x.ItemId == reqitem.ItemId).FirstOrDefault<Item>();
                Item item = Litems.Where(x => x.ItemId == reqitem.ItemId).FirstOrDefault<Item>();
                WCFRequisitionItem WCFreq = WCFRequisitionItem.Make(reqitem.ReqId, reqitem.ItemId, item.Description, reqitem.Quantity);
                LWCFreqItems.Add(WCFreq);
            }
            return LWCFreqItems;
        }


        public WCFEmployee GetEmpById(string id)
        {
            //LUSS ctx = new LUSS();
            Employee emp = rmBLL.GetEmpByID(Convert.ToInt16(id));
            //Employee emp = ctx.Employees.Where(x => x.EmpId.ToString() == id).First<Employee>();
            WCFEmployee WCFemp = WCFEmployee.Make(emp.EmpId, emp.Name, emp.Position, emp.Phone, emp.Email, emp.DeptId);
            return WCFemp;
        }


        public void ApproveReq(WCFRequisition r)
        {
            Requisition req = new Requisition
            {
                ReqId = r.reqid,
                EmpId = r.empid,
                //SubmitDate = r.submitdate,
                ApproveBy = r.approveby,
                //ApproveDate = (Date) r.approvedate,
                Status = r.status,
                EmpComments = r.empcomments,
                ApproverComments = r.approvercomments
            };
            
            rBLL.ApproveReq(req, (int)req.ApproveBy);
        }

        public void RejectReq(WCFRequisition r)
        {
            Requisition req = new Requisition
            {
                ReqId = r.reqid,
                EmpId = r.empid,
                //SubmitDate = Convert.ToDateTime(r.submitdate),
                ApproveBy = r.approveby,
                //ApproveDate = Convert.ToDateTime(r.approvedate),
                Status = r.status,
                EmpComments = r.empcomments,
                ApproverComments = r.approvercomments
            };
            
            rBLL.RejectReq(req, (int)req.ApproveBy);
        }

        public void AppointDeptRep(WCFDepartment d)
        {
            string startdate = d.ahstartdd + "/" + d.ahstartmm + "/" + d.ahstartyy;
            string enddate = d.ahenddd + "/" + d.ahendmm + "/" + d.ahendyy;
            Department dept = new Department
            {
                DeptId = d.deptid,
                DeptRep = d.rep,
                //ActingHead = d.ah,
                //AHStartDate = Convert.ToDateTime(startdate),
                //AHEndDate = Convert.ToDateTime(enddate)
            };
            rmBLL.AppointRep(dept);
        }
        public void AppointDeptAH(WCFDepartment d)
        {
            string startdate = d.ahstartdd + "/" + d.ahstartmm + "/" + d.ahstartyy;
            string enddate = d.ahenddd + "/" + d.ahendmm + "/" + d.ahendyy;
            Department dept = new Department
            {
                DeptId = d.deptid,
                DeptRep = d.rep,
                ActingHead = d.ah,
                AHStartDate = Convert.ToDateTime(startdate),
                AHEndDate = Convert.ToDateTime(enddate)
            };

            rmBLL.AppointAH(dept);
        }

        public WCFEmployee getCurrentDeptRep(string departmentID)
        {
            Employee emp = rmBLL.getCurrentDeptRep(Convert.ToInt32(departmentID));
            WCFEmployee wcfemp = WCFEmployee.Make(emp.EmpId, emp.Name, emp.Position, emp.Phone, emp.Email, emp.DeptId);
            return wcfemp;
        }

        public WCFEmployee getCurrentActingHead(string departmentID)
        {

            Employee emp = rmBLL.getCurrentActingHead(Convert.ToInt32(departmentID));
            WCFEmployee wcfemp = WCFEmployee.Make(emp.EmpId, emp.Name, emp.Position, emp.Phone, emp.Email, emp.DeptId);
            return wcfemp;

        }




        public List<WCFEmployee> ListEmpByDept(string id)
        {
            List<Employee> Lemp = rmBLL.getEmployeeListByDept(Convert.ToInt32(id));
            List<WCFEmployee> WCFLemp = new List<WCFEmployee>();
            foreach (Employee emp in Lemp)
            {
                //Employee emp = s.GetEmpByID(r.EmpId);
                //Employee emp = ctx.Employees.Where(x => x.EmpId == r.EmpId).FirstOrDefault<Employee>();
                WCFEmployee wcfemp = WCFEmployee.Make(emp.EmpId, emp.Name, emp.Position, emp.Phone, emp.Email, emp.DeptId);
                WCFLemp.Add(wcfemp);
            }
            return WCFLemp;
        }

        public WCFDepartment GetDept(string id)
        {
            Department dept = rmBLL.GetDeptByID(Convert.ToInt32(id));
            //WCFDepartment WCFdept = WCFDepartment.Make(1, 1, 1, "01", "01", "01", "01", "01", "01");
            WCFDepartment WCFdept = WCFDepartment.Make(dept.DeptId, dept.DeptRep, dept.ActingHead, "", "", "", "", "", "");
            return WCFdept;
        }


    }
}
