using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebsiteBH.Models;
using WebsiteBH.Models.EF;

namespace WebsiteBH.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wishlist
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var userName = User.Identity.Name;
            IEnumerable<Wishlist> items = db.Wishlists.Where(x => x.UserName == userName).OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var pagedList = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(pagedList);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishlist(int ProductId)
        {
            if (!Request.IsAuthenticated)
            {
                return Json(new { Success = false, Message = "Bạn chưa đăng nhập." });
            }
            var userName = User.Identity.Name;
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == userName);
            if (checkItem != null)
            {
                return Json(new { Success = false, Message = "Sản phẩm đã được yêu thích rồi." });
            }
            var item = new Wishlist
            {
                ProductId = ProductId,
                UserName = userName,
                CreatedDate = DateTime.Now
            };
            db.Wishlists.Add(item);
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult PostDeleteWishlist(int id)
        {
            var userName = User.Identity.Name;
            var checkItem = db.Wishlists.FirstOrDefault(x => x.Id == id && x.UserName == userName);
            if (checkItem != null)
            {
                db.Wishlists.Remove(checkItem);
                db.SaveChanges();
                return Json(new { Success = true, Message = "Xóa thành công." });
            }
            return Json(new { Success = false, Message = "Xóa thất bại." });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
