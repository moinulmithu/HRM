using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class AspNetUsersEntity
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email ID")]
        public string EmailID { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Display(Name = "Client ID")]
        public int? ClientID { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        [Display(Name = "User Image")]
        public string UserImage { get; set; }
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

    }
}
