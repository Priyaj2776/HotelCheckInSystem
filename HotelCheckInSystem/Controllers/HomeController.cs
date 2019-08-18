using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using HotelCheckInSystem.Models;
using HotelCheckInSystem.Data;
using HotelCheckInSystem.Types;
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
                using(HotelCheckInDataAccess dataAccess = new HotelCheckInDataAccess(_connectionstring))
                {
                    User validUser = dataAccess.GetUser(user.UserName, user.Password);
                    if (validUser.IsActive )
                    {
                        
                        switch (validUser.Role.Id)
                        {
                            case RoleType.Manager:
                                return RedirectToAction("Index", "Manager");
                            case RoleType.Maintenance:
                                return RedirectToAction("Index", "Maintenance");
                            case RoleType.HouseKeeping:
                                return RedirectToAction("Index", "HouseKeeping");
                            case RoleType.FrontDesk:
                                return RedirectToAction("Index", "FrontDesk");
                        }
                    }
                    else
                    {
                        ViewBag.NotValidUser = "Invalid Username/Password";
                    }
                }

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
