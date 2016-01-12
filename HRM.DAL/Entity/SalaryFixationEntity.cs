using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class SalaryFixationEntity:BaseEntity
    {
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Address { get; set; }
        public string TINNo { get; set; }
        public string NID { get; set; }
        public string MobNo { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public string JoiningDate { get; set; }
        public string BirthDate { get; set; }
        public string CurrentGrade { get; set; }
        public string NumberOfChild { get; set; }
        public decimal Basic { get; set; }
        public decimal CurBasic { get; set; }
        public string LastIncreDate { get; set; }
        public string LastPromotionDate { get; set; }
        public string DateOfPresentScale { get; set; }
        public string PostingPlace { get; set; }
        public decimal NewBasic { get; set; }
        public decimal HouseRent { get; set; }
        public decimal Medical { get; set; }
        public decimal ChildEduAllow { get; set; }
        public decimal DA { get; set; }
        public decimal GrossSalary { get; set; }
        public int isApproved { get; set; }
        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
        public string ApprovedBy { get; set; }
        public string AppovalDate { get; set; }
        public decimal BasicASONJune2015 { get; set; }
        public decimal InitialBasic { get; set; }
        public decimal Increment { get; set; }
        public decimal StartingBasic { get; set; }
        public decimal NewBasicPoint { get; set; }
        public decimal PersonalPay { get; set; }
        public string Status { get; set; }
        public string FileNo { get; set; }
        public decimal BasicIncrement { get; set; }
        public decimal? Total34 { get; set; }
        public decimal? Total56 { get; set; }
        public decimal? Total78 { get; set; }
        public string GradeDes2009 { get; set; }
        public string GradeDes2015 { get; set; }//PayScale2009
        public string PayScale2009 { get; set; }
        public string PayScale2015 { get; set; }//PayScale2009
        public decimal NewBasicConDec15Basic { get; set; }







       
        
        
    }
}
