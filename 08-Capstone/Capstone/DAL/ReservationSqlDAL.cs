﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ReservationSqlDAL
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = NationalParkReservation; Integrated Security = True";
        private const string SQL_SearchForReservation = "";

        public List<Campsite> SearchForReservation(string park, string campground, DateTime arrivalDate, DateTime departureDate)
        {
            List<Campsite> campsites = new List<Campsite>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   SqlCommand cmd = new SqlCommand(SQL_SearchForReservation, conn);

                }
            }
            catch
            {

            }

            return campsites;
        }
    }
}
