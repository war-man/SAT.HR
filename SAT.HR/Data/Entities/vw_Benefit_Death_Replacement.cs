//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAT.HR.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_Benefit_Death_Replacement
    {
        public int BdID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> BdYear { get; set; }
        public Nullable<int> RecID { get; set; }
        public string RecName { get; set; }
        public string BdFullName { get; set; }
        public string BdTime { get; set; }
        public Nullable<decimal> BdPer { get; set; }
        public Nullable<decimal> BdAmout { get; set; }
        public Nullable<System.DateTime> BdDate { get; set; }
        public string BdRemark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    }
}
