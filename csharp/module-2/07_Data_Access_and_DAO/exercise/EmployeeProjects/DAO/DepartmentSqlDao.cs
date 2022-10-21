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
            Department department = null;

            using (SqlConnection conn = new SqlConnection(connectionString)) //name the database connection
            {
                conn.Open();//open the connection to the DB

                SqlCommand cmd = new SqlCommand("SELECT department_id, name FROM department WHERE department_id = @department_id;", conn);
                cmd.Parameters.AddWithValue("@department_id", departmentId); //add a value for the SQL parameter of @city_id in the query string above 

                SqlDataReader reader = cmd.ExecuteReader(); //runs the SQL query against the database

                if (reader.Read()) //if we can actually read the result set (no errors, data rows exist)
                {
                    department = CreateDepartmentFromReader(reader); //go create a city object from the results 

                }
                return department;
            }
           
        }
        private Department CreateDepartmentFromReader(SqlDataReader reader)
        {
            Department department = new Department();
            department.DepartmentId = Convert.ToInt32(reader["department_id"]);
            department.Name = Convert.ToString(reader["name"]);


            return department;
        }


        public IList<Department> GetAllDepartments()
        {

            IList<Department> departments = new List<Department>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM department", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Department department = CreateDepartmentFromReader(reader);
                    departments.Add(department);
                }
                return departments;
            }
            // return new List<Department>();

        }

        public void UpdateDepartment(Department updatedDepartment)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE department SET name = @name WHERE department_id = @department_id;", conn);
                cmd.Parameters.AddWithValue("@name", updatedDepartment.Name);
                cmd.Parameters.AddWithValue("@department_id", updatedDepartment.DepartmentId);

                cmd.ExecuteNonQuery(); //returns # of rows changed, but we're not doing anything with that information here 
            }
        }
    }

 }

    

        




