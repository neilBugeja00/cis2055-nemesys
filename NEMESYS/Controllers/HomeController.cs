﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        [Route("report-details/{id}", Name = "reportDetailsRoute")]
        public async Task<ViewResult> GetReportDetails(int id)
        {
            var data = await GetReportById(id);

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
            var data = await editReportById(id);

            return View(data);
        }

        [Route("report-edit/{id}", Name = "editReportRoute")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ViewResult> EditReport(int id, ReportClass reportClass)
        {
            var report = await _context.Reports.FindAsync(id);
            report.ReportTitle = reportClass.ReportTitle;
            report.HazardLocation = reportClass.HazardLocation;
            report.HazardType = reportClass.HazardType;
            report.HazardDate = reportClass.HazardDate;
            report.HazardDescription = reportClass.HazardDescription;
            _cc.Update(report);
            _cc.SaveChanges();
            ViewBag.messageReportEditted = "The report " + report.ReportTitle + " is editted successfully !";
            return View();
        }

        public IActionResult HallOfFame()
        {
            return View();
        }


        [Authorize]
        public IActionResult CreateReport()
        {
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

            //manually inputting data into report
            report.ReportDate = DateTime.Now.ToShortDateString();
            report.HazardStatus = "Open";
            report.ReporterFirstName = firstName.ToString();
            report.ReporterLastName = lastName.ToString();
            report.ReporterEmail = email.ToString();

            if (mobile!=null)
            {
                report.ReporterMobile = mobile.ToString();
            }

            _cc.Add(report);
            _cc.SaveChanges();
            ViewBag.messageReportSubmitted = "The report " + report.ReportTitle + " is saved successfully !";
            return View(report);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
