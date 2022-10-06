using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public IList<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT park_id, name, location, establish_date, area, visitors, description FROM park ORDER BY location ASC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = GetParkFromReader(reader);
                        parks.Add(park);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred getting all parks");
                Console.WriteLine(ex.Message);
                throw;
            }

            return parks;
        }

        private Park GetParkFromReader(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.Name = Convert.ToString(reader["name"]);
            park.Location = Convert.ToString(reader["location"]);
            park.EstablishDate = Convert.ToDateTime(reader["establish_date"]);
            park.Area = Convert.ToInt32(reader["area"]);
            park.Visitors = Convert.ToInt32(reader["visitors"]);
            park.Description = Convert.ToString(reader["description"]);

            return park;
        }
    }
}
