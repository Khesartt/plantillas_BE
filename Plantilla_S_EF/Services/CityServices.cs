using Microsoft.EntityFrameworkCore;
using Plantilla_S_EF.Context;
using Plantilla_S_EF.Models;
using System;
using System.Linq;

namespace Plantilla_S_EF.Services
{
    public class CityServices
    {
        public readonly PrincipalContext db;
        private Respond<City> respond;

        public CityServices(PrincipalContext _db)
        {
            db = _db;
            respond = new Respond<City>();
        }


        public Respond<City> getCities()
        {
            try
            {
                respond.resultsL = db.cities.ToList();
                return respond;

            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }
        }
        public Respond<City> GetCity(int id)
        {
            try
            {
                respond.result = db.cities.Where(x => x.id == id).FirstOrDefault();
                return respond;

            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }


        }
        public Respond<City> addCity(City city)
        {
            try
            {
                city.id = 0;
                city.Token = Guid.NewGuid();
                db.cities.Add(city);
                db.SaveChanges();
                return respond;
            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }
        }
        public Respond<City> editCity(City city)
        {

            try
            {
                City cityData = db.cities.Where(x => x.id == city.id).FirstOrDefault();
                if (city != null)
                {
                    cityData.name = city.name;
                    cityData.population = city.population;
                    cityData.updatedDate = DateTime.Now;
                    cityData.Token = Guid.NewGuid();
                    cityData.disabled = city.disabled;
                    cityData.pib = city.pib;
                    cityData.id_country = city.id_country;
                    db.Entry(cityData).State = EntityState.Modified;
                    db.SaveChanges();
                    return respond;

                }
                else
                {
                    respond.message = "no se encontro nada en base de datos";
                    respond.error = true;
                    return respond;
                }
            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }

        }
        public Respond<City> deleteCity(int id)
        {
            try
            {
                City city = db.cities.Where(x => x.id == id).FirstOrDefault();
                if (city != null)
                {
                    db.Remove(city);
                    db.SaveChanges();
                    return respond;
                }
                else
                {
                    respond.message = "no se encontro nada en base de datos";
                    respond.error = true;
                    return respond;
                }
            }
            catch (Exception ex)
            {

                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }

        }

    }
}
