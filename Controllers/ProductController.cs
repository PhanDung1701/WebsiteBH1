using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBH.Models;


namespace WebsiteBH.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products

        public ActionResult Index(int? page)
        {
            int pageSize = 12; 
            int pageNumber = (page ?? 1); 
            var items = db.Products.OrderBy(p => p.Id).ToPagedList(pageNumber, pageSize);

            return View(items);
        }

        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }

            return View(item);
        }
        public ActionResult ProductCategory(string alias, int id, int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            var items = db.Products.Where(x => x.ProductCategoryId == id).OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);

            var cate = db.ProductCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }

            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(10).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(10).ToList();
            return PartialView(items);
        }
    }
}