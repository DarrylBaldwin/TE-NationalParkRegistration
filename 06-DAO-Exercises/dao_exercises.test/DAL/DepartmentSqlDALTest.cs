using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;

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

            using(SqlConnection conn = new SqlConnection(connectionString))
            {

            }
        }
    }
}
