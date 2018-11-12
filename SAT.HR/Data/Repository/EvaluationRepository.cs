﻿using SAT.HR.Data.Entities;
using SAT.HR.Helpers;
using SAT.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAT.HR.Data.Repository
{
    public class EvaluationRepository
    {
        public EvaluationPageResult GetPage(string filter, int? draw, int? initialPage, int? pageSize, string sortDir, string sortBy, string usertype, string capid)
        {
            EvaluationPageResult result = new EvaluationPageResult();
            List<EvaluationViewModel> list = new List<EvaluationViewModel>();

            try
            {
                using (SATEntities db = new SATEntities())
                {
                    string perPage = initialPage.HasValue ? Convert.ToInt32(initialPage) == 0 ? "1" : initialPage.ToString() : "1";
                    var data = db.sp_Evaluation_List(pageSize.ToString(), perPage, sortBy, sortDir, usertype, capid, filter).ToList();

                    int i = 0;
                    foreach (var item in data)
                    {
                        EvaluationViewModel model = new EvaluationViewModel();
                        model.RowNumber = ++i;
                        model.UserID = item.UserID;
                        model.IDCard = item.IDCard;
                        model.FullNameTh = item.FullNameTh;
                        model.PoName = item.PoName;
                        model.recordsTotal = (int)item.recordsTotal;
                        model.recordsFiltered = (int)item.recordsFiltered;
                        list.Add(model);
                    }

                    result.draw = draw ?? 0;
                    result.recordsTotal = list.Count != 0 ? list[0].recordsTotal : 0;
                    result.recordsFiltered = list.Count != 0 ? list[0].recordsFiltered : 0;
                    result.data = list;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }

        public EvaluationViewModel EvaluationByUser(int userid, int capid)
        {
            try
            {
                EvaluationViewModel model = new EvaluationViewModel();
                using (SATEntities db = new SATEntities())
                {
                    var user = db.vw_Employee.Where(x => x.UserID == userid).FirstOrDefault();
                    model.UserID = user.UserID;
                    model.IDCard = user.IDCard;
                    model.FullNameTh = user.TiShortName + user.FullNameTh;

                    var cap = db.vw_Capability.Where(x => x.CapID == capid).FirstOrDefault();
                    model.CapYear = cap.CapYear;
                    model.CapTName = cap.CapTName;
                    model.CapGName = cap.CapGName;
                    model.CapGTName = cap.CapGTName;
                    model.EvaluationName = cap.CapTName + " / " + cap.CapGName + " / " + cap.CapGTName;

                    List<EvaluationDetailViewModel> lists = new List<EvaluationDetailViewModel>();
                    var evaluation = db.sp_Evaluation_GetByUser(userid, capid).ToList();
                    foreach (var item in evaluation)
                    {
                        EvaluationDetailViewModel eval = new EvaluationDetailViewModel();
                        eval.UserID = userid;
                        eval.CapDID = item.CapDID;
                        eval.CapDName = item.CapDName;
                        eval.CapDDesc = item.CapDDesc;
                        eval.CapScore1 = item.Score1;
                        eval.CapScore2 = item.Score2;
                        eval.UserScore1 = item.UserScore1;
                        eval.UserScore2 = item.UserScore2;
                        lists.Add(eval);
                    }
                    model.ListEvaluation = lists;

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseData UpdateEntity(List<EvaluationDetailViewModel> newdata)
        {
            using (SATEntities db = new SATEntities())
            {
                ResponseData result = new Models.ResponseData();
                try
                {
                    foreach (var item in newdata)
                    {
                        var objUpdate = db.tb_Evaluation.Where(x => x.UserID == item.UserID && x.CapDID == item.CapDID).FirstOrDefault();
                        if (objUpdate != null)
                        {
                            objUpdate.Score1 = item.UserScore1;
                            objUpdate.Score2 = item.UserScore2;
                            objUpdate.CreateBy = UtilityService.User.UserID;
                            objUpdate.CreateDate = DateTime.Now;
                            objUpdate.ModifyBy = UtilityService.User.UserID;
                            objUpdate.ModifyDate = DateTime.Now;
                            db.SaveChanges();
                        }
                        else
                        {
                            tb_Evaluation objInsert = new tb_Evaluation();
                            objInsert.UserID = (int)item.UserID;
                            objInsert.CapDID = item.CapDID;
                            objInsert.Score1 = item.UserScore1;
                            objInsert.Score2 = item.UserScore2;
                            objInsert.CreateBy = UtilityService.User.UserID;
                            objInsert.CreateDate = DateTime.Now;
                            objInsert.ModifyBy = UtilityService.User.UserID;
                            objInsert.ModifyDate = DateTime.Now;
                            db.tb_Evaluation.Add(objInsert);
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.MessageCode = "";
                    result.MessageText = ex.Message;
                }
                return result;
            }
        }


    }
}