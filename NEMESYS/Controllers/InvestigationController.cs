using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NEMESYS.Areas.Identity.Data;
using NEMESYS.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NEMESYS.Controllers
{
    public class InvestigationController : Controller
    {
        private readonly ILogger<InvestigationController> _logger;
        private readonly ConnectionStringClass _cc;
        private readonly UserManager<NEMESYSUser> _userManager;
        private ConnectionStringClass _context { get; }

        public InvestigationController(ILogger<InvestigationController> logger, ConnectionStringClass cc, UserManager<NEMESYSUser> userManager, ConnectionStringClass context)
        {
            _logger = logger;
            _cc = cc;
            _userManager = userManager;
            _context = context;
        }

        //======================================= GET DETAILS OF INVESTIGATIONS =======================================
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


        //======================================= EDIT DESCRIPTION OF INVESTIGATION =======================================
        [Route("editInvestigation-entry/{id}", Name = "editInvestigationEntryRoute")]
        public async Task<IActionResult> EditInvestigationEntry(int id)
        {
            //get report
            var report = await _context.Reports.FindAsync(id);
            //save investigation ID from report
            int investigationID = Int32.Parse(report.InvestigationEntryID);

            var data = await GetInvestigationByID(investigationID);

            return View(data);
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



        //======================================= EDIT STATUS OF INVESTIGATION =======================================
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

            var data = await GetReportById(id);

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




        //======================================= CREATION OF INVESTIGATION =======================================
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


        //======================================= VIEW DETAILS OF INVESTIGATION =======================================
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


        //======================================= LINK INVESTIGATION WITH REPORT =======================================
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

    }
}
