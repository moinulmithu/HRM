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
    public class DAOfficeBranch 
    {
        #region IDataAccess<BranchEntity> Members

        public bool Save(List<OfficeBranchEntity> lstEntity)
        {
            object result = DAHelper<OfficeBranchEntity>.Insert(lstEntity);
            return true;
        }

        public bool Update(List<OfficeBranchEntity> lstEntity)
        {
            object result = DAHelper<OfficeBranchEntity>.Update(lstEntity);
            return true;
        }

        public List<OfficeBranchEntity> GetList(string filter)
        {
            List<OfficeBranchEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT * FROM OfficeBranch";
                    break;
                default:
                    sqlString = string.Format("SELECT * FROM OfficeBranch WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<OfficeBranchEntity>.MapObject(reader);

            return lstEntity;
        }

        #endregion

        internal List<OfficeBranchEntity> GetBranchListByFilter(string filter)
        {
            List<OfficeBranchEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT * FROM OfficeBranch";
                    break;
                default:
                    sqlString = string.Format("SELECT * FROM OfficeBranch WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<OfficeBranchEntity>.MapObject(reader);

            return lstEntity;
        }

        internal List<OfficeBranchEntity> GetBranchNameListForDropdown(string filter)
        {
            List<OfficeBranchEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "select  ID,BranchCode,BranchName from Branch order by BranchName";
                    break;
                default:
                    sqlString = string.Format("select  ID,BranchCode,BranchName from Branch WHERE {0} order by BranchName ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<OfficeBranchEntity>.MapObject(reader);

            return lstEntity;
        }




        internal List<OfficeBranchEntity> GetBranchForEdit(string filter)
        {
            List<OfficeBranchEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = "SELECT * FROM OfficeBranch";
                    break;
                default:
                    sqlString = string.Format("SELECT * FROM OfficeBranch WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<OfficeBranchEntity>.MapObject(reader);

            return lstEntity;
        }



        public void GetBranchIdForDelete(string filter)
        {

            string sqlString = string.Empty;

            sqlString = string.Format("delete OfficeBranch WHERE {0} ", filter);

            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);
        }
    
    
    
    
    
    
    
    
    }

}
