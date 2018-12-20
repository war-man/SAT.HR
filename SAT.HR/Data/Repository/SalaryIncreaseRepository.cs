﻿using SAT.HR.Data.Entities;
using SAT.HR.Helpers;
using SAT.HR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SAT.HR.Data
{
    public class SalaryIncreaseRepository
    {
        public SalaryIncreaseViewModel SalaryIncrease()
        {
            try
            {
                SalaryIncreaseViewModel model = new SalaryIncreaseViewModel();
                model.Year = DateTime.Now.Year + 543;
                model.UpLevel = 1;
                model.UpStep = (decimal)1.0;

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SalaryIncreaseSep1ViewModel SalaryIncreaseSep1()
        {
            try
            {
                SalaryIncreaseSep1ViewModel model = new SalaryIncreaseSep1ViewModel();
                model.Year = DateTime.Now.Year + 543;
                model.UpLevel = 1;
                model.UpStep = (decimal)1.0;

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SalaryIncreaseViewModel GetEmpSalaryIncrease(int year, int level, decimal step)
        {
            SalaryIncreaseViewModel model = new SalaryIncreaseViewModel();
            using (SATEntities db = new SATEntities())
            {
                try
                {
                    List<SalaryIncreaseSep2ViewModel> listStep2 = new List<SalaryIncreaseSep2ViewModel>();
                    var salaryincrease = db.sp_Salary_Increase_List(year, level, step).ToList();
                    foreach (var item in salaryincrease)
                    {
                        SalaryIncreaseSep2ViewModel step2 = new SalaryIncreaseSep2ViewModel();
                        step2.Year = item.Year;
                        step2.Seq = item.Seq;
                        step2.UpStep = item.UpStep;
                        step2.UserID = item.UserID;
                        step2.FullNameTh = item.FullNameTh;
                        step2.Old_Level = item.Old_Level;
                        step2.New_Level = item.New_Level;
                        step2.Old_Step = item.Old_Step;
                        step2.New_Step = item.New_Step;
                        step2.Old_Salary = item.Old_Salary;
                        step2.New_Salary = item.New_Salary;
                        step2.Selected = true;
                        listStep2.Add(step2);
                    }
                    model.Step2 = listStep2;
                }
                catch (Exception ex)
                {
                    throw;
                }
                return model;
            }
        }

        public ResponseData UpdateSalaryIncrease(SalaryIncreaseViewModel data)
        {
            using (SATEntities db = new SATEntities())
            {
                using (var transection = db.Database.BeginTransaction())
                {
                    ResponseData result = new ResponseData();
                    try
                    {
                        tb_Salary_Increase_Header head = new tb_Salary_Increase_Header();

                        #region FileUpload

                        if (data.FileUpload != null)
                        {
                            HttpPostedFileBase fileUpload = data.FileUpload;
                            if (fileUpload != null && fileUpload.ContentLength > 0)
                            {
                                var fileName = Path.GetFileName(fileUpload.FileName);
                                var fileExt = System.IO.Path.GetExtension(fileUpload.FileName).Substring(1);

                                string directory = SysConfig.PathUploadSalaryIncrease;
                                bool isExists = System.IO.Directory.Exists(directory);
                                if (!isExists)
                                    System.IO.Directory.CreateDirectory(directory);

                                string newFileName = (data.Step2.Count > 0 ? data.Step2[0].Seq : 1) + "_" + data.Year + "." + fileExt;
                                string fileLocation = Path.Combine(directory, newFileName);

                                fileUpload.SaveAs(fileLocation);

                                data.PathFile = newFileName;
                            }
                        }

                        #endregion

                        #region tb_Salary_Increase_Header

                        head.Seq = data.Step2.Count > 0 ? data.Step2[0].Seq : 1;
                        head.Year = data.Year;
                        head.UpLevel = data.UpLevel;
                        head.UpStep = data.UpStep;
                        head.BookCmd = data.BookCmd;
                        head.DateCmd = data.DateCmd;
                        head.DateEff = data.DateEff;
                        head.PathFile = data.PathFile;
                        head.CreateBy = UtilityService.User.UserID;
                        head.CreateDate = DateTime.Now;
                        head.ModifyBy = UtilityService.User.UserID;
                        head.ModifyDate = DateTime.Now;
                        db.tb_Salary_Increase_Header.Add(head);
                        db.SaveChanges();

                        #endregion

                        int headerID = head.HeaderID;
                        if (data.Step2 != null)
                        {
                            foreach (var item in data.Step2)
                            {
                                if (Convert.ToBoolean(item.Selected))
                                {
                                    #region tb_Salary_Increase_Detail

                                    tb_Salary_Increase_Detail detail = new tb_Salary_Increase_Detail();
                                    detail.HeaderID = headerID;
                                    detail.Year = item.Year;
                                    detail.Seq = item.Seq;
                                    detail.UpStep = item.UpStep;
                                    detail.UserID = item.UserID;
                                    detail.FullNameTh = item.FullNameTh;
                                    detail.Old_Level = item.Old_Level;
                                    detail.New_Level = item.New_Level;
                                    detail.Old_Step = item.Old_Step;
                                    detail.New_Step = item.New_Step;
                                    detail.Old_Salary = item.Old_Salary;
                                    detail.New_Salary = item.New_Salary;
                                    detail.CreateBy = UtilityService.User.UserID;
                                    detail.CreateDate = DateTime.Now;
                                    detail.ModifyBy = UtilityService.User.UserID;
                                    detail.ModifyDate = DateTime.Now;
                                    db.tb_Salary_Increase_Detail.Add(detail);
                                    db.SaveChanges();

                                    #endregion

                                    #region tb_user

                                    var user = db.tb_User.Where(m => m.UserID == item.UserID).FirstOrDefault();
                                    user.SalaryLevel = item.New_Level;
                                    user.SalaryStep = item.New_Step;
                                    user.Salary = item.New_Salary;
                                    user.ModifyBy = UtilityService.User.UserID;
                                    user.ModifyDate = DateTime.Now;
                                    db.SaveChanges();

                                    #endregion
                                }
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

        public FileViewModel DownloadSalaryIncrease(int? id)
        {
            FileViewModel model = new FileViewModel();
            try
            {
                using (SATEntities db = new SATEntities())
                {
                    var data = db.tb_Salary_Increase_Header.Where(x => x.HeaderID == id).FirstOrDefault();
                    string filename = data.PathFile;

                    string[] fileSplit = filename.Split('.');
                    int length = fileSplit.Length - 1;
                    string fileExt = fileSplit[length].ToUpper();

                    var doctype = db.tb_Document_Type.Where(x => x.DocType == fileExt).FirstOrDefault();
                    string Contenttype = doctype.ContentType;

                    string filepath = SysConfig.PathDownloadSalaryIncrease;

                    model.FileName = filename;
                    model.FilePath = filepath;
                    model.ContentType = Contenttype;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return model;
        }

        public List<SalaryIncreaseToExport> GetSalaryIncreaseToExport(SalaryIncreaseViewModel data)
        {
            using (SATEntities db = new SATEntities())
            {
                var model = new List<SalaryIncreaseToExport>();
                foreach (var item in data.Step2)
                {
                    //if (Convert.ToBoolean(item.Selected))
                    {
                        SalaryIncreaseToExport obj = new SalaryIncreaseToExport();
                        obj.Year = item.Year;
                        obj.Seq = item.Seq;
                        obj.FullNameTh = item.FullNameTh;
                        obj.UpStep = item.UpStep;
                        obj.Level = item.Old_Level;
                        obj.Old_Step = item.Old_Step;
                        obj.New_Step = item.New_Step;
                        obj.Old_Salary = item.Old_Salary;
                        obj.New_Salary = item.New_Salary;
                        model.Add(obj);
                    }
                }
                return model;
            }
        }

        public SalaryIncreaseHeader GetSalaryIncreaseHistory(string filter, int? draw, int? initialPage, int? pageSize, string sortDir, string sortBy)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_Salary_Increase_Header.ToList();

                int recordsTotal = data.Count();

                if (!string.IsNullOrEmpty(filter))
                {
                    data = data.Where(x => x.Year.ToString().Contains(filter) || x.Seq.ToString().Contains(filter) || x.UpLevel.ToString().Contains(filter) 
                    || x.UpStep.ToString().Contains(filter) || x.BookCmd.Contains(filter)).ToList();
                }

                int recordsFiltered = data.Count();

                switch (sortBy)
                {
                    #region

                    case "Year":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.Year).ToList() : data.OrderByDescending(x => x.Year).ToList();
                        break;
                    case "Seq":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.Seq).ToList() : data.OrderByDescending(x => x.Seq).ToList();
                        break;
                    case "UpLevel":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.UpLevel).ToList() : data.OrderByDescending(x => x.UpLevel).ToList();
                        break;
                    case "UpStep":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.UpStep).ToList() : data.OrderByDescending(x => x.UpStep).ToList();
                        break;
                    case "BookCmd":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.BookCmd).ToList() : data.OrderByDescending(x => x.BookCmd).ToList();
                        break;
                    case "DateCmdText":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.DateCmd).ToList() : data.OrderByDescending(x => x.DateCmd).ToList();
                        break;
                    case "DateEffText":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.DateEff).ToList() : data.OrderByDescending(x => x.DateEff).ToList();
                        break;

                   #endregion
                }

                int start = initialPage.HasValue ? (int)initialPage / (int)pageSize : 0;
                int length = pageSize ?? 10;

                var list = data.Select((s, i) => new SalaryIncreaseHeaderViewModel()
                {
                    RowNumber = ++i,
                    HeaderID = s.HeaderID,
                    Year = s.Year,
                    Seq = s.Seq,
                    UpLevel = s.UpLevel,
                    UpStep = s.UpStep,
                    BookCmd = s.BookCmd,
                    DateCmd = s.DateCmd,
                    DateEff = s.DateEff,
                    PathFile = s.PathFile,
                    DateCmdText = s.DateCmd.Value.ToString("dd/MM/yyy"),
                    DateEffText = s.DateEff.Value.ToString("dd/MM/yyy"),
                }).Skip(start * length).Take(length).ToList();

                SalaryIncreaseHeader result = new SalaryIncreaseHeader();
                result.draw = draw ?? 0;
                result.recordsTotal = recordsTotal;
                result.recordsFiltered = recordsFiltered;
                result.data = list;

                return result;
            }
        }

        public SalaryIncreaseViewModel GetSalaryIncreaseHistoryDetail(int id)
        {
            try
            {
                using (SATEntities db = new SATEntities())
                {
                    SalaryIncreaseViewModel model = new SalaryIncreaseViewModel();

                    var header = db.tb_Salary_Increase_Header.Where(m => m.HeaderID == id).FirstOrDefault();
                    model.Year = header.Year;
                    model.UpLevel = header.UpLevel;
                    model.UpStep = header.UpStep;
                    model.UpLevel = header.UpLevel;
                    model.UpStep = header.UpStep;
                    model.BookCmd = header.BookCmd;
                    model.DateCmd = header.DateCmd;
                    model.DateEff = header.DateEff;
                    model.PathFile = header.PathFile;
                    model.CreateBy = header.CreateBy;
                    model.CreateDate = header.CreateDate;

                    var list = new List<SalaryIncreaseSep2ViewModel>();
                    var detail = db.tb_Salary_Increase_Detail.Where(m => m.HeaderID == id).ToList();
                    foreach (var item in detail)
                    {
                        SalaryIncreaseSep2ViewModel objDetail = new SalaryIncreaseSep2ViewModel();
                        objDetail.Year = item.Year;
                        objDetail.Seq = (int)item.Seq;
                        objDetail.UpStep = item.UpStep;
                        objDetail.UserID = item.UserID;
                        objDetail.FullNameTh = item.FullNameTh;
                        objDetail.Old_Level = item.Old_Level;
                        objDetail.New_Level = item.New_Level;
                        objDetail.Old_Step = (decimal)item.Old_Step;
                        objDetail.New_Step = (decimal)item.New_Step;
                        objDetail.Old_Salary = (decimal)item.Old_Salary;
                        objDetail.New_Salary = (decimal)item.New_Salary;
                        objDetail.CreateBy = item.CreateBy;
                        objDetail.CreateDate = item.CreateDate;
                        list.Add(objDetail);
                    }
                    model.Step2 = list;

                    return model;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}