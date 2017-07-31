using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using System.Net.Mail;

namespace LUSSIS.RawCode.BLL.data.Raj
{
    public class VoucherManagementBLL
    {
        
        LUSSdb dbObject = new LUSSdb();

        public List<Item> getItems()
        {
            return dbObject.Items.ToList();
        }

        public Item getItemById(int id)
        {
            return dbObject.Items.Where(x => x.ItemId == id).Single<Item>();
        }

        public void AddRaiseAdjItem(int voucherId, int itemId, int adjQty)
        {
            try
            {
                InvAdjItem i = new InvAdjItem();
                i.VoucherId = voucherId;
                i.ItemId = itemId;
                i.Quantity = adjQty;

                dbObject.InvAdjItems.Add(i);
                dbObject.SaveChanges();
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

                dbObject.InvAdjVouchers.Add(iav);
                dbObject.SaveChanges();
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
            return dbObject.InvAdjVouchers.Where(x => x.SubmitDate == date).First<InvAdjVoucher>();
        }

        public StoreEmployee getStoreEmployeeById(int empId)
        {
            return dbObject.StoreEmployees.Where(x => x.StoreEmpId == empId).First<StoreEmployee>();
        }

        public void sendnotification(StoreEmployee se, int voucherId)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                MailMessage mm = new MailMessage("lusissa44@gmail.com", "razz.aiw@gmail.com");
                mm.Subject = "Adjustment Voucher";
                mm.Body = $"Hi,\n\n" + se.Name + " Raised an adjustment Voucher as Voucher No : " + voucherId + "\n\nThis is an automated generated email, please do not reply to this email";
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