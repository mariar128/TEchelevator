using System.Collections.Generic;
using Tutorial.Models;

namespace Tutorial.DAO
{
    public interface ICustomerDao
    {
        // Step Four: Add a new DAO method
        /// <summary>
        /// Get a customer from the datastore that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="customerId">The id of the customer to retrieve.</param>
        /// <returns>A complete Customer object.</returns>
        Customer GetCustomer(int customerId);

        /// <summary>
        /// Get customers whose first or last names include the given search string.
        /// </summary>
        /// <param name="search">The string to search for in customer names.</param>
        /// <returns>A List of Customer objects.</returns>
        IList<Customer> FindCustomersByName(string search);
    }
}
