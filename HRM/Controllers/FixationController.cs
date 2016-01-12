using HRM.DAL;
using HRM.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using HRM.Models;

namespace HRM.Controllers
{
    [Authorize]
    public class FixationController : Controller
    {
        [Authorize(Users = "admin")]
        public ActionResult Index()
        {
            List<StructureTypeEntity> lstStructureType = new List<StructureTypeEntity>();
            lstStructureType = DAFacade.GetStructureTypeListByFilter(string.Format("ScaleYear='2009'"));
            ViewBag.StructureType = lstStructureType.ToList();
            return View();
        }

        public PartialViewResult Calculate(string grade, decimal basic, int numberOfChild,int locationID)
        {
            try
            {

                List<SalaryFixationEntity> lstSalaryFixation = DAFacade.CalculateSalaryFix(grade, basic, numberOfChild, locationID);
                return PartialView("_Calculate", lstSalaryFixation);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult SingleView()
        {
            return View();
        }
        public PartialViewResult GetIndividualSalaryFixationInfo(string empCode)
        {
            try
            {
                 string currentUserBranchCode=string.Empty;
                 if (HttpContext.User.Identity.Name.ToLower() == "admin")
                 {
                     currentUserBranchCode = "admin";
                 }
                 else
                 {
                     ApplicationDbContext _ctx = new ApplicationDbContext();
                     ApplicationUser branchCode = _ctx.Users.Where(u => u.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                     currentUserBranchCode = branchCode.BranchCode;
                 }
                 List<SalaryFixationEntity> lstSalaryFixation = DAFacade.GetSalaryFixationList(string.Format("EmpCode='{0}' and  BranchCode = case when  '{1}' = 'admin' then BranchCode else '{1}' end", empCode, currentUserBranchCode));
                return PartialView("_IndividualSalaryFixationInfo", lstSalaryFixation);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult BatchView()
        {
            if (HttpContext.User.Identity.Name.ToLower() == "admin")
            {
                ViewBag.BranchName = DAFacade.GetBranchNameListForDropdown(string.Empty);
            }
            else
            {
                ApplicationDbContext _ctx = new ApplicationDbContext();
                ApplicationUser branchCode = _ctx.Users.Where(u => u.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
                ViewBag.BranchName = DAFacade.GetBranchNameListForDropdown(string.Format("BranchCode='{0}'",branchCode.BranchCode));
            }
            return View();
        }
        public PartialViewResult GetBranchInfo(string branchName)
        {
            try
            {

                List<SalaryFixationEntity> lstSalaryFixation = DAFacade.GetSalaryFixationList(string.Format("PostingPlace='{0}'", branchName));
                return PartialView("_BranchInfo", lstSalaryFixation);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ExportToExcel(DataTable dataTable)
        {
            var lines = new List<string>();
            string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();

            var header = string.Join(",", columnNames);
            lines.Add(header);

            var valueLines = dataTable.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);

            //File.WriteAllLines("excel.csv", lines);
        }
	}
}