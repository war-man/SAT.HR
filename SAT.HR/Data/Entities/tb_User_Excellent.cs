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
    
    public partial class tb_User_Excellent
    {
        public int UeID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> ExID { get; set; }
        public Nullable<int> ExTID { get; set; }
        public string UeProjectName { get; set; }
        public Nullable<int> UeRecYear { get; set; }
        public Nullable<System.DateTime> UeRecDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    
        public virtual tb_Excellent_Type tb_Excellent_Type { get; set; }
        public virtual tb_User tb_User { get; set; }
    }
}
