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
    
    public partial class tb_Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_Country()
        {
            this.tb_Course = new HashSet<tb_Course>();
            this.tb_User_Education = new HashSet<tb_User_Education>();
            this.tb_User_Training = new HashSet<tb_User_Training>();
        }
    
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_Course> tb_Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_User_Education> tb_User_Education { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_User_Training> tb_User_Training { get; set; }
    }
}
