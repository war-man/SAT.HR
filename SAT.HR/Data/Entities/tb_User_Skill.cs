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
    
    public partial class tb_User_Skill
    {
        public int UskID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> LID { get; set; }
        public string LIOther { get; set; }
        public Nullable<int> LkID { get; set; }
        public Nullable<int> LkTID { get; set; }
        public Nullable<decimal> Score { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    
        public virtual tb_Language tb_Language { get; set; }
        public virtual tb_Language_Skill tb_Language_Skill { get; set; }
        public virtual tb_Language_Skill_Type tb_Language_Skill_Type { get; set; }
        public virtual tb_User tb_User { get; set; }
    }
}