using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStateRPG
{
	class Gui
	{


		/* Le classi seguenti sono semplicemente usate per formattare il testo ed ho deciso di renderle statiche poiché
		 non intendo istanziare la UI */
		public static void Title(String str)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			str = String.Format("===== {0} =====\n\n", str);
			Console.Write(str);
			Console.ResetColor();
		}

		public static void MenuTitle(String str)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
			str = String.Format("=== {0}\n", str);
			Console.Write(str);
			Console.ResetColor();
		}

		public static void MenuOption(int index, String str)
		{
			str = String.Format(" - ({0}) : {1} \n", index, str);
			Console.Write(str);
		}

		public static void AskForInput(String str)
		{
			str = String.Format("- {0}: ", str);
			Console.Write(str);
		}

		public static int GetInput(String str)
		{
			Nullable<int> input = null;
			str = String.Format("- {0}: ", str);
			Console.Write(str);
			while (input == null) 
			{
				try
				{
					input = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception e)
				{
					Console.Write("Inserire un valore consono !");
				}
			}
			return input.Value;
		}

		
		public static void Announcement(String str)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			str = String.Format("\t(~) ({0})!\n ", str);
			Console.Write(str);
			Console.ResetColor();
		}
	}
}
