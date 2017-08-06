using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;
using System.Net.Mail;

namespace LUSSIS.RawCode.BLL
{
    public class VoucherManagementBLL
    {
        LUSSdb context = new LUSSdb();

        //Created by Khin
        public List<AdVoucherLIst> getAdjVoucherListBelow250()
        {
            context = new LUSSdb();
            List<AdVoucherLIst> list = new List<AdVoucherLIst>();
            var voucherlist = (from iav in context.InvAdjVouchers
                               join ia in context.InvAdjItems
                                   on iav.VoucherId equals ia.VoucherId
                               join i in context.Items
                               on ia.ItemId equals i.ItemId
                               join e in context.StoreEmployees on iav.RaiseBy equals e.StoreEmpId
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
            context = new LUSSdb();
            List<AdVoucherLIst> list = new List<AdVoucherLIst>();
            var voucherlist = (from iav in context.InvAdjVouchers
                               join ia in context.InvAdjItems
                                   on iav.VoucherId equals ia.VoucherId
                               join i in context.Items
                               on ia.ItemId equals i.ItemId
                               join e in context.StoreEmployees on iav.RaiseBy equals e.StoreEmpId
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
            context = new LUSSdb();
            List<AdjustmentItem> list = new List<AdjustmentItem>();
            var itemlist = (from ai in context.InvAdjItems
                            join i in context.Items
                                on ai.ItemId equals i.ItemId
                            join av in context.InvAdjVouchers
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
                                Price = ((i.Supplier1Price+i.Supplier2Price+i.Supplier3Price)/3)*ai.Quantity
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
                ai.Price = Math.Round(Convert.ToDecimal(i.Price), 2);
                list.Add(ai);

            }
            return list;
        }

        public Boolean updateAdjVoucher(InvAdjVoucher adjVoucher)
        {
            try
            {
                using (context = new LUSSdb())
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

        //--------------------------------------------------------------------------------------------------------

        //Created by Raj

        //LUSSdb dbObject = new LUSSdb();

        public List<Item> getItems()
        {
            return context.Items.ToList();
        }

        public Item getItemById(int id)
        {
            return context.Items.Where(x => x.ItemId == id).Single<Item>();
        }

        public void AddRaiseAdjItem(int voucherId, int itemId, int adjQty)
        {
            try
            {
                List<InvAdjItem> lItem = context.InvAdjItems.Where(x => x.VoucherId == voucherId).ToList<InvAdjItem>();
                InvAdjItem i = new InvAdjItem();
                if (lItem.Count != 0)
                {
                    foreach(InvAdjItem ia in lItem)
                    {
                        if(ia.ItemId == itemId)
                        {
                            ia.Quantity = ia.Quantity + adjQty;
                        }
                        else
                        {
                            i.VoucherId = voucherId;
                            i.ItemId = itemId;
                            i.Quantity = adjQty;
                            context.InvAdjItems.Add(i);
                        }
                    }
                }
                else
                {
                    i.VoucherId = voucherId;
                    i.ItemId = itemId;
                    i.Quantity = adjQty;

                    context.InvAdjItems.Add(i);
                }
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
        }

        public void RaiseVoucher(int RaiseBy, DateTime SubmitDate, String Status, String EmpComments)
        {
            try
            {
                InvAdjVoucher iav = new InvAdjVoucher();
                iav.RaiseBy = RaiseBy;
                iav.SubmitDate = SubmitDate;
                iav.Status = Status;
                iav.EmpComments = EmpComments;

                context.InvAdjVouchers.Add(iav);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
            //  InvAdjVoucher test = ctx.InvAdjVouchers.Where(x => x.VoucherId == 1).First<InvAdjVoucher>();
            //  List<InvAdjVoucher> listA = ctx.InvAdjVouchers.Where(x => x.Status == "Pending").ToList<InvAdjVoucher>();
        }

        public InvAdjVoucher getAdjVocherIdByDate(DateTime date)
        {
            return context.InvAdjVouchers.Where(x => x.SubmitDate == date).First<InvAdjVoucher>();
        }

        public StoreEmployee getStoreEmployeeById(int empId)
        {
            return context.StoreEmployees.Where(x => x.StoreEmpId == empId).First<StoreEmployee>();
        }

        public void sendnotification(StoreEmployee se, int voucherId, int itemId)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mm = new MailMessage("lusissa44@gmail.com", "razz.aiw@gmail.com");
                mm.Subject = "Adjustment Voucher";
                mm.Body = $"Hi,\n\n" + se.Name + " Raised an adjustment Voucher for an Item ID " + itemId
                    + " with the Voucher No : " + voucherId + "\n\nThis is an automated generated email, please do not reply to this email";
                client.Send(mm);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SmtpException has occured: " + ex.Message);
            }
        }


    }
}