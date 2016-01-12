using HRM.DAL.Entity;
using HRM.DAL.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace HRM.DAL.DataAccess
{
    public class DANavbar
    {
        public bool Save(List<NavbarEntity> lstEntity)
        {
            object result = DAHelper<NavbarEntity>.Insert(lstEntity);
            return true;
        }

        public bool Update(List<NavbarEntity> lstEntity)
        {
            object result = DAHelper<NavbarEntity>.Update(lstEntity);
            return true;
        }

        internal List<NavbarEntity> GetNavbarListByFilter(string filter)
        {
            List<NavbarEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT DISTINCT N.* 
                                FROM UserAccessPage UAP
                                INNER JOIN Navbar N ON N.ID=UAP.ManuID order by Displayorder";
                    break;
                default:
                    sqlString = string.Format(@"SELECT DISTINCT N.* 
                                                FROM UserAccessPage UAP
                                                INNER JOIN Navbar N ON N.ID=UAP.ManuID WHERE {0} order by Displayorder ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<NavbarEntity>.MapObject(reader);

            return lstEntity;
        }

        internal List<NavbarEntity> GetNavbarListForAdminuser(string filter)
        {
            List<NavbarEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT * FROM  Navbar order by Displayorder ";
                    break;
                default:
                    sqlString = string.Format(@"SELECT * FROM  Navbar WHERE {0} order by Displayorder ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<NavbarEntity>.MapObject(reader);

            return lstEntity;
        }

        internal List<NavbarEntity> GetMenuNameAndMenuIDForDropDownList(string filter)
        {
            List<NavbarEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT ID,NameOption FROM  Navbar";
                    break;
                default:
                    sqlString = string.Format(@"SELECT ID,NameOption FROM  Navbar WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<NavbarEntity>.MapObject(reader);

            return lstEntity;
        }
        internal List<NavbarEntity> GetUsernameForDropDownList(string filter)
        {
            List<NavbarEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT UserName FROM  AspNetUsers";
                    break;
                default:
                    sqlString = string.Format(@"SELECT UserName FROM  AspNetUsers WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<NavbarEntity>.MapObject(reader);

            return lstEntity;
        }

        internal List<NavbarEntity> GetUserNameForRoles(string filter)
        {
            List<NavbarEntity> lstEntity = null;
            string sqlString = string.Empty;
            switch (filter)
            {
                case "":
                    sqlString = @"SELECT DISTINCT N.* 
                                FROM UserAccessPage UAP
                                INNER JOIN Navbar N ON N.ID=UAP.ManuID";
                    break;
                default:
                    sqlString = string.Format(@"SELECT DISTINCT N.* 
                                FROM UserAccessPage UAP
                                INNER JOIN Navbar N ON N.ID=UAP.ManuID WHERE {0} ", filter);
                    break;

            }
            SqlDataReader reader = SqlHelper.ExecuteReader(Constants.ConnectionString, CommandType.Text, sqlString);

            lstEntity = ObjectMapHelper<NavbarEntity>.MapObject(reader);

            return lstEntity;
        }

        internal void DeleteNavbarById(string filter)
        {

            string sqlString = string.Empty;

            sqlString = string.Format("Delete from Navbar  WHERE {0}", filter);

            object reader = SqlHelper.ExecuteScalar(Constants.ConnectionString, CommandType.Text, sqlString);

        }
    }
}
