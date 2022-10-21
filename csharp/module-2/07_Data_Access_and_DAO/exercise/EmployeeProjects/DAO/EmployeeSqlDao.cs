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
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }
                return employees;
            }


        }


        private Employee CreateEmployeeFromReader(SqlDataReader reader)
        {
            Employee employees = new Employee();
            employees.DepartmentId = Convert.ToInt32(reader["department_id"]);
            employees.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            employees.FirstName = Convert.ToString(reader["first_name"]);
            employees.LastName = Convert.ToString(reader["last_name"]);
            employees.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            employees.HireDate = Convert.ToDateTime(reader["hire_date"]);


            return employees;
        }
        public IList<Employee> GetEmployeesByProjectId(int projectId)
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee JOIN project_employee ON employee.employee_id = project_employee.employee_id WHERE project_id = @project_id;", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }
                return employees;
            }



        }
        public void AddEmployeeToProject(int projectId, int employeeId)
        {
          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO project_employee(project_id, employee_id) VALUES(@project_id, @employee_id)", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);

                cmd.ExecuteReader(); 

            }
        }
        public void RemoveEmployeeFromProject(int projectId, int employeeId)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM project_employee WHERE employee_id = @employee_id AND project_id = @project_id; ", conn);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM timesheet WHERE employee_id = @employee_id AND project_id = @project_id; ", conn);
                cmd2.Parameters.AddWithValue("@employee_id", employeeId);
                cmd.Parameters.AddWithValue("@project_id", projectId);
                

                SqlCommand cmd3 = new SqlCommand("DELETE FROM employee WHERE employee_id = @employee_id; ", conn);
                cmd3.Parameters.AddWithValue("@employee_id", employeeId);

                cmd3.ExecuteNonQuery();
            }
        }
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM project JOIN project_employee ON project.project_id = project_employee.project_id JOIN employee ON project_employee.employee_id = employee.employee_id WHERE employee_id = @employee_id AND project_id = @project_id", conn);


                
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }
                return employees;
            }
        }

        public IList<Employee> SearchEmployeesByName(string firstNameSearch, string lastNameSearch)
        {

            //IList<Department> departments = new List<Department>();

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM department", conn);


            //    SqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Department department = CreateDepartmentFromReader(reader);
            //        departments.Add(department);
            //    }
            return null;
        }
        // return new List<Employee>() { new Employee() };
    }



}



    





        
