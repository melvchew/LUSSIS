using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUSSIS.RawCode.DAL.Khin
{
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
}
