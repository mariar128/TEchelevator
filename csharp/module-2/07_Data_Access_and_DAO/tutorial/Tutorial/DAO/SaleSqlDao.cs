using System;
using System.Data.SqlClient;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public class SaleSqlDao : ISaleDao
    {
        private readonly string connectionString;

        public SaleSqlDao(string connString)
        {
            connectionString = connString;
        }

        public decimal GetTotalSales()
        {
            decimal totalSales = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Step Two: Add SQL for retrieving total sales
                SqlCommand cmd = new SqlCommand("SELECT 0;", conn);

                totalSales = Convert.ToDecimal(cmd.ExecuteScalar());
            }

            return totalSales;
        }

        public Sale GetSale(int saleId)
        {
            Sale sale = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT sale_id, total, is_delivery, customer_id " +
                                                "FROM sale " +
                                                "WHERE sale_id = @sale_id;", conn);
                cmd.Parameters.AddWithValue("@sale_id", saleId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    sale = CreateSaleFromReader(reader);
                }
            }

            return sale;
        }

        private Sale CreateSaleFromReader(SqlDataReader reader)
        {
            Sale sale = new Sale();
            // Step Three: Copy returned values into an object
            

            
            return sale;
        }
    }
}
