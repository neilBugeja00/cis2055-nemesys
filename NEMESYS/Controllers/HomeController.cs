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

        //======================================= INDEX (HOME) PAGE DISPLAY ALL REPORTS =======================================
        public IActionResult Index()
        {
            List<ReportClass> reports = (from report in this._cc.Reports.Take(1000)
                                        select report).ToList();
            return View(reports);
        }


        //======================================= HALL OF FAME =======================================
        public IActionResult HallOfFame()
        {
            List<NEMESYSUser> users = new List<NEMESYSUser>();
            users = _userManager.Users.ToList();

            List<NEMESYSUser> SortedList = users.OrderByDescending(o => o.NumberOfReports).ToList();

            return View(SortedList);
        }



        //======================================= EDIT REPORTS PAGE =======================================
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



        //=======================================INVESTIGATE REPORTS PAGE =======================================
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


        //======================================= VIEW INVESTIGATIONS PAGE =======================================
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


        //======================================= CREATE REPORT PAGE =======================================
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
