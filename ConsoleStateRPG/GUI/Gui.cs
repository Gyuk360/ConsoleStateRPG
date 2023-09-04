using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class Gui
	{
		private String header;
		public String Header
		{
			get { return this.header; }
			set { this.header = value; }
		}


		public Gui() 
		{
			this.header = "Welcome to the Game !!!" + "\n" + "=======================================" + "\n";
		}
		 
		public void render()
		{
			Console.WriteLine(this.header);
		}
		
		
		/* Le classi seguenti sono semplicemente usate per formattare il testo ed ho deciso di renderle statiche poiché
		 non intendo istanziare la UI */
		public static String Title (String str)
		{
			str = String.Format("===== {0} =====\n\n", str);
			return str;
		}

		public static String MenuTitle(String str)
		{
			str = String.Format("=== {0}\n", str);
			return str;
		}

		public static String MenuOption(int index,String str)
		{
			str = String.Format(" - ({0}) : {1} \n", index, str);
			return str;
		}
	}
}
