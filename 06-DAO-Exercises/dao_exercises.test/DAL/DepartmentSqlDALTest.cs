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
    public class DepartmentSqlDALTest
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

                cmd = new SqlCommand("INSERT INTO department (name) VALUES ('TestDepartment'); SELECT CAST(SCOPE_IDENTITY() as int)", conn);
                id = (int)cmd.ExecuteScalar();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void GetDepartmentsTest()
        {
            DepartmentSqlDAL departmentDAL = new DepartmentSqlDAL(connectionString);

            IList<Department> departments = departmentDAL.GetDepartments();

            Assert.IsNotNull(departments);
            bool areEqual = false;
            foreach (Department id in departments)
            {
                if (id.Name == "TestDepartment") { areEqual = true; }
            }
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod()]
        public void CreateDepartmentTest()
        {
            DepartmentSqlDAL departmentDAL = new DepartmentSqlDAL(connectionString);
            Department department = new Department();
            department.Name = "Brand New Dept";
            int otherID = departmentDAL.CreateDepartment(department);

            Assert.AreEqual(id + 1, otherID);
        }

        [TestMethod()]
        public void UpdateDepartmentTest()
        {
            DepartmentSqlDAL departmentSqlDAL = new DepartmentSqlDAL(connectionString);
            Department department = new Department();
            department.Name = "TestDepartment";
            department.Id = id;
            bool result = departmentSqlDAL.UpdateDepartment(department);
            Assert.AreEqual(true, result);
        }
    }
}
