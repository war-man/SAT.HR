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
    
    public partial class vw_RoleMenu
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public int MenuID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string MenuName { get; set; }
        public string MenuType { get; set; }
        public Nullable<bool> R_View { get; set; }
        public Nullable<bool> R_Add { get; set; }
        public Nullable<bool> R_Edit { get; set; }
        public Nullable<bool> R_Delete { get; set; }
    }
}
