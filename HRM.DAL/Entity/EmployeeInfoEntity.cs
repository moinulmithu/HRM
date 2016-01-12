using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class EmployeeInfoEntity : BaseEntity
    {
        //public int ID { get; set; }
        public string EmpCode { get; set; }
        public string AptCode { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Resident { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
        public string Division { get; set; }
        public string BirthDate { get; set; }
        public string JoiningDate { get; set; }

       public string ResignDate { get; set; }
        public string OfficeBranch { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string StatusDate { get; set; }
        public string EmailID { get; set; }
        public string PayBy { get; set; }
        public string ProvidentFund { get; set; }
        public string AccNo { get; set; }
        public decimal? PFDeductAmt { get; set; }
        public string Bank { get; set; }
        public string PFDeductRule { get; set; }
        public string BankBranch { get; set; }
        public string IncomeTex { get; set; }
        public decimal? TaxDeductAmt { get; set; }
        public string IsBlock { get; set; }
        public string TinNo { get; set; }
        public string NationalID { get; set; }
        public string ConfirmationDate { get; set; }
        public string UserID { get; set; }
        public Int32 EmploymentStatus { get; set; }
        //public string ChangeType { get; set; }
        public string ChangeDate { get; set; }
        public string IsCompanyCar { get; set; }
        public Int32 WC_GrpLeaderId { get; set; }
        public decimal WC_DayWagesRate { get; set; }
        public string PunchCardNo { get; set; }
        public string ImgFileName { get; set; }
        //-- Optional Field


        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string JobGrade { get; set; }
        public string DutyStation { get; set; }
        public string ContractPeriod { get; set; }
        public string LastContractDay { get; set; }
        public string ResignationDay { get; set; }
        public string ReleaseDate { get; set; }

        public string SupervisorID1 { get; set; }
        public string SuperName1 { get; set; }
        public string SupervisorDesignation1 { get; set; }

        public string SupervisorID2 { get; set; }
        public string SuperName2 { get; set; }
        public string SupervisorDesignation2 { get; set; }

        public string ReviewerID { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerDesignation { get; set; }
        public Int32 EmploymentType { get; set; }
        public string Mobile { get; set; }
        public string PABX { get; set; }
        public string FatherName { get; set; }
        public string FatherCont { get; set; }
        public string MotherName { get; set; }
        public string MotherCont { get; set; }
        public string Religion { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string Spouse { get; set; }
        public string SpouseDOB { get; set; }
        public string Child1 { get; set; }
        public string Child1DOB { get; set; }
        public string Child2 { get; set; }
        public string Child2DOB { get; set; }
        public string Child3 { get; set; }
        public string Child3DOB { get; set; }

        public string Nominee1 { get; set; }
        public string NomRel1 { get; set; }
        public string Nomcont1 { get; set; }
        public decimal? NomShare1 { get; set; }

        public string Nominee2 { get; set; }
        public string NomRel2 { get; set; }
        public string Nomcont2 { get; set; }
        public decimal? NomShare2 { get; set; }

        public string Nominee3 { get; set; }
        public string NomRel3 { get; set; }
        public string Nomcont3 { get; set; }
        public decimal? NomShare3 { get; set; }

        public string Nominee4 { get; set; }
        public string NomRel4 { get; set; }
        public string Nomcont4 { get; set; }
        public decimal? NomShare4 { get; set; }

        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string JurisdictionDiv { get; set; }
        public string HighestEducation { get; set; }
        public string DegreeName { get; set; }
        public string AcademicSubject { get; set; }
        public string Institution { get; set; }
        public string LastOrganization { get; set; }
        public string PositionHeld { get; set; }
        public string LJReleaseDate { get; set; }
        public string PreExperience { get; set; }

        public string WalletNo { get; set; }
        public Int32 SalaryFundSource { get; set; }
        public Int32 AreaTypeId { get; set; }
        //public decimal? GrossAmount { get; set; }
        //public decimal? LFA { get; set; }
        public Int32 HaveDailyAllowance { get; set; }
        public Int32 HaveMobileAllowance { get; set; }
        public decimal DailyAllowance { get; set; }
        public decimal MobileAllowance { get; set; }

        public String ConfirmationText { get; set; }
        public byte[] EmpImage { get; set; }
        public int? PrintOrder { get; set; }
        public string _Group { get; set; }

        public string RefName1 { get; set; }
        public string RefDesig1 { get; set; }
        public string RefORG1 { get; set; }
        public string RefCont1 { get; set; }
        public string RefEmail1 { get; set; }

        public string RefName2 { get; set; }
        public string RefDesig2 { get; set; }
        public string RefORG2 { get; set; }
        public string RefCont2 { get; set; }
        public string RefEmail2 { get; set; }

        public int? SaveType { get; set; }

        public decimal MobileAllo { get; set; }
        public decimal FuelAllo { get; set; }
        public decimal CarManAllo { get; set; }
        public decimal DriverAllo { get; set; }
        public decimal MiscAllo { get; set; }
        public decimal OtherAllo { get; set; }

        public decimal NomGratuity1 { get; set; }
        public decimal NomGratuity2 { get; set; }
        public decimal NomGratuity3 { get; set; }
        public decimal NomGratuity4 { get; set; }
        public decimal RelocationExpense { get; set; }
        public decimal AirTicket { get; set; }
        public decimal TemporaryAccomodation { get; set; }

        public int? Remaining { get; set; }
        public int? Strength { get; set; }
        public string OfficEmailID { get; set; }

        public string EntryBy { get; set; }
        public string EntryDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }

    }
}
