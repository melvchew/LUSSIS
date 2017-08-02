using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using LUSSIS.RawCode.BLL;

//Done by Peter
namespace LUSSIS.Store
{
    public partial class UploadExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnTransfer.Enabled = false;

                //MaxContentLength error is fired before any event handlers. Handled in Global.asax and here.
                if ((string)Session["Err"] == "FileTooLarge")
                {
                    Session["Err"] = "";
                    lbStatus.Text = "File size is too big. Please choose a file smaller than 2MB.";
                    if ((string)Session["xlPath"] != "" && System.IO.File.Exists((string)Session["xlPath"]))
                    {
                        System.IO.File.Delete((string)Session["xlPath"]);
                    }
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Clear previous file and reset variables if reuploading
            lbStatus.Text = "";
            btnTransfer.Enabled = false;
            if ((string)Session["xlPath"] != "" && System.IO.File.Exists((string)Session["xlPath"]))
            {
                System.IO.File.Delete((string)Session["xlPath"]);
            }
            lbFileSubmit.Text = "";
            Session["xlPath"] = "";

            if (FileUpload1.HasFile)
            {
                String savePath = Server.MapPath("~/ExcelFiles/");
                Boolean fileExtOK = false;
                String fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = { ".xlsx" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileExtOK = true;
                    }
                }

                if (fileExtOK)
                {
                    savePath += FileUpload1.FileName;
                    //try
                    {
                        FileUpload1.PostedFile.SaveAs(savePath);
                        lbFileSubmit.Text = FileUpload1.FileName + " ready for transfer.";
                        Session["xlPath"] = savePath; //To pass to btnTransfer_Click()
                        btnTransfer.Enabled = true;
                    }
                    //catch
                    //{
                    //    lbStatus.Text = "File upload failed. Please try again.";
                    //}
                }
                else
                {
                    lbStatus.Text = "Please make sure file is of type .xlsx only.";
                }
            }
            else
            {
                lbStatus.Text = "Please select a file.";
            }
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            lbStatus.Text = "";
            btnTransfer.Enabled = false;

            StockManagementBLL upload = new StockManagementBLL();
            string sqlConnStr = "Data Source=.;Initial Catalog=LUSSdb;Integrated Security=True";
            string xlPath = (string)Session["xlPath"];

            //Try-catch is in method
            upload.txfToDb(sqlConnStr, xlPath, "Supplier", "SupplierStaging", "SupplierBackup", "Item", "ItemStaging", "ItemBackup");

            if (xlPath != "" && System.IO.File.Exists(xlPath))
            {
                System.IO.File.Delete(xlPath);
            }

            lbStatus.Text = upload.Status;
            lbFileSubmit.Text = "";
        }
    }
}