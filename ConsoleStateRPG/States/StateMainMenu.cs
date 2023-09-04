using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	 class StateMainMenu 
		 : State
	{

		Character character;
		public StateMainMenu(Stack<State> States) 
			: base(States)  //base è l'equivalente di Super in Java
		{
			this.character = new Character("GYUK");
		}

		
		override public void Update()
		{


			Console.Write(Gui.MenuTitle("Benvenuto"));
			Console.WriteLine(character.ToString());
			Console.Write(Gui.MenuOption(0, "Crea personaggio"));
			Console.Write(Gui.MenuOption(-1, "Esci dal gioco"));
			Console.WriteLine("inserisci un numero positivo per terminare il menu state ");
			int number = Convert.ToInt32(Console.ReadLine());
			if (number > 0)
				this.end = true;

			Console.WriteLine("hai inserito  " + number + " nel menu state");

		}
	}
}
