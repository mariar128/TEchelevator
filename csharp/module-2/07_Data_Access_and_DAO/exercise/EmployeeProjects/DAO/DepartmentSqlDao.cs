using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class DepartmentSqlDao : IDepartmentDao
    {
        private readonly string connectionString;

        public DepartmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Department GetDepartment(int departmentId)
        {
            return new Department(0, "Not implemented Yet");
        }

        public IList<Department> GetAllDepartments()
        {
            return new List<Department>();

        }

        public void UpdateDepartment(Department updatedDepartment)
        {

        }


    }
}
