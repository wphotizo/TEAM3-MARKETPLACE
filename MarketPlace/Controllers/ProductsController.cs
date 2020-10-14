using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlace_DAL;
using MarketPlace_Services;

namespace MarketPlace.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }


        public ActionResult Compare()
        {
            return View();
        }



        public ActionResult GetProductProductDetailJson(int pid)
        {
                Service Service = new Service();
                var ProductList = Service.GetProductProductDetailJson(pid);
                ViewBag.Products = Json(ProductList, JsonRequestBehavior.AllowGet); ;
               // return View("ProductDetail");

                return Json(ProductList, JsonRequestBehavior.AllowGet);
            
        }


        public ActionResult GetAllProductProductDetailJson(int[] arr)
        {
            Service Service = new Service();
            var ProductList = Service.GetAllProductProductDetailJson(arr);
            ViewBag.Products = Json(ProductList, JsonRequestBehavior.AllowGet); ;
            // return View("ProductDetail");

            return Json(ProductList, JsonRequestBehavior.AllowGet);

        }


        

    }
}