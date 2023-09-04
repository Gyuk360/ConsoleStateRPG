using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class StateGame
		: State
	{
		public StateGame(Stack<State> states) 
			: base(states) 
		{
		}

		override public void Update()
		{
			Console.WriteLine("inserisci un numero positivo per terminare il GameState ");
			int number = Convert.ToInt32(Console.ReadLine());

			Console.Write(Gui.MenuTitle("Benvenuto"));
			Console.Write(Gui.MenuOption(0, "Crea personaggio"));
			Console.Write(Gui.MenuOption(-1, "Esci dal gioco"));
			if (number > 0)
				this.end = true;

			Console.WriteLine("hai inserito  " + number + " nel game state");

		}

	}
}
