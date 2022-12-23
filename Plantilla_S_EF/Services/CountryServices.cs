using Microsoft.EntityFrameworkCore;
using Plantilla_S_EF.Context;
using Plantilla_S_EF.Models;
using Plantilla_S_EF.Models.respondsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plantilla_S_EF.Services
{
    public class CountryServices
    {
        public readonly PrincipalContext db;
        private Respond<Country> respond;

        public CountryServices(PrincipalContext _db)
        {
            db = _db;
            respond = new Respond<Country>();
        }
        public Respond<Country> getCountries()
        {
            try
            {
                respond.resultsL = db.countries.ToList();
                return respond;

            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }
        }
        public Respond<Country> GetCountry(int id)
        {
            try
            {
                respond.result = db.countries.Where(x => x.id == id).FirstOrDefault();
                return respond;

            }
            catch (Exception ex)
            {
                respond.message = ex.ToString();
                respond.error = true;
                return respond;
            }


        }
        public Respond<Country> addCountry(Country country)
        {
            try
            {
                country.id = 0;
                country.Token = Guid.NewGuid();
                db.countries.Add(country);
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
        public Respond<Country> editCountry(Country country)
        {

            try
            {
                Country countryData = db.countries.Where(x => x.id == country.id).FirstOrDefault();
                if (countryData != null)
                {
                    countryData.name = country.name;
                    countryData.population = country.population;
                    countryData.updatedDate = DateTime.Now;
                    countryData.Token = Guid.NewGuid();
                    countryData.disabled = country.disabled;
                    countryData.pib = country.pib;
                    db.Entry(countryData).State = EntityState.Modified;
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
        public Respond<Country> deleteCountry(int id)
        {
            try
            {
                Country country = db.countries.Where(x => x.id == id).FirstOrDefault();
                if (country != null)
                {
                    db.Remove(country);
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

        public Respond<CountryRespond> GetAll()
        {
            Respond<CountryRespond> specialRespond = new Respond<CountryRespond>();
            try
            {
                List<Country> countries = db.countries.ToList();

                specialRespond.resultsL = new List<CountryRespond>();
                foreach (var item in countries)
                {
                    CountryRespond countryRespond = new CountryRespond();
                    countryRespond.cities = db.cities.Where(x => x.id_country == item.id).ToList();
                    countryRespond.id = item.id;
                    countryRespond.name = item.name;
                    countryRespond.population = item.population;
                    countryRespond.updatedDate = item.updatedDate;
                    countryRespond.pib = item.pib;
                    countryRespond.disabled = item.disabled;
                    countryRespond.Token = item.Token;
                    specialRespond.resultsL.Add(countryRespond);
                }
                return specialRespond;

            }
            catch (Exception ex)
            {
                specialRespond.message = ex.ToString();
                specialRespond.error = true;
                return specialRespond;
            }


        }

    }
}
