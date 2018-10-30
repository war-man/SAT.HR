﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SATEntities : DbContext
    {
        public SATEntities()
            : base("name=SATEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Accumulative_Fund> tb_Accumulative_Fund { get; set; }
        public virtual DbSet<tb_Action_Type> tb_Action_Type { get; set; }
        public virtual DbSet<tb_Agent_Type> tb_Agent_Type { get; set; }
        public virtual DbSet<tb_Bank_Loan> tb_Bank_Loan { get; set; }
        public virtual DbSet<tb_Benefit_Child_Education> tb_Benefit_Child_Education { get; set; }
        public virtual DbSet<tb_Benefit_Child_Fund> tb_Benefit_Child_Fund { get; set; }
        public virtual DbSet<tb_Benefit_Cremation> tb_Benefit_Cremation { get; set; }
        public virtual DbSet<tb_Benefit_Death_Replacement> tb_Benefit_Death_Replacement { get; set; }
        public virtual DbSet<tb_Benefit_Death_Subsidy> tb_Benefit_Death_Subsidy { get; set; }
        public virtual DbSet<tb_Benefit_Home_Rental> tb_Benefit_Home_Rental { get; set; }
        public virtual DbSet<tb_Benefit_Loan> tb_Benefit_Loan { get; set; }
        public virtual DbSet<tb_Benefit_Medical> tb_Benefit_Medical { get; set; }
        public virtual DbSet<tb_Benefit_Other_Welfare> tb_Benefit_Other_Welfare { get; set; }
        public virtual DbSet<tb_Benefit_Provident_Fund> tb_Benefit_Provident_Fund { get; set; }
        public virtual DbSet<tb_Benefit_Remuneration> tb_Benefit_Remuneration { get; set; }
        public virtual DbSet<tb_Benefit_Type> tb_Benefit_Type { get; set; }
        public virtual DbSet<tb_Blood_Type> tb_Blood_Type { get; set; }
        public virtual DbSet<tb_Capability> tb_Capability { get; set; }
        public virtual DbSet<tb_Capability_Detail> tb_Capability_Detail { get; set; }
        public virtual DbSet<tb_Capability_Group> tb_Capability_Group { get; set; }
        public virtual DbSet<tb_Capability_Type> tb_Capability_Type { get; set; }
        public virtual DbSet<tb_Certificate> tb_Certificate { get; set; }
        public virtual DbSet<tb_Claim_Type> tb_Claim_Type { get; set; }
        public virtual DbSet<tb_Country> tb_Country { get; set; }
        public virtual DbSet<tb_Degree> tb_Degree { get; set; }
        public virtual DbSet<tb_Department> tb_Department { get; set; }
        public virtual DbSet<tb_Discipline> tb_Discipline { get; set; }
        public virtual DbSet<tb_District> tb_District { get; set; }
        public virtual DbSet<tb_Division> tb_Division { get; set; }
        public virtual DbSet<tb_Document_Number> tb_Document_Number { get; set; }
        public virtual DbSet<tb_Document_Type> tb_Document_Type { get; set; }
        public virtual DbSet<tb_Education> tb_Education { get; set; }
        public virtual DbSet<tb_Empower> tb_Empower { get; set; }
        public virtual DbSet<tb_Excellent_Type> tb_Excellent_Type { get; set; }
        public virtual DbSet<tb_Holiday> tb_Holiday { get; set; }
        public virtual DbSet<tb_Insignia> tb_Insignia { get; set; }
        public virtual DbSet<tb_Leave_Type> tb_Leave_Type { get; set; }
        public virtual DbSet<tb_Loan_Type> tb_Loan_Type { get; set; }
        public virtual DbSet<tb_Major> tb_Major { get; set; }
        public virtual DbSet<tb_Man_Power> tb_Man_Power { get; set; }
        public virtual DbSet<tb_Marital_Status> tb_Marital_Status { get; set; }
        public virtual DbSet<tb_Member_Type> tb_Member_Type { get; set; }
        public virtual DbSet<tb_Menu> tb_Menu { get; set; }
        public virtual DbSet<tb_Menu_Role> tb_Menu_Role { get; set; }
        public virtual DbSet<tb_Move_Level_Detail> tb_Move_Level_Detail { get; set; }
        public virtual DbSet<tb_Move_Level_Head> tb_Move_Level_Head { get; set; }
        public virtual DbSet<tb_Move_Man_Power_Detail> tb_Move_Man_Power_Detail { get; set; }
        public virtual DbSet<tb_Move_Man_Power_Head> tb_Move_Man_Power_Head { get; set; }
        public virtual DbSet<tb_Move_Type> tb_Move_Type { get; set; }
        public virtual DbSet<tb_Nationality> tb_Nationality { get; set; }
        public virtual DbSet<tb_Occupation> tb_Occupation { get; set; }
        public virtual DbSet<tb_Part_Type> tb_Part_Type { get; set; }
        public virtual DbSet<tb_Position> tb_Position { get; set; }
        public virtual DbSet<tb_Position_Agent> tb_Position_Agent { get; set; }
        public virtual DbSet<tb_Position_Type> tb_Position_Type { get; set; }
        public virtual DbSet<tb_Province> tb_Province { get; set; }
        public virtual DbSet<tb_Recieve_Type> tb_Recieve_Type { get; set; }
        public virtual DbSet<tb_Religion> tb_Religion { get; set; }
        public virtual DbSet<tb_Rent_Type> tb_Rent_Type { get; set; }
        public virtual DbSet<tb_Role> tb_Role { get; set; }
        public virtual DbSet<tb_Salary> tb_Salary { get; set; }
        public virtual DbSet<tb_Section> tb_Section { get; set; }
        public virtual DbSet<tb_Sex> tb_Sex { get; set; }
        public virtual DbSet<tb_SubDistrict> tb_SubDistrict { get; set; }
        public virtual DbSet<tb_SysConfig> tb_SysConfig { get; set; }
        public virtual DbSet<tb_Title> tb_Title { get; set; }
        public virtual DbSet<tb_Training_Type> tb_Training_Type { get; set; }
        public virtual DbSet<tb_Transfer_Type> tb_Transfer_Type { get; set; }
        public virtual DbSet<tb_User> tb_User { get; set; }
        public virtual DbSet<tb_User_Certificate> tb_User_Certificate { get; set; }
        public virtual DbSet<tb_User_Education> tb_User_Education { get; set; }
        public virtual DbSet<tb_User_Excellent> tb_User_Excellent { get; set; }
        public virtual DbSet<tb_User_Family> tb_User_Family { get; set; }
        public virtual DbSet<tb_User_History> tb_User_History { get; set; }
        public virtual DbSet<tb_User_Insignia> tb_User_Insignia { get; set; }
        public virtual DbSet<tb_User_Position> tb_User_Position { get; set; }
        public virtual DbSet<tb_User_Role> tb_User_Role { get; set; }
        public virtual DbSet<tb_User_Status> tb_User_Status { get; set; }
        public virtual DbSet<tb_User_Training> tb_User_Training { get; set; }
        public virtual DbSet<tb_User_Type> tb_User_Type { get; set; }
        public virtual DbSet<tb_Working_Type> tb_Working_Type { get; set; }
        public virtual DbSet<vw_Capability> vw_Capability { get; set; }
        public virtual DbSet<vw_Department> vw_Department { get; set; }
        public virtual DbSet<vw_Employee> vw_Employee { get; set; }
        public virtual DbSet<vw_Man_Power> vw_Man_Power { get; set; }
        public virtual DbSet<vw_Menu_Role> vw_Menu_Role { get; set; }
        public virtual DbSet<vw_Move_Level_Detail> vw_Move_Level_Detail { get; set; }
        public virtual DbSet<vw_Move_Level_Head> vw_Move_Level_Head { get; set; }
        public virtual DbSet<vw_Move_Man_Power_Detail> vw_Move_Man_Power_Detail { get; set; }
        public virtual DbSet<vw_Move_Man_Power_Head> vw_Move_Man_Power_Head { get; set; }
        public virtual DbSet<vw_Section> vw_Section { get; set; }
        public virtual DbSet<vw_Title> vw_Title { get; set; }
        public virtual DbSet<vw_User> vw_User { get; set; }
        public virtual DbSet<vw_User_Certificate> vw_User_Certificate { get; set; }
        public virtual DbSet<vw_User_Education> vw_User_Education { get; set; }
        public virtual DbSet<vw_User_Excellent> vw_User_Excellent { get; set; }
        public virtual DbSet<vw_User_Family> vw_User_Family { get; set; }
        public virtual DbSet<vw_User_History> vw_User_History { get; set; }
        public virtual DbSet<vw_User_Insignia> vw_User_Insignia { get; set; }
        public virtual DbSet<vw_User_NotRole> vw_User_NotRole { get; set; }
        public virtual DbSet<vw_User_Position> vw_User_Position { get; set; }
        public virtual DbSet<vw_User_Role> vw_User_Role { get; set; }
        public virtual DbSet<vw_User_Training> vw_User_Training { get; set; }
    
        public virtual ObjectResult<sp_Menu_GetByUser_Result> sp_Menu_GetByUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Menu_GetByUser_Result>("sp_Menu_GetByUser", userIDParameter);
        }
    
        public virtual ObjectResult<sp_Menu_Report_GetByUser_Result> sp_Menu_Report_GetByUser(Nullable<int> userID, Nullable<int> parentID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var parentIDParameter = parentID.HasValue ?
                new ObjectParameter("ParentID", parentID) :
                new ObjectParameter("ParentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Menu_Report_GetByUser_Result>("sp_Menu_Report_GetByUser", userIDParameter, parentIDParameter);
        }
    
        public virtual ObjectResult<sp_Menu_GetByRole_Result> sp_Menu_GetByRole(Nullable<int> roleID, string menuType)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var menuTypeParameter = menuType != null ?
                new ObjectParameter("MenuType", menuType) :
                new ObjectParameter("MenuType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Menu_GetByRole_Result>("sp_Menu_GetByRole", roleIDParameter, menuTypeParameter);
        }
    
        public virtual ObjectResult<sp_Employee_List_Result> sp_Employee_List(string pageSize, string initialPage, string sortBy, string sortrDir, string userType, string userStatus, string keyword)
        {
            var pageSizeParameter = pageSize != null ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(string));
    
            var initialPageParameter = initialPage != null ?
                new ObjectParameter("InitialPage", initialPage) :
                new ObjectParameter("InitialPage", typeof(string));
    
            var sortByParameter = sortBy != null ?
                new ObjectParameter("SortBy", sortBy) :
                new ObjectParameter("SortBy", typeof(string));
    
            var sortrDirParameter = sortrDir != null ?
                new ObjectParameter("SortrDir", sortrDir) :
                new ObjectParameter("SortrDir", typeof(string));
    
            var userStatusParameter = userStatus != null ?
                new ObjectParameter("UserStatus", userStatus) :
                new ObjectParameter("UserStatus", typeof(string));
    
            var userTypeParameter = userType != null ?
                new ObjectParameter("UserType", userType) :
                new ObjectParameter("UserType", typeof(string));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("Keyword", keyword) :
                new ObjectParameter("Keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Employee_List_Result>("sp_Employee_List", pageSizeParameter, initialPageParameter, sortByParameter, sortrDirParameter, userTypeParameter, userStatusParameter, keywordParameter);
        }
    }
}
