using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;
using LUSSIS.RawCode.Generics;
using System.Net.Mail;

namespace LUSSIS.RawCode.BLL
{
    public class EmailBLL
    {

        //Created by Melvin

        LUSSdb context = new LUSSdb();
        //Melvin
        public void SendRequisitionStatusUpdate(Employee emp, Requisition req)
        {
            //emp is the emp who raised the Requisition
            //req is the req raised by the employee
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mm = new MailMessage("lusissa44@gmail.com", emp.Email);
            mm.Subject = "Requisition Status Update";
            mm.Body = $"Dear {emp.Name},\n\nYour request for stationary, requisition id : {req.ReqId} has been {req.Status}\n\nThis is an automated generated email, please do not reply to this email";
            client.Send(mm);
        }

        public void SendRequisitionNotification(Employee emp, Requisition req, Department dept)
        {
            //Department is the department of the employee, head and acting head. They should be the same department
            //emp is emp who raised the requisition
            //req is the req raised by the employee
            {
                List<Employee> ListEmp = new List<Employee>();
                Employee Head = context.Employees.Where(e => e.EmpId == dept.DeptHead).First<Employee>();
                Employee ActingHead = context.Employees.Where(e => e.EmpId == dept.ActingHead).FirstOrDefault<Employee>();
                ListEmp.Add(Head);
                ListEmp.Add(ActingHead);
                if (ListEmp == null)
                {
                    //throw Exception;
                }
                for (int i = 0; i < ListEmp.Count; i++)
                {
                    if (ListEmp[i] != null)
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailMessage mm = new MailMessage("lusissa44@gmail.com",
                        ListEmp[i].Email);
                        mm.Subject = "New Stationary Requisition by " + emp.Name;
                        mm.Body = $"{emp.Name} has submitted a new requisition\nRequisition ID: {req.ReqId}\nrequires your approval\n\nThis is an auto generated email, please do not reply to this email";
                        //add in the hyperlink later
                        client.Send(mm);
                    }

                }
            }


        }

        public void SendNewPurchoseOrderNotification(StoreEmployee emp, List<PurchaseOrder> po)
        {
            //emp is the emp who raised the new purchase order
            //po is the purchase order the emp raised.
            {
                List<StoreEmployee> Store = context.StoreEmployees.Where(se => se.Position == "Manager").ToList<StoreEmployee>();
                Store.AddRange(context.StoreEmployees.Where(se => se.Position == "Supervisor").ToList<StoreEmployee>());
                if (Store == null)
                {
                    //throw exception;
                }
                for (int i = 0; i < Store.Count; i++)
                {
                    if (Store[i] != null)
                    {
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailMessage mm = new MailMessage("lusissa44@gmail.com",
                        Store[i].Email);
                        mm.Subject = $"New Purchase Order raised by {emp.Name}";
                        string text = "";
                        text = $"{emp.Name} has submitted {po.Count } new Purchase Order(s).";
                        for (int j = 0; j < po.Count; j++)
                        {
                            text = text + $"\nPurchase Order Id : {po[j].POId}";
                        }
                        text = text + $"\n\nThis is an auto generated email, please do not reply to this email";
                        mm.Body = text;
                        //add in the hyperlink later
                        client.Send(mm);
                    }

                }
            }

        }
        public void SendPurchaseOrderStatusUpdate(StoreEmployee emp, PurchaseOrder po)
        {
            //emp is the emp that raised the purchase order
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new System.Net.NetworkCredential("lusissa44@gmail.com", "TEAM5!SA44");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mm = new MailMessage("lusissa44@gmail.com",
            emp.Email);
            mm.Subject = $"Purchase Order: {po.POId} has been {po.Status}";
            mm.Body = $"Dear {emp.Name},\n\nThe purchase order that you have raise:\nPurchase Order : {po.POId} has been {po.Status}\n\nThis is an auto generated email, please do not reply to this email";
            //add in the hyperlink later
            client.Send(mm);

        }

        //---------------------------------------------------------------------------------------------------------------------
        //Created by Jinshan

        public void SendEmailsToClerk()
        {
            int send_hour = 9;//hour of sending email
            int send_minute = 30;//minute of sending email
            int now_Hour = Convert.ToInt32(DateTime.Now.Hour.ToString());//current hour
            int now_Minute = Convert.ToInt32(DateTime.Now.Minute.ToString());//current minute

            if (((now_Hour == send_hour) && (now_Minute >= send_minute)) && ((now_Hour == send_hour) && (now_Minute < send_minute + 1)))//judge the sending time
            {
                List<Item> items = new List<Item>();
                items = GetLowStock();
                if (items.Count!=0)
                {   //get all the Clerk emails
                    List<String> em = GetEmailAddress();
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
                        mm.Body = SetEmailBody();
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
            using (context = new LUSSdb())
            {
                l1 = context.StoreEmployees.Where(se => se.Position == "Clerk").ToList();
            }

            for (int i = 0; i < l1.Count; i++)
            {
                l2.Add(l1[i].Email);
            }

            return l2;
        }

        //get low stock 
        public List<Item> GetLowStock()
        {

            List<Item> items = new List<Item>();

            using (LUSSdb entities = new LUSSdb())
            {

                List<Item> l2 = entities.Items.ToList();
                for (int i = 0; i < l2.Count; i++)
                {
                    if (l2[i].StockBalance < l2[i].ReorderLvl)
                    {
                        items.Add(l2[i]);
                    }
                }
            }
            return items;
        }

        //set email body
        public string SetEmailBody()
        {
            string s = null;
            List<Item> items = new List<Item>();
            items = GetLowStock();
            for (int i = 0; i < items.Count; i++)
            {
                s = s + items[i].Description + "\r\n";
            }

            return ("There are" + " " + items.Count + " " + "items which are low stock:" + "\r\n" + s);
        }

    }
}