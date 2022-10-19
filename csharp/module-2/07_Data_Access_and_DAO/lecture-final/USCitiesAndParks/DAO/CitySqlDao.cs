using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class CitySqlDao : ICityDao
    {
        private readonly string connectionString;

        public CitySqlDao(string connString) //CitySqlDao instantiated in Program.cs and that's where the connection string comes from 
        {
            connectionString = connString;
        }

        //method to retrieve city data from the database
        public City GetCity(int cityId) 
        {
            City city = null;

            using (SqlConnection myFavoriteDBConnection = new SqlConnection(connectionString)) //name the database connection
            {
                myFavoriteDBConnection.Open();//open the connection to the DB

                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE city_id = @city_id;", myFavoriteDBConnection);
                cmd.Parameters.AddWithValue("@city_id", cityId); //add a value for the SQL parameter of @city_id in the query string above 

                SqlDataReader reader = cmd.ExecuteReader(); //runs the SQL query against the database

                if (reader.Read()) //if we can actually read the result set (no errors, data rows exist)
                {
                    city = CreateCityFromReader(reader); //go create a city object from the results 
                }
            }

            return city; //return the city object
        }

        public IList<City> GetCitiesByState(string stateAbbreviation)
        {
            IList<City> cities = new List<City>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT city_id, city_name, state_abbreviation, population, area FROM city WHERE state_abbreviation = @state_abbreviation;", conn);
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

                cmd.ExecuteNonQuery(); //returns # of rows changed, but we're not doing anything with that information here 
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
