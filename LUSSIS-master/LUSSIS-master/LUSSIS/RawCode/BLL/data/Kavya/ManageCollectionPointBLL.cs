using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Kavya
{
    public class ManageCollectionPointBLL
    {
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
    }
}