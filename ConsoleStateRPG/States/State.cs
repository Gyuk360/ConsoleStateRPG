using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	/* Avendo scelto di usare un Design Pattern a stati per evitare che il codice si trasformasse in un 
	 * grumo di if condizionali questa classe sarà quella di partenza per l'eritarietà, ogni stato del mio gioco
	 * sarà dunque una classe figlia di questa */
	class State
	{
		protected Stack<State> states;
		public State(Stack<State> states) 
		{
			this.states = states;
		}
		protected bool end = false;

		virtual public void Update() 
		{

		}
		public bool RequestEnd() { return end; }
		
	}
}
