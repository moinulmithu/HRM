using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Interfaces
{
    public interface IDataAccess<T> where T : new()
    {
        bool Save(List<T> lstData);
        bool Update(List<T> lstData);
        List<T> GetContractMasterList(string filter);
    }
}
