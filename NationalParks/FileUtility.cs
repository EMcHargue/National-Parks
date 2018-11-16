using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NationalParks
{
    class FileUtility
    {
        // Creates an array with all national parks

        public Park[] GetParks()
        {
            Park[] NationalParks = new Park[56];

            using (StreamReader str = new StreamReader("../../NationalParks.csv"))
            {
                str.ReadLine();

                for (var i = 0; i < 56; i++)
                {
                    string result;
                    List<string> park = new List<string>();

                    Park nationalPark = new Park();

                    result = str.ReadLine();
                    park = new List<string>(result.Split(','));

                    nationalPark.Name = park[1];
                    nationalPark.State = park[2];
                    nationalPark.Acres = int.Parse(park[3]);

                    NationalParks[i] = nationalPark;
                }
            }
            return NationalParks;
        }

        // Counts the number of parks in a Parks list of National Parks

        public int Count(Parks NationalParks)
        {
            int count = 0;
            foreach (Park element in NationalParks)
            {
                count++;
            }

            return count;
        }

        public void WriteParks(FileUtility fileUtility, Parks nationalParks1, Parks nationalParks2, string fileName)
        {
            string writeVisited = "n";
            string writeToVisit = "n";

            if (fileUtility.Count(nationalParks1) != 0)
            {
                Console.WriteLine("Do you want to save your list of visited National Parks?");
                Console.WriteLine("For Yes, type Y; for No, type N");
                writeVisited = Console.ReadLine();
            }

            if (fileUtility.Count(nationalParks2) != 0)
            {
                Console.WriteLine("Do you want to save your list of National Parks to visit?");
                Console.WriteLine("For Yes, type Y; for No, type N");
                writeToVisit = Console.ReadLine();
            }

            if (writeVisited.ToLower() == "y" || writeToVisit.ToLower() == "y")
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    if (writeVisited.ToLower() == "y")
                    {
                        sw.WriteLine("Parks you have visited:");
                        foreach (Park element in nationalParks1)
                        {
                            sw.WriteLine(element.Name);
                        }
                        sw.WriteLine("");
                    }


                    if (writeToVisit.ToLower() == "y")
                    {
                        sw.WriteLine("Parks you would like to visit:");
                        foreach (Park element in nationalParks2)
                        {
                            sw.WriteLine(element.Name);
                        }
                        sw.WriteLine("");
                    }
                }
            }
        }
    }
}
