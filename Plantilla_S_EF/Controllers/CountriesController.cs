using Microsoft.AspNetCore.Mvc;
using Plantilla_S_EF.Context;
using Plantilla_S_EF.Models;
using Plantilla_S_EF.Models.respondsModels;
using Plantilla_S_EF.Services;

namespace Plantilla_S_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly CountryServices countryServices;

        public CountriesController(PrincipalContext context)
        {
            countryServices = new CountryServices(context);
        }
        [HttpGet("getAll")]
        public Respond<CountryRespond> GetAll()
        {
            return countryServices.GetAll();
        }
        // GET: api/Countries
        [HttpGet("getCountries")]
        public Respond<Country> Getcountries()
        {
            return countryServices.getCountries();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public Respond<Country> GetCountry(int id)
        {
            return countryServices.GetCountry(id);
        }

        // PUT: api/Countries/editar
        [HttpPut("editar")]
        public Respond<Country> PutCountry(Country country)
        {
            return countryServices.editCountry(country);
        }

        [HttpPost]
        public Respond<Country> PostCountry(Country country)
        {
            return countryServices.addCountry(country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public Respond<Country> DeleteCountry(int id)
        {
            return countryServices.deleteCountry(id);
        }
       
    }
}
