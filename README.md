# National-Parks

National Parks is a program that, with two classes (Park and Parks) lets the user see data about United States national parks (states and number of acres) and create their own lists of parks the user has visited and parks the user wants to visit.  The data is compiled from a csv file obtained from https://public.opendatasoft.com/explore/dataset/national-parks/table/.

The Options presented from the main menu allow a user to:
1. View all national parks
2. View the largest 10 national parks in the United States
3. View the smallest 10 national parks in the United States
4. Look up park information by name; the program will display the states in which the park is located and the acres of the park
5. Create a list of parks that the user has visited.  This list will persist until the termination of the program.
6. Create a list of parks that the user wants to visit.  This list will also persist.

If a user enters a partial name in any of the park searches, the program can suggest the national park that the user may have meant using a LINQ query.

Upon exit from the program, if the user has created lists, the user has the option to save their lists to a .txt file.
