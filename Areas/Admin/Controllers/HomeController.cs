﻿using WebsiteBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBH.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Nhân viên")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var item = db.Users.ToList();
            return View(item);
        }
    }
}