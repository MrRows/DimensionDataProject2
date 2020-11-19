using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using MVCProject2ROWSMITH.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject2ROWSMITH.Controllers
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
            using (SqlConnection con = new SqlConnection("Server=DESKTOP-JS9OEOU;Database=Project2_ItDev;Trusted_Connection=True;MultipleActiveResultSets=True"))
            {
                SqlCommand cmd = new SqlCommand("insert into Test(id,colour) values(1,'red')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
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
    }
}
