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
    
    public partial class tb_Salary_Increase_Detail
    {
        public int ID { get; set; }
        public Nullable<int> HeaderID { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Seq { get; set; }
        public Nullable<decimal> UpStep { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> Old_Level { get; set; }
        public Nullable<int> New_Level { get; set; }
        public Nullable<decimal> Old_Step { get; set; }
        public Nullable<decimal> New_Step { get; set; }
        public Nullable<decimal> Old_Salary { get; set; }
        public Nullable<decimal> New_Salary { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
    }
}
