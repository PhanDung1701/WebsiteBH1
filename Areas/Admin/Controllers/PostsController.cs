using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBH.Models;

namespace WebsiteBH.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View();
        }
    }
}