using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CampgroundReservations.Models;

namespace CampgroundReservations.DAO
{
    public class ReservationSqlDao : IReservationDao
    {
        private readonly string connectionString;

        public ReservationSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public int CreateReservation(int siteId, string name, DateTime fromDate, DateTime toDate)
        {
            int reservationId = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reservation (site_id, name, from_date, to_date, create_date) VALUES (@siteId, @name, @fromDate, @toDate, GETDATE());", conn);
                    cmd.Parameters.AddWithValue("@siteId", siteId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        cmd = new SqlCommand("SELECT @@IDENTITY", conn);
                        reservationId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred inserting reservation");
                Console.WriteLine(ex.Message);
                throw;
            }

            return reservationId;
        }

        public IList<Reservation> GetUpcomingReservations(int parkId)
        {
            List<Reservation> reservations = new List<Reservation>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT reservation_id, r.site_id, r.name, from_date, to_date, create_date "
                                                        + "FROM reservation r "
                                                        + "INNER JOIN site s ON s.site_id = r.site_id "
                                                        + "INNER JOIN campground c ON c.campground_id = s.campground_id "
                                                        + "WHERE park_id = @parkId AND from_date BETWEEN GETDATE() AND GETDATE() + 30", conn);
                    cmd.Parameters.AddWithValue("@parkId", parkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Reservation reservation = GetReservationFromReader(reader);
                        reservations.Add(reservation);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred getting upcoming reservations");
                Console.WriteLine(ex.Message);
                throw;
            }

            return reservations;
        }

        private Reservation GetReservationFromReader(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = Convert.ToInt32(reader["reservation_id"]);
            reservation.SiteId = Convert.ToInt32(reader["site_id"]);
            reservation.Name = Convert.ToString(reader["name"]);
            reservation.FromDate = Convert.ToDateTime(reader["from_date"]);
            reservation.ToDate = Convert.ToDateTime(reader["to_date"]);
            reservation.CreateDate = Convert.ToDateTime(reader["create_date"]);

            return reservation;
        }
    }
}
