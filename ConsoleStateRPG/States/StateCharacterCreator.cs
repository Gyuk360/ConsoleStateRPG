using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class StateCharacterCreator
		: State
	{
		protected ArrayList characterList;

		private void CreateCharacter() 
		{
			Gui.AskForInput("Inserisci il nome del personaggio");
			String name = Console.ReadLine();
			this.characterList.Add(new Character(name));
			Gui.Announcement("Personaggio creato");
		}

		private void RemoveCharacter() 
		{
			try
			{
				int choice = Gui.GetInput("Seleziona la tua vittima");
				this.characterList.Remove((Character)this.characterList[choice - 1]);
				Gui.Announcement("R.I.P.");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				this.RemoveCharacter();
			}
			
		}
		public StateCharacterCreator(Stack<State> states , ArrayList character_list)
			: base(states)
		{
			this.characterList = character_list;	
		}

		public void ProcessInput(int input)
		{
			switch (input)
			{
				case -1:
					this.end = true;
					break;
				case 0:
					this.CreateCharacter();
					break;
				case 1:
					this.RemoveCharacter() ;
					break;
				default: break;

			}

		}
		override public void Update()
		{

			//this.states.Push(new StateCharacterCreator(this.states, this.characterList));
			Gui.MenuTitle("Benvenuto nella creazione personaggio");
			Gui.MenuOption(0, "Crea personaggio");
			Gui.MenuOption(1, "Elimina personaggio");
			Gui.MenuOption(-1, "Esci dalla sezione");
			int input = Gui.GetInput("Inserire il numero corrispondente all'opzione da selezionare");
			this.ProcessInput(input);

		}
	}
}
