using System;
using System.Data.SqlClient;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public class AccountSqlDao : IAccountDao
    {
        private readonly string connectionString;
        const decimal startingBalance = 1000;

        public AccountSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Account GetAccountByUserId(int userId)
        {
            Account returnAccount = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT account_id, balance, u.user_id, u.username FROM account a inner join tenmo_user u on a.user_id = u.user_id WHERE a.user_id = @userid", conn);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        returnAccount = GetAccountFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnAccount;
        }

        private Account GetAccountFromReader(SqlDataReader reader)
        {
            Account a = new Account()
            {
                AccountId = Convert.ToInt32(reader["account_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                Balance = Convert.ToDecimal(reader["balance"])
            };

            return a;
        }
    }
}
