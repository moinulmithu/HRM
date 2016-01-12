using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using HRM.DAL.Entity;
using HRM.DAL.Interfaces;
using System.Data.SqlClient;
using HRM.DAL.Helper;


using System.IO;
using System.IO.IsolatedStorage;
using HRM.DAL;


namespace HRM.DAL.DataAccess
{
    public class DAEmployeeInfo 
    {

        private string CreateFolder(string FilesFullName)
        {
            DirectoryInfo myDirectoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
            myDirectoryInfo.CreateSubdirectory(FilesFullName); 
            return myDirectoryInfo.FullName;

        }


        #region IDataAccess<BankInfoEntity> Members

        public bool Save(List<EmployeeInfoEntity> lstEntity)
        {
            if (GetDuplicateEmpCode(lstEntity[0].EmpCode) == 0)
            {
                object result = DAHelper<EmployeeInfoEntity>.Insert(lstEntity);
                return true;
            }
            else
            {
                // object result = DAHelper<EmployeeInfoEntity>.Insert(lstEntity);
                return false ;
            }
        }

        public bool Update(List<EmployeeInfoEntity> lstEntity)
        {
            //LogEmpUpdateInfo(lstEntity[0].EmpCode, UpdatedBy);
            object result = DAHelper<EmployeeInfoEntity>.Update(lstEntity);
            return true;
        }

        public List<EmployeeInfoEntity> GetList(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT * FROM EmployeeInfo ORDER BY EmpCode ASC ";
                    break;
                default:
                    sqlString = string.Format("SELECT * FROM EmployeeInfo WHERE {0} ORDER BY EmpCode ASC ", filter);
                    break;
            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);
            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }

        #endregion




        private int GetDuplicateEmpCode(string EmpCode)
        {

            object value = null;

            string queryString = string.Format("SELECT ei.EmpCode  FROM dbo.EmployeeInfo ei WHERE ei.EmpCode ='{0}'", EmpCode);

            try
            {
                value = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, queryString);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);

        }


        internal List<EmployeeInfoEntity> GetEmployeeInfoListByFilter(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT CONVERT(varchar(12),cast(JoiningDate as DATE),103)JoiningDate,dbo.ProfileStrengthCount(EmpCode)Strength, * FROM EmployeeInfo order by EmpCode";
                    break;
                default:
                    sqlString = string.Format("SELECT CONVERT(varchar(12),cast(JoiningDate as DATE),103)JoiningDate,dbo.ProfileStrengthCount(EmpCode)Strength, * FROM EmployeeInfo WHERE {0} order by EmpCode ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }
        internal List<EmployeeInfoEntity> GetEmployeeInfoListByFilterEmp(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT  * FROM EmployeeInfo order by EmpCode";
                    break;
                default:
                    sqlString = string.Format("SELECT  * FROM EmployeeInfo WHERE {0} order by EmpCode ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }



        internal List<EmployeeInfoEntity> GetEmployeeInfoForEdit(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT ID, EmpCode,saveType,refCont1,refCont2,RefEmail1,RefEmail2, Prefix,NomShare1,NomShare2,NomShare3,NomShare4,NomRel1,NomRel2,NomRel3,NomRel4,NomCont1,NomCont2,NomCont3,NomCont4, EmpName, FirstName, MiddleName, LastName, Designation, JobGrade,EmpImage,
                                    Division, Department, OfficeBranch, DutyStation, Location, Convert(varchar(12),cast(JoiningDate as DATE),103)JoiningDate, Convert(varchar(12),cast(ConfirmationDate as DATE),103)ConfirmationDate, 
                                    ContractPeriod, CONVERT(NVarchar(12),CAST( LastContractDay as DATE),103)LastContractDay, CONVERT(NVarchar(12),CAST( ResignationDay as DATE),103)ResignationDay,CONVERT(NVarchar(12),CAST( ResignDate as DATE),103)ResignDate,
                                    CONVERT(NVarchar(12),CAST( ReleaseDate as DATE),103)ReleaseDate, SupervisorID1, SuperName1, SupervisorDesignation1,SupervisorID2, SuperName2, SupervisorDesignation2, ReviewerID, ReviewerName,
                                    ReviewerDesignation, EmploymentStatus, EmploymentType, Mobile, PABX, EmailID, UserID,
                                    FatherName, MotherName, Gender, Religion, CONVERT(nvarchar(12),cast( BirthDate as DATE),103)BirthDate, BloodGroup, MaritalStatus, Spouse,
                                    SpouseDOB, Child1, Child1DOB, Child2, Child2DOB, Child3, Child3DOB, PresentAddress, 
                                    PermanentAddress, JurisdictionDiv, HighestEducation, AcademicSubject, Institution, 
                                    LastOrganization, PositionHeld, LJReleaseDate, PreExperience, AccNo, WalletNo, TinNo, 
                                    Bank, BankBranch, Resident, PayBy, ProvidentFund, PFDeductAmt, PFDeductRule, [Status],_Group,
                                    StatusDate, NationalID, [Type], IncomeTex, TaxDeductAmt, IsBlock, ChangeDate, IsCompanyCar,
                                    AreaTypeId, WC_GrpLeaderId, WC_DayWagesRate, PunchCardNo, SalaryFundSource, SalaryPayFromAccount, MobileAllo,FuelAllo,CarManAllo,DriverAllo, MiscAllo,OtherAllo,RelocationExpense,AirTicket,TemporaryAccomodation,
                                    WalletPayfromAccount, HaveDailyAllowance, HaveMobileAllowance, DailyAllowance, MobileAllowance,
                                    ConfirmationText, AptCode, ImgFileName,nominee1,nominee2,nominee3,nominee4,FatherCont,MotherCont,RefName1 ,RefDesig1 , RefORG1 ,RefEmail1 ,RefName2 ,RefDesig2 ,RefORG2 ,RefCont2 , RefEmail2 ,NomGratuity1,NomGratuity2,NomGratuity3,NomGratuity4
                                    FROM EmployeeInfo";
                    break;
                default:
                    sqlString = string.Format(@"SELECT ID, EmpCode,saveType,refCont1,refCont2,RefEmail1,RefEmail2, Prefix,NomShare1,NomShare2,NomShare3,NomShare4,NomRel1,NomRel2,NomRel3,NomRel4,NomCont1,NomCont2,NomCont3,NomCont4, EmpName, FirstName, MiddleName, LastName, Designation, JobGrade,EmpImage,
                                    Division, Department, OfficeBranch, DutyStation, Location, Convert(varchar(12),cast(JoiningDate as DATE),103)JoiningDate, Convert(varchar(12),cast(ConfirmationDate as DATE),103)ConfirmationDate, 
                                    ContractPeriod, CONVERT(NVarchar(12),CAST( LastContractDay as DATE),103)LastContractDay, CONVERT(NVarchar(12),CAST( ResignationDay as DATE),103)ResignationDay,CONVERT(NVarchar(12),CAST( ResignDate as DATE),103)ResignDate,
                                    CONVERT(NVarchar(12),CAST( ReleaseDate as DATE),103)ReleaseDate, SupervisorID1, SuperName1, SupervisorDesignation1,SupervisorID2, SuperName2, SupervisorDesignation2, ReviewerID, ReviewerName,
                                    ReviewerDesignation, EmploymentStatus, EmploymentType, Mobile, PABX, EmailID, UserID,
                                    FatherName, MotherName, Gender, Religion, CONVERT(nvarchar(12),cast( BirthDate as DATE),103)BirthDate, BloodGroup, MaritalStatus, Spouse,
                                    SpouseDOB, Child1, Child1DOB, Child2, Child2DOB, Child3, Child3DOB, PresentAddress, 
                                    PermanentAddress, JurisdictionDiv, HighestEducation, AcademicSubject, Institution, 
                                    LastOrganization, PositionHeld, LJReleaseDate, PreExperience, AccNo, WalletNo, TinNo, 
                                    Bank, BankBranch, Resident, PayBy, ProvidentFund, PFDeductAmt, PFDeductRule, [Status],_Group,
                                    StatusDate, NationalID, [Type], IncomeTex, TaxDeductAmt, IsBlock, ChangeDate, IsCompanyCar,
                                    AreaTypeId, WC_GrpLeaderId, WC_DayWagesRate, PunchCardNo, SalaryFundSource, SalaryPayFromAccount, MobileAllo,FuelAllo,CarManAllo,DriverAllo, MiscAllo,OtherAllo,RelocationExpense,AirTicket,TemporaryAccomodation,
                                    WalletPayfromAccount, HaveDailyAllowance, HaveMobileAllowance, DailyAllowance, MobileAllowance,
                                    ConfirmationText, AptCode, ImgFileName,nominee1,nominee2,nominee3,nominee4,FatherCont,MotherCont,RefName1 ,RefDesig1 , RefORG1 ,RefEmail1 ,RefName2 ,RefDesig2 ,RefORG2 ,RefCont2 , RefEmail2 ,NomGratuity1,NomGratuity2,NomGratuity3,NomGratuity4
                                    FROM EmployeeInfo WHERE {0} ", filter);
                    break;
            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);

            return lstEntity;
        }


        public void GetEmployeeInfoIdForDelete(string filter)
        {

            string sqlString = string.Empty;
      
            sqlString = string.Format("delete EmployeeInfo WHERE {0} ", filter);
            sqlString = string.Format("delete Training WHERE {0} ", filter);
            sqlString = string.Format("delete Employment WHERE {0} ", filter);
            sqlString = string.Format("delete Education WHERE {0} ", filter);
            sqlString = string.Format("delete Reward WHERE {0} ", filter);
            sqlString = string.Format("delete EmployeesSalaryStructure WHERE {0} ", filter);
            sqlString = string.Format("delete Belongings WHERE {0} ", filter);

            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);
        }


        public void LogEmpUpdateInfo(string EmpCode, string UpdatedBy)
        {

            string sqlString = string.Empty;

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spLogEmpUpdateInfo", new object[] { EmpCode, UpdatedBy });

            
        }


      

        

        public void EditEmployeeInfo(string filter, string EmpCode)
        {

            string sqlString = string.Empty;

            sqlString = string.Format("UPDATE EmployeeInfo SET {0} WHERE {1} ", filter, EmpCode);

            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);
        }


   
        internal object GetAuto_EMPCode(int EmploymentType, string NewEmpCode) 
        {
            object result = SqlHelper.ExecuteNonQuery(Constants.ConnectionString, "Get_AutoEMPCode", new object[] { EmploymentType, NewEmpCode });
            return result;
        }

    
        internal List<EmployeeInfoEntity> GetEmployeeProfileStrengthInfo(string EmpCode)
        {
            List<EmployeeInfoEntity> lstEntity = null;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "ProfileStrengthCount", new object[] { EmpCode });

                lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            }
            catch (Exception ex)
            {


                throw ex;
            }

            return lstEntity;
        }
        
       
        internal List<EmployeeInfoEntity> DuplicateDataCheck( string AccNo)
        {
            List<EmployeeInfoEntity> lstEntity = null;

            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "CheckDuplicateData", new object[] {  AccNo });

                lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            }
            catch (Exception ex)
            {


                throw ex;
            }

            return lstEntity;
        }
        internal List<EmployeeInfoEntity> GetEmployeeAutoNumber(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spEmployeeAutoNumber", new object[] { filter });
            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }

        internal List<EmployeeInfoEntity> GetEmployeeConfirmationInfo( )
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spConfirmationDueList", new object[] {  });
            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }
        internal List<EmployeeInfoEntity> SaveEmployeeImageInDataBase(string EmpCode)
        {
            List<EmployeeInfoEntity> lstEntity = null;
            string sqlString = string.Empty;

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "UpdateImage", new object[] { EmpCode });
            lstEntity = ObjectMapHelper<EmployeeInfoEntity>.MapObject(reader);
            return lstEntity;
        }


      

    }
}
