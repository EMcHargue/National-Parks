using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NationalParks
{
    class Program
    {
        static void Main(string[] args)
        {
            FileUtility fileUtility = new FileUtility();

            //Creates array of Parks with all National Parks available

            Parks AllTheParks = new Parks();
            Park[] ParkArray = new Park[56];
            ParkArray = fileUtility.GetParks();

            Parks VisitedParks = new Parks();
            Parks ParksToVisit = new Parks();


            foreach (Park element in ParkArray)
            {
                AllTheParks.AddPark(element);
            }

            bool clear = true;

            while (clear)
            {

                Console.WriteLine("National Parks");
                Console.WriteLine("");
                Console.WriteLine("Option 0: Test");
                Console.WriteLine("Option 1: View a list of all the National Parks");
                Console.WriteLine("Option 2: View the largest 10 National Parks");
                Console.WriteLine("Option 3: View the smallest 10 National Parks");
                Console.WriteLine("Option 4: Find information about a National Park by name");
                Console.WriteLine("Option 5: Build a list of National Parks you've visited");
                Console.WriteLine("Option 6: Build a list of National Parks you would like to visit");
                Console.WriteLine("Type 'quit' to exit program");
                Console.WriteLine("");

                string option = Console.ReadLine();


                if (option.ToLower() == "quit")
                {
                    Console.Clear();
                    bool visited = false;
                    bool toVisit = false;

                    int visitedCount = fileUtility.Count(VisitedParks);
                    int toVisitCount = fileUtility.Count(ParksToVisit);

                    if (visitedCount != 0)
                    {
                        Console.WriteLine("Do you want to save your list of visited National Parks?");
                        Console.WriteLine("For Yes, type Y; for No, type N");
                        string write = Console.ReadLine();

                        if (write.ToLower() == "y")
                        {
                            visited = true;
                        }
                    }

                    if (toVisitCount != 0)
                    {
                        Console.WriteLine("Do you want to save your list of National Parks to visit?");
                        Console.WriteLine("For Yes, type Y; for No, type N");
                        string write = Console.ReadLine();

                        if (write.ToLower() == "y")
                        {
                            toVisit = true;
                        }
                    }

                    if (visited || toVisit)
                    {
                        Console.WriteLine("What is your name?");
                        string fileName = Console.ReadLine() + "'s-National-Parks.txt";

                        fileUtility.WriteParks(fileUtility, VisitedParks, ParksToVisit, fileName);
                        
                    }


                    clear = false;

                }
                else if (option == "1")
                {

                    foreach (Park element in AllTheParks)
                    {
                        Console.WriteLine(element.Name);
                    }
                    Console.WriteLine("To return to the menu, press any key");
                    string returnKey = Console.ReadLine();
                    Console.Clear();
                }
                if (option == "2")
                {
                    List<Park> BiggestParks = new List<Park>();
                    BiggestParks = AllTheParks.MaxAcres();

                    foreach (Park element in BiggestParks)
                    {
                        Console.WriteLine(element.Name + ", with ");
                        Console.WriteLine(element.Acres + " acres");
                    }

                    Console.WriteLine("To return to the menu, press any key");
                    string returnKey = Console.ReadLine();
                    Console.Clear();
                }
                if (option == "3")
                {
                    List<Park> SmallestParks = new List<Park>();
                    SmallestParks = AllTheParks.MinAcres();

                    foreach (Park element in SmallestParks)
                    {
                        Console.WriteLine(element.Name + ", with ");
                        Console.WriteLine(element.Acres + " acres");
                    }

                    Console.WriteLine("To return to the menu, press any key");
                    string returnKey = Console.ReadLine();
                    Console.Clear();
                }
                if (option == "4")
                {
                    string name = "";

                    while (name.ToLower() != "back")
                    {
                        Console.WriteLine("What is the name of the National Park you are looking for?");
                        Console.WriteLine("To go back to the menu, type 'back'");
                        name = Console.ReadLine();

                        Park namedPark = new Park();



                        if (name != null)
                        {
                            // Creates list of Parks that contain the name string 
                            // for partial entries

                            IEnumerable<Park> QueriedParks = AllTheParks.ListOfQueriedParks(name);

                            if (AllTheParks.IsAPark(name.ToLower()))
                            {
                                namedPark = AllTheParks.GetParkByName(name);
                                Console.WriteLine("");
                                Console.WriteLine(namedPark.Name + " is in " + namedPark.State + ".");
                                Console.WriteLine(namedPark.Name + " has " + namedPark.Acres + " acres.");
                                Console.WriteLine("");
                            }

                            // Suggests park names based on partial entries

                            else if (QueriedParks.Count() != 0)
                            {
                                string correctName = AllTheParks.SuggestAPark(QueriedParks);

                                if (AllTheParks.IsAPark(correctName))
                                {
                                    namedPark = AllTheParks.GetParkByName(correctName);

                                    AllTheParks.DisplayPark(namedPark);
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("That is not a National Park");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.WriteLine("That is not a National Park");
                                Console.WriteLine("");
                            }
                        }
                    }

                    Console.Clear();

                }
                if (option == "5")
                {
                    string name = "";
                    bool back = true;

                    Console.WriteLine("What parks have you visited?");
                    Console.WriteLine("To go back to the menu, type 'back'");

                    while (back)
                    {
                        Park park = new Park();

                        name = Console.ReadLine();

                        if (name == "back")
                        {
                            back = false;
                        }
                        else if (name.ToLower() == "view")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You have visited:");

                            List<Park> ListOfParks = VisitedParks.GetParks();

                            foreach (Park element in ListOfParks)
                            {
                                Console.WriteLine(element.Name);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                            Console.WriteLine("");
                        }
                        else if (name != null)
                        {
                            if (VisitedParks.IsAPark(name))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("That National Park is already in your list");
                                Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                Console.WriteLine("");
                            }

                            else if (!AllTheParks.IsAPark(name))
                            {
                                IEnumerable<Park> QueriedParks = AllTheParks.ListOfQueriedParks(name);

                                if (QueriedParks.Count() != 0)
                                {
                                    string correctName = AllTheParks.SuggestAPark(QueriedParks);

                                    if (AllTheParks.IsAPark(correctName))
                                    {
                                        Park namedPark = AllTheParks.GetParkByName(correctName);

                                        if (VisitedParks.IsAPark(correctName))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("That National Park is already in your list");
                                            Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                            Console.WriteLine("");
                                        }
                                        else
                                        {
                                            VisitedParks.AddPark(namedPark);
                                            Console.WriteLine("");
                                            Console.WriteLine("Add another National Park");
                                            Console.WriteLine("to view your list of visited National Parks, type 'view'");
                                            Console.WriteLine("or type 'back' to go back to the menu");
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("That is not a National Park");
                                        Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");

                                        Console.WriteLine("");
                                    }
                                    
                                }
                                else
                                { 
                                    Console.WriteLine("");
                                    Console.WriteLine("That is not a National Park.");
                                    Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Park namedPark = AllTheParks.GetParkByName(name);

                                VisitedParks.AddPark(namedPark);
                                Console.WriteLine("");
                                Console.WriteLine("Add another National Park");
                                Console.WriteLine("to view your list of visited National Parks, type 'view'");
                                Console.WriteLine("or type 'back' to go back to the menu");
                                Console.WriteLine("");
                            }
                        }
                    }

                    Console.Clear();
                    
                }
                if (option == "6")
                {
                    string name = "";
                    bool back = true;

                    Console.WriteLine("What parks would you like to visit?");
                    Console.WriteLine("To go back to the menu, type 'back'");

                    while (back)
                    {
                        Park park = new Park();

                        name = Console.ReadLine();

                        if (name == "back")
                        {
                            back = false;
                        }
                        else if (name.ToLower() == "view")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You would like to visit:");

                            List<Park> ListOfParks = ParksToVisit.GetParks();

                            foreach (Park element in ListOfParks)
                            {
                                Console.WriteLine(element.Name);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                            Console.WriteLine("");
                        }
                        else if (name != null)
                        {
                            if (ParksToVisit.IsAPark(name))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("That National Park is already in your list");
                                Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                Console.WriteLine("");
                            }

                            else if (!AllTheParks.IsAPark(name))
                            {
                                IEnumerable<Park> QueriedParks = AllTheParks.ListOfQueriedParks(name);

                                if (QueriedParks.Count() != 0)
                                {
                                    string correctName = AllTheParks.SuggestAPark(QueriedParks);

                                    if (AllTheParks.IsAPark(correctName))
                                    {
                                        Park namedPark = AllTheParks.GetParkByName(correctName);

                                        if (ParksToVisit.IsAPark(correctName))
                                        {
                                            Console.WriteLine("");
                                            Console.WriteLine("That National Park is already in your list");
                                            Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                            Console.WriteLine("");
                                        }
                                        else
                                        {
                                            ParksToVisit.AddPark(namedPark);
                                            Console.WriteLine("");
                                            Console.WriteLine("Add another National Park");
                                            Console.WriteLine("to view your list of National Parks to visit, type 'view'");
                                            Console.WriteLine("or type 'back' to go back to the menu");
                                            Console.WriteLine("");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("That is not a National Park");
                                        Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");

                                        Console.WriteLine("");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine("That is not a National Park.");
                                    Console.WriteLine("Enter another National Park, or type 'back' to return to the menu");
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Park namedPark = AllTheParks.GetParkByName(name);

                                ParksToVisit.AddPark(namedPark);
                                Console.WriteLine("");
                                Console.WriteLine("Add another National Park");
                                Console.WriteLine("to view your list of visited National Parks, type 'view'");
                                Console.WriteLine("or type 'back' to go back to the menu");
                                Console.WriteLine("");
                            }
                        }
                    }

                    Console.Clear();

                }
            }
        }
    }
}
