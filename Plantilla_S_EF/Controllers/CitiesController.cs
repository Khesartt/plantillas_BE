using Microsoft.AspNetCore.Mvc;
using Plantilla_S_EF.Context;
using Plantilla_S_EF.Models;
using Plantilla_S_EF.Services;

namespace Plantilla_S_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CityServices cityServices;

        public CitiesController(PrincipalContext context)
        {
            cityServices = new CityServices(context);
        }

        // GET: api/Cities
        [HttpGet]
        public Respond<City> Getcities()
        {
            return cityServices.getCities();
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public Respond<City> GetCity(int id)
        {
            return cityServices.GetCity(id);
        }

        // PUT: api/Cities/editar
        [HttpPut("editar")]
        public Respond<City> PutCity(City city)
        {
            return cityServices.editCity(city);
        }

        [HttpPost]
        public Respond<City> PostCity(City city)
        {
            return cityServices.addCity(city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public Respond<City> DeleteCity(int id)
        {
            return cityServices.deleteCity(id);
        }

        [HttpGet("getByCountry/{id}")]
        public Respond<City> getByCountry(int id)
        {
            return cityServices.getCitiesByCountry(id);
        }
        [HttpGet("getByCountry2/{id}")]
        public Respond<City> getByCountry2(int id)
        {
            return cityServices.getCitiesByCountry2(id);
        }
    }
}
