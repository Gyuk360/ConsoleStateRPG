
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleStateRPG
{
	// La classe di gioco destinata ad eseguire la logica del gioco stesso
    internal class Game
	{
		private bool end;
		private Stack<State> states;
		/* non è errato che si trovi qui dato che se cercassimo solo di passare il riferimento il garbage collector
		cancellerebbe il personaggio al termine dello scope della funzione */
		private ArrayList characterList;

		// invoco i costruttori cosi che il codice al loro interno sia eseguito
		private void InitStates()
		{ 
		    this.states = new Stack<State>();
			this.states.Push(new StateMainMenu(this.states , characterList));
		}

		private void InitCharacterList() 
		{
			this.characterList = new ArrayList();
		}
		private void InitVariables()
		{ 
			this.end = false;
		}

		// Costruttore che invoca i metodi di inizializzazione
	    public Game()
		{
			this.InitCharacterList();
			this.InitVariables();
			this.InitStates();
		}



		public void Run()
		{
			while (this.states.Count > 0) // Condiziono l'esecuzione alla presenza di stati
			{
				
				
			this.states.Peek().Update();

			if (this.states.Peek().RequestEnd())
				this.states.Pop();  // il garbage collector viene invocato direttamente da Pop()
				

			}
			Console.WriteLine("Game End !  ");
		}
	}
}
