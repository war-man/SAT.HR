﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAT.HR.Data.Entities;
using SAT.HR.Models;

namespace SAT.HR.Data.Repository
{
    public class MajorRepository
    {
        public MajorResult GetPage(string filter, int? draw, int? initialPage, int? pageSize, string sortDir, string sortBy)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_Major.ToList();

                int recordsTotal = data.Count();

                if (!string.IsNullOrEmpty(filter))
                {
                    data = data.Where(x => x.MajName.Contains(filter)).ToList();
                }

                int recordsFiltered = data.Count();

                switch (sortBy)
                {
                    case "MajName":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.MajName).ToList() : data.OrderByDescending(x => x.MajName).ToList();
                        break;
                }

                int start = initialPage.HasValue ? (int)initialPage / (int)pageSize : 0;
                int length = pageSize ?? 10;

                var list = data.Select((s, i) => new MajorViewModel()
                {
                    RowNumber = ++i,
                    MajID = s.MajID,
                    MajName = s.MajName,
                    MajStatus = s.MajStatus,
                }).Skip(start * length).Take(length).ToList();

                MajorResult result = new MajorResult();
                result.draw = draw ?? 0;
                result.recordsTotal = recordsTotal;
                result.recordsFiltered = recordsFiltered;
                result.data = list;

                return result;
            }
        }

        public MajorViewModel GetByID(int id)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_Major.Where(x => x.MajID == id).FirstOrDefault();
                MajorViewModel model = new Models.MajorViewModel();
                model.MajID = data.MajID;
                model.MajName = data.MajName;
                model.MajStatus = data.MajStatus;
                return model;
            }
        }

        public ResponseData AddByEntity(MajorViewModel data)
        {
            using (SATEntities db = new SATEntities())
            {
                ResponseData result = new Models.ResponseData();
                try
                {
                    tb_Major model = new tb_Major();
                    model.MajID = data.MajID;
                    model.MajName = data.MajName;
                    model.MajStatus = data.MajStatus;
                    model.CreateBy = data.ModifyBy;
                    model.CreateDate = DateTime.Now;
                    model.ModifyBy = data.ModifyBy;
                    model.ModifyDate = DateTime.Now;
                    db.tb_Major.Add(model);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                }
                return result;
            }
        }

        public ResponseData UpdateByEntity(MajorViewModel newdata)
        {
            using (SATEntities db = new SATEntities())
            {
                ResponseData result = new Models.ResponseData();
                try
                {
                    var data = db.tb_Major.Single(x => x.MajID == newdata.MajID);
                    data.MajName = newdata.MajName;
                    data.MajStatus = newdata.MajStatus;
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
                    var obj = db.tb_Major.SingleOrDefault(c => c.MajID == id);
                    if (obj != null)
                    {
                        db.tb_Major.Remove(obj);
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