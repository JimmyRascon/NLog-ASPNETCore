using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog_ASPNETCore.Models;

namespace NLog_ASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                _logger.LogInformation("Index page");
                _logger.LogDebug("Calling a not implemented method");

                BadMethod();

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something bad happened!");
                return View();
            }
        }

        public IActionResult About()
        {
            _logger.LogInformation("About page");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            _logger.LogInformation("Contact page");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void BadMethod()
        {
            throw new NotImplementedException();
        }
    }
}
