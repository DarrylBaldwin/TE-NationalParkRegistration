using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ParkSQLDALTest
    {

        //// Define scope
        //TransactionScope transaction;
        //private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=world;Integrated Security=True";

        //[TestInitialize]
        //public void Initialize()
        //{

        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    transaction.Dispose();

        //}


        [TestMethod]
        public void GetParkName()
        {
            List<string> test = new List<string>();
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL();
            test = parkSqlDAL.GetParkName();
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void GetParkInfoTest()
        {
            List<Park> parks = new List<Park>();
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL();
            parks = parkSqlDAL.GetParkInfo("Acadia");
            Assert.IsNotNull(parks);
            
        }
    }
}
