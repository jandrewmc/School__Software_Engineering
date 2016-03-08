using System;
using System.Collections.Generic;

namespace JazInterpreter
{
	public class SymbolsTable : ISymbolsTable
	{
		public static List<List<Identifier>> variableTable;
		public static Dictionary<string, int> labelTable;

		public static void initializeSymbolsTable()
		{
			variableTable = new List<List<Identifier>> ();
			labelTable = new Dictionary<string, int> ();			
		}

		public static void addLevel(int currentLevel)
		{
			int addedLevel = currentLevel + 1;

			variableTable.Add(new List<Identifier>());

			foreach(var identifier in variableTable[currentLevel])
				variableTable[addedLevel].Add((Identifier)identifier.Clone());
		}

		private static void buildVariableTable(string[,] code)
		{
			addLevel (0);

			//every lvalue in the table
			for (int i = 0; i < code.GetLength(0); i++)
			{
				if (code[i,0] == "lvalue")
				{
					variableTable [0].Add (new Identifier {
						Value = 0,
						Name = code [i, 1]
					});
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

			buildVariableTable (code);
			buildLabelTable (code);
		}
	}
}

