using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;

namespace Capstone
{
    public class ParkReservationCLI
    {
        public void RunCLI()
        {
            PrintTitleScreen("View Parks Interface");
            Console.WriteLine("Select Park For Further Details");
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL();
            List<string> parks = parkSqlDAL.GetParkName();
            for (int i = 0; i < parks.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {parks[i]}");
            }
            Console.WriteLine("Q) Quit");
            bool validInput = false;
            string userInput = "";

            do
            {
                Console.Write("\nEnter choice (1, 2, 3, 4, Q): ");
                userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "Q")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                }
            } while (validInput == false);
            if (userInput == "1" || userInput == "2" || userInput == "3")
            {
                ParkMenu(parks[Convert.ToInt32(userInput) - 1]);       
            }            

            Console.ReadLine();
        }
        public void DisplayParkInformation(string name)
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL();
            Park park = parkSqlDAL.GetParkInfo(name);

            Console.WriteLine();
            PrintTitleScreen("Park Information Screen");
            Console.WriteLine("Name:".PadRight(17) + park.Name);
            Console.WriteLine("Location:".PadRight(17) + park.Location);
            Console.WriteLine("Established:".PadRight(17) + park.EstablishDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Area:".PadRight(17) + park.Area.ToString("N0") + (" acres"));
            Console.WriteLine("Annual Visitors:".PadRight(17) + park.AnnualVisitorCount.ToString("N0"));
            Console.WriteLine();
            Console.WriteLine(park.Description);

        }

        public void ViewCampgrounds(string name)
        {
            CampgroundSqlDAL campgroundSqlDAL = new CampgroundSqlDAL();

            List<Campground> campgrounds = campgroundSqlDAL.GetCampgrounds(name);
            Console.WriteLine();
            PrintTitleScreen(name + " Campgrounds");
            Console.WriteLine("".PadRight(5) + "name".PadRight(32) + "open".PadRight(11) + "close".PadRight(11) + "daily fee");

            for (int i = 0; i < campgrounds.Count; i++)
            {
                Console.WriteLine(i + 1 + ")".PadRight(5) +
                    campgrounds[i].Name.PadRight(32) +
                    campgrounds[i].OpenMonth.ToString().PadRight(11) +
                    campgrounds[i].ClosingMonth.ToString().PadRight(11) +
                    campgrounds[i].DailyFee.ToString("C2"));
            }
        }

        public void SearchForReservation(string name)
        {

        }

        public void PrintTitleScreen(string name)
        {
            string dashes = new string('-', name.Length + 2);
            Console.WriteLine(dashes);
            Console.WriteLine(" " + name);
            Console.WriteLine(dashes);
        }

        public void ParkMenu(string name)
        {
            DisplayParkInformation(name);
            Console.WriteLine("\nSelect a Command");
            Console.WriteLine("1) View Campgrounds");
            Console.WriteLine("2) Search for Reservation");
            Console.WriteLine("3) Return to Previous Screen");

            bool validInput = false;
            string userInput = "";

            do
            {
                Console.Write("\nEnter choice (1, 2, 3): ");
                userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "2" || userInput == "3")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input. Please try again.");
                }
            } while (validInput == false);
            switch (userInput)
            {
                case "1":
                    ViewCampgrounds(name);
                    break;

                case "2":
                    SearchForReservation(name);
                    break;

                case "3":
                    break;
            }

        }
    }
}