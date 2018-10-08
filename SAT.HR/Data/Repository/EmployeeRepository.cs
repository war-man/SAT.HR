﻿using SAT.HR.Data.Entities;
using SAT.HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAT.HR.Data.Repository
{
    public class EmployeeRepository
    {
        public List<EmployeeViewModel> GetAll()
        {
            using (SATEntities db = new SATEntities())
            {
                var list = db.tb_User.Select(s => new EmployeeViewModel()
                {
                    UserID = s.UserID,
                    UserName = s.UserName,
                    Password = s.Password,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    UserType = s.UserType,
                    //UserTypeName = s.UserTypeName,
                    SexID = s.SexID,
                    //SexName = s.SexName,
                })
                .OrderBy(x => x.UserName).ToList();
                return list;
            }
        }

        public List<EmployeeViewModel> GetEmployee()
        {
            using (SATEntities db = new SATEntities())
            {
                var list = GetAll();
                
                return list;
            }
        }

        public EmployeePageResult GetPage(string filter, int? draw, int? initialPage, int? pageSize, string sortDir, string sortBy)
        {
            using (SATEntities db = new SATEntities())
            {
                var data = db.tb_User.ToList();

                int recordsTotal = data.Count();

                if (!string.IsNullOrEmpty(filter))
                {
                    data = data.Where(x => x.UserName.Contains(filter)).ToList();
                }

                int recordsFiltered = data.Count();

                switch (sortBy)
                {
                    case "UserName":
                        data = (sortDir == "asc") ? data.OrderBy(x => x.UserName).ToList() : data.OrderByDescending(x => x.UserName).ToList();
                        break;

                }

                int start = initialPage.HasValue ? (int)initialPage / (int)pageSize : 0;
                int length = pageSize ?? 10;

                var list = data.Select((s, i) => new EmployeeViewModel()
                {
                    RowNumber = ++i,
                    UserID = s.UserID,
                    UserName = s.UserName,
                    Password = s.Password,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    UserType = s.UserType,
                    //UserTypeName = s.UserTypeName,
                    SexID = s.SexID,
                    //SexName = s.SexName,
                }).Skip(start * length).Take(length).ToList();


                EmployeePageResult result = new EmployeePageResult();
                result.draw = draw ?? 0;
                result.recordsTotal = recordsTotal;
                result.recordsFiltered = recordsFiltered;
                result.data = list;

                return result;
            }
        }

    }
}