using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public void Add(Restaurant restaurant)
        {
            //Add the restaurant to the Restaurants table in OdeToFoodDbContext
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            //Find method work with the key value
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r =>r.Id==id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //return db.Restaurants;
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //optimistic concurrency: The last user click the save button will be the user that writes into the 
            //database and save their change
            var entry = db.Entry(restaurant) ;
            entry.State = EntityState.Modified;
            //Get the object that the user are looking for, but in a modified state
            //This means that when the user click the save button, the EntityF will make sure
            //that the dat in the database matches the properties of this object
            db.SaveChanges();
        }
    }
}
