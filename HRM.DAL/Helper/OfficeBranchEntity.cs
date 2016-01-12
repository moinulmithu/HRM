using HRM.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DAL.Helper
{
    public class OfficeBranchEntity : BaseEntity
    {
        
        public string BranchName { get; set; }
        public int BranchType { get; set; }
        public string BranchCode { get; set; }
        //public string CreatedDate { get; set; }
        //public int SortOrder { get; set; }
        //public int CompanyID { get; set; }

    }
}
