using Plantilla_S_ADO.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Plantilla_S_ADO.Context;

namespace Plantilla_S_ADO.Services
{
    public class CountryService
    {
        public List<Country> getCountries()
        {
            List<Country> countries = new List<Country>();
            PrincipalContext cn = new PrincipalContext();

            using (var conexion = new SqlConnection(cn.getConnection()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("listCountries", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        countries.Add(new Country()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString(),
                            population = Convert.ToInt64(dr["population"]),
                            updatedDate = DateTime.Parse(dr["updatedDate"].ToString()),
                            Token = Guid.Parse(dr["Token"].ToString()),
                            disabled = bool.Parse(dr["disabled"].ToString()),
                            pib = Convert.ToInt32(dr["pib"]),
                        });
                    }
                }
                return countries;
            }
        }

        public Country getCountry(int id)
        {
            Country country = new Country();
            PrincipalContext cn = new PrincipalContext();

            using (var conexion = new SqlConnection(cn.getConnection()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("getById_Country", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        country.id = Convert.ToInt32(dr["id"]);
                        country.name = dr["name"].ToString();
                        country.population = Convert.ToInt64(dr["population"]);
                        country.updatedDate = DateTime.Parse(dr["updatedDate"].ToString());
                        country.Token = Guid.Parse(dr["Token"].ToString());
                        country.disabled = bool.Parse(dr["disabled"].ToString());
                        country.pib = Convert.ToInt32(dr["pib"]);
                    }
                }
                return country;
            }
        }

        public bool saveCity(Country country)
        {
            PrincipalContext cn = new PrincipalContext();
            try
            {
                using (var conexion = new SqlConnection(cn.getConnection()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("saveCountry", conexion);
                    cmd.Parameters.AddWithValue("name", country.name);
                    cmd.Parameters.AddWithValue("population", country.population);
                    cmd.Parameters.AddWithValue("updatedDate", country.updatedDate);
                    cmd.Parameters.AddWithValue("Token", country.Token);
                    cmd.Parameters.AddWithValue("disabled", country.disabled);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool editCountry(Country country)
        {
            PrincipalContext cn = new PrincipalContext();
            try
            {
                using (var conexion = new SqlConnection(cn.getConnection()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("editCountry", conexion);
                    cmd.Parameters.AddWithValue("id", country.id);
                    cmd.Parameters.AddWithValue("name", country.name);
                    cmd.Parameters.AddWithValue("population", country.population);
                    cmd.Parameters.AddWithValue("updatedDate", country.updatedDate);
                    cmd.Parameters.AddWithValue("Token", country.Token);
                    cmd.Parameters.AddWithValue("disabled", country.disabled);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteCountry(int id)
        {
            PrincipalContext cn = new PrincipalContext();
            try
            {
                using (var conexion = new SqlConnection(cn.getConnection()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("deleteCountry", conexion);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
