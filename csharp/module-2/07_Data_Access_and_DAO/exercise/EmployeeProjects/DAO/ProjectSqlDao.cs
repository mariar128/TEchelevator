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
            return new Project(0, "Not Implemented Yet", DateTime.Now, DateTime.Now.AddDays(1));
        }

        public IList<Project> GetAllProjects()
        {
            return new List<Project>();
        }

        public Project CreateProject(Project newProject)
        {
            return null;
        }

        public void DeleteProject(int projectId)
        {

        }

    }
}
