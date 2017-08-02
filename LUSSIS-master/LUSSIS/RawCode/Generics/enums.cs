using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.Generics
{
    public enum ReqStatus
    {
        PENDING, CANCELLED, APPROVED, REJECTED, PARTIAL, DELIVERED
    }

    public enum PurchaseOrderStatus
    {
        PENDING, CANCELLED, APPROVED, REJECTED, RECIEVED
    }

    public enum AdjVoucherStatus
    {
        PENDING, APPROVED, REJECTED
    }
}