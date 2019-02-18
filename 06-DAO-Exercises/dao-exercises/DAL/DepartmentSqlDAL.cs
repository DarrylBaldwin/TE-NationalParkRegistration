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
        private const string SQL_GetDepartments = "SELECT * FROM department";
        private const string SQL_UpdateDepartment = @"UPDATE department SET name = (@name) WHERE department_id = (@department_id)";
        private const string SQL_CreateDepartment = @"INSERT INTO department (name) VALUES (@name)";

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
                    SqlCommand cmd = new SqlCommand(SQL_GetDepartments, connection);
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
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Creates a new department.
        /// </summary>
        ///// <param name="newDepartment">The department object.</param>
        /// <returns>The id of the new department (if successful).</returns>
        public int CreateDepartment(Department newDepartment)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_CreateDepartment, connection);
                    cmd.Parameters.AddWithValue("@department_id", newDepartment.Id);
                    cmd.Parameters.AddWithValue("@name", newDepartment.Name);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = 1;
                    }

                    //cmd = new SqlCommand(SQL_CheckDepartment);
                    //cmd.Parameters.AddWithValue("@id", newDepartment.Name);
                    //SqlDataReader reader = cmd.ExecuteReader();

                    //while (reader.Read())
                    //{
                    //    newDepartment.Id = Convert.ToInt32(reader["department_id"]);
                    //}
                    //result = newDepartment.Id;
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

        /// <summary>
        /// Updates an existing department.
        /// </summary>
        ///// <param name="updatedDepartment">The department object.</param>
        /// <returns>True, if successful.</returns>
        public bool UpdateDepartment(Department updatedDepartment)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_UpdateDepartment, conn);
                    cmd.Parameters.AddWithValue("@department_id", updatedDepartment.Id);
                    cmd.Parameters.AddWithValue("@name", updatedDepartment.Name);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }


            }
            catch (SqlException ex)
            {

                throw;
            }
            return result;
        }

    }
}
