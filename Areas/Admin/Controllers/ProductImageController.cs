
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBH.Models.EF;
using WebsiteBH.Models;

namespace WebsiteBH.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int Id)
        {
            ViewBag.ProductId = Id;
            var items = db.ProductImage.Where(x => x.ProductId == Id).ToList();
            return View(items);
        }

        public ActionResult AddImage(int productId, string url)
        {
            db.ProductImage.Add(new ProductImage
            {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImage.Find(id);
            db.ProductImage.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }

    }
}