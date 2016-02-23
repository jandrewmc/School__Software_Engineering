using System;
using System.Collections.Generic;

namespace JazInterpreter
{
	public class SymbolsTable : ISymbolsTable
	{
		public static Dictionary<string, int>[] variableTable;
		public static Dictionary<string, int> labelTable;

		public static void initializeSymbolsTable()
		{
			//TODO: maximum supported symbols table depth is currently 20
			variableTable = new Dictionary<string,int>[] 
			{
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> (),
				new Dictionary<string, int> ()
			};
			labelTable = new Dictionary<string, int> ();			
		}

		private static void buildVariableTable(string[,] code)
		{
			//every lvalue in the table
			for (int i = 0; i < code.GetLength(0); i++)
			{
				if (code[i,0] == "lvalue")
				{
					for (int j = 0; j < variableTable.GetLength(0); j++)
					{
						variableTable [j].Add (code [i, 1], 0);
					}
				}
			}
		}

		private static void buildLabelTable(string[,] code)
		{
			//every label in the table needs an entry in the symbols table
			for (int i = 0; i < code.GetLength(0); i++)
			{
				if (code[i, 0] == "label")
				{
					//add the name of the label and the first line of code after the label
					labelTable.Add (code [i, 1], i);
				}
			}
		}

		public static void buildSymbolTable(string[,] code)
		{
			initializeSymbolsTable ();

			buildSymbolTable (code);
			buildLabelTable (code);
		}
	}
}

