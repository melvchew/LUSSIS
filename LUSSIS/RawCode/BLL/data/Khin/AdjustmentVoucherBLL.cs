using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALUSSIS.RawCode.DAL.Khin;

namespace LUSSIS.RawCode.BLL.data.Khin
{
    public class AdjustmentVoucherBLL
    {
        public List<AdVoucherLIst> getAdjVoucherListBelow250()
        {
            LUSSdbEntities ctx = new LUSSdbEntities();
            List<AdVoucherLIst> list = new List<AdVoucherLIst>();
            var voucherlist = (from iav in ctx.InvAdjVouchers
                               join ia in ctx.InvAdjItems
                                   on iav.VoucherId equals ia.VoucherId
                               join i in ctx.Items
                               on ia.ItemId equals i.ItemId
                               join e in ctx.Employees on iav.RaiseBy equals e.EmpId
                               where iav.Status == "PENDING"
                               where i.Supplier1Price * ia.Quantity < 250
                               select new
                               {
                                   Voucherid = iav.VoucherId,
                                   SubmitDate = iav.SubmitDate,
                                   RaiseBy = e.Name
                               }).ToList();
            foreach (var v in voucherlist)
            {
                AdVoucherLIst iav = new AdVoucherLIst();
                iav.VoucherID = v.Voucherid;
                iav.submitDate = v.SubmitDate;
                iav.raiseBy = v.RaiseBy;
                list.Add(iav);

            }
            return list;

        }
        public List<AdVoucherLIst> getAdjVoucherList()
        {
            LUSSdbEntities ctx = new LUSSdbEntities();
            List<AdVoucherLIst> list = new List<AdVoucherLIst>();
            var voucherlist = (from iav in ctx.InvAdjVouchers
                               join ia in ctx.InvAdjItems
                                   on iav.VoucherId equals ia.VoucherId
                               join i in ctx.Items
                               on ia.ItemId equals i.ItemId
                               join e in ctx.Employees on iav.RaiseBy equals e.EmpId
                               where iav.Status == "PENDING"

                               select new
                               {
                                   Voucherid = iav.VoucherId,
                                   SubmitDate = iav.SubmitDate,
                                   RaiseBy = e.Name
                               }).ToList();
            foreach (var v in voucherlist)
            {
                AdVoucherLIst iav = new AdVoucherLIst();
                iav.VoucherID = v.Voucherid;
                iav.submitDate = v.SubmitDate;
                iav.raiseBy = v.RaiseBy;
                list.Add(iav);

            }
            return list;

        }

        public List<AdjustmentItem> getAdjustmentItemByID(int id)
        {
            LUSSdbEntities ctx = new LUSSdbEntities();
            List<AdjustmentItem> list = new List<AdjustmentItem>();
            var itemlist = (from ai in ctx.InvAdjItems
                            join i in ctx.Items
                                on ai.ItemId equals i.ItemId
                            join av in ctx.InvAdjVouchers
                             on ai.VoucherId equals av.VoucherId
                            where ai.VoucherId == id
                            select new
                            {
                                Voucherid = ai.VoucherId,
                                SubmitDate = av.SubmitDate,
                                Category = i.Category,
                                Description = i.Description,
                                Quantity = ai.Quantity,
                                Unit = i.Unit,
                                Price = i.Supplier1Price,
                            }).ToList();
            foreach (var i in itemlist)
            {
                AdjustmentItem ai = new AdjustmentItem();
                ai.VoucherID = i.Voucherid;
                ai.SubmitDate = i.SubmitDate;
                ai.Category = i.Category;
                ai.Description = i.Description;
                ai.Qty = i.Quantity;
                ai.Unit = i.Unit;
                ai.Price = i.Price;
                list.Add(ai);

            }
            return list;
        }

        public Boolean updateAdjVoucher(InvAdjVoucher adjVoucher)
        {
            try
            {
                using (LUSSdbEntities context = new LUSSdbEntities())
                {
                    InvAdjVoucher voucher = context.InvAdjVouchers.Where(p => p.VoucherId == adjVoucher.VoucherId).FirstOrDefault();
                    voucher.Status = adjVoucher.Status;
                    voucher.ApproverComments = adjVoucher.ApproverComments;
                    voucher.ApproveBy = adjVoucher.ApproveBy;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}