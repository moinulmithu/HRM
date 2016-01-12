using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public  class ProcessEmpSalaryStructureEntity : BaseEntity
    {
       
        public int EmpID { get; set; }
        public string EmpCode { get; set; }
      

        public int StructureID { get; set; }
        public int SalaryHeadID { get; set; }
        public int SalaryHeadType { get; set; }
        public int YearID { get; set; }
         public int? TaxYearID { get; set; }
        public decimal? Amount { get; set; }
        public int SalaryTypeID { get; set; }
        public int BasedOnID { get; set; }
        public string CreatedDate { get; set; }
        public int PeriodID { get; set; }
        public string PeriodName { get; set; }
        public int SortOrder { get; set; }
        public int CompanyID { get; set; }
       
        public string Division { get; set; }


        public string AccountName { get; set; }
        public decimal? TaxableAmount { get; set; }
        public decimal? ExempAmount { get; set; }

        
        public decimal? Taxable { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? SlabAmount { get; set; }
        public decimal? TaxAmount { get; set; }

        public string SlabText { get; set; }



        public string EmpName { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string TaxYearName { get; set; }

    }
}
