﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SAT.HR.Models
{
    public class BonusCalculatorViewModel
    {
        public Nullable<int> Seq { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string BookCmd { get; set; }
        public DateTime? DateCmd { get; set; }
        public string PathFile { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public HttpPostedFileBase FileUpload { get; set; }
        public BonusCalculatorStep1ViewModel Step1 { get; set; }
        public List<BonusCalculatorStep2ViewModel> Step2 { get; set; }
        public BonusCalculatorStep3ViewModel Step3 { get; set; }
    }

    public class BonusCalculatorStep1ViewModel
    {
        public Nullable<int> Seq { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> Rate { get; set; }
    }

    public class BonusCalculatorStep2ViewModel
    {
        public Nullable<int> Year { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> Seq { get; set; }
        public string FullNameTh { get; set; }
        public Nullable<decimal> UpStep { get; set; }
        public Nullable<decimal> Bonus { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<decimal> M1 { get; set; }
        public Nullable<decimal> M2 { get; set; }
        public Nullable<decimal> M3 { get; set; }
        public Nullable<decimal> M4 { get; set; }
        public Nullable<decimal> M5 { get; set; }
        public Nullable<decimal> M6 { get; set; }
        public Nullable<decimal> M7 { get; set; }
        public Nullable<decimal> M8 { get; set; }
        public Nullable<decimal> M9 { get; set; }
        public Nullable<decimal> M10 { get; set; }
        public Nullable<decimal> M11 { get; set; }
        public Nullable<decimal> M12 { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }

    public class BonusCalculatorStep3ViewModel
    {
        public string BookCmd { get; set; }
        public DateTime? DateCmd { get; set; }
        public string PathFile { get; set; }
        public HttpPostedFileBase FileUpload { get; set; }
    }

    public class BonusCalculatorToExport
    {
        [DisplayName("ปีบัญชี")]
        public Nullable<int> Year { get; set; }

        [DisplayName("รอบที่")]
        public Nullable<int> Seq { get; set; }

        [DisplayName("ชื่อ นามสกุล")]
        public string FullNameTh { get; set; }

        [DisplayName("อัตรา")]
        public Nullable<decimal> UpStep { get; set; }

        [DisplayName("โบนัส")]
        public Nullable<decimal> Bonus { get; set; }

        [DisplayName("เงินเดือน")]
        public Nullable<decimal> Salary { get; set; }

        public Nullable<decimal> M1 { get; set; }
        public Nullable<decimal> M2 { get; set; }
        public Nullable<decimal> M3 { get; set; }
        public Nullable<decimal> M4 { get; set; }
        public Nullable<decimal> M5 { get; set; }
        public Nullable<decimal> M6 { get; set; }
        public Nullable<decimal> M7 { get; set; }
        public Nullable<decimal> M8 { get; set; }
        public Nullable<decimal> M9 { get; set; }
        public Nullable<decimal> M10 { get; set; }
        public Nullable<decimal> M11 { get; set; }
        public Nullable<decimal> M12 { get; set; }
    }

    public class BonusCalculatorHeader
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<BonusCalculatorHeaderViewModel> data { get; set; }
    }

    public class BonusCalculatorHeaderViewModel
    {
        public int RowNumber { get; set; }
        public int HeaderID { get; set; }
        public Nullable<int> Seq { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string BookCmd { get; set; }
        public DateTime? DateCmd { get; set; }
        public string PathFile { get; set; }
        public string DateCmdText { get; set; }
    }

}