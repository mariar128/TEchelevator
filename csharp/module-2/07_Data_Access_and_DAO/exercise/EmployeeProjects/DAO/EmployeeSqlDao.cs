using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class EmployeeSqlDao : IEmployeeDao
    {
        private readonly string connectionString;

        public EmployeeSqlDao(string connString)
        {
            connectionString = connString;
        }

        public IList<Employee> GetAllEmployees()
        {
            return new List<Employee>();
        }

        public IList<Employee> SearchEmployeesByName(string firstNameSearch, string lastNameSearch)
        {
            return new List<Employee>() { new Employee() };
        }

        public IList<Employee> GetEmployeesByProjectId(int projectId)
        {
            return new List<Employee>();
        }

        public void AddEmployeeToProject(int projectId, int employeeId)
        {

        }

        public void RemoveEmployeeFromProject(int projectId, int employeeId)
        {

        }

        public IList<Employee> GetEmployeesWithoutProjects()
        {
            return new List<Employee>();
        }


    }
}
