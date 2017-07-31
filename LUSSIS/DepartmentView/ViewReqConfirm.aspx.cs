using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUSSIS.RawCode.BLL.data.HUXIAOXI;
using LUSSIS.RawCode.DAL;

//Made by Hu Xiaoxi(Team5)
namespace LUSSIS.Employee
{
    public partial class ViewReqConfirm : System.Web.UI.Page
    {
        LUSSdb context;
        RequisitionBLL rs = new RequisitionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Reqservice rs = new Reqservice();
            int rid = Int32.Parse(Request.QueryString["rid"]);

            using (context = new LUSSdb())
            {
                Requisition req = context.Requisitions.Where(r => r.ReqId == rid).ToList().First();

                Lite_ReqStatus.Text = "Requisition Status: " + req.Status;
                Lite_ReqId.Text = "Requisition ID: " + req.ReqId;
                Lite_ReqDate.Text = "Requisition Date: " + String.Format("{0:F}", req.SubmitDate.ToString());

                List<RequisitionItem> lReqItems = rs.GetReqItems(req);

                gvDisReqItem.DataSource = lReqItems;

                gvDisReqItem.DataBind();
            }
        }

        protected int GetDisbursedQty(int reqId, int itemId)
        {
            return rs.GetDisbursedQty(reqId, itemId);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if ((String)Session["View"] == "dept")
            {
                Response.Redirect("ViewDeptReqHistory.aspx");
            }
            else if ((String)Session["View"] == "own")
            {
                Response.Redirect("ViewOwnReqHistory.aspx");
            }
        }
    }
}