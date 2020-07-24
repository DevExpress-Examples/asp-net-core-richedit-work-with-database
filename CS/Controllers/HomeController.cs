using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RichSaveLoadDB.Models;

namespace RichSaveLoadDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly DocsDbContext _context;

        public HomeController(DocsDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            var model = _context.Docs.FirstOrDefault();
            if (model == null)
                model = new DocumentInfo();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SaveDocument(string base64, string fileName, int format, string reason)
        {
            byte[] fileContents = System.Convert.FromBase64String(base64);
            var doc = _context.Docs.FirstOrDefault();
            if (doc == null)
            {
                doc = new DocumentInfo();
                doc.DocumentBytes = fileContents;
                doc.DocumentFormat = format;
                doc.DocumentName = fileName;
                _context.Docs.Add(doc);
            }
            else
            {
                doc.DocumentBytes = fileContents;
                doc.DocumentFormat = format;
                doc.DocumentName = fileName;
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
