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
    public class DATaxYearInfo 
    {


        public List<TaxYearInfoEntity> GetTaxYearInfoListByFilter(string filter)
        {
            List<TaxYearInfoEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT ID,TaxYearName FROM TaxYearInfo";
                    break;
                default:
                    sqlString = string.Format("SELECT ID,TaxYearName FROM TaxYearInfo WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<TaxYearInfoEntity>.MapObject(reader);

            return lstEntity;
        }

       
    }

}
