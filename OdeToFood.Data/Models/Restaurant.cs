using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Models
{
    //Make the class public so we can use this class outside OdeToFood.Data project
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Display(Name = "Type of food")]
        public CuisineType Cuisine { get; set; }

    }
}
 