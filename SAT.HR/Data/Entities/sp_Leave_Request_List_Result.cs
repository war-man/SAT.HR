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
    
    public partial class sp_Leave_Request_List_Result
    {
        public int FormID { get; set; }
        public int LeaveYear { get; set; }
        public string DocNo { get; set; }
        public Nullable<int> LeaveType { get; set; }
        public string LeaveTypeName { get; set; }
        public Nullable<int> RequestID { get; set; }
        public string RequestName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> DayTime { get; set; }
        public Nullable<decimal> TotalDay { get; set; }
        public string LeaveReason { get; set; }
        public string CancelReason { get; set; }
        public string Remark { get; set; }
        public string PathFile { get; set; }
        public Nullable<int> Status { get; set; }
        public string StatusName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public string CreateByName { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public Nullable<int> ModifyBy { get; set; }
        public Nullable<int> recordsTotal { get; set; }
        public Nullable<int> recordsFiltered { get; set; }
    }
}
