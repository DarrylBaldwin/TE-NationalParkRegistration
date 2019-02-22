using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone.Tests
{
    [TestClass]
    public class ReservationSQLDALTest
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
        public void SearchForReservationTest()
        {
            List<Reservation> test = new List<Reservation>();
            ReservationSqlDAL reservationSqlDAL = new ReservationSqlDAL();
            test = reservationSqlDAL.SearchForReservation(string park, string campground);
        }

        [TestMethod]
        public void BookReservationTest()
        {

        }
    }
}
