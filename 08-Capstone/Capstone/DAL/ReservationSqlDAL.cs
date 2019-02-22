using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAL
{
    public class ReservationSqlDAL
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = NationalParkReservation; Integrated Security = True";
        private const string SQL_SearchForReservation =
            @"SELECT site.*
            FROM site
            JOIN campground
            ON site.campground_id = campground.campground_id
            JOIN park
            ON campground.park_id = park.park_id
            WHERE park.name = @park AND campground.name = @campground AND site.site_id NOT IN (
            SELECT reservation.site_id
            FROM reservation
            JOIN site
            ON reservation.site_id = site.site_id
            JOIN campground
            ON site.campground_id = campground.campground_id
            JOIN park
            ON campground.park_id = park.park_id
            WHERE park.name = @park AND campground.name = @campground AND reservation.from_date <= @arrivalDate AND reservation.to_date >= @departureDate); ";

        public List<Campsite> SearchForReservation(string park, string campground, DateTime arrivalDate, DateTime departureDate)
        {
            List<Campsite> campsites = new List<Campsite>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   SqlCommand cmd = new SqlCommand(SQL_SearchForReservation, conn);
                    cmd.Parameters.AddWithValue("@park", park);
                    cmd.Parameters.AddWithValue("@campground", campground);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.Parameters.AddWithValue("@departureDate", departureDate);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Campsite campsite = new Campsite();
                        campsite.CampsiteId = 
                        campsite.name = 
                        campsite.CampsiteId = 
                        campsite.CampsiteId = 
                        campsite.CampsiteId =

                    }
                }
            }
            catch
            {

            }

            return campsites;
        }
    }
}
