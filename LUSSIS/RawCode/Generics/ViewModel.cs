using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LUSSIS.RawCode.DAL;

namespace LUSSIS.RawCode.Generics
{
    public class ViewModel
    {
    }
    public class AdjustmentItem
    {
        private int voucherID;
        private DateTime submitDate;
        private string category;
        private string description;
        private string unit;
        private decimal price;
        private int qty;

        public int VoucherID
        {
            get { return voucherID; }
            set { voucherID = value; }
        }
        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        public DateTime SubmitDate
        {
            get { return submitDate; }
            set { submitDate = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }

    public class AdVoucherLIst
    {
        private int Voucherid;
        private DateTime SubmitDate;
        private string RaiseBy;

        public string raiseBy
        {
            get { return RaiseBy; }
            set { RaiseBy = value; }
        }

        public int VoucherID
        {
            get { return Voucherid; }
            set { Voucherid = value; }
        }

        public DateTime submitDate
        {
            get { return SubmitDate; }
            set { SubmitDate = value; }
        }

    }
    public class OrderListItem
    {
        public PurchaseOrderItem PurchaseOrderItem { get; set; }
        public Supplier Supplier { get; set; }
    }

    public class ConsolidatedDisbursementItem
    {
        public Item Item { get; set; }
        public int AmountRetrieved { get; set; }
        public int AmountDisbursed { get; set; }
    }
}