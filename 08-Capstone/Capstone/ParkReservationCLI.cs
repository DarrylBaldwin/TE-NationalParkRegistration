using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;

namespace Capstone
{
    public class ParkReservationCLI
    {
        public void RunCLI()
        {
            Console.WriteLine("View Parks Interface");
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
                Console.WriteLine("\nEnter choice (1, 2, 3, 4, Q)");
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
            DisplayParkInformation(parks[Convert.ToInt32(userInput)]);           
            }            

            switch (userInput)
            {
                case "1":
                    ViewCampgroundsMethod();
                    break;
                

                default:
                    break;
            }
            Console.ReadLine();
        }
        public void DisplayParkInformation(string name)
        {
            ParkSqlDAL parkSqlDAL = new ParkSqlDAL();
            parkSqlDAL.GetParkInfo(name);

        }

        public void ViewCampgroundsMethod()
        {

        }
    }
}
