﻿
using Microsoft.AspNetCore.Mvc;
using Pemesanan_Makanan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pemesanan_Makanan.Controllers
{
    public class LoginController : Controller
    {
        db dbop = new db();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Ad_login ad)
        {
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "Selamat Datang Admin";
                Response.Redirect("Home/Index");
            }
            else
            {
                TempData["msg"] = "Login gagal, terdapat kesalahan !!!!";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
