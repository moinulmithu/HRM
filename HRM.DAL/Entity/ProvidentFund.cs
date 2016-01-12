using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DAL.Entity
{
    public class ProvidentFundEntity : BaseEntity
    {

        [Display(Name = "Emp Code")]
        public string EmpCode { get; set; }
        [Display(Name = "Emp Name")]
        public string EmpName { get; set; }
        public string Designation { get; set; }
        [Display(Name = "Period Name")]
        public string PeriodName { get; set; }
        [Display(Name = "PF Own")]
        public string PFOwn { get; set; }
        [Display(Name = "PF Company")]
        public string PFComp { get; set; }

        public int FromPeriodID { get; set; }
        public int ToPeriodID { get; set; }
        public string PFPer { get; set; }

    }
}
