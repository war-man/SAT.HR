﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAT.HR.Data.Entities;
using SAT.HR.Models;

namespace SAT.HR.Data.Repository
{
    public class LeaveTypeRepository
    {
        public LeaveTypeResult GetPage(string filter, int? draw, int? initialPage, int? pageSize, string sortDir, string sortBy)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_LeaveType.ToList();

                int recordsTotal = data.Count();

                if (!string.IsNullOrEmpty(filter))
                {
                    data = data.Where(x => x.LevYear.Contains(filter)).ToList();
                }

                int recordsFiltered = data.Count();

                switch (sortBy)
                {
                    case "LevYear":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.LevYear).ToList() : data.OrderByDescending(x => x.LevYear).ToList(); break;
                    case "LevName":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.LevName).ToList() : data.OrderByDescending(x => x.LevName).ToList(); break;
                    case "LevStartDateText":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.LevStartDate).ToList() : data.OrderByDescending(x => x.LevStartDate).ToList(); break;
                    case "LevEndDateText":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.LevEndDate).ToList() : data.OrderByDescending(x => x.LevEndDate).ToList(); break;
                    case "LevMax":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.LevMax).ToList() : data.OrderByDescending(x => x.LevMax).ToList(); break;
                }

                int start = initialPage.HasValue ? (int)initialPage / (int)pageSize : 0;
                int length = pageSize ?? 10;

                var list = data.Select((s, i) => new LeaveTypeViewModel()
                {
                    RowNumber = ++i,
                    LevID = s.LevID,
                    LevYear = s.LevYear,
                    LevName = s.LevName,
                    LevStartDateText = s.LevStartDate.Value.ToString("dd/MM/yyyy"),
                    LevEndDateText = s.LevEndDate.Value.ToString("dd/MM/yyyy"),
                    LevMax = s.LevMax,
                    LevStatus = s.LevStatus,
                }).Skip(start * length).Take(length).ToList();

                LeaveTypeResult result = new LeaveTypeResult();
                result.draw = draw ?? 0;
                result.recordsTotal = recordsTotal;
                result.recordsFiltered = recordsFiltered;
                result.data = list;

                return result;
            }
        }

        public LeaveTypeViewModel GetByID(int id)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_LeaveType.Where(x => x.LevID == id).FirstOrDefault();
                LeaveTypeViewModel model = new Models.LeaveTypeViewModel();
                model.LevID = data.LevID;
                model.LevYear = data.LevYear;
                model.LevName = data.LevName;
                model.LevStartDate = data.LevStartDate;
                model.LevEndDate = data.LevEndDate;
                model.LevMax = data.LevMax;
                return model;
            }
        }

        public ResponseData AddByEntity(LeaveTypeViewModel data)
        {
            using (SATEntities db = new SATEntities())
            {
                ResponseData result = new Models.ResponseData();
                try
                {
                    tb_LeaveType model = new tb_LeaveType();
                    model.LevID = data.LevID;
                    model.LevYear = data.LevYear;
                    model.LevName = data.LevName;
                    model.LevStartDate = data.LevStartDate;
                    model.LevEndDate = data.LevEndDate;
                    model.LevMax = data.LevMax;
                    model.CreateBy = data.ModifyBy;
                    model.CreateDate = DateTime.Now;
                    model.ModifyBy = data.ModifyBy;
                    model.ModifyDate = DateTime.Now;
                    db.tb_LeaveType.Add(model);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return result;
            }
        }

        public ResponseData UpdateByEntity(LeaveTypeViewModel newdata)
        {
            using (SATEntities db = new SATEntities())
            {
                ResponseData result = new Models.ResponseData();
                try
                {
                    var data = db.tb_LeaveType.Single(x => x.LevID == newdata.LevID);
                    data.LevYear = newdata.LevYear;
                    data.LevName = newdata.LevName;
                    data.LevStartDate = newdata.LevStartDate;
                    data.LevEndDate = newdata.LevEndDate;
                    data.LevMax = newdata.LevMax;
                    data.ModifyBy = newdata.ModifyBy;
                    data.ModifyDate = DateTime.Now;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return result;
            }
        }

        public ResponseData RemoveByID(int id)
        {
            ResponseData result = new Models.ResponseData();
            using (SATEntities db = new SATEntities())
            {
                try
                {
                    var obj = db.tb_LeaveType.SingleOrDefault(c => c.LevID == id);
                    if (obj != null)
                    {
                        db.tb_LeaveType.Remove(obj);
                        db.SaveChanges();
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