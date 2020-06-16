using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        //Get a reference of IRestaurant Data to get the info of the restaurant
        //Create a private field named db. The controller will get access to the DB through this interface
        IRestaurantData db;
        //Constructor to initialize the db field
        public HomeController(IRestaurantData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            //create a model to hold the info of restaurants returned by GetAll() method and pass it to the view
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}