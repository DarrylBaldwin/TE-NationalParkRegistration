using System;
using System.Collections.Generic;
using System.Text;
using dao_exercises.Models;
using System.Data.SqlClient;


namespace dao_exercises.DAL
{
    public class ProjectSqlDAL
    {
        private string connectionString;
        private const string SQL_GetAllProjects = ("SELECT * FROM project");
        private const string SQL_CreateProject = ("INSERT INTO project (name, from_date, to_date) VALUES (@name, @from_date, @to_date)");
        private const string SQL_AssignEmployeetoProject = ("INSERT INTO project_employee (project_id, employee_id) VALUES (@project_id, @employee_id);");
        private const string SQL_RemoveEmployeetoProject = ("DELETE FROM project_employee WHERE project_id = @project_id AND employee_id = @employee_id;");

        // Single Parameter Constructor
        public ProjectSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns all projects.
        /// </summary>
        /// <returns></returns>
        public IList<Project> GetAllProjects()
        {
            List<Project> result = new List<Project>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetAllProjects, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project tempproject = new Project();
                        tempproject.ProjectId = Convert.ToInt32(reader["project_id"]);
                        tempproject.Name = Convert.ToString(reader["name"]);
                        tempproject.StartDate = Convert.ToDateTime(reader["from_date"]);
                        tempproject.EndDate = Convert.ToDateTime(reader["to_date"]);
                        result.Add(tempproject);
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Assigns an employee to a project using their IDs.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool AssignEmployeeToProject(int projectId, int employeeId)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_AssignEmployeetoProject, conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.ExecuteNonQuery();

                    result = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Removes an employee from a project.
        /// </summary>
        /// <param name="projectId">The project's id.</param>
        /// <param name="employeeId">The employee's id.</param>
        /// <returns>If it was successful.</returns>
        public bool RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_RemoveEmployeetoProject, connection);
                    cmd.Parameters.AddWithValue("@project_id", projectId);
                    cmd.Parameters.AddWithValue("@employee_id", employeeId);
                    cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Creates a new project.
        /// </summary>
        /// <param name="newProject">The new project object.</param>
        /// <returns>The new id of the project.</returns>
        public int CreateProject(Project newProject)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateProject, connection);
                    cmd.Parameters.AddWithValue("@project_id", newProject.ProjectId);
                    cmd.Parameters.AddWithValue("@name", newProject.Name);
                    cmd.Parameters.AddWithValue("@from_date", newProject.StartDate);
                    cmd.Parameters.AddWithValue("@to_date", newProject.EndDate);
                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw;
            }

            return result;
        }

    }
}
