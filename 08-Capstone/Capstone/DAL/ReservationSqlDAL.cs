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
            @"SELECT site.*, campground.daily_fee
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

        public const string SQL_MakeReservation = "INSERT INTO reservation (site_id, name, from_date, to_date, create_date) VALUES (@site_id, @name, @arrivalDate, @departureDate, @create_date); SELECT CAST(SCOPE_IDENTITY() as int);";

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
                        campsite.SiteNumber = Convert.ToInt32(reader["site_number"]);
                        campsite.MaxOccupancy = Convert.ToInt32(reader["max_occupancy"]);
                        campsite.Accessible = Convert.ToByte(reader["accessible"]);
                        campsite.MaxRvLength = Convert.ToInt32(reader["max_rv_length"]);
                        campsite.Utilities = Convert.ToByte(reader["utilities"]);
                        campsite.DailyFee = Convert.ToDecimal(reader["daily_fee"]);
                        campsites.Add(campsite);
                    }
                }
            }
            catch
            {

            }

            return campsites;
        }

        public int MakeReservation(string name, int campsiteId, DateTime arrivalDate, DateTime departureDate)
        {
            int reservationId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    SqlCommand cmd = new SqlCommand(SQL_MakeReservation, conn);
                    cmd.Parameters.AddWithValue("@site_id", campsiteId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    cmd.Parameters.AddWithValue("@departureDate", departureDate);
                    cmd.Parameters.AddWithValue("@create_date", System.DateTime.Now);
                    reservationId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch
            {
                
            }

            return reservationId;
        }
    }
}
