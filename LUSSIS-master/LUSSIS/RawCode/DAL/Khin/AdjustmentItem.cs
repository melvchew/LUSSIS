using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUSSIS.RawCode.DAL.Khin
{
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
}
