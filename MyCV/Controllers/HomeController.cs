
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCV.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting.Internal;
using System.Net;

namespace MyCV.Controllers
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
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetPdf()
        {
            string filePath = "~/documents/Salwa_Abdul-Rahman_CV.pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=test.pdf");
            return File(filePath, "application/pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    internal class HttpStatusCodeResult : ActionResult
    {
        private HttpStatusCode forbidden;

        public HttpStatusCodeResult(HttpStatusCode forbidden)
        {
            this.forbidden = forbidden;
        }
    }
}
