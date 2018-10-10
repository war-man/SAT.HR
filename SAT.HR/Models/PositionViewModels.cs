using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAT.HR.Models
{
    public class PositionViewModel
    {
        public int RowNumber { get; set; }

        public int PoID { get; set; }

        public string PoCode { get; set; }

        public string PoName { get; set; }

        public bool? PoStatus { get; set; }

        public DateTime? CreateDate { get; set; }

        public Nullable<int> CreateBy { get; set; }

        public DateTime? ModifyDate { get; set; }

        public Nullable<int> ModifyBy { get; set; }
    }

    public class PositionResult
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<PositionViewModel> data { get; set; }
    }
}
