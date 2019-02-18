using System;
using System.Collections.Generic;
using System.Text;
using dao_exercises.Models;
using System.Data.SqlClient;

namespace dao_exercises.DAL
{
    class DepartmentSqlDAL
    {
        private string connectionString;
        private const string SQL_GetDepartsment = "SELECT * FROM department";
        private const string SQL_CheckDepartment = "SELECT id FROM department WHERE name = @newDepartment;";
        private const string SQL_CreateDepartment = @"INSERT INTO department (name) VALUES (@newDepartment);";

        // Single Parameter Constructor
        public DepartmentSqlDAL(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        /// <summary>
        /// Returns a list of all of the departments.
        /// </summary>
        /// <returns></returns>
        public IList<Department> GetDepartments()
        {
            List<Department> result = new List<Department>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetDepartsment, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department tempdepartment = new Department();
                        tempdepartment.Id = Convert.ToInt32(reader["department_id"]);
                        tempdepartment.Name = Convert.ToString(reader["name"]);
                        result.Add(tempdepartment);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        /// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateDepartment);
                    cmd.Parameters.AddWithValue("@name", newDepartment.Name);

                    cmd = new SqlCommand(SQL_CheckDepartment);
                    cmd.Parameters.AddWithValue("@id", newDepartment.Name);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        newDepartment.Id = Convert.ToInt32(reader["department_id"]);
                    }
            }
            catch
            {
                throw;
            }

            return newDepartment.Id;
        }

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        /// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            throw new NotImplementedException();
        }

    }
}
