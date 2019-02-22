using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using Capstone.DAL;
using Capstone.Models;
using System;

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
            string park = "";
            string campground = "";
            DateTime arrivalDate = DateTime.MinValue;
            DateTime departureDate = DateTime.MinValue;
            List<Campsite> test = new List<Campsite>();
            ReservationSqlDAL reservationSqlDAL = new ReservationSqlDAL();
            test = reservationSqlDAL.SearchForReservation(park, campground, arrivalDate, departureDate);
        }

        [TestMethod]
        public void BookReservationTest()
        {

        }
    }
}
