﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAT.HR.Models
{
    public class BaseViewModels
    {
        public Actions actions { get; set; }

        public class Actions
        {
            public bool? IsView { get; set; }
            public bool? IsActionAdd { get; set; }
            public bool? IsActionEdit { get; set; }
            public bool? IsActionDeleted { get; set; }
            public bool? IsActionExport { get; set; }
        }
    }

    public class ResponseData
    {
        public string MessageCode { get; set; }
        public string MessageText { get; set; }
    }
}