using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NEMESYS.Areas.Identity.Data;
using NEMESYS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NEMESYS.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConnectionStringClass _cc;
        private readonly UserManager<NEMESYSUser> _userManager;
        private ConnectionStringClass _context { get; }

        public HomeController(ILogger<HomeController> logger, ConnectionStringClass cc, UserManager<NEMESYSUser> userManager, ConnectionStringClass context)
        {
            _logger = logger;
            _cc = cc;
            _userManager =userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            List<ReportClass> reports = (from report in this._cc.Reports.Take(1000)
                                        select report).ToList();
            return View(reports);
        }

        public async Task<ReportClass> GetReportById(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report != null)
            {
                var reportDetails = new ReportClass()
                {
                    ReportID = report.ReportID,
                    ReportDate = report.ReportDate,
                    HazardLocation = report.HazardLocation,
                    HazardType = report.HazardType,
                    HazardDate = report.HazardDate,
                    HazardPhoto = report.HazardPhoto,
                    HazardDescription = report.HazardDescription,
                    HazardUpvotes = report.HazardUpvotes,
                    ReporterFirstName = report.ReporterFirstName,
                    ReporterLastName = report.ReporterLastName,
                    ReporterEmail = report.ReporterEmail,
                    ReporterMobile = report.ReporterMobile,
                    ReportTitle = report.ReportTitle,
                    HazardStatus = report.HazardStatus,
                    InvestigationEntryID = report.InvestigationEntryID
                };                
                return reportDetails;
            }

            return null;
        }

        [Route("report-details/{id}", Name = "reportDetailsRoute")]
        public async Task<ViewResult> GetReportDetails(int id)
        {
            var data = await GetReportById(id);

            return View(data);
        }

        public async Task<InvestigationClass> GetInvestigationByID(int id)
        {
            var investigation = await _context.Investigations.FindAsync(id);

            if (investigation != null)
            {
                var investigationDetails = new InvestigationClass()
                {
                    InvestigationDescription = investigation.InvestigationDescription,
                    InvestigationID = investigation.InvestigationID,
                    InvestigationDate = investigation.InvestigationDate,
                    InvestigatorFirstName = investigation.InvestigatorFirstName,
                    InvestigatorLastName = investigation.InvestigatorLastName,
                    InvestigatorEmail = investigation.InvestigatorEmail,
                    InvestigatorMobile = investigation.InvestigatorMobile,
                    InvestigatingReportID = investigation.InvestigatingReportID
                };
                return investigationDetails;
            }

            return null;
        }

        [Route("Investigation-view/{id}", Name = "viewInvestigationEntryRoute")]
        public async Task<ViewResult> ViewInvestigationEntry(int id)
        {

            //get report
            var report = await _context.Reports.FindAsync(id);

            //save investigation ID from report
            int investigationID = Int32.Parse(report.InvestigationEntryID);

            var data = await GetInvestigationByID(investigationID);
            return View(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult EditUserReport()
        {
            var user = _userManager.GetUserAsync(HttpContext.User);

            //user email
            var email = user.Result.Email;

            //list of all reports
            List<ReportClass> reports = (from report in this._cc.Reports.Take(1000)
                                         select report).ToList();

            //Empty list of user reports
            List<ReportClass> userReports = new List<ReportClass>();

            //Loop traverses all reports and stores reports with matching user email to list of user reports
            foreach (ReportClass report in reports)
            {
                if (email == report.ReporterEmail)
                {
                    userReports.Add(report);
                }
            }
            
            return View(userReports);
        }

        public async Task<ReportClass> editReportById(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report != null)
            {
                var reportDetails = new ReportClass()
                {
                    ReportDate = report.ReportDate,
                    HazardLocation = report.HazardLocation,
                    HazardType = report.HazardType,
                    HazardDate = report.HazardDate,
                    HazardPhoto = report.HazardPhoto,
                    HazardDescription = report.HazardDescription,
                    HazardUpvotes = report.HazardUpvotes,
                    ReporterFirstName = report.ReporterFirstName,
                    ReporterLastName = report.ReporterLastName,
                    ReporterEmail = report.ReporterEmail,
                    ReporterMobile = report.ReporterMobile,
                    ReportTitle = report.ReportTitle,
                    HazardStatus = report.HazardStatus
                };

                return reportDetails;
            }

            return null;
        }

        [Route("report-edit/{id}", Name = "editReportRoute")]
        public async Task<ViewResult> EditReport(int id)
        {
            //populating dropdown
            List<SelectListItem> typesOfHazards = new()
            {
                new SelectListItem { Value = "1", Text = "Unsafe act" },
                new SelectListItem { Value = "2", Text = "Condition" },
                new SelectListItem { Value = "3", Text = "Equipment" }
            };
            ViewBag.typesOfHazards = typesOfHazards;

            var data = await editReportById(id);

            return View(data);
        }


        [Route("report-edit/{id}", Name = "editReportRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> EditReport(int id, ReportClass reportClass)
        {            
            var report = await _context.Reports.FindAsync(id);

            //setting variables of report (in sql) equal to variables of form
            report.ReportTitle = reportClass.ReportTitle;
            report.HazardLocation = reportClass.HazardLocation;
            report.HazardType = reportClass.HazardType;
            report.HazardDate = reportClass.HazardDate;
            report.HazardDescription = reportClass.HazardDescription;

            //Converting dropdown answer (1,2,3) into proper values
            if (reportClass.HazardType == "1")
            {
                report.HazardType = "Unsafe act";
            }
            else if (reportClass.HazardType == "2")
            {
                report.HazardType = "Condition";
            }
            else if (reportClass.HazardType == "3")
            {
                report.HazardType = "Equipment";
            }

            _cc.Update(report);
            _cc.SaveChanges();
            ViewBag.messageReportEditted = "The report " + report.ReportTitle + " is editted successfully !";
            return View();
        }

        [Route("report-delete/{id}", Name = "deleteReportRoute")]
        public async Task<ViewResult> DeleteReport(int id)
        {
            var data = await editReportById(id);

            return View(data);
        }

        [Route("report-delete/{id}", Name = "deleteReportRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReport(int id, int test)
        {
            var report = await _context.Reports.FindAsync(id);
            _cc.Remove(report);
            _cc.SaveChanges();
            ViewBag.messageReportEditted = "The report " + report.ReportTitle + " is deleted successfully !";
            return View("HallOfFame");
        }

        public IActionResult HallOfFame()
        {
            List<NEMESYSUser> users = new List<NEMESYSUser>();
            users = _userManager.Users.ToList();

            List<NEMESYSUser> SortedList = users.OrderByDescending(o => o.NumberOfReports).ToList();

            return View(SortedList);
        }

        [Authorize(Roles = "Investigator")]
        public IActionResult InvestigateReport()
        {
            List<ReportClass> reports = (from report in this._cc.Reports.Take(1000)
                                         select report).ToList();

            //Empty list of user reports
            List<ReportClass> userReports = new List<ReportClass>();

            //Loop traverses all reports and stores reports with matching user email to list of user reports
            foreach (ReportClass report in reports)
            {
                if (report.Investigator==null)
                {
                    userReports.Add(report);
                }
            }

            return View(userReports);
        }

        
        [Route("investigate-details/{id}", Name = "investigateReportRoute")]
        public async Task<ViewResult> InvestigateReportDetails(int id)
        {
            var data = await GetReportById(id);

            return View(data);
        }

        [Route("investigate-details/{id}", Name = "investigateReportRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InvestigateReportDetails(int id, int test)
        {
            var report = await _context.Reports.FindAsync(id);

            var user = _userManager.GetUserAsync(HttpContext.User);

            //getting data from logged in user
            var email = user.Result.Email;

            report.Investigator = email;
            _cc.Update(report);
            _cc.SaveChanges();
            ViewBag.messageReportEditted = "The report " + report.ReportTitle + " is being investigated by you !";
            return View("HallOfFame");
        }

        [Authorize(Roles = "Investigator")]
        [Authorize]
        public IActionResult UserInvestigatingReports()
        {
            var user = _userManager.GetUserAsync(HttpContext.User);

            //user email
            var email = user.Result.Email;

            //list of all reports
            List<ReportClass> reports = (from report in this._cc.Reports.Take(1000)
                                         select report).ToList();

            //Empty list of user reports
            List<ReportClass> userReports = new List<ReportClass>();

            //Loop traverses all reports and stores reports with matching user email to list of user reports
            foreach (ReportClass report in reports)
            {
                if (email == report.Investigator)
                {
                    userReports.Add(report);
                }
            }

            return View(userReports);
        }

        [Route("investigatorStatus-edit/{id}", Name = "editInvestigationStatusRoute")]
        public async Task<ViewResult> EditInvestigationStatusRoute(int id)
        {
            //populating dropdown
            List<SelectListItem> typesOfStatus = new()
            {
                new SelectListItem { Value = "1", Text = "Being Worked On" },
                new SelectListItem { Value = "2", Text = "Closed" },
                new SelectListItem { Value = "3", Text = "No Action Needed" }
            };
            ViewBag.typesOfStatus = typesOfStatus;

            var data = await editReportById(id);

            return View(data);
        }


        [Route("investigatorStatus-edit/{id}", Name = "editInvestigationStatusRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> EditInvestigationStatusRoute(int id, ReportClass reportClass)
        {
            var report = await _context.Reports.FindAsync(id);

            //setting variables of report (in sql) equal to variables of form
            report.HazardStatus = reportClass.HazardStatus;

            //Converting dropdown answer (1,2,3) into proper values
            if (reportClass.HazardStatus == "1")
            {
                report.HazardStatus = "Being Worked On";
            }
            else if (reportClass.HazardStatus == "2")
            {
                report.HazardStatus = "Closed";
            }
            else if (reportClass.HazardStatus == "3")
            {
                report.HazardStatus = "No Action Needed";
            }

            _cc.Update(report);
            _cc.SaveChanges();
            ViewBag.messageReportStatusEditted = "The report status is editted successfully !";
            return View();
        }
        
        [Route("investigation-entry/{id}", Name = "createInvestigationEntryRoute")]
        public async Task<IActionResult> CreateInvestigationEntry(int id)
        {
            //get report
            var report = await _context.Reports.FindAsync(id);

            if (String.Equals(report.InvestigationEntryID, "0"))
            {
                return View();
            }
            else
            {
                return View("HallOfFame");
            }
            
        }

        [Route("investigation-entry/{id}", Name = "createInvestigationEntryRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInvestigationEntry(InvestigationClass investigation, int id)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);

            //getting data from logged in user
            var email = user.Result.Email;
            var firstName = user.Result.FirstName;
            var lastName = user.Result.LastName;
            var mobile = user.Result.PhoneNumber;

            //manually inputting data into investigation
            investigation.InvestigatorEmail = email;
            investigation.InvestigatorFirstName = firstName;
            investigation.InvestigatorLastName = lastName;
            investigation.InvestigationDate = DateTime.Now.ToShortDateString();
            investigation.InvestigatingReportID = id;

            if (mobile != null)
            {
                investigation.InvestigatorMobile = mobile.ToString();
            }

            //get report
            var report = await _context.Reports.FindAsync(id);
            

            //saving data
            _cc.Add(investigation);
            _cc.SaveChanges();

            String strInvestigationID = investigation.InvestigationID.ToString();
            report.InvestigationEntryID = strInvestigationID;
            _cc.Update(report);
            _cc.SaveChanges();

            ViewBag.messageInvestigationSubmitted = "The investigation entry is saved successfully !";
            return View(investigation);
        }

        [Route("editInvestigation-entry/{id}", Name = "editInvestigationEntryRoute")]
        public async Task<IActionResult> EditInvestigationEntry(int id)
        {
            //get report
            var report = await _context.Reports.FindAsync(id);
            //save investigation ID from report
            int investigationID = Int32.Parse(report.InvestigationEntryID);

            var data = await GetInvestigationByID(investigationID);

            if (String.Equals(report.InvestigationEntryID, "0"))
            {                
                return View("HallOfFame");
            }
            else
            {
                return View(data);
            }
        }

        [Route("editInvestigation-entry/{id}", Name = "editInvestigationEntryRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInvestigationEntry(int id, InvestigationClass investigationClass)
        {
            //get report
            var report = await _context.Reports.FindAsync(id);

            //from report ID find the investigation

            int idInvestigation = Int32.Parse(report.InvestigationEntryID);

            //finding investigation
            var investigation = await _context.Investigations.FindAsync(idInvestigation);


            //updating description
            investigation.InvestigationDescription = investigationClass.InvestigationDescription;

            //saving data
            _cc.Update(investigation);
            _cc.SaveChanges();
            ViewBag.messageInvestigationEditted = "The investigation has been editted successfully !";

            return View(investigation);
        }

        [Authorize]
        public IActionResult CreateReport()
        {
            //populating dropdown
            List<SelectListItem> typesOfHazards = new()
            {
                new SelectListItem { Value = "1", Text = "Unsafe act" },
                new SelectListItem { Value = "2", Text = "Condition" },
                new SelectListItem { Value = "3", Text = "Equipment" }
            };
            ViewBag.typesOfHazards = typesOfHazards;

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReport(ReportClass report)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);

            //getting data from logged in user
            var email = user.Result.Email;
            var firstName = user.Result.FirstName;
            var lastName = user.Result.LastName;
            var mobile = user.Result.PhoneNumber;
            var numberOfReports = user.Result.NumberOfReports;

            //manually inputting data into report
            report.ReportDate = DateTime.Now.ToShortDateString();
            report.HazardStatus = "Open";
            report.ReporterFirstName = firstName.ToString();
            report.ReporterLastName = lastName.ToString();
            report.ReporterEmail = email.ToString();
            report.InvestigationEntryID = "0";

            if (mobile!=null)
            {
                report.ReporterMobile = mobile.ToString();
            }

            //Converting dropdown answer (1,2,3) into proper values
            if (report.HazardType == "1")
            {
                report.HazardType = "Unsafe act";
            }else if (report.HazardType == "2")
            {
                report.HazardType = "Condition";
            }else if (report.HazardType == "3")
            {
                report.HazardType = "Equipment";
            }

            //Incrementing number of reports by 1
            user.Result.NumberOfReports = numberOfReports++;

            //saving data
            _cc.Add(report);            
            _cc.SaveChanges();
            ViewBag.messageReportSubmitted = "The report '" + report.ReportTitle + "' is saved successfully !";
            return View(report);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
