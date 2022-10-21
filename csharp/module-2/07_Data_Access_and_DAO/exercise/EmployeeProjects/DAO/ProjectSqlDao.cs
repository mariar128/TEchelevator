using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class ProjectSqlDao : IProjectDao
    {
        private readonly string connectionString;

        public ProjectSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Project GetProject(int projectId)
        {
            Project project = null;

            using (SqlConnection conn = new SqlConnection(connectionString)) //name the database connection
            {
                conn.Open();//open the connection to the DB

                SqlCommand cmd = new SqlCommand("SELECT project_id, name, from_date, to_date FROM project WHERE project_id = @project_id;", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId); //add a value for the SQL parameter of @city_id in the query string above 

                SqlDataReader reader = cmd.ExecuteReader(); //runs the SQL query against the database

                if (reader.Read()) //if we can actually read the result set (no errors, data rows exist)
                {
                    project = CreateProjectFromReader(reader); //go create a city object from the results 
                }

            } //return the city object
            return project;
        }
        private Project CreateProjectFromReader(SqlDataReader reader)
        {
            Project projects = new Project();
            projects.ProjectId = Convert.ToInt32(reader["project_id"]);
            projects.Name = Convert.ToString(reader["name"]);
            projects.FromDate = Convert.ToDateTime(reader["from_date"]);
            projects.ToDate = Convert.ToDateTime(reader["to_date"]);



            return projects;
        }

        public IList<Project> GetAllProjects()
        {
            IList<Project> projects = new List<Project>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM project", conn);


                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Project project = CreateProjectFromReader(reader);
                    projects.Add(project);
                }
                return projects;
            }
            //  return new List<Project>();
        }

        public Project CreateProject(Project newProject)
        {
            {
                int newProjectId;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO project (name, from_date, to_date) " +
                                                    "OUTPUT INSERTED.project_id " +
                                                    "VALUES (@name, @from_date, @to_date);", conn);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@from_date", newProject.FromDate);
                    cmd.Parameters.AddWithValue("@to_date", newProject.ToDate);

                    newProjectId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return GetProject(newProjectId);
            }

        }
        public void DeleteProject(int projectId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM project_employee WHERE project_id = @project_id;", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("DELETE FROM timesheet WHERE project_id = @project_id;", conn);
                cmd2.Parameters.AddWithValue("@project_id", projectId);

                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("DELETE FROM project WHERE project_id = @project_id;", conn);
                cmd3.Parameters.AddWithValue("@project_id", projectId);

                cmd3.ExecuteNonQuery();
            }
            
          
              

            }

        }
    }






//      Project project = new Project();
//    project.ProjectId = Convert.ToInt32(reader["project_id"]);
//   project.Name = Convert.ToString(reader["name"]);
//     project.FromDate = Convert.ToDateTime(reader

//  return project;
//      }
//    }

