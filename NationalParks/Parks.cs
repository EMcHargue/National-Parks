using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalParks
{
    class Parks : IEnumerable
    {

        List<Park> ListOfParks = new List<Park>();

        public IEnumerator<Park> GetEnumerator()
        {
            return ListOfParks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ListOfParks.GetEnumerator();
        }

        // Selects park by name from list of parks (Parks)

        public Park GetParkByName(string Name)
        {
            Park park = new Park();
            bool match = false;
            while (match == false)
            {
                foreach (Park element in ListOfParks)
                {
                    if (Name.ToLower() == element.Name.ToLower())
                    {
                        park = element;
                        match = true;
                    }
                }
            }
            return park;
        }

        // Adds all Park elements to the current list of parks

        public List<Park> GetParks()
        {
            List<Park> ParkList = new List<Park>();
            foreach (Park element in ListOfParks)
            {
                ParkList.Add(element);
            }
            return ParkList;
        }

        // Adds Park to the list of parks

        public void AddPark(Park NamedPark)
        {
            if (ListOfParks == null)
            {
                ListOfParks = new List<Park>();
            }

            ListOfParks.Add(NamedPark);
        }

        public bool IsAPark(string Name)
        {
            bool isAPark = false;
            foreach (Park element in ListOfParks)
            {
                if (element.Name.ToLower() == Name.ToLower())
                {
                    isAPark = true;
                    break;
                }
            }
            return isAPark;
        }


        public List<Park> MaxAcres()
        {
            List<Park> BiggestParks = new List<Park>();
            for (var i = 0; i < 10; i++)
            {
                BiggestParks.Add(ListOfParks.OrderByDescending(y => y.Acres).ElementAt(i));
            }

            return BiggestParks;
        }

        public List<Park> MinAcres()
        {
            List<Park> SmallestParks = new List<Park>();
            for (var i = 0; i < 10; i++)
            {
                SmallestParks.Add(ListOfParks.OrderBy(y => y.Acres).ElementAt(i));
            }

            return SmallestParks;
        }

        // Creates list of National Parks based on partial entries

        public IEnumerable<Park> ListOfQueriedParks(string QueriedPark)
        {
            IEnumerable<Park> QueriedParks = new List<Park>();

            QueriedParks = from Park park in ListOfParks
                           where park.Name.ToLower().Contains(QueriedPark.ToLower())
                           select park;

            return QueriedParks;
        }

        public string SuggestAPark(IEnumerable QueriedParks)
        {
            Console.WriteLine("");
            Console.WriteLine("Did you mean:");
            Console.WriteLine("");
            foreach (Park element in QueriedParks)
            {
                Console.WriteLine(element.Name);
            }
            Console.WriteLine("");
            Console.WriteLine("Please type the name of your National Park");
            Console.WriteLine("");
            
            string name = Console.ReadLine();
            return name;


        }

        public void DisplayPark(Park park)
        {
            Console.WriteLine("");
            Console.WriteLine(park.Name + " is in " + park.State + ".");
            Console.WriteLine(park.Name + " has " + park.Acres + " acres.");
            Console.WriteLine("");
        }

    }
}
