using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.DAL.Interfaces;
using HRM.DAL.Entity;
using HRM.DAL.Helper;
using System.Data;
using System.Data.SqlClient;

namespace HRM.DAL.DataAccess
{
    public class DASalaryFixation 
    {
        public bool Save(List<SalaryFixationEntity> lstEntity)
        {
            object result = DAHelper<SalaryFixationEntity>.Insert(lstEntity);
            return true;
        }

        public bool Update(List<SalaryFixationEntity> lstEntity)
        {
            object result = DAHelper<SalaryFixationEntity>.Update(lstEntity);
            return true;
        }


       
        internal List<SalaryFixationEntity> CalculateSalaryFix(string Grade, decimal Basic, int NumOfChild, int LocationID)
        {
            List<SalaryFixationEntity> lstEntity = null;
            string sqlString = string.Empty;

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spSalaryFixation", new object[] { Grade, Basic, NumOfChild, LocationID });

            lstEntity = ObjectMapHelper<SalaryFixationEntity>.MapObject(reader);

            return lstEntity;
        }
        internal void SaveEmpWithSalaryFix(string EmpCode, string ApproveBy )
        {
            
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spUpdateEmpInfo", new object[] { EmpCode, ApproveBy });
           
        }
        public void UpdateSalaryFix(string filter)
        {
            string sqlString = string.Empty;
            sqlString = string.Format("Update SalaryFixation Set isApproved=1 Where {0}", filter);
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);
        }
        public List<SalaryFixationEntity> GetSalaryFixationList(string filter)
        {
            List<SalaryFixationEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    //This query should be changed after createing CarLoanPayment table
                    sqlString = @"Select s.ID,  EmpCode, EmpName,FileNo,FatherName,MotherName,Address, NID,TINNo, MobNo, Designation, Gender,
                         Convert(nvarchar(12),Cast(JoiningDate as Date), 103)JoiningDate,
                         Convert(nvarchar(12),Cast(BirthDate as Date), 103) BirthDate,
                         case when LastIncreDate is null then LastIncreDate  when LastIncreDate='0' then LastIncreDate when LastIncreDate='' then LastIncreDate else Convert(nvarchar(12),Cast(LastIncreDate as Date), 103) end LastIncreDate,
                         Convert(nvarchar(12),Cast(LastPromotionDate as Date), 103) LastPromotionDate,
                         Convert(nvarchar(12),Cast(DateOfPresentScale as Date), 103) DateOfPresentScale,
                          CurrentGrade, NumberOfChild, s.Basic, CurBasic,
                                                          LastIncreDate, PostingPlace, NewBasic, HouseRent, Medical, ChildEduAllow, DA, GrossSalary, isApproved,Case When isApproved=0 Then 'Draft' When isApproved=1 Then 'Processing' When isApproved=2 Then 'Approved' End Status,  EntryBy, EntryDate, ApprovedBy, AppovalDate, BasicASONJune2015, InitialBasic, Increment, StartingBasic, NewBasicPoint,
														  
								(NewBasic-BasicASONJune2015)BasicIncrement,(BasicASONJune2015+PersonalPay)Total34,(BasicASONJune2015+PersonalPay-InitialBasic)Total56,(BasicASONJune2015+PersonalPay+StartingBasic-InitialBasic)Total78,GradeDes2009,GradeDes2015,(select top 1 PayScale2009 from StructureType where StructureName=CurrentGrade)PayScale2009,(select top 1 PayScale2015 from StructureType where StructureName=CurrentGrade)PayScale2015,NewBasicConDec15Basic  						  
														  
														    FROM SalaryFixation S
															left join Branch B on b.BranchCode =s.BranchCode
														 
								  ";
                    break;
                default:


                    sqlString = string.Format(@" Select s.ID,  EmpCode, EmpName,FileNo,FatherName,MotherName,Address, NID,TINNo, MobNo, Designation, Gender,
                         Convert(nvarchar(12),Cast(JoiningDate as Date), 103)JoiningDate,
                         Convert(nvarchar(12),Cast(BirthDate as Date), 103) BirthDate,
                         case when LastIncreDate is null then LastIncreDate  when LastIncreDate='0' then LastIncreDate when LastIncreDate='' then LastIncreDate else Convert(nvarchar(12),Cast(LastIncreDate as Date), 103) end LastIncreDate,
                         Convert(nvarchar(12),Cast(LastPromotionDate as Date), 103) LastPromotionDate,
                         Convert(nvarchar(12),Cast(DateOfPresentScale as Date), 103) DateOfPresentScale,
                          CurrentGrade, NumberOfChild, s.Basic, CurBasic,
                                                          LastIncreDate, PostingPlace, NewBasic, HouseRent, Medical, ChildEduAllow, DA, GrossSalary, isApproved,Case When isApproved=0 Then 'Draft' When isApproved=1 Then 'Processing' When isApproved=2 Then 'Approved' End Status,  EntryBy, EntryDate, ApprovedBy, AppovalDate, BasicASONJune2015, InitialBasic, Increment, StartingBasic, NewBasicPoint,
														  
								(NewBasic-BasicASONJune2015)BasicIncrement,(BasicASONJune2015+PersonalPay)Total34,(BasicASONJune2015+PersonalPay-InitialBasic)Total56,(BasicASONJune2015+PersonalPay+StartingBasic-InitialBasic)Total78,GradeDes2009,GradeDes2015,(select top 1 PayScale2009 from StructureType where StructureName=CurrentGrade)PayScale2009,(select top 1 PayScale2015 from StructureType where StructureName=CurrentGrade)PayScale2015,NewBasicConDec15Basic  						  
														  
														    FROM SalaryFixation S
														 
								   WHERE  {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<SalaryFixationEntity>.MapObject(reader);

            return lstEntity;
        }
    }
}
