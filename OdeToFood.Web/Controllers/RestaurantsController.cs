using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            //Get the restaurant based on the id
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        //1st Create Action: return the view which contains the form that the user can type into
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        //2nd Create Action: Receive the info back from the user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {

            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        //1st Edit Action (response to a Http Get method): return the view which contains the form that user can edit info
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

        }
        //2nd Edit Action(response to a Http Post Method): Receive the info and save it
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
        }

        //1st Delete Action: Present the info of the restaurant to the user
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        //2nd Delete Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
    
}