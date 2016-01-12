using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
  public  class NavbarEntity:BaseEntity
    {
        [Display(Name="Manu Name")]
        public string NameOption { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string ImageClass { get; set; }
        public string ActiveLi { get; set; }
        public bool Status { get; set; }
        public int ParentID { get; set; }
        public bool IsParent { get; set; }
        public string UserName { get; set; }
    }
}
