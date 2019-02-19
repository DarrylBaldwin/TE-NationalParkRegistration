using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using dao_exercises.DAL;
using dao_exercises.Models;

namespace dao_exercises.test.DAL
{
    [TestClass()]
    public class EmployeeSqlDALTest
    {
        private TransactionScope tran;
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True";
        private int id;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                cmd = new SqlCommand("INSERT INTO employee (department_id, first_name, last_name, job_title, birth_date, gender, hire_date) VALUES (4, 'John', 'Fulton', 'Teacher', '1969-12-12', 'M', '1969-12-12')", conn);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()] 
        public void GetAllEmployeesTest()
        {
            EmployeeSqlDAL employee = new EmployeeSqlDAL(connectionString);
            IList<Employee> result = employee.GetAllEmployees();
            Assert.IsNotNull(result);

            bool areEqual = false;
            foreach (Employee id in result)
            {
                if (id.LastName == "Fulton") { areEqual = true; }
            }
            Assert.IsTrue(areEqual);
        }

        [TestMethod()]
        public void EmployeeSearchTest()
        {
            EmployeeSqlDAL employee = new EmployeeSqlDAL(connectionString);
            IList<Employee> restul = employee.Search("John", "Fulton");
            Assert.IsNotNull(restul);
        }

        [TestMethod()]
        public void EmployeeWithoutProjectTest()
        {
            EmployeeSqlDAL employee = new EmployeeSqlDAL(connectionString);
            IList<Employee> restul = employee.GetEmployeesWithoutProjects();
            Assert.IsNotNull(restul);

            bool test = false;
            foreach (Employee id in restul)
            {
                if (id.FirstName == "John")
                {
                    test = true;
                }
            }
            Assert.IsTrue(test);
        }
    }
}
