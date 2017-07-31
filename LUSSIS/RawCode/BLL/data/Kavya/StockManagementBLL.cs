using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Kavya
{
    public class StockManagementBLL
    {
        public Department GetCurrentDeptById(int depId)  // Used also in ChangeCollectionPointBLL.cs
        {
            return context.Departments.Where(x => x.DeptId == depId).FirstOrDefault();
        }

        public Disbursement GetDisbursement(DateTime disDate, Department dep)
        {
            String s = disDate.ToString("dd/MM/yyyy");
            DateTime d = Convert.ToDateTime(s);
            return context.Disbursements.Where(x => x.DisburseDate == d && x.Department.DeptId == dep.DeptId).First<Disbursement>();
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

        public Disbursement GetDisbursementByID(int id)
        {
            return context.Disbursements.Where(x => x.DisbursementId == id).First<Disbursement>();
        }

        public CollectionPoint GetCollectionPointOfDepartment(Department dep)
        {
            return context.CollectionPoints.Where(x => x.CollectionPointId == dep.CollectionPointId).First<CollectionPoint>();
        }
    }
}