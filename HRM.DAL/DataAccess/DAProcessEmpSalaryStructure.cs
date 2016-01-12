using HRM.DAL.Entity;
using HRM.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.DAL.DataAccess
{
  public  class DAProcessEmpSalaryStructure
    {
        public List<ProcessEmpSalaryStructureEntity> GetEmpYearlyTaxInfo(string filter)
        {
            List<ProcessEmpSalaryStructureEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"select E.EmpCode,E.EmpName,E.Department,E.Designation,PES.PeriodName,T.TaxYearName,SY.YearName,PES.Amount
                                    from ProcessEmpSalaryStructure PES
                                    INNER JOIN EmployeeInfo E ON E.EmpCode=PES.EmpCode
                                    INNER JOIN TaxYearInfo T ON T.ID=PES.TaxYearID
                                    INNER JOIN SalaryYear SY ON SY.ID=PES.YearID";
                    break;
                default:
                    sqlString = string.Format(@"select E.EmpCode,E.EmpName,E.Department,E.Designation,PES.PeriodName,T.TaxYearName,SY.YearName,PES.Amount
                                    from ProcessEmpSalaryStructure PES
                                    INNER JOIN EmployeeInfo E ON E.EmpCode=PES.EmpCode
                                    INNER JOIN TaxYearInfo T ON T.ID=PES.TaxYearID
                                    INNER JOIN SalaryYear SY ON SY.ID=PES.YearID WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<ProcessEmpSalaryStructureEntity>.MapObject(reader);

            return lstEntity;
        }
    }
}
