using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC_Machine_Test.Models;
using PagedList;
using PagedList.Mvc;



namespace MVC_Machine_Test.Controllers
{
    public class ProductController : Controller
    {

        // GET: Product
        public ActionResult Index(int? i)
        {
            using (Model1 db = new Model1())
            {
                return View(db.Products.ToList().ToPagedList(i ?? 1, 10));
            }


        }


        public ActionResult Details(int id)
        {
            using (Model1 db = new Model1())
            {
                return View(db.Products.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }
                        

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product Product)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    db.Products.Add(Product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                return View(db.Products.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                return View(db.Products.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, Product product, object maxRows)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    Product product1 = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
                    db.Products.Remove(product1);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
