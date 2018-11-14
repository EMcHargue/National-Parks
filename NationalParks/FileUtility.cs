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

        public int Count(Parks NationalParks)
        {
            int count = 0;
            foreach (Park element in NationalParks)
            {
                count++;
            }

            return count;
        }

        public void WriteParksVisited(Parks nationalParks, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Parks you have visited:");
                foreach (Park element in nationalParks)
                {
                    sw.WriteLine(element.Name);
                }
                sw.WriteLine("");
            }

        }

        public void WriteParks(FileUtility fileUtility, Parks nationalParks1, Parks nationalParks2, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                if (fileUtility.Count(nationalParks1) != 0)
                {
                    Console.WriteLine("Do you want to save your list of visited National Parks?");
                    Console.WriteLine("For Yes, type Y; for No, type N");
                    string write = Console.ReadLine();

                    if (write.ToLower() == "y")
                    {
                        sw.WriteLine("Parks you have visited:");
                        foreach (Park element in nationalParks1)
                        {
                            sw.WriteLine(element.Name);
                        }
                        sw.WriteLine("");
                    }
                    
                }

                if (fileUtility.Count(nationalParks2) != 0)
                {
                    Console.WriteLine("Do you want to save your list of National Parks to visit?");
                    Console.WriteLine("For Yes, type Y; for No, type N");
                    string write = Console.ReadLine();

                    if (write.ToLower() == "y")
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
