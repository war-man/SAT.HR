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
    
    public partial class vw_Department
    {
        public int DepID { get; set; }
        public string DepName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> Seq { get; set; }
        public Nullable<int> TypeID { get; set; }
        public int DepLevel { get; set; }
        public string DepPath { get; set; }
        public string FullPath { get; set; }
    }
}
