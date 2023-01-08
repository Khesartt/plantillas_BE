using Plantilla_S_ADO.Context;
using Plantilla_S_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace Plantilla_S_ADO.Services
{
    public class CityServices
    {
        public List<City> getCities()
        {
            List<City> cities = new List<City>();
            PrincipalContext cn = new PrincipalContext();

            using (var conexion = new SqlConnection(cn.getConnection()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("listCities", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        cities.Add(new City()
                        {
                            id = Convert.ToInt32(dr["id"]),
                            name = dr["name"].ToString(),
                            population = Convert.ToInt64(dr["population"]),
                            updatedDate = DateTime.Parse(dr["updatedDate"].ToString()),
                            Token = Guid.Parse(dr["Token"].ToString()),
                            disabled = bool.Parse(dr["disabled"].ToString()),
                            pib = Convert.ToInt32(dr["pib"]),
                            id_country = Convert.ToInt32(dr["id_country"])
                        });
                    }
                }
                return cities;
            }
        }

        public City getCity(int id)
        {
            City city = new City();
            PrincipalContext cn = new PrincipalContext();

            using (var conexion = new SqlConnection(cn.getConnection()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("getById_City", conexion);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        city.id = Convert.ToInt32(dr["id"]);
                        city.name = dr["name"].ToString();
                        city.population = Convert.ToInt64(dr["population"]);
                        city.updatedDate = DateTime.Parse(dr["updatedDate"].ToString());
                        city.Token = Guid.Parse(dr["Token"].ToString());
                        city.disabled = bool.Parse(dr["disabled"].ToString());
                        city.pib = Convert.ToInt32(dr["pib"]);
                        city.id_country = Convert.ToInt32(dr["id_country"]);
                    }
                }
                return city;
            }
        }

        public bool saveCity(City city) {
            PrincipalContext cn = new PrincipalContext();
            try
            {
            using (var conexion = new SqlConnection(cn.getConnection()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("saveCity", conexion);
                cmd.Parameters.AddWithValue("name", city.name);
                cmd.Parameters.AddWithValue("population", city.population);
                cmd.Parameters.AddWithValue("updatedDate", city.updatedDate);
                cmd.Parameters.AddWithValue("Token", city.Token);
                cmd.Parameters.AddWithValue("disabled", city.disabled);
                cmd.Parameters.AddWithValue("id_country", city.id_country);

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
        public bool editCity(City city)
        {
            PrincipalContext cn = new PrincipalContext();
            try
            {
                using (var conexion = new SqlConnection(cn.getConnection()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("editCity", conexion);
                    cmd.Parameters.AddWithValue("id", city.id);
                    cmd.Parameters.AddWithValue("name", city.name);
                    cmd.Parameters.AddWithValue("population", city.population);
                    cmd.Parameters.AddWithValue("updatedDate", city.updatedDate);
                    cmd.Parameters.AddWithValue("Token", city.Token);
                    cmd.Parameters.AddWithValue("disabled", city.disabled);
                    cmd.Parameters.AddWithValue("id_country", city.id_country);

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

        public bool deleteCity(int id)
        {
            PrincipalContext cn = new PrincipalContext();
            try
            {
                using (var conexion = new SqlConnection(cn.getConnection()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("deleteCity", conexion);
                    cmd.Parameters.AddWithValue("id",id);
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
