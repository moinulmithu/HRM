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
   public class DAStructureType
    {
       public List<StructureTypeEntity> GetStructureTypeListByFilter(string filter)
       {
           List<StructureTypeEntity> lstEntity = null;
           string sqlString = string.Empty;
           switch (filter)
           {
               case "":

                   sqlString = @"Select ID,  StructureName,PayScale2009  FROM StructureType order by cast(SUBSTRING( StructureName,7,3)as int) ";
                   break;
               default:


                   sqlString = string.Format(@"Select ID,  StructureName,PayScale2009  FROM StructureType  WHERE  {0} order by cast(SUBSTRING( StructureName,7,3)as int)  ", filter);
                   break;

           }
           SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

           lstEntity = ObjectMapHelper<StructureTypeEntity>.MapObject(reader);

           return lstEntity;
       }
    }
}
