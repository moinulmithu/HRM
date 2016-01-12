using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRM.DAL.Entity;
using HRM.DAL.Interfaces;
using System.Data.SqlClient;
using System.Data;
using HRM.DAL.Helper;

namespace HRM.DAL.DataAccess
{
    public class DASalaryPeriod
    {        
        internal List<SalaryPeriodEntity> GetSalaryPeriodForDropDown(string filter)
        {
            List<SalaryPeriodEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT ID, PeriodName FROM  dbo.SalaryPeriod";
                    break;
                default:
                    sqlString = string.Format(@"SELECT ID, PeriodName FROM  dbo.SalaryPeriod WHERE {0} ", filter);
                    break;

            }

            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<SalaryPeriodEntity>.MapObject(reader);

            return lstEntity;
        }

       
    }

}
