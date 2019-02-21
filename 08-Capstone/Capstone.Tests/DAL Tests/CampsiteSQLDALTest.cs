using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class CampsiteSQLDALTest
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
        public void GetCampsiteIntoTest()
        {
            //get list of campsites in campground in park to user
        }
    }
}
