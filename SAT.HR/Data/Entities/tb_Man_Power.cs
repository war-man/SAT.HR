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
    
    public partial class tb_Man_Power
    {
        public int MpID { get; set; }
        public Nullable<int> DivID { get; set; }
        public Nullable<int> DepID { get; set; }
        public Nullable<int> SecID { get; set; }
        public Nullable<int> PoID { get; set; }
        public Nullable<int> DisID { get; set; }
        public string MpMan { get; set; }
        public string MpIncumbent { get; set; }
        public Nullable<int> EduID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    
        public virtual tb_Department tb_Department { get; set; }
        public virtual tb_Discipline tb_Discipline { get; set; }
        public virtual tb_Division tb_Division { get; set; }
        public virtual tb_Education tb_Education { get; set; }
        public virtual tb_Position tb_Position { get; set; }
        public virtual tb_Section tb_Section { get; set; }
    }
}
