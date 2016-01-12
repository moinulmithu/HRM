using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class TaxYearInfoEntity : BaseEntity
    {
       
        public string TaxYearName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int TaxInfoID { get; set; }
        public int SortOrder { get; set; }
        public decimal TaxLimit { get; set; }
        public string ChallanNotes { get; set; }

    }
}
