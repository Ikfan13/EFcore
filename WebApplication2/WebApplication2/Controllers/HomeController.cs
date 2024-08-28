using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CompanyContext companyContext;

        public HomeController(ILogger<HomeController> logger,CompanyContext cc)
        {
            _logger = logger;
            companyContext = cc;
        }

        public IActionResult Index()
        {
            return View();
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
        public String createinformation()
        {
            var info = new Information()
            {
                 Name="Sanjai",
                 Licence="2k01",
                 Revenew=20000,
                 Established=Convert.ToDateTime("2024/08/01")

            };
           
            companyContext.Entry(info).State=Microsoft.EntityFrameworkCore.EntityState.Added;
            companyContext.SaveChanges();
            return "Added Successfully";
            
        }
    }
}
