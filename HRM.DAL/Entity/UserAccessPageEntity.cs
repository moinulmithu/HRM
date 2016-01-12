using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class UserAccessPageEntity : BaseEntity
    {

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Menu Name")]
        public int ManuID { get; set; }
        public bool Status { get; set; }
        public string NameOption { get; set; }

    }
}
