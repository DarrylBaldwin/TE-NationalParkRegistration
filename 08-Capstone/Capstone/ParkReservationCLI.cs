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
            Console.WriteLine("Q) quit");
            bool validInput = false;

            do
            {
                Console.WriteLine("Enter choice");
            } while (validInput == false);
            Console.ReadLine();
        }
    }
}
