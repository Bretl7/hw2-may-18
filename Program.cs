// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace hw2_may_18
{
	public class Program
	{
		public static void PrintPlayerName(Player p)
		{
			Console.WriteLine("Player Name: " + p.Name);
		}

		public static void PrintPlayerNameAndEmailAndID(Player p)
        {
			Console.WriteLine("\nPlayer Name: " + p.Name + "\n" +
							  "Player Email: " + p.Email + "\n" +
							  "Player ID: " + p.Id);
        }

		public static void SearchByName(ArrayList a)
        {
			string searchName = "";
			Console.Write("Enter a name to search: ");
			searchName = Console.ReadLine().Trim();
			bool foundUser = false;
			for (int i = 0; i < a.Count; i++)
			{ 
				if (((Player)a[i]).Name == searchName)
                {
					((Player)a[i]).Print(PrintPlayerNameAndEmailAndID, ((Player)a[i]));
					foundUser = true;
				}
				if (i == (a.Count - 1) && !foundUser) Console.WriteLine("User " + "\'" + searchName +"\' does not exit");
            }
        }

		public static void PrintAllUsers(ArrayList a)
        {
			for (int i = 0; i < a.Count; i++)
            {
				((Player)a[i]).Print(PrintPlayerNameAndEmailAndID, ((Player)a[i]));
				Console.WriteLine("---------------------------");
			}
			Console.WriteLine("-------------End of List-------------");
		}

		public static void Main()
		{
			Console.Write("Welcome to Player creator. Please enter the number of players you would like to create (0 - 10): ");
			byte numOfPlayers = 0;
			string userEntry = Console.ReadLine();

			try
            {
				byte.TryParse(userEntry, out numOfPlayers);
				//numOfPlayers = Convert.ToByte(Console.ReadLine());
				//userEntry = Console.ReadLine();
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
			
			ArrayList arrListOfPlayers = new ArrayList();

			Console.WriteLine("Success! num of players = " + numOfPlayers);
			byte count = 0;
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
					Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
					Match match = regex.Match(userEmail);


					if (match.Success) isValidEmail = true;
					else Console.WriteLine("Invalid Email address, please enter valid email: ");
				}
				arrListOfPlayers.Add(new Player(userName, userEmail));
				
				count++;
			}



			bool isDone = false;
			while (!isDone)
            {
				Console.WriteLine("\nPlease choose one of the following options:\n" +
					"\ta - Search user by name\n" +
					"\tb - Print out all users' data\n" +
					"\tc - Terminate program");
				string choice = Console.ReadLine().Trim().ToLower();
				if (choice == "c") isDone = true;

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





			for (int i = 0; i < arrListOfPlayers.Count; i++)
            {
				//Console.WriteLine(((Player)arrListOfPlayers[i]).Name);
			}

			//p1.Name = "Bret";
			//p1.Print(PrintPlayerName, p1);
			//((Player)arrListOfPlayers[0]).Print(PrintPlayerNameAndEmailAndID, ((Player)arrListOfPlayers[0]));

			//Console.WriteLine("Player Name: " + arrListOfPlayers[0].getName() + " ID: " + arrListOfPlayers[0]);
		}
	}
}
