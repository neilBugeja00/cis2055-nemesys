using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NEMESYS.Areas.Identity.Data;
using NEMESYS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NEMESYS.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConnectionStringClass _cc;
        private readonly UserManager<NEMESYSUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ConnectionStringClass cc, UserManager<NEMESYSUser> userManager)
        {
            _logger = logger;
            _cc = cc;
            _userManager =userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
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
            //var test1 = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var user = _userManager.GetUserAsync(HttpContext.User);
            //var user = _userManager.GetUserAsync(User);
           //var test3 = _userManager.FindByIdAsync(User.Identity.Name);

            var email = user.Result.Email;
            var firstName = user.Result.FirstName;
            var lastName = user.Result.LastName;
            var mobile = user.Result.PhoneNumber;

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
            ViewBag.messageReportSubmitted = "The record " + report.ReportTitle + " is saved successfully !";
            return View(report);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
