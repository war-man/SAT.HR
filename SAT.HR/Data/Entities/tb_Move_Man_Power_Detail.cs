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
    
    public partial class tb_Move_Man_Power_Detail
    {
        public int MopID { get; set; }
        public int UserID { get; set; }
        public int CurPoID { get; set; }
        public Nullable<int> MovPoID { get; set; }
        public Nullable<int> PoTID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public string MovRemark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    
        public virtual tb_Agent_Type tb_Agent_Type { get; set; }
        public virtual tb_Move_Man_Power_Head tb_Move_Man_Power_Head { get; set; }
        public virtual tb_Position tb_Position { get; set; }
        public virtual tb_Position_Type tb_Position_Type { get; set; }
    }
}
