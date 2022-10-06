using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class CitySqlDao : ICityDao
    {
        private readonly string connectionString;

        public CitySqlDao(string connString)
        {
            connectionString = connString;
        }

        public City GetCity(int cityId)
        {
            City city = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE city_id = @city_id;", conn);
                cmd.Parameters.AddWithValue("@city_id", cityId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    city = CreateCityFromReader(reader);
                }
            }
            return city;
        }

        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area " +
                                                "FROM city " +
                                                "WHERE state_abbreviation = @state_abbreviation " +
                                                "ORDER BY city_id;", conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    City city = CreateCityFromReader(reader);
                    cities.Add(city);
                }
            }

            return cities;
        }

        public City CreateCity(City city)
        {
            int newCityId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO city (city_name, state_abbreviation, population, area) " +
                                                "OUTPUT INSERTED.city_id " +
                                                "VALUES (@city_name, @state_abbreviation, @population, @area);", conn);
                cmd.Parameters.AddWithValue("@city_name", city.CityName);
                cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                cmd.Parameters.AddWithValue("@population", city.Population);
                cmd.Parameters.AddWithValue("@area", city.Area);

                newCityId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetCity(newCityId);
        }

        public void UpdateCity(City city)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE city SET city_name = @city_name, state_abbreviation = @state_abbreviation, population = @population, area = @area WHERE city_id = @city_id;", conn);
                cmd.Parameters.AddWithValue("@city_name", city.CityName);
                cmd.Parameters.AddWithValue("@state_abbreviation", city.StateAbbreviation);
                cmd.Parameters.AddWithValue("@population", city.Population);
                cmd.Parameters.AddWithValue("@area", city.Area);
                cmd.Parameters.AddWithValue("@city_id", city.CityId);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCity(int cityId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM city WHERE city_id = @city_id;", conn);
                cmd.Parameters.AddWithValue("@city_id", cityId);

                cmd.ExecuteNonQuery();
            }
        }

        private City CreateCityFromReader(SqlDataReader reader)
        {
            City city = new City();
            city.CityId = Convert.ToInt32(reader["city_id"]);
            city.CityName = Convert.ToString(reader["city_name"]);
            city.StateAbbreviation = Convert.ToString(reader["state_abbreviation"]);
            city.Population = Convert.ToInt32(reader["population"]);
            city.Area = Convert.ToDecimal(reader["area"]);

            return city;
        }
    }
}
