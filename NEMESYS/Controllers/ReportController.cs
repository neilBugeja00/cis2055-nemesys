using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NEMESYS.Areas.Identity.Data;
using NEMESYS.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NEMESYS.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ConnectionStringClass _cc;
        private readonly UserManager<NEMESYSUser> _userManager;
        private ConnectionStringClass _context { get; }

        public ReportController(ILogger<ReportController> logger, ConnectionStringClass cc, UserManager<NEMESYSUser> userManager, ConnectionStringClass context)
        {
            _logger = logger;
            _cc = cc;
            _userManager = userManager;
            _context = context;
        }


        //======================================= GET DETAILS OF REPORTS =======================================
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


        //======================================= DISPLAY DETAILS OF REPORT =======================================
        [Route("report-details/{id}", Name = "reportDetailsRoute")]
        public async Task<ViewResult> GetReportDetails(int id)
        {
            var data = await GetReportById(id);

            return View(data);
        }


        //======================================= EDIT DETAILS OF REPORT =======================================
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

            var data = await GetReportById(id);

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



        //======================================= DELETE REPORT =======================================
        [Route("report-delete/{id}", Name = "deleteReportRoute")]
        public async Task<ViewResult> DeleteReport(int id)
        {
            var data = await GetReportById(id);

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
            return View("DeleteConfirm");
        }

    }
}
