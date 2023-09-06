using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleStateRPG
{
	class StateGame
		: State
	{
		protected Character character;
		public StateGame(Stack<State> states , Character activecharacter) 
			: base(states) 
		{
			this.character = activecharacter;
		}

		public void CombatPhase()
		{
			//Dobbiamo evitare che il personaggio resti ferito dallo scontro precedente.
			this.character.resetHp();
			//A ogni combat genero un nemico casuale , forse in futuro avranno una classe dedicata come i personaggi
			Random rnd = new Random();
			int enemyHp = rnd.Next(60, 80);
			int enemyAttack = rnd.Next(5 ,10);
			while(this.character.GetHp() > 0 && enemyHp > 0) 
			{
				Gui.Title("Tocca a te !");
				int input = Gui.GetInput("premi '1' per attaccare oppure '0' per tentare un contrattacco.");
				if (input == 1)
				{
					int accuracyCheck = character.GetAccuracy() + rnd.Next(5, 10);
					if (accuracyCheck <= 15)
					{
						Gui.Title("Lo hai mancato");
					}
					else
					{
						enemyHp -= rnd.Next(character.GetDamage(), character.GetDamageMax());
						Gui.Title("Bel colpo! Gli restano soltanto " + enemyHp + " punti ferita");

					}

				}
				else if (input == 0)
				{
					int defenseCheck = character.GetDefense() + rnd.Next(1, 5);
					if (defenseCheck <= 7)
					{
						Gui.Title("La tua difesa vacilla, sei scoperto");
					}
					else
					{
						enemyHp -= character.GetDefense();
						Gui.Title("Lo hai respinto con lo scudo ferendolo");
					}
				}
				if (enemyHp > 0)
				{
					Gui.Announcement("Tocca al nemico");
					int enemyChoice = rnd.Next(0, 2);
					if (enemyChoice > 0 )
					{
						this.character.TakeDamageSetHp(enemyAttack);
						Gui.Title("Ti ha colpito! hai subito " + enemyAttack + " danni!");
					}
					else
					{
						int heal = rnd.Next(1, 5);
						enemyHp += heal;
						Gui.Title("Attenzione il nemico si cura di " + heal + " punti ferita !!!");
					}
					Gui.Title("Al giocatore restano " + this.character.GetHp() + " punti ferita");
					Gui.Title("Al nemico restano " + enemyHp + " punti ferita");
				}
				if (this.character.GetHp() <= 0)
				{
					Gui.Announcement("Sarai ricordato con onore...");
					break;
				}
				else if(enemyHp <= 0)
				{
					Gui.Announcement("Hai vinto !");
					break;
				}
			}
		}

		public void ProcessInput(int input)
		{
			switch (input)
			{
				case -1:
					this.end = true;
					break;
				case 0:
					this.CombatPhase();
					break;
				default: break;
			}

		}

		override public void Update()
		{

			Gui.MenuTitle("Benvenuto");
			Gui.MenuOption(0, "START!");
			Gui.MenuOption(-1, "Esci dal gioco");
			int input = Gui.GetInput("Inserire il numero corrispondente all'opzione da selezionare");
			this.ProcessInput(input);

		}

	}
}
