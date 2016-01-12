using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;

using System.Security;



namespace HRM.DAL.Entity
{
    public class UserRegistrationEntity //: BaseEntity
    {
        [Required(ErrorMessage="Email is Required")]
        [Display(Name="Email ID")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Please provide fullname", AllowEmptyStrings = false)]
        [Display(Name="Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")] 
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please provide Mobile Number", AllowEmptyStrings = false)]
        [Display(Name="Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please provide Date Of Birth", AllowEmptyStrings = false)]
        [Display(Name="Date Of Birth")]
        public string dob { get; set; }

        [Required(ErrorMessage = "Please provide Current Location", AllowEmptyStrings = false)]
        [Display(Name="Current Location")]
        public string CurrentLocation { get; set; }

        public string RegisDateTime { get; set; }
    }
}
