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
    
    public partial class tb_SubDistrict
    {
        public int SubDistrictID { get; set; }
        public string SubDistrictName { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> ProvinceID { get; set; }
    
        public virtual tb_Province tb_Province { get; set; }
    }
}
