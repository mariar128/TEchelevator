using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public class CustomerSqlDao : ICustomerDao
    {
        private readonly string connectionString;

        public CustomerSqlDao(string connString)
        {
            connectionString = connString;
        }

        // Step Four: Add a new DAO method
        public Customer GetCustomer(int customerId)
        {
            Customer customer = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT customer_id, first_name, last_name, street_address, city, " +
                                                "phone_number, email_address, email_offers " +
                                                "FROM customer " +
                                                "WHERE customer_id = @customer_id;", conn);
                cmd.Parameters.AddWithValue("@customer_id", customerId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    customer = CreateCustomerFromReader(reader);
                }
            }

            return customer;
        }

        public IList<Customer> FindCustomersByName(string search)
        {
            IList<Customer> customers = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT customer_id, first_name, last_name, street_address, city, " +
                                                "phone_number, email_address, email_offers " +
                                                "FROM customer " +
                                                "WHERE first_name LIKE @first_name OR last_name LIKE @last_name;", conn);
                cmd.Parameters.AddWithValue("@first_name", "%" + search + "%");
                cmd.Parameters.AddWithValue("@last_name", "%" + search + "%");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = CreateCustomerFromReader(reader);
                    customers.Add(customer);
                }
            }

            return customers;
        }

        private Customer CreateCustomerFromReader(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerId = Convert.ToInt32(reader["customer_id"]);
            customer.FirstName = Convert.ToString(reader["first_name"]);
            customer.LastName = Convert.ToString(reader["last_name"]);
            customer.StreetAddress = Convert.ToString(reader["street_address"]);
            customer.City = Convert.ToString(reader["city"]);
            customer.PhoneNumber = Convert.ToString(reader["phone_number"]);
            customer.EmailAddress = Convert.ToString(reader["email_address"]);
            customer.EmailOffers = Convert.ToBoolean(reader["email_offers"]);

            return customer;
        }
    }
}
