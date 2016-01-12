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
    public class DAAspNetUsers 
    {
        public bool Save(List<AspNetUsersEntity> lstEntity)
        {
            object result = DAHelper<AspNetUsersEntity>.Insert(lstEntity);
            return true;
        }

        public bool Update(List<AspNetUsersEntity> lstEntity)
        {
            object result = DAHelper<AspNetUsersEntity>.Update(lstEntity);
            return true;
        }

        internal List<AspNetUsersEntity> GetAspNetUsersListByFilter(string filter)
        {
            List<AspNetUsersEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT  U.Id, U.UserName, U.PasswordHash, U.SecurityStamp, U.Discriminator, U.EmailID, U.MobileNumber, U.UserImage,U.BranchCode, B.BranchName
                                FROM AspNetUsers U
								inner join Branch B on B.BranchCode=U.BranchCode";
                    break;
                default:
                    sqlString = string.Format(@"SELECT  U.Id, U.UserName, U.PasswordHash, U.SecurityStamp, U.Discriminator, U.EmailID, U.MobileNumber, U.UserImage,U.BranchCode, B.BranchName
                                FROM AspNetUsers U
								inner join Branch B on B.BranchCode=U.BranchCode where {0} ORDER BY U.UserName ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<AspNetUsersEntity>.MapObject(reader);

            return lstEntity;
        }
        internal List<AspNetUsersEntity> GetUsersImageByFilter(string filter)
        {
            List<AspNetUsersEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT UserImage FROM AspNetUsers";
                    break;
                default:
                    sqlString = string.Format(@"SELECT UserImage FROM AspNetUsers WHERE {0}", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<AspNetUsersEntity>.MapObject(reader);

            return lstEntity;
        }
        internal void DeleteAspNetUsersById(string filter)
        {

            string sqlString = string.Empty;

            sqlString = string.Format("Delete from AspNetUsers  WHERE {0}", filter);

            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);

        }
    }

}
