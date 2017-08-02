using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.RawCode.BLL.data.ZhangJinshan
{
    public class EmailBLL
    {
        public void SendEmailsToClerk()
        {
            int send_hour = 13;//hour of sending email
            int send_minute = 4;//minute of sending email
            int now_Hour = Convert.ToInt32(DateTime.Now.Hour.ToString());//current hour
            int now_Minute = Convert.ToInt32(DateTime.Now.Minute.ToString());//current minute

            if (((now_Hour == send_hour) && (now_Minute > send_minute)) && ((now_Hour == send_hour) && (now_Minute <= send_minute + 1)))//judge the sending time
            {
                List<String> em = GetEmailAddress();
                if (GetLowStock())
                {
                    //send email to clerks
                    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new System.Net.NetworkCredential
                    (@"lusissa44@gmail.com", "TEAM5!SA44");
                    client.EnableSsl = true;
                    client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    for (int j = 0; j < em.Count; j++)
                    {
                        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage("lusissa44@gmail.com", em[j]);
                        mm.Subject = "Low Stock Information";
                        mm.Body = "some items are low stock";
                        client.Send(mm);
                    }
                }
            }
        }

        //Get clerk email

        public List<String> GetEmailAddress()
        {
            List<StoreEmployee> l1 = new List<StoreEmployee>();
            List<string> l2 = new List<string>();
            using (LUSSdb entity = new LUSSdb())
            {
                l1 = entity.StoreEmployees.Where(se => se.Position == "Clerk").ToList();
            }

            for (int i = 0; i < l1.Count; i++)
            {
                l2.Add(l1[i].Email);
            }

            return l2;
        }

        //get low stock 
        public bool GetLowStock()
        {
            bool low = false;

            using (LUSSdb entities = new LUSSdb())
            {

                List<Item> l2 = entities.Items.ToList();
                for (int i = 0; i < l2.Count; i++)
                {
                    if (((Item)l2[i]).StockBalance < ((Item)l2[i]).ReorderLvl)
                    {
                        low = true;
                        break;
                    }
                }
            }

            return low;
        }
    }
}