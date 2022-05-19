using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2_may_18
{
	//internal class Class1
	//{
	//}
	public class Player : IPlayer
	{
		private readonly Guid _id = Guid.NewGuid();
		private string _name;
		private string _email;

		public Player()
		{
			_name = "";
			_email = "";
		}
		public Player(string name, string email)
		{ _name = name;
			_email = email;
		}

		public Guid Id { get { return _id; } }

		public string Name { get { return _name; } set { _name = value; } }

		public string Email { get { return _email; } set { _email = value; } }

		public delegate void PrintPlayerInfo(Player p);

		public void Print(PrintPlayerInfo printPlayer, Player player) { printPlayer(player); }
	}
}
