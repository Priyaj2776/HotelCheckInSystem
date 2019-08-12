using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HotelCheckInSystem.Models;
using HotelCheckInSystem.Data;
using System.Data.SqlClient;
namespace HotelCheckInSystem.Controllers
{
    public class HomeController : Controller
    {
        string _connectionstring;
        public HomeController(IConfiguration iconfiguration)
        {
            IConfiguration _iconfiguration = iconfiguration;
            _connectionstring = _iconfiguration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            
            if (ModelState.IsValid)
            {
                

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
