using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Melvin
{
    public class RequisitionBLL
    {

        //Melvin

        public void ApproveReq(Requisition req, int bossid)
        {
            {
                DateTime date = DateTime.Now.Date;
                Requisition requisition = ctx.Requisitions.FirstOrDefault(r => r.ReqId == req.ReqId);
                requisition.Status = (ReqStatus.APPROVED).ToString();
                requisition.ApproveDate = date;
                requisition.ApproveBy = bossid;
                requisition.ApproverComments = req.ApproverComments;
                ctx.SaveChanges();
            }

        }
        public void RejectReq(Requisition req, int bossid)
        {
            {
                DateTime date = DateTime.Now.Date;
                Requisition requisition = ctx.Requisitions.FirstOrDefault(r => r.ReqId == req.ReqId);
                requisition.Status = (ReqStatus.REJECTED).ToString();
                requisition.ApproveDate = date;
                requisition.ApproveBy = bossid;
                requisition.ApproverComments = req.ApproverComments;
                ctx.SaveChanges();

            }

        }

        public List<RequisitionItem> GetListOfRequisitionItems(Requisition req)
        {
            {

                List<RequisitionItem> RList = ctx.RequisitionItems.Where(x => x.ReqId == req.ReqId).ToList<RequisitionItem>();
                if (RList == null)
                {
                    //throw exception;

                }
                return RList;
            }
        }

        public List<Requisition> GetPendingReqByDepartment(Department dept)
        {
            {
                List<Requisition> RList = ctx.Requisitions.Where(r => r.Status == "PENDING" && r.Employee.DeptId == dept.DeptId).ToList<Requisition>();

                if (RList == null)
                {
                    //throw exception;
                }
                return RList;


            }
        }

        public List<Requisition> GetPendingReq()
        {
            {
                List<Requisition> RList = ctx.Requisitions.Where(r => r.Status == "PENDING").ToList<Requisition>();

                if (RList == null)
                {
                    //throw exception;
                }
                return RList;

            }

        }

        public Requisition GetReq(int id)
        {
            {
                Requisition req = ctx.Requisitions.Where(r => r.ReqId == id).First<Requisition>();
                if (req == null)
                {
                    //throw exception;
                }
                return req;
            }

        }
    }
}