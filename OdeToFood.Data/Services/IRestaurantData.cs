using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    //Make it public so we can use it outside of odeToFood.Data
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Update(Restaurant restaurant);
        void Delete(int id);

    }
}
