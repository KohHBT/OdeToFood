using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        //Create a private field list of restaurants to contain the info of restaurants in the memory
        List<Restaurant> restaurants;
        //A constructor to add the info of restaurants
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Papa John's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 2, Name = "Com Tam So 9", Cuisine = CuisineType.Vietnamese},
                new Restaurant{Id = 3, Name = "Tokyo One", Cuisine = CuisineType.Japanese},
                new Restaurant{Id = 4, Name = "McDonald", Cuisine = CuisineType.None},
            };
        }

        public void Add(Restaurant restaurant)
        {
            //Add the restaurant to the in memory list
            restaurants.Add(restaurant);
            //Generate the Id of the new restaut( finding th max id and add 1 to it)
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        //GetAll method: return the list of restaurants in memory
        public IEnumerable<Restaurant> GetAll()
        {
            //Use OrderBy to return the restaurants in ascending order of Name
            return restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
