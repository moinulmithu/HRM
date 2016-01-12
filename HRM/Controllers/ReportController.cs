using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.Reporting.WebForms;

using HRM.Models;
using System.Collections;
using System.Data;
using HRM.DAL.Entity;
using HRM.DAL;
using System.IO;
using System.Net;
using iTextSharp.text.pdf;
using HRM.Util;
using HRM.DAL.Helper;
using System.Data.SqlClient;
using System.Configuration;
namespace HRM.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        DataSet _ds = null;
        int _rptType = 0;
        string _Department = string.Empty;
        string _Designation = string.Empty;
        string _JoiningdateFrom = string.Empty;
        string _JoiningdateTo = string.Empty;
        string _ResignDateFrom = string.Empty;
        string _ResignDateTo = string.Empty;
        int _reconciliationType = 0;
        int _YearID = 0;
        string _empCode = string.Empty;
        int _periodID = 0;
        string _PeriodName = string.Empty;
        int _previousPeriodID = 0;
        int _ReconMasterID = 0;
        string _Password = string.Empty;
        string _payMode = string.Empty;
        string _bankName = string.Empty;
        string _isBlock = string.Empty;
        int _monthID = 0;
        string _branchCode=string.Empty;
        //private DataSet ds;
         ReportViewer rptViewer=new ReportViewer();
        string pmReportHeader = "ReportOF";
       
        // GET: /Reports/
        public ActionResult Index()
        {
            List<SalaryPeriodEntity>lstSalaryPeriod=new List<SalaryPeriodEntity>();
            lstSalaryPeriod=DAFacade.GetSalaryPeriodForDropDown(string.Empty);
            ViewBag.SalaryPeriod=lstSalaryPeriod.ToList();
            return View();
        }

        public ActionResult ShowReport(int reportType, string empCode, int periodID, int yearID)
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
                currentUserBranchCode=branchCode.BranchCode;
            }
            LoadPayrollReport(reportType, empCode, periodID, yearID, currentUserBranchCode);            
            return PartialView();
        }
       public ActionResult demoAction()
        {
            return PartialView();
        }


        #region report
       public void LoadPayrollReport(int rptType, string empCode, int periodID, int yearID,string branchCode)
        {
           string pmReportHeader = "ReportOF";
           string  password=empCode;
            _rptType = rptType;
            _empCode = empCode;
            _periodID = periodID;
            _YearID = yearID;
           _branchCode=branchCode;
            DataSet rptDataSet = null;
            ReportDataSource rptDataSource = null;

            if (rptType == 18)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSEmployeeList", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\EmployeelistReport.rdlc");
            }
            else if (rptType == 19)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSEmployeeList", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\DepartmentWiseSummary.rdlc");
                LoadSubReportData();
            }
            else if (rptType == 20)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("CiticellDataSet", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\ReconciliationPrint.rdlc");
                ReportParameter PM = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM });

            }
            else if (rptType == 1)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSPayroll", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\CryRptPayslip.rdlc");
                LoadSubReportData();
            }
            else if (rptType == 2)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSPayroll", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"CryRptTotalReconciliationStatement.rdlc");
                LoadSubReportData();


            }
            else if (rptType == 4)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("Payroll", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\MonthlySlarySheet.rdlc");
                ReportParameter PM = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM });
                //LoadSubReportData();
            }
            else if (rptType == 9)
            {

                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("GreyDataset", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"CryRptBankPaymentReport1.rdlc");

                ReportParameter PM1 = new ReportParameter("PayMode", _payMode);
                ReportParameter PM2 = new ReportParameter("BankName", _bankName);
                ReportParameter PM3 = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM1, PM2, PM3 });

            }


            else if (rptType == 21)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSCitycell", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\rptAccountingJV.rdlc");
                ReportParameter PM = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM });
                LoadSubReportData();
            }
            if (rptType == 22)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSCitycell", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\rptDepartmentwiseJV.rdlc");
                ReportParameter PM = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM });
                LoadSubReportData();
            }
            if (rptType == 23)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSCitycell", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\rptAccountingJVforFinance.rdlc");
                ReportParameter PM = new ReportParameter("PeriodName", _PeriodName);
                this.rptViewer.LocalReport.SetParameters(new ReportParameter[] { PM });
                LoadSubReportData();
            }
            if (rptType == 100)
            {
                rptDataSet = GetDataset();
                rptDataSource = new ReportDataSource("DSPayroll", rptDataSet.Tables[0]);
                this.rptViewer.LocalReport.ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Reports\EmployeeSalaryFixationnew.rdlc");
                
            }
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(rptDataSource);
            rptViewer.ShowExportControls = false;
            rptViewer.LocalReport.Refresh();

            #region Create PDF

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            byte[] bytes = rptViewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            Constants app = new Constants();
            app.LoadSettings();

            //FileStream fs = System.IO.File.Create(Server.MapPath("~"+app.FileUploadLocation + "\\" + "_" + pmReportHeader + "." + extension));
            FileStream fs = System.IO.File.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, app.FileUploadLocation + "\\" + "_" + pmReportHeader + "." + extension));
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            List<GridtoPDFEntity> lstEntity = new List<GridtoPDFEntity>();
            GridtoPDFEntity entity = new GridtoPDFEntity();

            entity.FileName = pmReportHeader + "." + extension;
            //entity.FileLocation = app.FileUploadLocation + "_" + pmReportHeader + "." + extension;
            entity.FileLocation =  "_" + pmReportHeader + "." + extension;
            entity.CreatedDate = DateTime.Now.ToShortDateString();
            lstEntity.Add(entity);
            string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, app.FileUploadLocation + entity.FileLocation);
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                //if (password != "")
                //{

                //    using (MemoryStream inputData = new MemoryStream(FileBuffer))
                //    {
                //        using (MemoryStream outputData = new MemoryStream())
                //        {
                //            string PDFFilepassword = password;
                //            PdfReader reader = new PdfReader(inputData);
                //            PdfEncryptor.Encrypt(reader, outputData, true, PDFFilepassword, PDFFilepassword, PdfWriter.ALLOW_SCREENREADERS);
                //            FileBuffer = outputData.ToArray();
                //        }
                //    }
                //}

                Response.Clear();
                Response.ContentType = mimeType;
                //Response.AddHeader("content-disposition", "attachment; filename=foo." + fileNameExtension);
                Response.BinaryWrite(FileBuffer);
                Response.End();


                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-length", FileBuffer.Length.ToString());
                //Response.BinaryWrite(FileBuffer);

            }
            #endregion

        }

        public DataSet GetDataset()
        {
            _ds = new DataSet();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (_rptType == 18)
                {
                    cmd = SqlHelper.CreateCommand(con, "spRptEmployeeList", new object[] { _Department, _Designation, _JoiningdateFrom, _JoiningdateTo, _ResignDateFrom, _ResignDateTo });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 19)
                {
                    cmd = SqlHelper.CreateCommand(con, "spRptEmployeeStatus", new object[] { _YearID });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 20)
                {
                    cmd = SqlHelper.CreateCommand(con, "spReconciliationPrint", new object[] { _ReconMasterID, _periodID });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 1)
                {
                    cmd = SqlHelper.CreateCommand(con, "spRptPaySlip", new object[] { _empCode, _periodID });
                    cmd.CommandTimeout = 3000;

                }
                else if (_rptType == 2)
                {
                    if (_periodID > _previousPeriodID)
                    {
                        _reconciliationType = 1;
                    }
                    else
                    {
                        _reconciliationType = 2;
                    }
                    cmd = SqlHelper.CreateCommand(con, "spRptTotalReconciliationStatement", new object[] { "0", _periodID, _previousPeriodID, _reconciliationType });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 4)
                {
                    cmd = SqlHelper.CreateCommand(con, "SalarySheetPrint", new object[] { _periodID, _YearID });
                    cmd.CommandTimeout = 3000;

                }
                else if (_rptType == 9)
                {

                    //cmd = SqlHelper.CreateCommand(con, "spRptUpdatedSalarySheet", new object[] { _periodID, 1, _isBlock, _payMode });
                    cmd = SqlHelper.CreateCommand(con, "spRptUpdatedSalarySheet", new object[] { _periodID, _YearID, "No", "All Pay" });
                    cmd.CommandTimeout = 3000;
                }

                else if (_rptType == 21 || _rptType == 23)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalMaster", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 22)
                {
                    cmd = SqlHelper.CreateCommand(con, "spDepartmentwiseJV", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 100)
                {
                    cmd = SqlHelper.CreateCommand(con, "spGetSalaryFixationRptWithCode", new object[] { _empCode, _branchCode });
                    cmd.CommandTimeout = 3000;
                }
                else if (_rptType == 101)
                {
                    cmd = SqlHelper.CreateCommand(con, "spGetSalaryFixationRpt", new object[] { _empCode });
                    cmd.CommandTimeout = 3000;
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(_ds);
                con.Close();
            }
            catch
            {
                con.Close();
                SqlConnection.ClearAllPools();
            }
            return _ds;
        }

        private void LoadSubReportData()
        {
            try
            {

                rptViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
            }
            catch (Exception)
            {
                throw;
            }
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "SubDepartmentWiseSummary")
            {
                e.DataSources.Add(new ReportDataSource("DSEmployeeList", GetSubDataset(1).Tables[0]));
            }
            else if (e.ReportPath == "CryRptPayslipAddition")
            {
                e.DataSources.Add(new ReportDataSource("DSPayroll", GetSubDataset(2).Tables[0]));
            }
            else if (e.ReportPath == "SubDeductPayslip")
            {
                e.DataSources.Add(new ReportDataSource("DSPayroll", GetSubDataset(3).Tables[0]));
            }
            else if (e.ReportPath == "CrySubReconciliationSalarySheet")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(10).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnal" || e.ReportPath == "SubJurnalFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(11).Tables[0]));
            }

            else if (e.ReportPath == "SubJurnalLWF" || e.ReportPath == "SubJurnalLWFFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(15).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalResign" || e.ReportPath == "SubJurnalResignFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(12).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalForPE" || e.ReportPath == "SubJurnalForPEFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(16).Tables[0]));
            }

            else if (e.ReportPath == "SubJurnalForPEInc")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(38).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalForPEFinanceIn")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(39).Tables[0]));
            }

            else if (e.ReportPath == "SubReportForTotal")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(17).Tables[0]));
            }

            else if (e.ReportPath == "SubReportJurnalMaster")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(18).Tables[0]));
            }

            else if (e.ReportPath == "SubReportDiff")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(19).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalFrac")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(20).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalIncrement")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(22).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalFractionalSalary")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(25).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalIncrementFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(24).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalReverseLWP" || e.ReportPath == "SubJurnalReverseLWPFinance")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(23).Tables[0]));
            }
            else if (e.ReportPath == "SubJurnalAdj")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(21).Tables[0]));
            }


            else if (e.ReportPath == "subDepartmentWiseHeadCound")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(13).Tables[0]));
            }
            else if (e.ReportPath == "SubJournalResult")
            {
                e.DataSources.Add(new ReportDataSource("DSCitycell", GetSubDataset(14).Tables[0]));
            }

        }

        private DataSet GetSubDataset(int count)
        {
            _ds = new DataSet();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (count == 1)
                {
                    cmd = SqlHelper.CreateCommand(con, "spRptEmployeeStatus", new object[] { _YearID });
                    cmd.CommandTimeout = 3000;
                }
                else if (count == 2)
                {
                    cmd = SqlHelper.CreateCommand(con, "spRptPaySlipAddition", new object[] { _empCode, _periodID });
                    cmd.CommandTimeout = 3000;
                }
                else if (count == 3)
                {
                    cmd = SqlHelper.CreateCommand(con, "spPayslipDeduct", new object[] { _empCode, _periodID });
                    cmd.CommandTimeout = 3000;
                }
                else if (count == 10)
                {
                    if (_periodID > _previousPeriodID)
                    {
                        _reconciliationType = 1;
                    }
                    else
                    {
                        _reconciliationType = 2;
                    }
                    cmd = SqlHelper.CreateCommand(con, "spRptReconciliationSalarySheet", new object[] { _previousPeriodID, _periodID, _reconciliationType });
                    cmd.CommandTimeout = 3000;
                }
                else if (count == 11)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalNewJoin", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                if (count == 12)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalResign", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                if (count == 13)
                {
                    cmd = SqlHelper.CreateCommand(con, "spDepartmentwiseJVHEadCount", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                if (count == 14)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalResult", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }

                if (count == 15)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalaryInd", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }

                if (count == 16)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalaryIndFOPE", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                if (count == 38)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalaryIndFOPEinc", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }
                if (count == 39)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalaryIndFOPEinc", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }

                if (count == 17)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalaryFORTOTAL", new object[] { _periodID });
                    cmd.CommandTimeout = 3000;
                }

                if (count == 18)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalMasterprevious", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }

                if (count == 19)
                {
                    cmd = SqlHelper.CreateCommand(con, "spJournalSalarydiff", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 20)
                {
                    cmd = SqlHelper.CreateCommand(con, "SpfractionalAmount", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 22)
                {
                    cmd = SqlHelper.CreateCommand(con, "spSubJurnalIncrement", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 25)
                {
                    cmd = SqlHelper.CreateCommand(con, "spSubJurnalFractionSalary", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 24)
                {
                    cmd = SqlHelper.CreateCommand(con, "spSubJurnalIncrementFinance", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 23)
                {
                    cmd = SqlHelper.CreateCommand(con, "spSubJurnalReverseLWP", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                if (count == 21)
                {
                    cmd = SqlHelper.CreateCommand(con, "SpAdjustmentAmount", new object[] { _periodID });
                    cmd.CommandTimeout = 30000;
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(_ds);
                con.Close();
            }
            catch
            {
                con.Close();

                SqlConnection.ClearAllPools();
            }
            return _ds;
        }
        #endregion
    }
}