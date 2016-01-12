using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class SalaryPeriodEntity : BaseEntity
    {
        
        public string PeriodName { get; set; }
        public string MonthName { get; set; }
        public int YearID { get; set; }
        public string YearName { get; set; }
        public string FinancialYear { get; set; }
        public int TaxYearID { get; set; }
        public string TaxYear { get; set; }
        public string CreatedDate { get; set; }
        public int SortOrder { get; set; }
        public int CompanyID { get; set; }
        public int LockLabel { get; set; }
        public decimal DaysWorking { get; set; }
        public string MailText { get; set; }

        public Int32? NoOfDysInMonth { get; set; }
        public Int32? MonthId { get; set; }
        public string LockLabelDesc { get; set; }
        public int? IsReprocess { get; set; }
    }
}
