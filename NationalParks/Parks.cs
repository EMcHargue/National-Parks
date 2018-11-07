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

        public List<Park> GetParks()
        {
            List<Park> ParkList = new List<Park>();
            foreach (Park element in ListOfParks)
            {
                ParkList.Add(element);
            }
            return ParkList;
        }

        public void AddPark(Park NamedPark)
        {
            if (ListOfParks == null)
            {
                ListOfParks[0] = NamedPark;
            }
            else
            {
                ListOfParks.Add(NamedPark);
            }
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
    }
}
