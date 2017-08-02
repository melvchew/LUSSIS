//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LUSSIS.RawCode.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement()
        {
            this.DisburseReqItems = new HashSet<DisburseReqItem>();
        }
    
        public int DisbursementId { get; set; }
        public int DeptId { get; set; }
        public int StoreEmpId { get; set; }
        public System.DateTime RetrieveDate { get; set; }
        public Nullable<System.DateTime> DisburseDate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual StoreEmployee StoreEmployee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisburseReqItem> DisburseReqItems { get; set; }
    }
}
