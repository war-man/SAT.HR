﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAT.HR.Models;
using SAT.HR.Data.Repository;
using SAT.HR.Helpers;
using System.IO;

namespace SAT.HR.Controllers
{
    public class HumanResourceController : BaseController
    {
        #region สมรรถนะ

        public ActionResult Capability()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Capability(int? draw, int? start, int? length, List<Dictionary<string, string>> order, List<Dictionary<string, string>> columns)
        {
            var search = Request["search[value]"];
            var dir = order[0]["dir"].ToLower();
            var column = columns[int.Parse(order[0]["column"])]["data"];
            var dataTableData = new CapabilityRepository().GetPage(search, draw, start, length, dir, column);
            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveCapability(CapabilityViewModel model)
        {
            ResponseData result = new Models.ResponseData();
            if (model.CapID != 0)
                result = new CapabilityRepository().UpdateByEntity(model);
            else
                result = new CapabilityRepository().AddByEntity(model);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCapability(int id)
        {
            var result = new CapabilityRepository().RemoveByID(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CapabilityHeader(int? id)
        {
            CapabilityViewModel model = new CapabilityViewModel();
            if (id.HasValue)
                model = new CapabilityRepository().GetByID((int)id);
            ViewBag.CapabilityType = DropDownList.GetCapabilityType(model.CapTID);
            ViewBag.CapabilityGroup = DropDownList.GetCapabilityGroup(model.CapGID);
            ViewBag.CapabilityGroupType = DropDownList.GetCapabilityGroupType(model.CapGID, model.CapGTID);
            return PartialView("_Capability", model);
        }

        public ActionResult CapabilityDetail(int? id)
        {
            var model = new List<CapabilityDetailViewModel>();
            if (id.HasValue)
                model = new CapabilityDetailRepository().GetByCap((int)id);
            CapabilityViewModel result = new CapabilityViewModel();
            result.CapID = (int)id;
            result.ListCapability = model;
            return View(result);
            //return PartialView("_CapabilityDetail", model);
        }

        public JsonResult SaveCapabilityDetail(CapabilityViewModel model)
        {
            ResponseData result = new Models.ResponseData();
            //if (model.CapID != 0)
            //    result = new CapabilityDetailRepository().UpdateByEntity(model);
            //else
            //    result = new CapabilityDetailRepository().AddByEntity(model);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SubmitCapabilityDetail(List<CapabilityDetailViewModel> model)
        {
            ResponseData result = new Models.ResponseData();
            result = new CapabilityDetailRepository().SubmitByEntity(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCapabilityDetail(int id)
        {
            var result = new CapabilityDetailRepository().RemoveByID(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CapabilityGroupType(int capgid)
        {
            var result = DropDownList.GetCapabilityGroupType(capgid, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCapability(int? year)
        {
            var result = DropDownList.GetCapability(year, null);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  บันทึกข้อมูลสมรรถนะ

        public ActionResult Evaluation(int? year, int? usertype)
        {
            ViewBag.YearCapability = DropDownList.GetYearCapability(null);
            ViewBag.Capability = DropDownList.GetCapability(year, null);
            ViewBag.UserType = DropDownList.GetUserType(usertype);
            return View();
        }

        [HttpPost]
        public JsonResult Evaluation(int? draw, int? start, int? length, List<Dictionary<string, string>> order, List<Dictionary<string, string>> columns,string usertype, string capid)
        {
            var search = Request["search[value]"];
            var dir = order[0]["dir"].ToLower();
            var column = columns[int.Parse(order[0]["column"])]["data"];
            var dataTableData = new EvaluationRepository().GetPage(search, draw, start, length, dir, column, usertype, capid);
            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EvaluationDetail(int id, int capid)
        {
            var model = new EvaluationRepository().EvaluationByUser(id, capid);
            return View(model);
        }

        public JsonResult SaveEvaluation(EvaluationViewModel model)
        {
            ResponseData result = new EvaluationRepository().UpdateEntity(model.ListEvaluation);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region  การฝึกอบรม

        public ActionResult Trainning()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Trainning(int? draw, int? start, int? length, List<Dictionary<string, string>> order, List<Dictionary<string, string>> columns)
        {
            var search = Request["search[value]"];
            var dir = order[0]["dir"].ToLower();
            var column = columns[int.Parse(order[0]["column"])]["data"];
            var dataTableData = new TrainningRepository().GetPage(search, draw, start, length, dir, column);
            return Json(dataTableData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CourseTrainningDetail(int? id)
        {
            var model = new TrainningRepository().GetByID(id);
            ViewBag.Country = DropDownList.GetCountry(model.CountryID);
            ViewBag.CourseType = DropDownList.GetCourseType(model.CourseTID);
            return View(model);
        }

        public ActionResult CourseTrainningDetailByID(int? id)
        {
            var model = new TrainningRepository().GetByID(id);
            return PartialView("_TrainningDetail", model);
        }

        public JsonResult SaveCourseTrainning(CourseViewModel data)
        {
            ResponseData result = new Models.ResponseData();
            if (data.CourseID != 0)
                result = new TrainningRepository().UpdateByEntity(data);
            else
                result = new TrainningRepository().AddByEntity(data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadFileCourseTrainning(int id)
        {
            var result = new TrainningRepository().DownloadFileCourse(id);
            string fileName = result.FileName;
            string filePath = result.FilePath;
            string contentType = result.ContentType;
            return new FilePathResult(Path.Combine(filePath, fileName), contentType);
        }

        #endregion

        #region  การวางแผนพัฒนารายบุคคล

        public ActionResult IndividualPlan()
        {
            return View();
        }

        public ActionResult IndividualPlanDetail()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult IndividualPlan(int? draw, int? start, int? length, List<Dictionary<string, string>> order, List<Dictionary<string, string>> columns)
        //{
        //    var search = Request["search[value]"];
        //    var dir = order[0]["dir"].ToLower();
        //    var column = columns[int.Parse(order[0]["column"])]["data"];
        //    var dataTableData = new IndividualPlanRepository().GetPage(search, draw, start, length, dir, column);
        //    return Json(dataTableData, JsonRequestBehavior.AllowGet);
        //}


        #endregion
    }
}