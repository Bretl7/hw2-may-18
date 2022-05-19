using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_may_18
{
	/// <summary>
	/// Class Player inherits IPlayer Interface
	/// that Program.cs uses to access Player.cs
	/// </summary>
	public class Player : IPlayer
	{
		private readonly Guid _id = Guid.NewGuid();
		private string _name;
		private string _email;

		/// <summary>
		/// Non-default constrctor that sets Name and Email to
		/// an empty string...takes no parameters
		/// </summary>
		public Player()
		{
			_name = "";
			_email = "";
		}

		/// <summary>
		/// Non-default constructor that takes a user's entered name
		/// and email address and stores it in the corresponding
		/// fields of the class
		/// </summary>
		/// <param name="name"></param>
		/// <param name="email"></param>
		public Player(string name, string email)
		{ _name = name;
			_email = email;
		}

		/// <summary>
		/// This method uses the Iplayer interface method Id
		/// to only return a player's ID at the user's request
		/// </summary>
		public Guid Id { get { return _id; } }

		/// <summary>
		/// This method uses the Iplayer interface method Name
		/// to return a player's Name and set a player's Name
		/// at the user's request
		/// </summary>
		public string Name { get { return _name; } set { _name = value; } }

		/// <summary>
		/// This method uses the Iplayer interface method Email
		/// to return a player's Email and set a player's Email
		/// at the user's request
		/// </summary>
		public string Email { get { return _email; } set { _email = value; } }

		/// <summary>
		/// This delegate method is used to print out a player's
		/// info. The developer can use this delegate to create various
		/// methods outside of this class to use the Print method as seen fit
		/// </summary>
		/// <param name="p"></param>
		public delegate void PrintPlayerInfo(Player p);

		/// <summary>
		/// The Print method uses the delegate above to allow
		/// the developer to print out various player's info 
		/// in a versatile way without having to change/add
		/// any print methods to this class
		/// </summary>
		/// <param name="printPlayer"></param>
		/// <param name="player"></param>
		public void Print(PrintPlayerInfo printPlayer, Player player) { printPlayer(player); }
	}
}
