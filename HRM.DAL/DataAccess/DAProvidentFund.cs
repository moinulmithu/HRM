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
   public class DAProvidentFund
    {

       public List<ProvidentFundEntity> GetProvidentFund(string EmpCode, int FromPeriodID, int ToPeriodID)
       {
           List<ProvidentFundEntity> lstEntity = null;

           SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spPFSummary", new object[] { EmpCode, FromPeriodID, ToPeriodID });
           lstEntity = ObjectMapHelper<ProvidentFundEntity>.MapObject(reader);
           return lstEntity;
       }

       public List<ProvidentFundDetailsEntity> GetProvidentFundDetails(string EmpCode, int FromPeriodID, int ToPeriodID)
       {
           List<ProvidentFundDetailsEntity> lstEntity = null;

           SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, "spPFDetails", new object[] { EmpCode, FromPeriodID, ToPeriodID });
           lstEntity = ObjectMapHelper<ProvidentFundDetailsEntity>.MapObject(reader);
           return lstEntity;
       }

      
    }
}
