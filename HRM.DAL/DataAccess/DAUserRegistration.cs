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
    public class DAUserRegistration : IDataAccess<UserRegistrationEntity>
    {
        #region IDataAccess<UsersEntity> Members

        public bool Save(List<UserRegistrationEntity> lstEntity)
        {
            object result = DAHelper<UserRegistrationEntity>.Insert(lstEntity);
            return true;
        }

        public bool Update(List<UserRegistrationEntity> lstEntity)
        {
            object result = DAHelper<UserRegistrationEntity>.Update(lstEntity);
            return true;
        }

        public List<UserRegistrationEntity> GetContractMasterList(string filter)
        {
            List<UserRegistrationEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "select * from UserRegistration";
                    break;
                default:
                    sqlString = string.Format("select * from UserRegistration WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<UserRegistrationEntity>.MapObject(reader);

            return lstEntity;
        }

        #endregion

        internal List<UserRegistrationEntity> GetUserForEdit(string filter)
        {
            List<UserRegistrationEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "select * from UserRegistration";
                    break;
                default:
                    sqlString = string.Format("select * from UserRegistration WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<UserRegistrationEntity>.MapObject(reader);

            return lstEntity;
        }


        internal List<UserRegistrationEntity> LoggedIn(string filter)
        {
            List<UserRegistrationEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "select EmailID,Password from UserRegistration";
                    break;
                default:
                    sqlString = string.Format("select EmailID,Password from UserRegistration WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<UserRegistrationEntity>.MapObject(reader);

            return lstEntity;
        }
       

      

       


    }

}
