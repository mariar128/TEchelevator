using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using USCitiesAndParks.Models;

namespace USCitiesAndParks.DAO
{
    public class ParkSqlDao : IParkDao
    {
        private readonly string connectionString;

        public ParkSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Park GetPark(int parkId)
        {
            Park park = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT park_id, park_name, date_established, area, has_camping FROM park WHERE park_id = @park_id;", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                     park = CreateParkFromReader(reader);
                }
            }

            return park;
        }

        public IList<Park> GetParksByState(string stateAbbreviation)
        {
            IList<Park> parks = new List<Park>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT p.park_id, park_name, date_established, area, has_camping FROM park p " +
                                                "JOIN park_state ps ON p.park_id = ps.park_id " +
                                                "WHERE state_abbreviation = @state_abbreviation;", conn);
                cmd.Parameters.AddWithValue("@state_abbreviation", stateAbbreviation);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Park park = CreateParkFromReader(reader);
                    parks.Add(park);
                }
            }

            return parks;
        }

        public Park CreatePark(Park park)
        {
            int newParkId;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO park (park_name, date_established, area, has_camping) " +
                                                "OUTPUT INSERTED.park_id " +
                                                "VALUES (@park_name, @date_established, @area, @has_camping);", conn);
                cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                cmd.Parameters.AddWithValue("@area", park.Area);
                cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);

                newParkId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return GetPark(newParkId);
        }

        public void UpdatePark(Park park)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE park SET park_name = @park_name, date_established = @date_established, area = @area, has_camping = @has_camping WHERE park_id = @park_id;", conn);
                cmd.Parameters.AddWithValue("@park_name", park.ParkName);
                cmd.Parameters.AddWithValue("@date_established", park.DateEstablished);
                cmd.Parameters.AddWithValue("@area", park.Area);
                cmd.Parameters.AddWithValue("@has_camping", park.HasCamping);
                cmd.Parameters.AddWithValue("@park_id", park.ParkId);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePark(int parkId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // must delete records in park_state first
                SqlCommand cmd = new SqlCommand("DELETE FROM park_state WHERE park_id = @park_id; DELETE FROM park WHERE park_id = @park_id;", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddParkToState(int parkId, string state_abbreviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO park_state (park_id, state_abbreviation) VALUES (@park_id, @state_abbreviation);", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                cmd.Parameters.AddWithValue("@state_abbreviation", state_abbreviation);

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveParkFromState(int parkId, string state_abbreviation)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM park_state WHERE park_id = @park_id AND state_abbreviation = @state_abbreviation;", conn);
                cmd.Parameters.AddWithValue("@park_id", parkId);
                cmd.Parameters.AddWithValue("@state_abbreviation", state_abbreviation);

                cmd.ExecuteNonQuery();
            }
        }

        private Park CreateParkFromReader(SqlDataReader reader)
        {
            Park park = new Park();
            park.ParkId = Convert.ToInt32(reader["park_id"]);
            park.ParkName = Convert.ToString(reader["park_name"]);
            park.DateEstablished = Convert.ToDateTime(reader["date_established"]);
            park.Area = Convert.ToDecimal(reader["area"]);
            park.HasCamping = Convert.ToBoolean(reader["has_camping"]);

            return park;
        }
    }
}
