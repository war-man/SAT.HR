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
    
    public partial class vw_User_Skill
    {
        public int UskID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string UserName { get; set; }
        public string FullNameTh { get; set; }
        public Nullable<int> LID { get; set; }
        public string Language { get; set; }
        public Nullable<int> LkID { get; set; }
        public string LkName { get; set; }
        public Nullable<int> LkTID { get; set; }
        public string LkTName { get; set; }
        public string LIOther { get; set; }
    }
}
