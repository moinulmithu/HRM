using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class GridtoPDFEntity
    {
        public string startdate { get; set; }
        public string enddate { get; set; }
        public string FileName { get; set; }
        public string FileLocation { get; set; }
        public int PeriodID { get; set; }
        public string CreatedDate { get; set; }
        public Int32 SendingStatus { get; set; }
    }
}
