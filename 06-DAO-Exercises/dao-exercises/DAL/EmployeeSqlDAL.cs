using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using dao_exercises.Models;

namespace dao_exercises.DAL
{
    class EmployeeSqlDAL
    {
        private string connectionString;
        private const string SQL_GetEmployees = "SELECT * FROM employee";
        private const string SQL_FindEmployees = "SELECT * FROM employee WHERE first_name LIKE @firstname AND last_name LIKE @lastname";
<<<<<<< HEAD
        private const string SQL_EmployeesNoProjects = @"SELECT first_name, last_name FROM project_employee RIGHT JOIN employee ON employee.employee_id = project_employee.employee_id WHERE employee.employee_id IS NULL";
=======
        private const string SQL_EmployeesNoProjects = @"SELECT employee.employee_id, employee.first_name, employee.last_name, employee.job_title, employee.birth_date, employee.gender FROM project_employee RIGHT JOIN employee ON employee.employee_id = project_employee.employee_id WHERE project_employee.project_id IS NULL";
>>>>>>> ef7fef28443724a4b826c779d3239952a64bdba4

        // Single Parameter Constructor
        public EmployeeSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        public IList<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetEmployees, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempemployee = new Employee();
                        tempemployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempemployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempemployee.LastName = Convert.ToString(reader["last_name"]);
                        tempemployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempemployee.Gender = Convert.ToString(reader["gender"]);
                        tempemployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        result.Add(tempemployee);
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
        /// Searches the system for an employee by first name or last name.
        /// </summary>
        /// <remarks>The search performed is a wildcard search.</remarks>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns>A list of employees that match the search.</returns>
        public IList<Employee> Search(string firstname, string lastname)
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_FindEmployees, connection);
                    cmd.Parameters.AddWithValue("@firstname", "%" + firstname + "%");
                    cmd.Parameters.AddWithValue("@lastname", "%" + lastname + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempemployee = new Employee();
                        tempemployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempemployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempemployee.LastName = Convert.ToString(reader["last_name"]);
                        tempemployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempemployee.Gender = Convert.ToString(reader["gender"]);
                        tempemployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        result.Add(tempemployee);
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
        /// Gets a list of employees who are not assigned to any active projects.
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetEmployeesWithoutProjects()
        {
            List<Employee> result = new List<Employee>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_EmployeesNoProjects, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee tempemployee = new Employee();
                        tempemployee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
                        tempemployee.FirstName = Convert.ToString(reader["first_name"]);
                        tempemployee.LastName = Convert.ToString(reader["last_name"]);
                        tempemployee.JobTitle = Convert.ToString(reader["job_title"]);
                        tempemployee.Gender = Convert.ToString(reader["gender"]);
                        tempemployee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
                        result.Add(tempemployee);
                    }
                }
            }

            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
