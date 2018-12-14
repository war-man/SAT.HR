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
    
    public partial class vw_Leave_Request
    {
        public int FormHeaderID { get; set; }
        public string DocNo { get; set; }
        public Nullable<int> FormID { get; set; }
        public Nullable<int> FormMasterID { get; set; }
        public Nullable<int> LeaveYear { get; set; }
        public Nullable<int> LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> TotalDay { get; set; }
        public Nullable<int> DayTime { get; set; }
        public string LeaveReason { get; set; }
        public string CancelReason { get; set; }
        public string LeaveFile { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastApproveDate { get; set; }
        public Nullable<int> TransLastStepID { get; set; }
        public Nullable<int> TransNextStepID { get; set; }
        public Nullable<int> TransCurrentStepID { get; set; }
        public Nullable<int> RequestMpID { get; set; }
        public Nullable<int> RequestUserID { get; set; }
        public string RequestUserName { get; set; }
        public string ApproverComment { get; set; }
        public string Action { get; set; }
        public string Status { get; set; }
        public string NextApproverName { get; set; }
        public string LastApproverName { get; set; }
    }
}
