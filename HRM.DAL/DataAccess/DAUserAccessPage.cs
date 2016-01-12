using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.DAL.Entity;
using HRM.DAL.Helper;
using HRM.DAL.Interfaces;
using System.Data.SqlClient;

using System.Data;

namespace HRM.DAL.DataAccess
{
    class DAUserAccessPage //: IDataAccess<UserAccessPageEntity>
    {

        public bool Save(List<UserAccessPageEntity> lstPageAccess)
        {
            object result = DAHelper<UserAccessPageEntity>.Insert(lstPageAccess);
            return true;
        }

        public bool Update(List<UserAccessPageEntity> lstPageAccess)
        {
            object result = DAHelper<UserAccessPageEntity>.Update(lstPageAccess);
            return true;
        }

        public List<UserAccessPageEntity> GetUserAccessPageListByFilter(string filter)
        {
            List<UserAccessPageEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT UAP.ID, UAP.UserName, UAP.ManuID, UAP.[Status],N.NameOption
                                FROM  UserAccessPage UAP
                                INNER JOIN Navbar N ON N.ID=UAP.ManuID";
                    break;
                default:
                    sqlString = string.Format(@"SELECT UAP.ID, UAP.UserName, UAP.ManuID, UAP.[Status],N.NameOption
                                            FROM  UserAccessPage UAP
                                            INNER JOIN Navbar N ON N.ID=UAP.ManuID WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);
            lstEntity = ObjectMapHelper<UserAccessPageEntity>.MapObject(reader);
            return lstEntity;
        }




        internal void DeleteUserAccessPage(string filter)
        {
            string sqlString = string.Empty;
            sqlString = string.Format("Delete from UserAccessPage  WHERE {0}", filter);
            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);

        }
    }
}
