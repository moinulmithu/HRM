using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.DAL.Entity;
using HRM.DAL.DataAccess;
using HRM.DAL.Interfaces;

using System.Collections;
using HRM.DAL.Helper;

namespace HRM.DAL
{
    public class DAFacade
    {

        #region AspNetUsers

        public static object SaveAspNetUsers(List<AspNetUsersEntity> lstEntity)
        {
            return new DAAspNetUsers().Save(lstEntity);
        }


        public static object UpdateAspNetUsers(List<AspNetUsersEntity> lstEntity)
        {
            return new DAAspNetUsers().Update(lstEntity);
        }


        public static List<AspNetUsersEntity> GetAspNetUsersListByFilter(string filter)
        {
            List<AspNetUsersEntity> lstEntity = new DAAspNetUsers().GetAspNetUsersListByFilter(filter);
            return lstEntity;
        }

        public static List<AspNetUsersEntity> GetUsersImageByFilter(string filter)
        {
            List<AspNetUsersEntity> lstEntity = new DAAspNetUsers().GetUsersImageByFilter(filter);
            return lstEntity;
        }

        public static void DeleteAspNetUsersById(string filter)
        {
            new DAAspNetUsers().DeleteAspNetUsersById(filter);
        }

        #endregion

        #region UserAccessPage

        public static object SaveUserAccessPage(List<UserAccessPageEntity> lstEntity)
        {
            return new DAUserAccessPage().Save(lstEntity);
        }


        public static object UpdateUserAccessPage(List<UserAccessPageEntity> lstEntity)
        {
            return new DAUserAccessPage().Update(lstEntity);
        }


        public static List<UserAccessPageEntity> GetUserAccessPageListByFilter(string filter)
        {
            List<UserAccessPageEntity> lstEntity = new DAUserAccessPage().GetUserAccessPageListByFilter(filter);
            return lstEntity;
        }



        public static void DeleteUserAccessPageById(string filter)
        {
            new DAUserAccessPage().DeleteUserAccessPage(filter);
        }

        #endregion

        #region User Registration

        public static object SaveUser(List<UserRegistrationEntity> lstEntity)
        {
            return new DAUserRegistration().Save(lstEntity);
        }

        public static object UpdateUser(List<UserRegistrationEntity> lstEntity)
        {
            return new DAUserRegistration().Update(lstEntity);
        }

        public static List<UserRegistrationEntity> UserRegForEdit(string filter)
        {
            return new DAUserRegistration().GetUserForEdit(filter);
        }

        public static List<UserRegistrationEntity> LoginUser(string filter)
        {
            return new DAUserRegistration().LoggedIn(filter);
        }

        #endregion

        #region Navbar

        public static object SaveNavbar(List<NavbarEntity> lstEntity)
        {
            return new DANavbar().Save(lstEntity);
        }


        public static object UpdateNavbar(List<NavbarEntity> lstEntity)
        {
            return new DANavbar().Update(lstEntity);
        }


        public static List<NavbarEntity> GetNavbarListByFilter(string filter)
        {
            List<NavbarEntity> lstEntity = new DANavbar().GetNavbarListByFilter(filter);
            return lstEntity;
        }

        public static List<NavbarEntity> GetNavbarListForAdminuser(string filter)
        {
            List<NavbarEntity> lstEntity = new DANavbar().GetNavbarListForAdminuser(filter);
            return lstEntity;
        }
        public static List<NavbarEntity> GetMenuNameAndMenuIDForDropDownList(string filter)
        {
            List<NavbarEntity> lstEntity = new DANavbar().GetMenuNameAndMenuIDForDropDownList(filter);
            return lstEntity;
        }
        public static List<NavbarEntity> GetUsernameForDropDownList(string filter)
        {
            List<NavbarEntity> lstEntity = new DANavbar().GetUsernameForDropDownList(filter);
            return lstEntity;
        }
        public static List<NavbarEntity> GetUserNameForRoles(string filter)
        {
            List<NavbarEntity> lstEntity = new DANavbar().GetUserNameForRoles(filter);
            return lstEntity;
        }


        public static void DeleteNavbarById(string filter)
        {
            new DANavbar().DeleteNavbarById(filter);
        }

        #endregion

        #region Salary Period

        public static List<SalaryPeriodEntity> GetSalaryPeriodForDropDown(string filter)
        {
            List<SalaryPeriodEntity> lstEntity = new DASalaryPeriod().GetSalaryPeriodForDropDown(filter);
            return lstEntity;
        }
        #endregion

        #region EmployeeInfo
        public static List<EmployeeInfoEntity> GetEmployeeInfoListByFilter(string filter)
        {
            List<EmployeeInfoEntity> lstEntity = new DAEmployeeInfo().GetEmployeeInfoListByFilter(filter);
            return lstEntity;
        }
        #endregion

        #region ProvidentFund

        public static List<ProvidentFundEntity> GetProvidentFund(string EmpCode, int FromPeriodID, int ToPeriodID)
        {
            List<ProvidentFundEntity> lstEntity = new DAProvidentFund().GetProvidentFund(EmpCode, FromPeriodID, ToPeriodID);
            return lstEntity;

        }

        public static List<ProvidentFundDetailsEntity> GetProvidentFundDetails(string EmpCode, int FromPeriodID, int ToPeriodID)
        {
            List<ProvidentFundDetailsEntity> lstEntity = new DAProvidentFund().GetProvidentFundDetails(EmpCode, FromPeriodID, ToPeriodID);
            return lstEntity;

        }
        #endregion

        #region TaxCard
        public static List<ProcessEmpSalaryStructureEntity> GetEmpYearlyTaxInfo(string filter)
        {
            List<ProcessEmpSalaryStructureEntity> lstEntity = new DAProcessEmpSalaryStructure().GetEmpYearlyTaxInfo(filter);
            return lstEntity;
        }

        public static List<TaxYearInfoEntity> GetTaxYearInfoListByFilter(string filter)
        {
            return new DATaxYearInfo().GetTaxYearInfoListByFilter(filter);
        }
        #endregion

        #region -- Salary Fixation
        public static object UpdateSalaryFixation(List<SalaryFixationEntity> lstEntity)
        {

            return new DASalaryFixation().Update(lstEntity);
        }

        public static object SaveSalaryFixation(List<SalaryFixationEntity> lstEntity)
        {
            return new DASalaryFixation().Save(lstEntity);
        }
        public static List<SalaryFixationEntity> GetSalaryFixationList(string filter)
        {
            List<SalaryFixationEntity> lstEntity = new DASalaryFixation().GetSalaryFixationList(filter);
            return lstEntity;
        }

        public static List<SalaryFixationEntity> CalculateSalaryFix(string Grade, decimal Basic, int NumOfChild, int LocationID)
        {
            List<SalaryFixationEntity> lstEntity = new DASalaryFixation().CalculateSalaryFix(Grade, Basic, NumOfChild, LocationID);
            return lstEntity;
        }

        public static void SaveEmpWithSalaryFix(string EmpCode, string ApproveBy)
        {
            new DASalaryFixation().SaveEmpWithSalaryFix(EmpCode, ApproveBy);

        }
        public static void UpdateSalaryFix(string filter)
        {
            new DASalaryFixation().UpdateSalaryFix(filter);
        }
        #endregion

        #region StructureType

        public static List<StructureTypeEntity> GetStructureTypeListByFilter(string filter)
        {
            List<StructureTypeEntity> lstEntity = new DAStructureType().GetStructureTypeListByFilter(filter);
            return lstEntity;
        }
        #endregion

        #region Branch Info
        public static List<OfficeBranchEntity> GetBranchListByFilter(string filter)
        {
            List<OfficeBranchEntity> lstEntity = new DAOfficeBranch().GetBranchListByFilter(filter);
            return lstEntity;
        }
        public static List<OfficeBranchEntity> GetBranchNameListForDropdown(string filter)
        {
            List<OfficeBranchEntity> lstEntity = new DAOfficeBranch().GetBranchNameListForDropdown(filter);
            return lstEntity;
        }
        
        #endregion
    }
}
