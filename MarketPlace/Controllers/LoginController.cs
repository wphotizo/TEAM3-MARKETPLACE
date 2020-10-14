using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlace_DAL;
using MarketPlace_Services;
using System.Data.SqlClient;
using System.IO;

namespace MarketPlace.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        //Login Action
        public ActionResult Authenticate(tblUser user)
        {

            if (ModelState.IsValid)
            {
                Service loginService = new Service();
                var IsValid = loginService.LoginCustomer(user.email, user.password);
                
                if (IsValid.ToString() == "True")
                {
                    ViewBag.message = "";
                }
                else
                {
                    ViewBag.message = "Incorrect username or password";
                    return View("Login");
                }
             
                return IsValid ? RedirectToAction("SearchPage", "Search") :  RedirectToAction("Login", "Login");
            }
            else
            {
                
                return View("Login");
            }


        }

        // Redundant Save New User
        public ActionResult Insert(tblUser user)
        {
            Service insert_Service = new Service();
            insert_Service.saveCustomer(user);
            return View("Login");
        }

        [HttpPost]
        public ActionResult Save(FormCollection formCollection)
        {
            tblUser user = new tblUser();
      
            user.username = formCollection["username"];
            user.email = formCollection["email"];
            user.password = formCollection["password"];
            //user.picture = formCollection["picture"];


            Service insert_Service = new Service();
            insert_Service.saveCustomer(user);
         


            return Content("User successfully saved");
        }
    }

     
 }
