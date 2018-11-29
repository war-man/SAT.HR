﻿using SAT.HR.Data.Entities;
using SAT.HR.Helpers;
using SAT.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAT.HR.Data
{
    public class LeaveBalanceRepository
    {
        public LeaveBalanceViewModel GetByUser(int userid, int? year)
        {
            var data = new LeaveBalanceViewModel();
            var list = new List<LeaveBalanceViewModel>();
            try
            {
                using (SATEntities db = new SATEntities())
                {
                    var user = db.tb_User.Where(x => x.UserID == userid).FirstOrDefault();
                    data.UserID = user.UserID;
                    data.IDCard = user.IDCard;
                    data.FullNameTh = user.FirstNameTh +" " + user.LastNameTh;
                    
                    year = (year == null) ? DateTime.Now.Year + 543 : year;
                    data.LeaveYear = year;

                    var leavebalance = db.sp_Leave_Balance_User(userid, year).ToList();

                    int index = 1;
                    foreach (var item in leavebalance)
                    {
                        LeaveBalanceViewModel model = new LeaveBalanceViewModel();
                        model.RowNumber = index++;
                        model.UserID = data.UserID;
                        model.LevID = item.LevID;
                        model.LevYear = item.LevYear;
                        model.LevName = item.LevName;
                        model.LevMax = item.LevMax;
                        model.LevStandard = item.LevStandard;
                        model.LevUsed = item.LevUsed;
                        model.LevBalance = item.LevBalance;
                        list.Add(model);
                    }
                    data.ListLeaveBalance = list;
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResponseData SaveByEntity(LeaveBalanceViewModel data)
        {
            using (SATEntities db = new SATEntities())
            {
                using (var transection = db.Database.BeginTransaction())
                {
                    ResponseData result = new Models.ResponseData();
                    try
                    {
                        foreach (var item in data.ListLeaveBalance)
                        {
                            var leavebalance = db.tb_Leave_Balance.Where(x => x.UserID == item.UserID && x.LevYear == item.LevYear && x.LevID == item.LevID).FirstOrDefault();
                            if (leavebalance != null)
                            {
                                leavebalance.LevStandard = item.LevStandard;
                                leavebalance.LevMax = item.LevMax;
                                leavebalance.LevUsed = item.LevUsed;
                                leavebalance.ModifyBy = UtilityService.User.UserID;
                                leavebalance.ModifyDate = DateTime.Now;
                                db.SaveChanges();
                            }
                            else
                            {
                                tb_Leave_Balance model = new tb_Leave_Balance();
                                model.LevYear = item.LevYear;
                                model.LevID = item.LevID;
                                model.UserID = (int)item.UserID;
                                model.LevStandard = item.LevStandard;
                                model.LevMax = item.LevMax;
                                model.LevUsed = item.LevUsed;
                                model.CreateBy = UtilityService.User.UserID;
                                model.CreateDate = DateTime.Now;
                                model.ModifyBy = UtilityService.User.UserID;
                                model.ModifyDate = DateTime.Now;
                                db.tb_Leave_Balance.Add(model);
                                db.SaveChanges();
                            }
                        }

                        transection.Commit();
                    }
                    catch (Exception ex)
                    {
                        transection.Rollback();
                        result.MessageCode = "";
                        result.MessageText = ex.Message;
                    }
                    return result;
                }
            }
        }

    }
}