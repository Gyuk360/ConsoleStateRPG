using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleStateRPG
{
	class StateMainMenu
		: State
	{

		protected ArrayList characterList;
		protected Character activecharacter;
		public StateMainMenu(Stack<State> States, ArrayList character_list)
			: base(States)  //base è l'equivalente di Super in Java
		{
			this.characterList = character_list;
			this.activecharacter = null;
		}

		public void ProcessInput(int input)
		{
			switch (input)
			{
				case -1:
					this.end = true;
					break;
				case 0:
					this.StartGame();
					break;
				case 1:
					this.states.Push(new StateCharacterCreator(this.states, this.characterList));
					break;
				case 2:
					this.SelectCharacter();
					break;
				default: break;

			}

		}

		override public void Update()
		{


			Gui.MenuTitle("Benvenuto nel Menù Principale");
			Gui.MenuOption(0, "Nuovo gioco");
			Gui.MenuOption(1, "Crea personaggio");
			Gui.MenuOption(2, "Scelta del personaggio");
			Gui.MenuOption(-1, "Esci dal gioco");
			int input = Gui.GetInput("Inserire il numero corrispondete a una delle opzioni");
			this.ProcessInput(input);

		}

		public void SelectCharacter() 
		{
			int characterCount = 0;
			foreach (var character in this.characterList)
			{
				characterCount++;
				Gui.MenuOption(characterCount, character.ToString());
			}

			try
			{
				int choice = Gui.GetInput("Inserisci il numero corrispondente al personaggio da scegliere");
				this.activecharacter = (Character)this.characterList[choice-1];
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			if (activecharacter != null)
			{
				Gui.Announcement($"Hai scelto {this.activecharacter.ToString()} come personaggio attivo");
			}
		}

		public void StartGame() 
		{ // la partita non può iniziare finche il personaggio attivo è NULL
			if (activecharacter == null)
			{
				Gui.Announcement("Devi scegliere un personaggio per poter inizziare la partita");
			}
			else 
			{
				this.states.Push(new StateGame(this.states, this.activecharacter));
			}
		}
 	}
}
