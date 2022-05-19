// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace hw2_may_18
{
	/// <summary>
	/// This Class Program contains the Main method,
	/// as well as local methods created by developer,
	/// that drive the console app
	/// </summary>
	public class Program
	{
		/// <summary>
		/// This method uses a delegate in Player.cs file to
		/// print the name of the instance of the Player sent
		/// to this method
		/// </summary>
		/// <param name="p"></param>
		public static void PrintPlayerName(Player p)
		{
			Console.WriteLine("Player Name: " + p.Name);
		}

		/// <summary>
		/// This method uses a delegate in Player.cs file to
		/// print the name, email and ID of the instance of
		/// the Player sent to this method
		/// </summary>
		/// <param name="p"></param>
		public static void PrintPlayerNameAndEmailAndID(Player p)
        {
			Console.WriteLine("\nPlayer Name: " + p.Name + "\n" +
							  "Player Email: " + p.Email + "\n" +
							  "Player ID: " + p.Id);
        }

		/// <summary>
		/// This method uses a delegate in Player.cs
		/// to search for a name (entered by the user)
		/// </summary>
		/// <param name="a"></param>
		public static void SearchByName(ArrayList a)
        {
			string searchName = "";
			Console.Write("Enter a name to search: ");
			searchName = Console.ReadLine().Trim(); // Trims off exterior whitespaces, if any
			bool foundUser = false;
			// This for loop traverses through all Players in the ArrayList and
			// prints out any Player info that matches with the name provided by the user
			for (int i = 0; i < a.Count; i++)
			{ 
				if (((Player)a[i]).Name == searchName)
                {
					((Player)a[i]).Print(PrintPlayerNameAndEmailAndID, ((Player)a[i]));
					foundUser = true;
				}
				// This if statement is executed if at end of ArrayList and a user's name is not found
				if (i == (a.Count - 1) && !foundUser) Console.WriteLine("User " + "\'" + searchName +"\' does not exit");
            }
        }

		/// <summary>
		/// This method calls the PrintPlayerNameAndEmailAndID
		/// method in order to print out every user's name,
		/// email and ID
		/// </summary>
		/// <param name="a"></param>
		public static void PrintAllUsers(ArrayList a)
        {
			for (int i = 0; i < a.Count; i++)
            {
				((Player)a[i]).Print(PrintPlayerNameAndEmailAndID, ((Player)a[i]));
				Console.WriteLine("---------------------------");
			}
			Console.WriteLine("-------------End of List-------------");
		}

		/// <summary>
		/// This is the Main method that executes the
		/// program
		/// </summary>
		public static void Main()
		{
			Console.Write("Welcome to Player creator. Please enter the number of players you would like to create (0 - 10): ");
			byte numOfPlayers = 0;
			string userEntry = Console.ReadLine(); // User enters a number between 1-10 (hopefully)

			// This try/catch block ensures that the user enters a number between 1-10 only.
			// It will keep prompting the user until the requirements are met
			try
            {
				byte.TryParse(userEntry, out numOfPlayers); // This will try to parse the string into a number and store it in numOfPlayers
				
				// The while loop will keep prompting user to enter number between 1-10 until requirements met
				while (numOfPlayers < 1 || numOfPlayers > 10 || !byte.TryParse(userEntry, out numOfPlayers)) 
				{
					Console.WriteLine("An error occured in TRY, please ensure you enter a number between 1 and 10");
					userEntry = Console.ReadLine();
					byte.TryParse(userEntry, out numOfPlayers);
				}
			}
			catch (Exception e)
            {
				Console.WriteLine("An error occured, please ensure you enter a number between 1 and 10");
				numOfPlayers = 0;
				userEntry = Console.ReadLine();
				while (numOfPlayers < 1 && numOfPlayers > 10 && byte.TryParse(userEntry, out numOfPlayers))
                {
					Console.WriteLine("An error occured, please ensure you enter a number between 1 and 10");
					userEntry = Console.ReadLine();
					byte.TryParse(userEntry, out numOfPlayers);
				}
            }
			
			// Creating a ArrayList of Players instead of using a regular array
			ArrayList arrListOfPlayers = new ArrayList();

			Console.WriteLine("Success! num of players = " + numOfPlayers);

			byte count = 0;
			// This loop will prompt user to enter in email address for a player.
			// It will keep prompting user to enter emial until valid
			while (count < numOfPlayers)
            {
				bool isValidEmail = false;
				string userName = "";
				string userEmail = "";
				Console.Write("Please enter a name for Player " + (count + 1) + ": ");
				userName = Console.ReadLine();
                
				Console.Write("Please enter an email for Player " + (count + 1) + ": ");
				while (!isValidEmail)
                {
					isValidEmail = false;
					
					userEmail = Console.ReadLine();
					Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); // Ensures '@[a-z].com' is included
					Match match = regex.Match(userEmail);


					if (match.Success) isValidEmail = true;
					else Console.WriteLine("Invalid Email address, please enter valid email: ");
				}
				arrListOfPlayers.Add(new Player(userName, userEmail));
				
				count++;
			}



			bool isDone = false;
			// This loop will prompt the user for three actions:
			// a - Search player by name and prints out that player's info,
			// b - Print out every player's info to the console,
			// c - exit program
			// If none of these are selected, the it will prompt the user to enter valid option
			while (!isDone)
            {
				Console.WriteLine("\nPlease choose one of the following options:\n" +
					"\ta - Search Player by name\n" +
					"\tb - Print out all Players' data\n" +
					"\tc - Terminate program");
				string choice = Console.ReadLine().Trim().ToLower();
				if (choice == "c") isDone = true;

				// Options for user
				switch(choice)
                {
					case "a":
						SearchByName(arrListOfPlayers);
						break;
					case "b":
						PrintAllUsers(arrListOfPlayers);
						break;
					case "c":
						isDone = true;
						Console.WriteLine("-----------End of Program-----------");
						break;
					default:
						Console.WriteLine("Invalid entry...");
						break;
                }

            }


			//p1.Name = "Bret";
			//p1.Print(PrintPlayerName, p1);
			//((Player)arrListOfPlayers[0]).Print(PrintPlayerNameAndEmailAndID, ((Player)arrListOfPlayers[0]));

			//Console.WriteLine("Player Name: " + arrListOfPlayers[0].getName() + " ID: " + arrListOfPlayers[0]);
		}
	}
}
