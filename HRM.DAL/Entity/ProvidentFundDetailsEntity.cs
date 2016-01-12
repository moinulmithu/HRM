using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
   public class ProvidentFundDetailsEntity : BaseEntity
    {
        [Display(Name = "Emp Code")]
        public string EmpCode { get; set; }
        public int FromPeriodID { get; set; }
        public int ToPeriodID { get; set; }
        [Display(Name = "Emp Name")]
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        [Display(Name = "Period Name")]
        public string PeriodName { get; set; }
       [Display(Name = "PF Per")]
        public decimal PFPer { get; set; }
       [Display(Name = "PF Own")]
        public decimal PFOwn { get; set; }
       [Display(Name = "PF Comp.")]
        public decimal PFComp { get; set; }
    }
}
