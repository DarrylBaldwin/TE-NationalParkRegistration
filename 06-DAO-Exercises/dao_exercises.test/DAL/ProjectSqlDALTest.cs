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
    public class ProjectSqlDALTest
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

                cmd = new SqlCommand("INSERT INTO project (name, from_date, to_date) VALUES ('tech_elevator', '1776-07-04', '2077-01-01')", conn);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("INSERT INTO employee (department_id, first_name, last_name, job_title, birth_date, gender, hire_date) VALUES (4, 'John', 'Fulton', 'Teacher', '1969-12-12', 'M', '1969-12-12')", conn);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void GetAllProjectsTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);
            IList<Project> result = projectSqlDAL.GetAllProjects();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AssignEmployeeToProjectTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);
            bool result = projectSqlDAL.AssignEmployeeToProject(5, 2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void RemoveEmployeeFromProjectTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);
            bool result = projectSqlDAL.RemoveEmployeeFromProject(5,2);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void CreateProjecTest()
        {
            ProjectSqlDAL projectSqlDAL = new ProjectSqlDAL(connectionString);
            Project temp = new Project();
            temp.Name = "temp_project";
            temp.ProjectId = 24;
            temp.StartDate = System.DateTime.Now;
            temp.EndDate = System.DateTime.Now;
            int stupid = projectSqlDAL.CreateProject(temp);
            Assert.IsTrue(stupid > 0);
        }
    }
}
