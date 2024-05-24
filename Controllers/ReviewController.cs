using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBH.Models.EF;
using WebsiteBH.Models;

namespace WebsiteBH.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult _Review(int productId)
        {
            ViewBag.ProductId = productId;
            var item = new ReviewProduct();
            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                if (user != null)
                {
                    item.Email = user.Email;
                    item.FullName = user.FullName;
                    item.UserName = user.UserName;
                }
                return PartialView(item);
            }
            return PartialView();
        }

        public ActionResult LichSuDonHang()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = userManager.FindByName(User.Identity.Name);
                var items = _db.Orders.Where(x => x.CustomerId == user.Id).ToList();
                return PartialView(items);
            }

            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostReview(ReviewProduct req)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra đánh giá trùng lặp
                var existingReview = _db.Reviews
                    .FirstOrDefault(x => x.ProductId == req.ProductId && x.UserName == req.UserName);

                if (existingReview != null)
                {
                    return Json(new { Success = false, Message = "Bạn đã đánh giá sản phẩm này trước đó." });
                }

                req.CreatedDate = DateTime.Now;
                _db.Reviews.Add(req);
                _db.SaveChanges();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }

        [AllowAnonymous]
        public ActionResult _Load_Review(int productId)
        {
            var item = _db.Reviews.Where(x => x.ProductId == productId).OrderByDescending(x => x.Id).ToList();
            ViewBag.Count = item.Count;
            return PartialView(item);
        }
    }
}